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
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ContactModel> CreateAsync(ContactInputModel contactInputModel)
        {
            if (await _unitOfWork.ContactRepository.GetByEmailAsync(contactInputModel.Email) != null)
                throw new ArgumentException("Already exists");

            var contactModel = new ContactModel
            {
                Email = contactInputModel.Email,
                FirstName = contactInputModel.FirstName,
                LastName = contactInputModel.LastName
            };

            var entity = _mapper.Map<Contact>(contactModel);

            await _unitOfWork.ContactRepository.AddAsync(entity);
            await _unitOfWork.SaveAsync();

            return contactModel;
        }

        public async Task<ContactModel> GetByEmailAsync(string email)
        {
            var entity = await _unitOfWork.ContactRepository.GetByEmailAsync(email);
            if (entity == null)
                return null;

            return _mapper.Map<ContactModel>(entity);
        }
    }
}
