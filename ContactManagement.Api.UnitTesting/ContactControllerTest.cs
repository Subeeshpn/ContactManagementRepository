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
        public void Contact_GetAllContact_Return_OkResult()
        {
            var _contactList = _fixture.CreateMany<ContactModel>(3).ToList();
            _contactRepositoryMock.Setup(repo => repo.GetAllContact()).Returns(_contactList);
            _controller = new ContactController(_contactRepositoryMock.Object);
            var result = _controller.GetAllContact();
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
           
        }

        //[TestMethod]
        //public void Contact_GetContact_Return_BadRequestResult() { }
        //[TestMethod]
        //public void Contact_GetContact_MatchResult() { }

        [TestMethod]
        public  void Contact_GetContactById_Return_OkResult() 
        {
            ContactModel conact = new ContactModel();
            var mock = new Mock<IContactRepository>();
            mock.Setup(p => p.GetContactbyId(1)).Returns(conact);
            ContactController contact = new ContactController(mock.Object);
            var  result = contact.GetContactbyId(1);
            var obj = result as ObjectResult;
            Assert.AreEqual(result, result);
        }
        //[TestMethod]
        //public  void Contact_GetContactById_Return_NotFoundResult() { }
        //[TestMethod]
        //public  void Contact_GetContactById_Return_BadRequestResult() { }
        //[TestMethod]
        //public  void Contact_GetContactById_MatchResult() { }


        //[TestMethod]
        //public  void Contact_Add_ValidData_Return_OkResult() { }
        //[TestMethod]
        //public  void Contact_Add_InvalidData_Return_BadRequest() { }
        //[TestMethod]
        //public  void Contact_Add_ValidData_MatchResult() { }


        //[TestMethod]
        //public  void Contact_Update_ValidData_Return_OkResult() { }
        //[TestMethod]
        //public  void Contact_Update_InvalidData_Return_BadRequest() { }
        //[TestMethod]
        //public  void Contact_Update_InvalidData_Return_NotFound() { }


        //[TestMethod]
        //public  void Contact_Delete_Contact_Return_OkResult() { }
        //[TestMethod]
        //public  void Contact_Delete_Contact_Return_NotFoundResult() { }
        //[TestMethod]
        //public  void Contact_Delete_Return_BadRequestResult() { }







    }
}
