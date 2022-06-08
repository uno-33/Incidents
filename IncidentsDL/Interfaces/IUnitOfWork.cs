using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IncidentsDL.Interfaces
{
    public interface IUnitOfWork
    {
        IAccountRepository AccountRepository { get; }
        IContactRepository ContactRepository { get; }
        IIncidentRepository IncidentRepository { get; }
        void Dispose();
        Task<int> SaveAsync();
    }
}
