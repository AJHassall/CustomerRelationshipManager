using System.Collections.Generic;
using ContactManagementApi.Models; 
using ContactManagementApi.Data.Repositories;

namespace ContactManagementApi.Services
{
    public class FundService : IFundService
    {
        private readonly IFundRepository _fundRepository;

        public FundService(IFundRepository fundRepository)
        {
            _fundRepository = fundRepository;
        }

        public Fund GetFundById(int id)
        {
            return _fundRepository.GetFundById(id);
        }

        public IEnumerable<Fund> GetAllFunds()
        {
            return _fundRepository.GetAllFunds();
        }

        public Fund CreateFund(Fund fund)
        {
            return _fundRepository.CreateFund(fund);
        }

        public Fund UpdateFund(Fund fund)
        {
            return _fundRepository.UpdateFund(fund);
        }

        public void DeleteFund(int id)
        {
            _fundRepository.DeleteFund(id);
        }
    }
}