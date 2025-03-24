using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ContactManagementApi.Models;
using ContactManagementApi.Data;

namespace ContactManagementApi.Data.Repositories
{
    public class ContactRepository: IContactRepository
    {
        private readonly ContactDbContext _context;

        public ContactRepository(ContactDbContext context)
        {
            _context = context;
        }

        public Contact CreateContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return contact;
        }

        public Contact GetContactById(int id)
        {
            return _context.Contacts.Find(id);
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _context.Contacts.ToList();
        }

        public Contact UpdateContact(Contact contact)
        {
            _context.Entry(contact).State = EntityState.Modified;
            _context.SaveChanges();
            return contact;
        }

        public void DeleteContact(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Contact> GetContactsByFundId(int fundId)
        {
            return _context.ContactFundAssignments
                .Where(assignment => assignment.FundId == fundId)
                .Select(assignment => assignment.Contact)
                .ToList();
        }

        public IQueryable<Contact> GetContacts()
        {
            return _context.Contacts;

        }
    }
}
