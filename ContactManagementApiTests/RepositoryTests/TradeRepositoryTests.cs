using NUnit.Framework;
using ContactManagementApi.Data;
using ContactManagementApi.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ContactManagementApi.Models;

[TestFixture] 
public class TradeRepositoryTests
{
    [Test] 
    public void Get_ShouldReturnValue()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ContactDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        using var context = new ContactDbContext(options);
        var repository = new TradeRepository(context);

        var trade = new Trade
        {
           FundId = 1,
           
        };

        context.Trades.Add(trade);
        context.SaveChanges();

        // Act
        var createdAssignment = repository.Get(1);

        // Assert
        Assert.That(createdAssignment.FundId, Is.EqualTo(1));



    }
}