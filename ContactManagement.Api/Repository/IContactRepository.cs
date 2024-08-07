﻿using ContactManagement.Api.Models;
using ContactManagement.Api.Repository;
using System.Collections.Generic;

namespace ContactManagement.Api.Repository
{
    public interface IContactRepository
    {
        IEnumerable<ContactModel> GetAllContact();

        ContactModel GetContactbyId(int id);
        void CreateContact(ContactModel Contact);

        ContactModel UpdateContact(int id, ContactModel contactModel);

        void DeleteContact(int id);
    }
}
