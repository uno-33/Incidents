using IncidentsBL.Models;
using IncidentsBL.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IncidentsBL.Interfaces
{
    public interface IContactService
    {
        Task<ContactModel> CreateAsync(ContactInputModel contactInputModel);
        Task<ContactModel> GetByEmailAsync(string email);
    }
}
