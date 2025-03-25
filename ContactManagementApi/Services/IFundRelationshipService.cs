using System;
using System.Collections.Generic;
using ContactManagementApi.Models;
using ContactManagementApi.Data.Repositories;

namespace ContactManagementApi.Services
{
    public interface IFundRelationshipService
    {
        IEnumerable<FundRelationship> GetAll();
        IEnumerable<Contact> GetContactsByFundId(int fundId);
        void AssignContactToFund(int contactId, int fundId);
        void RemoveContactFromFund(int contactId, int fundId);

    }
}