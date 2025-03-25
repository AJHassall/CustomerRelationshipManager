using System;
using System.Collections.Generic;
using ContactManagementApi.Data.Repositories;
using ContactManagementApi.Models;
using ContactManagementApi.Services;
using Moq;
using NUnit.Framework;

[TestFixture]
public class FundRelationshipServiceTests
{
    private Mock<IUnitOfWork> _mockUnitOfWork;
    private Mock<IFundRelationshipRepository> _mockFundRelationships;
    private FundRelationshipService _service;

    [SetUp]
    public void Setup()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockFundRelationships = new Mock<IFundRelationshipRepository>();
        _mockUnitOfWork.Setup(uow => uow.FundRelationships).Returns(_mockFundRelationships.Object);
        _service = new FundRelationshipService(_mockUnitOfWork.Object);
    }

    [Test]
    public void GetContactsByFundId_ReturnsContacts()
    {
        int fundId = 1;
        var expectedContacts = new List<Contact> { new Contact { Name = "a" }, new Contact { Name = "b" } };
        _mockFundRelationships.Setup(repo => repo.GetContactsByFundId(fundId)).Returns(expectedContacts);

        var result = _service.GetContactsByFundId(fundId);

        Assert.AreEqual(expectedContacts, result);
        _mockFundRelationships.Verify(repo => repo.GetContactsByFundId(fundId), Times.Once);
    }
    [Test]
    public void AssignContactToFund_AssignsContact()
    {
        int contactId = 1;
        int fundId = 1;
        _mockFundRelationships.Setup(repo => repo.GetContactFundAssignment(contactId, fundId)).Returns((FundRelationship)null);

        _service.AssignContactToFund(contactId, fundId);

        _mockFundRelationships.Verify(repo => repo.CreateContactFundAssignment(It.Is<FundRelationship>(a => a.ContactId == contactId && a.FundId == fundId)), Times.Once);
        _mockUnitOfWork.Verify(uow => uow.Complete(), Times.Once);
    }

}
