using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product;

namespace Product.service
{
    public interface IContactService
    {
        public Task AddContact(Contact contact);
        public Task RemoveContact(string phoneNumber);
        public Task EditContact(string phoneNumber, Contact newContact);
        public Task<Contact> SearchContact(string searchTerm);
        public Task<List<Contact>> FindAll();
    }
}
