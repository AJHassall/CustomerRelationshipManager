using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ContactManagementApi.Models;
using ContactManagementApi.Data;

namespace ContactManagementApi.Data.Repositories
{
    public class FundRelationshipRepository : IFundRelationshipRepository
    {
        private readonly ContactDbContext _context;

        public FundRelationshipRepository(ContactDbContext context)
        {
            _context = context;
        }
        public IEnumerable<FundRelationship> GetAll()
        {
            return _context.ContactFundAssignments.ToList();
        }

        public IEnumerable<Contact> GetContactsByFundId(int fundId)
        {
            return _context.ContactFundAssignments
                .Where(assignment => assignment.FundId == fundId)
                .Select(assignment => assignment.Contact)
                .ToList();
        }

        public FundRelationship GetFundsAssignedToContact(int contactId)
        {
            return _context.ContactFundAssignments
                .Where(x => x.ContactId == contactId)
                .FirstOrDefault();
        }

        public FundRelationship CreateContactFundAssignment(FundRelationship contactFundAssignment)
        {
            _context.ContactFundAssignments.Add(contactFundAssignment);
            _context.SaveChanges();
            return contactFundAssignment;
        }

        public void DeleteContactFundAssignment(FundRelationship contactFundAssignment)
        {
            _context.ContactFundAssignments.Remove(contactFundAssignment);
            _context.SaveChanges();
        }

        public IQueryable<Contact> GetContacts()
        {
            return _context.Contacts;

        }

        public FundRelationship GetRelationship(int contactId, int fundId)
        {
            return _context.ContactFundAssignments
                    .Where(x => x.ContactId == contactId)
                    .Where(x => x.FundId == fundId)
                    .FirstOrDefault();
        }
    }
}
