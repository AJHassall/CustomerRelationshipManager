using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ContactManagementApi.Models;
using ContactManagementApi.Data;

namespace ContactManagementApi.Data.Repositories
{
    public class TradeRepository
    {
        private readonly ContactDbContext _context;

        public TradeRepository(ContactDbContext context)
        {
            _context = context;
        }

        public Trade Create(Trade contact)
        {
            _context.Trades.Add(contact);
            _context.SaveChanges();

            return contact;

        }
        public Trade Get(int id)
        {
            return _context.Trades.Find(id);
        }

    }
}
