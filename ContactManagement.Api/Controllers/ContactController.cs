﻿using ContactManagement.Api.Models;
using ContactManagement.Api.Repository;
using ContactManagement.Api.WebApiHelpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Reflection;

namespace ContactManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [Route("~/api/GetAllContacts")]
        [HttpGet]
        public IEnumerable<ContactModel> GetAllContact()
        {
            _logger.Info("ContactController: Get method called");
            var contact = _contactRepository.GetAllContact().AsEnumerable();

            return contact;
        }

        [HttpGet("{id}")]
        public IActionResult GetContactbyId(int id)
        {
            _logger.Info("ContactController: GetContactbyId method called");

            var contactResponse = _contactRepository.GetContactbyId(id);
            return Ok(contactResponse);
        }

        [HttpPost]
        public IActionResult CreateContact([FromBody] ContactModel model)
        {
            _logger.Info("ContactController: Post method called");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _contactRepository.CreateContact(model);
            return Ok(new { message = "User created" });
        }
        

        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, ContactModel model)
        {
            _logger.Info("ContactController: Put method called");
            ApiError apiError = new ApiError();

            if (id != model.id)
            {
                apiError.ErrorCode = BadRequest().StatusCode;
                apiError.errorMessage = "Invalid parameters in request body";
                apiError.ErrorDetails = "This error due to invalid parameters in request";

                return BadRequest(apiError);
            }

            var contactResponse = _contactRepository.UpdateContact(id, model);

            if (contactResponse == null)
            {
                return NotFound();
            }
            return Ok(new { message = "User updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            _logger.Info("ContactController: Delete method called");
            ApiError apiError = new ApiError();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _contactRepository.DeleteContact(id);
            return NoContent();
        }

    }
}
