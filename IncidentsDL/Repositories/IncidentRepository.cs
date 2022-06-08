using IncidentsDL.Entites;
using IncidentsDL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentsDL.Repositories
{
    public class IncidentRepository : IIncidentRepository
    {
        private readonly IncidentsDbContext _context;
        private readonly DbSet<Incident> _dbSet;

        public IncidentRepository(IncidentsDbContext context)
        {
            _context = context;
            _dbSet = _context.Incidents;
        }

        public async Task AddAsync(Incident entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<Incident> GetByNameAsync(string name)
        {
            var entity = await _dbSet.FindAsync(name);
            if (entity == null)
                return null;

            _context.Entry(entity).State = EntityState.Detached;

            return entity;
        }
    }
}
