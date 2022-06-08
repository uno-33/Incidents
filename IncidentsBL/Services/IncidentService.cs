using AutoMapper;
using IncidentsBL.Interfaces;
using IncidentsBL.Models;
using IncidentsBL.Models.InputModels;
using IncidentsDL.Entites;
using IncidentsDL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IncidentsBL.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IncidentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IncidentModel> CreateAsync(IncidentInputModel incidentInputModel)
        {
            var accountEntity = await _unitOfWork.AccountRepository.GetByNameAsync(incidentInputModel.AccountName);
            if (accountEntity == null)
                return null;

            var contactEntity = await _unitOfWork.ContactRepository.GetByEmailAsync(incidentInputModel.ContactEmail);
            if (contactEntity != null)
            {
                contactEntity.Account = accountEntity;
                contactEntity.FirstName = incidentInputModel.ContactFirstName;
                contactEntity.LastName = incidentInputModel.ContactLastName;
            }
            else
            {
                await _unitOfWork.ContactRepository.AddAsync(new Contact
                {
                    Account = accountEntity,
                    FirstName = incidentInputModel.ContactFirstName,
                    LastName = incidentInputModel.ContactLastName
                });
            }

            var incidentEntity = new Incident
            {
                Description = incidentInputModel.IncidentDescription
            };

            await _unitOfWork.IncidentRepository.AddAsync(incidentEntity);

            await _unitOfWork.SaveAsync();

            return _mapper.Map<IncidentModel>(incidentEntity);
        }
    }
}
