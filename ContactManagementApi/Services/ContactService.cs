using System;
using System.Collections.Generic;
using ContactManagementApi.Models;
using ContactManagementApi.Data.Repositories;

namespace ContactManagementApi.Services
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Contact CreateContact(Contact contact)
        {
            return _unitOfWork.Contacts.CreateContact(contact);
        }

        public Contact GetContactById(int id)
        {
            return _unitOfWork.Contacts.GetContactById(id);
        }

        public Contact UpdateContact(Contact contact)
        {
            return _unitOfWork.Contacts.UpdateContact(contact);
        }

        public void DeleteContact(int id)
        {
            if (_unitOfWork.FundRelationships.GetContactFundAssignment(id, 0) != null)
            {
                throw new InvalidOperationException("Contact is currently assigned to a fund and cannot be deleted.");
            }

            _unitOfWork.Contacts.DeleteContact(id);
            _unitOfWork.Complete();
        }

        public IEnumerable<Contact> GetContactsByFundId(int fundId)
        {
            return _unitOfWork.FundRelationships.GetContactsByFundId(fundId);
        }

        public void AssignContactToFund(int contactId, int fundId)
        {
            if (_unitOfWork.FundRelationships.GetContactFundAssignment(contactId, fundId) != null)
            {
                throw new InvalidOperationException("Contact is already assigned to this fund.");
            }

            var assignment = new FundRelationship
            {
                ContactId = contactId,
                FundId = fundId
            };

            _unitOfWork.FundRelationships.CreateContactFundAssignment(assignment);
            _unitOfWork.Complete();

        }

        public void RemoveContactFromFund(int contactId, int fundId)
        {
            var assignment = _unitOfWork.FundRelationships.GetContactFundAssignment(contactId, fundId);
            if (assignment == null)
            {
                throw new InvalidOperationException("Contact is not assigned to this fund.");
            }

            _unitOfWork.FundRelationships.DeleteContactFundAssignment(assignment);
        }

        public IEnumerable<Contact> GetContacts()
        {
            return _unitOfWork.Contacts.GetContacts();
        }
    }
}
