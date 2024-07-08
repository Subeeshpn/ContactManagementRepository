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

        public ContactModel UpdateContact(int id, ContactModel contactModel)
        {
            var contacts = ContactJsonHelper.ReadFromJsonFile();
            var existingContact = contacts.FirstOrDefault(p => p.id == id);

            if (existingContact != null)
            {
                existingContact.firstname = contactModel.firstname;
                existingContact.lastname = contactModel.lastname;
                existingContact.emailid = contactModel.emailid;
                ContactJsonHelper.WriteToJsonFile(contacts);
            }
            return existingContact;

        }

        public void DeleteContact(int id)
        {
            var contacts = ContactJsonHelper.ReadFromJsonFile();
            var contat = contacts.FirstOrDefault(c => c.id == id);

            if (contat == null)
            {

            }
            contacts.Remove(contat);
            ContactJsonHelper.WriteToJsonFile(contacts);
        }
    }
}
