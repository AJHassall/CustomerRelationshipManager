using NUnit.Framework;
using Moq;
using Microsoft.AspNetCore.Mvc;
using FundManagementApi.Controllers;
using ContactManagementApi.Services;
using ContactManagementApi.Models;
using ContactManagementApi.Data.Repositories;
using ContactManagementApi.Data;
using Microsoft.EntityFrameworkCore;

namespace FundManagementApi.Tests.Controllers
{
    [TestFixture]
    public class FundsControllerTests
    {
        private Mock<FundService> _mockFundService;
        private Mock<FundRepository> _mockFundRepository;
        private FundsController _controller;
        private ContactDbContext _context; // Use in-memory DbContext directly

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ContactDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ContactDbContext(options); // Create in-memory DbContext
            _mockFundRepository = new Mock<FundRepository>(_context); // Pass in-memory DbContext
            _mockFundService = new Mock<FundService>(_mockFundRepository.Object);
            _controller = new FundsController(_mockFundService.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public void GetFundById_ReturnsOk_WhenFundExists()
        {
            // Arrange
            var fund = new Fund { Name = "Test Fund" };
            _context.Funds.Add(fund);
            _context.SaveChanges();

            // Act
            var result = _controller.GetFundById(fund.FundId); // Use the generated FundId

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(_context.Funds.Find(fund.FundId), okResult.Value);
        }

    }
}