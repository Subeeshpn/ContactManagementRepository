using ContactManagement.Api.Models;
using ContactManagement.Api.WebApiHelpers;

namespace ContactManagement.Api.Repository
{
    public class ContactRepository:IContactRepository
    {
        public IEnumerable<ContactModel> GetAllContact()
        {
            return ContactJsonHelper.ReadFromJsonFile();
        }
    }
}
