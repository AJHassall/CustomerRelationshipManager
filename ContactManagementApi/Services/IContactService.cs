using System;
using System.Collections.Generic;
using ContactManagementApi.Models;
using ContactManagementApi.Data.Repositories;

namespace ContactManagementApi.Services
{
    public interface IContactService
    {
        Contact CreateContact(Contact contact);
        Contact GetContactById(int id);
        IEnumerable<Contact> GetContacts();
        Contact UpdateContact(Contact contact);
        void DeleteContact(int id);
        IEnumerable<Contact> GetContactsByFundId(int fundId);
        void AssignContactToFund(int contactId, int fundId);
        void RemoveContactFromFund(int contactId, int fundId);

    }
}