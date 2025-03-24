using NUnit.Framework;
using Moq;
using Microsoft.AspNetCore.Mvc;
using ContactManagementApi.Services;
using ContactManagementApi.Models;
using ContactManagementApi.Controllers;

namespace ContactManagementApi.Tests.Controllers
{
    [TestFixture]
    public class FundsControllerTests
    {
        private Mock<IFundService> _mockFundService;
        private FundsController _controller;

        [SetUp]
        public void Setup()
        {
            _mockFundService = new Mock<IFundService>();
            _controller = new FundsController(_mockFundService.Object);
        }

        [Test]
        public void GetFundById_ReturnsOk_WhenFundExists()
        {
            // Arrange
            var fund = new Fund { Name = "Test Fund" };
            _mockFundService.Setup(service => service.GetFundById(fund.FundId)).Returns(fund);

            // Act
            var result = _controller.GetFundById(fund.FundId);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(fund, okResult.Value);
        }

        [Test]
        public void GetFundById_ReturnsNotFound_WhenFundDoesNotExist()
        {
            // Arrange
            _mockFundService.Setup(service => service.GetFundById(1)).Returns((Fund)null);

            // Act
            var result = _controller.GetFundById(1);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }
    }
}