using System.Collections.Generic;
using ContactManagementApi.Models;
using ContactManagementApi.Data.Repositories;

namespace ContactManagementApi.Services
{
    public interface IFundService
    {
        Fund GetFundById(int id);
        IEnumerable<Fund> GetAllFunds();
        Fund CreateFund(Fund fund);
        Fund UpdateFund(Fund fund);
        void DeleteFund(int id);
    }
}
