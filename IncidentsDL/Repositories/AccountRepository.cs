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

    public class AccountRepository : IAccountRepository
    {
        private readonly IncidentsDbContext _context;
        private readonly DbSet<Account> _dbSet;

        public AccountRepository(IncidentsDbContext context)
        {
            _context = context;
            _dbSet = _context.Accounts;
        }

        public async Task AddAsync(Account entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<Account> GetByNameAsync(string name)
        {
            var entity = await _dbSet.SingleOrDefaultAsync(x => x.Name == name);
            if (entity == null)
                return null;

            _context.Entry(entity).State = EntityState.Detached;

            return entity;
        }
    }
}
