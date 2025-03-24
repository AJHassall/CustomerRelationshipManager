using NUnit.Framework;
using Moq;
using Microsoft.AspNetCore.Mvc;
using ContactManagementApi.Services;
using ContactManagementApi.Models;
using ContactManagementApi.Controllers;

namespace ContactManagementApi.Tests.Controllers
{
    [TestFixture]
    public class ContactsControllerTests
    {
        private Mock<IContactService> _mockContactService;
        private ContactsController _controller;

        [SetUp]
        public void Setup()
        {
            _mockContactService = new Mock<IContactService>();
            _controller = new ContactsController(_mockContactService.Object);
        }

        [Test]
        public void Assert_Contact_Valid_Contact_No_Error()
        {
            var contact = new Contact { Name = "John Doe", Email = "John.Doe@mail.com", PhoneNumber = "09999999999" };

            _mockContactService.Setup(service => service.CreateContact(contact)).Returns(contact);
            var result = _controller.CreateContact(contact);

            var okResult = result as CreatedAtActionResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual(contact, okResult.Value);
        }

        //A Contact must have a Name
        [Test]
        public void Assert_Error_When_Name_Invalid()
        {
            var contact = new Contact { Name = "", Email = "John.Doe@mail.com", PhoneNumber = "09999999999" };

            var result = _controller.CreateContact(contact);

            Assert.IsInstanceOf<BadRequestResult>(result);

            var badRequestResult = result as BadRequestResult;
            Assert.IsNotNull(badRequestResult);
            Assert.AreEqual(400, badRequestResult.StatusCode);
        }
    }
}