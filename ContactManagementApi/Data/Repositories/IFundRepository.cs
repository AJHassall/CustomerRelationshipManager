using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ContactManagementApi.Models;
using ContactManagementApi.Data;

namespace ContactManagementApi.Data.Repositories
{
    public interface IFundRepository
    {

        Fund GetFundById(int id);
        IEnumerable<Fund> GetAllFunds();
        Fund CreateFund(Fund fund);
        Fund UpdateFund(Fund fund);
        void DeleteFund(int id);
    }
}