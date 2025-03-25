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
        FundRelationship GetContactFundAssignment(int contactId, int fundId);
        FundRelationship CreateContactFundAssignment(FundRelationship contactFundAssignment);
        void DeleteContactFundAssignment(FundRelationship contactFundAssignment);

    }
}
