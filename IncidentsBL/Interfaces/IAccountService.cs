using IncidentsBL.Models;
using IncidentsBL.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IncidentsBL.Interfaces
{
    public interface IAccountService
    {
        Task<AccountModel> CreateAsync(AccountInputModel accountInputModel);
        Task<AccountModel> GetByNameAsync(string name);
    }
}
