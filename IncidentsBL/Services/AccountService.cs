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
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AccountModel> CreateAsync(AccountInputModel accountInputModel)
        {
            var contactEntity = await _unitOfWork.ContactRepository.GetByEmailAsync(accountInputModel.ContactEmail);
             
            if (contactEntity == null)
                return null;

            var accountEntity = await _unitOfWork.AccountRepository.GetByNameAsync(accountInputModel.Name);
            if(accountEntity != null)
            {
                throw new ArgumentException("Already exists");
            }

            accountEntity = new Account { Name = accountInputModel.Name };

            contactEntity.Account = accountEntity;

            await _unitOfWork.AccountRepository.AddAsync(accountEntity);
            await _unitOfWork.SaveAsync();

            return new AccountModel { Id = accountEntity.Id, Name = accountEntity.Name };
        }

        public async Task<AccountModel> GetByNameAsync(string name)
        {
            var entity = await _unitOfWork.AccountRepository.GetByNameAsync(name);
            if (entity == null)
                return null;

            return _mapper.Map<AccountModel>(entity);
        }
    }
}
