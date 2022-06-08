using IncidentsBL.Interfaces;
using IncidentsBL.Models;
using IncidentsBL.Models.InputModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Incidents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentsController : ControllerBase
    {
        private readonly IIncidentService _incidentService;

        public IncidentsController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }
        // POST api/<IncidentsController>
        [HttpPost]
        public async Task<ActionResult<IncidentModel>> Post([FromBody] IncidentInputModel inputModel)
        {
            IncidentModel result = await _incidentService.CreateAsync(inputModel);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
