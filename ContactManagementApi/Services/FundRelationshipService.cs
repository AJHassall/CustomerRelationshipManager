using System;
using System.Collections.Generic;
using ContactManagementApi.Models;
using ContactManagementApi.Data.Repositories;

namespace ContactManagementApi.Services
{
    public class FundRelationshipService : IFundRelationshipService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FundRelationshipService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<FundRelationship> GetAll()
        {
            return _unitOfWork.FundRelationships.GetAll();
        }

        public IEnumerable<Contact> GetContactsByFundId(int fundId)
        {
            return _unitOfWork.FundRelationships.GetContactsByFundId(fundId);
        }

        public void AssignContactToFund(int contactId, int fundId)
        {
            if (_unitOfWork.FundRelationships.GetRelationship(contactId, fundId) != null)
            {
                throw new InvalidOperationException("Contact is already assigned to this fund.");
            }

            var assignment = new FundRelationship
            {
                ContactId = contactId,
                FundId = fundId
            };

            _unitOfWork.FundRelationships.CreateContactFundAssignment(assignment);
            _unitOfWork.Complete();
        }

        public void RemoveContactFromFund(int contactId, int fundId)
        {
            var assignment = _unitOfWork.FundRelationships.GetRelationship(contactId, fundId);
            if (assignment == null)
            {
                throw new InvalidOperationException("Contact is not assigned to this fund.");
            }

            _unitOfWork.FundRelationships.DeleteContactFundAssignment(assignment);
            _unitOfWork.Complete();
        }

    }
}
