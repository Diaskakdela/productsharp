using Product.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.view.console
{
    public class ContactConsoleService
    {
        private readonly IContactService contactService;

        public ContactConsoleService(IContactService contactService)
        {
            this.contactService = contactService;
        }

        public void AddContact()
        {
            Console.Write("Введите имя: ");
            string firstName = Console.ReadLine();

            Console.Write("Введите фамилию: ");
            string lastName = Console.ReadLine();

            Console.Write("Введите номер телефона: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Введите электронную почту: ");
            string email = Console.ReadLine();

            Console.Write("Введите адрес (можно оставить пустым): ");
            string address = Console.ReadLine();

            var contact = new Contact(firstName, lastName, phoneNumber, email, address);

            Console.Write("Контакт создается");
            contactService.AddContact(contact);
        }

        public void RemoveContact()
        {
            Console.Write("Введите номер телефона для удаления контакта: ");
            string phoneNumber = Console.ReadLine();

            contactService.RemoveContact(phoneNumber);
            Console.WriteLine("Контакт удален (если он был найден).");
        }

        public void EditContact()
        {
            Console.Write("Введите номер телефона контакта, который нужно редактировать: ");
            string phoneNumber = Console.ReadLine();

            Contact existingContact = contactService.SearchContact(phoneNumber).Result;

            if (existingContact == null)
            {
                Console.WriteLine("Контакт не найден.");
                return;
            }

            Console.Write("Введите новое имя (- чтобы оставить прежнее): ");
            string newFirstName = Console.ReadLine();
            if (newFirstName != "-")
            {
                existingContact.FirstName = newFirstName;
            }

            Console.Write("Введите новую фамилию (- чтобы оставить прежнюю): ");
            string newLastName = Console.ReadLine();
            if (newLastName != "-")
            {
                existingContact.LastName = newLastName;
            }

            Console.Write("Введите новый номер телефона (- чтобы оставить прежний): ");
            string newPhoneNumber = Console.ReadLine();
            if (newPhoneNumber != "-")
            {
                existingContact.PhoneNumber = newPhoneNumber;
            }

            Console.Write("Введите новый email (- чтобы оставить прежний): ");
            string newEmail = Console.ReadLine();
            if (newEmail != "-")
            {
                existingContact.Email = newEmail;
            }

            Console.Write("Введите новый адрес (- чтобы оставить прежний): ");
            string newAddress = Console.ReadLine();
            if (newAddress != "-")
            {
                existingContact.Address = newAddress;
            }

            contactService.EditContact(phoneNumber, existingContact);
            Console.WriteLine("Контакт отредактирован.");
        }

        public void SearchContact()
        {
            Console.Write("Введите поисковый запрос (имя, фамилия или номер телефона): ");
            string searchTerm = Console.ReadLine();

            var contact = contactService.SearchContact(searchTerm).Result;
            if (contact != null)
            {
                Console.WriteLine("Найден контакт:");
                Console.WriteLine(contact.ToString());
            }
            else
            {
                Console.WriteLine("Контакт не найден.");
            }
        }

        public void FindAllContactsAsync()
        {
            List<Contact> contacts = contactService.FindAll().Result;
            Console.WriteLine("Все контакты:");
            foreach (Contact contact in contacts)
            {
                Console.WriteLine(contact.ToString());
            }
        }
    }
}
