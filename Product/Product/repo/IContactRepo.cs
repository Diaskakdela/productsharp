using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Product;

namespace Product.repo.impl
{
    internal interface IContactRepo
    {
        public  Task AddContact(Contact contact);
        public  Task RemoveContact(string phoneNumber);
        public  Task EditContact(string phoneNumber, Contact newContact);
        public  Task<Contact> SearchContact(string searchTerm);
        public  Task<List<Contact>> FindAll();
    }
}
