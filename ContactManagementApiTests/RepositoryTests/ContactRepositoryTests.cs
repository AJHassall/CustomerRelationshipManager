using NUnit.Framework;
using ContactManagementApi.Data;
using ContactManagementApi.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ContactManagementApi.Models;

[TestFixture] 
public class ContactRepositoryTests
{
    [Test] 
    public void CreateContactFundAssignment_ShouldAddAssignmentAndSaveChanges()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ContactDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        using (var context = new ContactDbContext(options))
        {
            var repository = new ContactRepository(context);

            var assignment = new ContactFundAssignment
            {
                ContactId = 1,
                FundId = 101,
            };

            // Act
            var createdAssignment = repository.CreateContactFundAssignment(assignment);

            // Assert
            Assert.NotNull(createdAssignment);
            Assert.AreEqual(1, context.ContactFundAssignments.Count());
            Assert.AreEqual(1, createdAssignment.ContactId);
            Assert.AreEqual(101, createdAssignment.FundId);
        }
    }

    [Test] 
    public void DeleteContactFundAssignment_ShouldRemoveAssignmentAndSaveChanges()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ContactDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        using (var context = new ContactDbContext(options))
        {
            var repository = new ContactRepository(context);

            var assignment = new ContactFundAssignment
            {
                ContactId = 1,
                FundId = 101,
            };

            context.ContactFundAssignments.Add(assignment);
            context.SaveChanges();

            // Act
            repository.DeleteContactFundAssignment(assignment);

            // Assert
            Assert.AreEqual(0, context.ContactFundAssignments.Count());
        }
    }
}