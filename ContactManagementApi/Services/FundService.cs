using System.Collections.Generic;
    using ContactManagementApi.Models;
    using ContactManagementApi.Data.Repositories;

    namespace ContactManagementApi.Services
    {
        public class FundService : IFundService
        {
            private readonly IUnitOfWork _unitOfWork;

            public FundService(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
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
                _unitOfWork.Funds.CreateFund(fund);
                _unitOfWork.Complete();
                return fund;
            }

            public Fund UpdateFund(Fund fund)
            {
                _unitOfWork.Funds.UpdateFund(fund);
                _unitOfWork.Complete();
                return fund;
            }

            public void DeleteFund(int id)
            {
                _unitOfWork.Funds.DeleteFund(id);
                _unitOfWork.Complete();
            }
        }
    }