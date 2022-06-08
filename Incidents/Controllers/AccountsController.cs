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
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        // POST api/<AccountsController>
        [HttpPost]
        public async Task<ActionResult<AccountModel>> PostAsync([FromBody] AccountInputModel inputModel)
        {
            AccountModel result;
            try
            {
                result = await _accountService.CreateAsync(inputModel);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            if (result == null)
                return NotFound();

            return Ok(result);
            
        }
    }
}
