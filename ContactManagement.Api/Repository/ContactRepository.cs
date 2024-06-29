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
        public void CreateContact(ContactModel newContact)
        {
            IList<ContactModel> lstContacts = new List<ContactModel>();
            lstContacts = ContactJsonHelper.ReadFromJsonFile();
            lstContacts.Add(newContact);
            ContactJsonHelper.WriteToJsonFile(lstContacts);
        }
        public void DeleteContact(int id)
        {
            var contacts = ContactJsonHelper.ReadFromJsonFile();
            var contat = contacts.FirstOrDefault(c => c.ContactId == id);

            if (contat == null)
            {

            }
            contacts.Remove(contat);
            ContactJsonHelper.WriteToJsonFile(contacts);
        }
    }
}
