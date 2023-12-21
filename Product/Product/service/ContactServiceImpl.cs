using Product.repo.impl;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product;

namespace Product.service
{
    internal class ContactServiceImpl : IContactService
    {

        private readonly IContactRepo _repository;

        public ContactServiceImpl(IContactRepo repository)
        {
            _repository = repository;
        }

        public async Task AddContact(Contact contact)
        {
            try
            {
                await _repository.AddContact(contact);
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Ошибка SQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        public async Task EditContact(string phoneNumber, Contact newContact)
        {
            try
            {
                await _repository.EditContact(phoneNumber, newContact);
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Ошибка SQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        public async Task<List<Contact>> FindAll() => await _repository.FindAll();

        public async Task RemoveContact(string phoneNumber)
        {
            await _repository.RemoveContact(phoneNumber);
        }

        public async Task<Contact> SearchContact(string searchTerm) => await _repository.SearchContact(searchTerm);
    }
}
