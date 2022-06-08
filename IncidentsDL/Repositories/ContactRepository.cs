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
    public class ContactRepository : IContactRepository
    {
        private readonly IncidentsDbContext _context;
        private readonly DbSet<Contact> _dbSet;

        public ContactRepository(IncidentsDbContext context)
        {
            _context = context;
            _dbSet = _context.Contacts;
        }

        public async Task AddAsync(Contact entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<Contact> GetByEmailAsync(string email)
        {
            var entity = await _dbSet.FindAsync(email);
            if (entity == null)
                return null;

            return entity;
        }
    }
}
