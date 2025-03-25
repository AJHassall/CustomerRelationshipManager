using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ContactManagementApi.Controllers;
using ContactManagementApi.Models;
using ContactManagementApi.Services;
using Microsoft.EntityFrameworkCore;
using ContactManagementApi.Data;
using System.Collections.Generic;
using System;

namespace ContactManagementApi.Tests.Integration
{
    [TestFixture]
    public class FundsIntegrationTest
    {
        private FundsController _controller;
        private IFundService _fundService;
        private ContactDbContext _context;
        private UnitOfWork _unitOfWork;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ContactDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new ContactDbContext(options);
            _unitOfWork = new UnitOfWork(_context);
            _fundService = new FundService(_unitOfWork);
            _controller = new FundsController(_fundService);

            _context.Funds.AddRange(
                new Fund { Name = "Test Fund 1" },
                new Fund { Name = "Test Fund 2" }
            );
            _context.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public void GetAll_ReturnsOkResultWithFunds()
        {

            //Arrange
            var result = _controller.GetAll() as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.IsNotNull(result.Value);
            var funds = result.Value as List<Fund>;
            Assert.That(funds.Count, Is.EqualTo(2));
        }

    }
}