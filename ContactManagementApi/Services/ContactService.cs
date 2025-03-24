using System;
using System.Collections.Generic;
using ContactManagementApi.Models;
using ContactManagementApi.Data.Repositories;

namespace ContactManagementApi.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public Contact CreateContact(Contact contact)
        {
            return _contactRepository.CreateContact(contact);
        }

        public Contact GetContactById(int id)
        {
            return _contactRepository.GetContactById(id);
        }

        public Contact UpdateContact(Contact contact)
        {
            return _contactRepository.UpdateContact(contact);
        }

        public void DeleteContact(int id)
        {
            if (_contactRepository.GetContactFundAssignment(id, 0) != null)
            {
                throw new InvalidOperationException("Contact is currently assigned to a fund and cannot be deleted.");
            }

            _contactRepository.DeleteContact(id);
        }

        public IEnumerable<Contact> GetContactsByFundId(int fundId)
        {
            return _contactRepository.GetContactsByFundId(fundId);
        }

        public void AssignContactToFund(int contactId, int fundId)
        {
            if (_contactRepository.GetContactFundAssignment(contactId, fundId) != null)
            {
                throw new InvalidOperationException("Contact is already assigned to this fund.");
            }

            var assignment = new ContactFundAssignment
            {
                ContactId = contactId,
                FundId = fundId
            };

            _contactRepository.CreateContactFundAssignment(assignment);
        }

        public void RemoveContactFromFund(int contactId, int fundId)
        {
            var assignment = _contactRepository.GetContactFundAssignment(contactId, fundId);
            if (assignment == null)
            {
                throw new InvalidOperationException("Contact is not assigned to this fund.");
            }

            _contactRepository.DeleteContactFundAssignment(assignment);
        }

        public IEnumerable<Contact> GetContacts()
        {
            return _contactRepository.GetContacts();
        }
    }
}