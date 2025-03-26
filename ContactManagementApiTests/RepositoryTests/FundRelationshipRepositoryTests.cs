using NUnit.Framework;
using ContactManagementApi.Data;
using ContactManagementApi.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ContactManagementApi.Models;
using Moq;
using Microsoft.Extensions.ObjectPool;

[TestFixture]
public class FundRelationshipsRepositoryTests
{
    private ContactDbContext _context;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<ContactDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new ContactDbContext(options);


    }
    [Test]
    public void GetFundsAssignedToContact_Returns_Value()
    {
        //Arrange

        _context.ContactFundAssignments.AddRange(
            new FundRelationship { ContactId = 1, FundId = 1 }
        );

        _context.SaveChanges();


        //Act
        var relationShipRepo = new FundRelationshipRepository(_context);

        var fundRelationship = relationShipRepo.GetFundsAssignedToContact(1);
        //Assert
        Assert.NotNull(fundRelationship);
        Assert.AreEqual(1, fundRelationship.ContactId);
        Assert.AreEqual(1, fundRelationship.FundId);

    }
}