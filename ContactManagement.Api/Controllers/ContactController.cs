using ContactManagement.Api.Models;
using ContactManagement.Api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [Route("~/api/GetAllContacts")]
        [HttpGet]
        public IEnumerable<ContactModel> GetAllContact()
        {

            var contact = _contactRepository.GetAllContact().AsEnumerable();

            return contact;
        }
        [HttpPost]
        public IActionResult CreateContact([FromBody] ContactModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _contactRepository.CreateContact(model);
            return Ok(new { message = "User created" });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _contactRepository.DeleteContact(id);
            return Ok(new { message = "User deleted" });
        }

    }
}
