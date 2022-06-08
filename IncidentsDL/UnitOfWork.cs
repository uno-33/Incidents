using IncidentsDL.Interfaces;
using IncidentsDL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IncidentsDL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IncidentsDbContext _context;

        private IAccountRepository _accountRepository;
        private IContactRepository _contactRepository;
        private IIncidentRepository _incidentRepository;

        public UnitOfWork(IncidentsDbContext context)
        {
            _context = context;
        }

        public IAccountRepository AccountRepository
        {
            get
            {
                if (_accountRepository == null)
                {
                    _accountRepository = new AccountRepository(_context);
                }
                return _accountRepository;
            }
        }

        public IContactRepository ContactRepository
        {
            get
            {
                if (_contactRepository == null)
                {
                    _contactRepository = new ContactRepository(_context);
                }
                return _contactRepository;
            }
        }

        public IIncidentRepository IncidentRepository
        {
            get
            {
                if (_incidentRepository == null)
                {
                    _incidentRepository = new IncidentRepository(_context);
                }
                return _incidentRepository;
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        #region Dispose
        private bool _disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
