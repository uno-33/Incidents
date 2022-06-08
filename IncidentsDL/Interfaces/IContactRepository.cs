using IncidentsDL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentsDL.Interfaces
{
    public interface IContactRepository
    {
        Task AddAsync(Contact entity);
        Task<Contact> GetByEmailAsync(string email);
    }
}
