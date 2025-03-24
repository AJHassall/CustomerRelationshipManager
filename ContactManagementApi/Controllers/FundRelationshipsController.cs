using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ContactManagementApi.Models;
using ContactManagementApi.Services;

namespace ContactManagementApi.Controllers
{
    [ApiController]
    [Route("api/fundrelationship")]
    public class FundRelationshipController : ControllerBase
    {
        private readonly IFundRelationshipService _fundRelationshipService;

        public FundRelationshipController(IFundRelationshipService fundRelationshipService)
        {
            _fundRelationshipService = fundRelationshipService;
        }

        [HttpGet("fund/{fundId}")]
        public IActionResult GetContactsByFundId(int fundId)
        {
            var contacts = _fundRelationshipService.GetContactsByFundId(fundId);
            return Ok(contacts);
        }

        [HttpPost("{contactId}/funds/{fundId}")]
        public IActionResult AssignContactToFund(int contactId, int fundId)
        {
            try
            {
                _fundRelationshipService.AssignContactToFund(contactId, fundId);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{contactId}/funds/{fundId}")]
        public IActionResult RemoveContactFromFund(int contactId, int fundId)
        {
            try
            {
                _fundRelationshipService.RemoveContactFromFund(contactId, fundId);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
