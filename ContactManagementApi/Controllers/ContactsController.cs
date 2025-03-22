using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ContactManagementApi.Models;
using ContactManagementApi.Services;
using FluentValidation;

namespace ContactManagementApi.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly ContactService _contactService;

        public ContactsController(ContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = _contactService.GetContactById(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpPost]
        public IActionResult CreateContact([FromBody] Contact contact)
        {
            var createdContact = _contactService.CreateContact(contact);
            return CreatedAtAction(nameof(GetContactById), new { id = createdContact.ContactId }, createdContact);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, [FromBody] Contact contact)
        {
            if (id != contact.ContactId)
            {
                return BadRequest("Contact ID mismatch.");
            }

            var updatedContact = _contactService.UpdateContact(contact);
            if (updatedContact == null)
            {
                return NotFound();
            }

            return Ok(updatedContact);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            try
            {
                _contactService.DeleteContact(id);
                return NoContent();
            }
            catch (System.InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("fund/{fundId}")]
        public IActionResult GetContactsByFundId(int fundId)
        {
            var contacts = _contactService.GetContactsByFundId(fundId);
            return Ok(contacts);
        }

        [HttpPost("{contactId}/funds/{fundId}")]
        public IActionResult AssignContactToFund(int contactId, int fundId)
        {
            try
            {
                _contactService.AssignContactToFund(contactId, fundId);
                return NoContent();
            }
            catch(System.InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{contactId}/funds/{fundId}")]
        public IActionResult RemoveContactFromFund(int contactId, int fundId)
        {
            try
            {
                _contactService.RemoveContactFromFund(contactId, fundId);
                return NoContent();
            }
            catch(System.InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
