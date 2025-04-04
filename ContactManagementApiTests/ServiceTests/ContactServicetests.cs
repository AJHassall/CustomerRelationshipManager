using NUnit.Framework;
using Moq;
using ContactManagementApi.Services;
using ContactManagementApi.Models;
using ContactManagementApi.Data.Repositories;
using System;

namespace ContactManagementApi.Tests.Services
{
    [TestFixture]
    public class ContactServiceTests
    {
        private Mock<IUnitOfWork> _mockContactRepository;
        private ContactService _contactService;

        [SetUp]
        public void Setup()
        {
            _mockContactRepository = new Mock<IUnitOfWork>();
            _contactService = new ContactService(_mockContactRepository.Object);
        }

        [Test]
        public void AssignContactToFund_CreatesAssignment_WhenNotAlreadyAssigned()
        {
            // Arrange
            int contactId = 1;
            int fundId = 2;
            _mockContactRepository.Setup(uow => uow.FundRelationships.GetFundsAssignedToContact(contactId)).Returns((FundRelationship)null);
            _mockContactRepository.Setup(uow => uow.FundRelationships.CreateContactFundAssignment(It.IsAny<FundRelationship>()));

            // Act
            _contactService.AssignContactToFund(contactId, fundId);

            // Assert
            _mockContactRepository.Verify(uow => uow.FundRelationships.CreateContactFundAssignment(It.Is<FundRelationship>(a => a.ContactId == contactId && a.FundId == fundId)), Times.Once);
        }

        [Test]
        public void AssignContactToFund_ThrowsException_WhenAlreadyAssigned()
        {
            // Arrange
            int contactId = 1;
            int fundId = 2;
            _mockContactRepository.Setup(uow => uow.FundRelationships.GetFundsAssignedToContact(contactId)).Returns(new FundRelationship());

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _contactService.AssignContactToFund(contactId, fundId));
            _mockContactRepository.Verify(uow => uow.FundRelationships.CreateContactFundAssignment(It.IsAny<FundRelationship>()), Times.Never);
        }
    }
}
