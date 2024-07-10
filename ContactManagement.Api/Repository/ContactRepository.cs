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
        public ContactModel GetContactbyId(int id)
        {
          
            var contacts = ContactJsonHelper.ReadFromJsonFile();
            var existingContact = contacts.FirstOrDefault(p => p.id == id);
            return existingContact;
        }
        public void CreateContact(ContactModel newContact)
        {
            IList<ContactModel> lstContacts = new List<ContactModel>();
            ContactModel addNewContact = new ContactModel();
            lstContacts = ContactJsonHelper.ReadFromJsonFile();
            int maxId= lstContacts.Max(p => p.id);
            addNewContact.id = maxId + 1;
            addNewContact.firstname = newContact.firstname;
            addNewContact.lastname =newContact.lastname;
            addNewContact.emailid =newContact.emailid;
            lstContacts.Add(addNewContact);
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
            var contact = contacts.FirstOrDefault(c => c.id == id);

            if (contact != null)
            {
                contacts.Remove(contact);
                ContactJsonHelper.WriteToJsonFile(contacts);
            }
            else
            {
                throw new Exception("Contact id is not found.");
            }
            
            
        }
    }
}
