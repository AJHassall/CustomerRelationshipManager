using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ContactManagementApi.Models;
using ContactManagementApi.Data;

namespace ContactManagementApi.Data.Repositories
{
    public class FundRepository
    {
        private readonly ContactDbContext _context;

        public FundRepository(ContactDbContext context)
        {
            _context = context;
        }

        public Fund GetFundById(int id)
        {
            return _context.Funds.Find(id);
        }

        public IEnumerable<Fund> GetAllFunds()
        {
            return _context.Funds.ToList();
        }

        //Potentially added for testing purposes.
        public Fund CreateFund(Fund fund)
        {
            _context.Funds.Add(fund);
            _context.SaveChanges();
            return fund;
        }

        public Fund UpdateFund(Fund fund)
        {
            _context.Entry(fund).State = EntityState.Modified;
            _context.SaveChanges();
            return fund;
        }

        public void DeleteFund(int id)
        {
            var fund = _context.Funds.Find(id);
            if (fund != null)
            {
                _context.Funds.Remove(fund);
                _context.SaveChanges();
            }
        }
    }
}