using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManagement.Api.Repository;
using Moq;
using AutoFixture;
using ContactManagement.Api.Controllers;
using ContactManagement.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace ContactsManagement.Api.UnitTest
{
    public class ContactControllerUnitTests
    {

        private readonly Mock<IContactRepository> contactService;
        public ContactControllerUnitTests()
        {
            contactService = new Mock<IContactRepository>();
        }


        [Fact]
        public void Contact_GetAllContact_Return_OkResult()
        {
            //arrange
            var contactList = GetContactData();
            contactService.Setup(x => x.GetAllContact())
                .Returns(contactList);
            var contactController = new ContactController(contactService.Object);
            //act
            var contactResult = contactController.GetAllContact();
            //assert
            Assert.NotNull(contactResult);
            Assert.Equal(GetContactData().Count(), contactResult.Count());
            Assert.Equal(GetContactData().ToString(), contactResult.ToString());
            Assert.True(contactList.Equals(contactResult));

        }

        //[fact]
        //public void Contact_GetContact_Return_BadRequestResult() { }
        //[fact]
        //public void Contact_GetContact_MatchResult() { }

        [Fact]
        public void Contact_GetContactById_Return_OkResult()
        {
            var contactList = GetContactData();
            contactService.Setup(x => x.GetContactbyId(2))
                .Returns(contactList[1]);
            var contactController = new ContactController(contactService.Object);
            //act
            var contactResult = contactController.GetContactbyId(1);
           
            //assert
            Assert.NotNull(contactList);
            //Assert.Equal(contactList[1].id, contactResult.id);
            //Assert.True(contactList[1].id 
        }

        //[Fact]
        //public void Contact_GetContactById_Return_NotFoundResult() { }
        //[Fact]
        //public void Contact_GetContactById_Return_BadRequestResult() { }
        //[Fact]
        //public void Contact_GetContactById_MatchResult() { }


        [Fact]
        public void Contact_Add_ValidData_Return_OkResult()
        {

            var newConact = new ContactModel { id = 3, firstname = "Sam Wilson",lastname="same last", emailid = "sam@example.com" };
            // Act
            var contactController = new ContactController(contactService.Object);
            var result = contactController.CreateContact(newConact) as CreatedAtActionResult; 
            // Assert
            Assert.NotNull(result); 
            Assert.Equal(201, result.StatusCode); 
            Assert.Equal("GetContactbyId", result.ActionName); 
            Assert.Equal(newConact.id, ((ContactModel)result.Value).id); 
        }
        //[Fact]
        //public void Contact_Add_InvalidData_Return_BadRequest() { }
        //[Fact]
        //public void Contact_Add_ValidData_MatchResult() { }


        //[Fact]
        //public void Contact_Update_ValidData_Return_OkResult() { }
        //[Fact]
        //public void Contact_Update_InvalidData_Return_BadRequest() { }
        [Fact]
        public void Contact_Update_InvalidData_Return_NotFound() {
            var updatedUser = new ContactModel { id = 1, firstname = "John Updated",lastname= "John Updated1", emailid = "john.updated@example.com" };
            contactService.Setup(service => service.UpdateContact(updatedUser.id, updatedUser));
            // Act
            var contactController = new ContactController(contactService.Object);
            var result = contactController.UpdateContact(1, updatedUser) as NoContentResult; 
            // Assert
            Assert.NotNull(result); 
            Assert.Equal(204, result.StatusCode); 
        }


        //[Fact]
        //public void Contact_Delete_Contact_Return_OkResult() { }
        [Fact]
        public void Contact_Delete_Contact_Return_NotFoundResult() 
        {
            var Id = 1;
            contactService.Setup(service => service.DeleteContact(Id));
            // Act
            var contactController = new ContactController(contactService.Object);
            //act

            var result = contactController.DeleteContact(Id) as NoContentResult;
            // Assert
            Assert.NotNull(result);
            Assert.Equal(204, result.StatusCode);

        }
        //[Fact]
        //public void Contact_Delete_Return_BadRequestResult() {}


        private List<ContactModel> GetContactData()
        {
            List<ContactModel> contactsData = new List<ContactModel>
        {
            new ContactModel
            {
                id = 1,
                firstname = "SAch",
                lastname = "sach2",
                emailid = "sach@gmail.com"
              
            },
             new ContactModel
            {
                id = 2,
                firstname = "kichu",
                lastname = "kichu1",
                emailid = "kichu@gmail.com"
            },
             new ContactModel
            {
                id = 3,
                firstname = "sree",
                lastname = "sree",
                emailid = "sree@gmail.com"
            },
        };
            return contactsData;
        }
    }
}