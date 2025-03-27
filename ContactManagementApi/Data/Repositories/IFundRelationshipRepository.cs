using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ContactManagementApi.Models;
using ContactManagementApi.Data;

namespace ContactManagementApi.Data.Repositories
{
    public interface IFundRelationshipRepository
    {
        IEnumerable<FundRelationship> GetAll();
        IEnumerable<Contact> GetContactsByFundId(int fundId);
        FundRelationship GetFundsAssignedToContact(int contactId);
        FundRelationship CreateContactFundAssignment(FundRelationship contactFundAssignment);
        void DeleteContactFundAssignment(FundRelationship contactFundAssignment);
        FundRelationship GetRelationship(int contactId, int fundId);
    }
}
