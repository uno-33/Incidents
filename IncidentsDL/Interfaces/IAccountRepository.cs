using IncidentsDL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentsDL.Interfaces
{
    public interface IAccountRepository
    {
        Task AddAsync(Account entity);
        Task<Account> GetByNameAsync(string name);
    }
}
