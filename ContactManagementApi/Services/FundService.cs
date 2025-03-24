using System.Collections.Generic;
using ContactManagementApi.Models; 
using ContactManagementApi.Data.Repositories;

namespace ContactManagementApi.Services
{
    public class FundService : IFundService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FundService(IUnitOfWork fundRepository)
        {
            _unitOfWork = fundRepository;
        }

        public Fund GetFundById(int id)
        {
            return _unitOfWork.Funds.GetFundById(id);
        }

        public IEnumerable<Fund> GetAllFunds()
        {
            return _unitOfWork.Funds.GetAllFunds();
        }

        public Fund CreateFund(Fund fund)
        {
            return _unitOfWork.Funds.CreateFund(fund);
        }

        public Fund UpdateFund(Fund fund)
        {
            return _unitOfWork.Funds.UpdateFund(fund);
        }

        public void DeleteFund(int id)
        {
            _unitOfWork.Funds.DeleteFund(id);
        }
    }
}