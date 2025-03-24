using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ContactManagementApi.Models;
using ContactManagementApi.Data;

namespace ContactManagementApi.Data.Repositories
{
    public interface IFundRelationshipRepository
    {
        IEnumerable<Contact> GetContactsByFundId(int fundId);
        ContactFundAssignment GetContactFundAssignment(int contactId, int fundId);
        ContactFundAssignment CreateContactFundAssignment(ContactFundAssignment contactFundAssignment);
        void DeleteContactFundAssignment(ContactFundAssignment contactFundAssignment);

    }
}