using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ContactManagementApi.Models;
using ContactManagementApi.Data;

namespace ContactManagementApi.Data.Repositories
{
    public interface IContactRepository
    {
        Contact CreateContact(Contact contact);
        Contact GetContactById(int id);
        IQueryable<Contact> GetContacts();
        IEnumerable<Contact> GetAllContacts();
        Contact UpdateContact(Contact contact);
        void DeleteContact(int id);


    }
}