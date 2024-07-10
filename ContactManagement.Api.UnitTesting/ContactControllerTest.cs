using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManagement.Api.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AutoFixture;
using ContactManagement.Api.Controllers;
using ContactManagement.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagement.Api.UnitTesting
{
    [TestClass]
    public class ContactControllerTest
    {
        private Mock<IContactRepository> _contactRepositoryMock;
        private Fixture _fixture;
        private ContactController _controller;

        public ContactControllerTest()
        {
            _fixture = new Fixture();
            _contactRepositoryMock = new Mock<IContactRepository>();
        }
        [TestMethod]
        public void Get_Contat_ReturnsOk()
        {
            var _contactList = _fixture.CreateMany<ContactModel>(3).ToList();
            _contactRepositoryMock.Setup(repo => repo.GetAllContact()).Returns(_contactList);
            _controller = new ContactController(_contactRepositoryMock.Object);
            var result = _controller.GetAllContact();
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
           
        }

       

    }
}
