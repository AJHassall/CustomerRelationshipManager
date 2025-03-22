using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ContactManagementApi.Models;
using ContactManagementApi.Services;
using FluentValidation;

namespace FundManagementApi.Controllers
{
    [ApiController]
    [Route("api/funds")]
    public class FundsController : ControllerBase
    {
        private readonly FundService _fundService;

        public FundsController(FundService fundService)
        {
            _fundService = fundService;
        }

        [HttpGet("{id}")]
        public IActionResult GetFundById(int id)
        {
            var fund = _fundService.GetFundById(id);
            if (fund == null)
            {
                return NotFound();
            }
            return Ok(fund);
        }

        [HttpPost]
        public IActionResult CreateFund([FromBody] Fund fund)
        {


            var createdFund = _fundService.CreateFund(fund);
            return CreatedAtAction(nameof(GetFundById), new { id = createdFund.FundId }, createdFund);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFund(int id, [FromBody] Fund fund)
        {
            if (id != fund.FundId)
            {
                return BadRequest("Fund ID mismatch.");
            }

            var updatedFund = _fundService.UpdateFund(fund);
            if (updatedFund == null)
            {
                return NotFound();
            }

            return Ok(updatedFund);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFund(int id)
        {
            try
            {
                _fundService.DeleteFund(id);
                return NoContent();
            }
            catch (System.InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}