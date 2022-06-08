using IncidentsBL.Models;
using IncidentsBL.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IncidentsBL.Interfaces
{
    public interface IIncidentService
    {
        Task<IncidentModel> CreateAsync(IncidentInputModel incidentInputModel);
    }
}
