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
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IAccountService _accountService;

        public ContactsController(IContactService contactService, IAccountService accountService)
        {
            _contactService = contactService;
            _accountService = accountService;
        }
        // POST api/<ContactsController>
        [HttpPost]
        public async Task<ActionResult<ContactModel>> PostAsync([FromBody] ContactInputModel inputModel)
        {
            ContactModel result;
            try
            {
                result = await _contactService.CreateAsync(inputModel);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            } 

            if (result != null)
                return Ok(result);

            return NotFound();
        }
    }
}
