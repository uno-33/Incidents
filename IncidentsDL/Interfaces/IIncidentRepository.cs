using IncidentsDL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentsDL.Interfaces
{
    public interface IIncidentRepository
    {
        Task AddAsync(Incident entity);
        Task<Incident> GetByNameAsync(string name);
    }
}
