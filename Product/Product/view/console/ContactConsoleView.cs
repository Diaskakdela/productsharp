using Product.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.view.console
{
    public class ContactConsoleView
    {
        private readonly ContactConsoleService consoleService;

        public ContactConsoleView(ContactConsoleService consoleService)
        {
            this.consoleService = consoleService;
        }

        public void start()
        {
            while (true)
            {
                Console.WriteLine("\nАдресная книга:");
                Console.WriteLine("1. Добавить контакт");
                Console.WriteLine("2. Удалить контакт");
                Console.WriteLine("3. Редактировать контакт");
                Console.WriteLine("4. Поиск контакта");
                Console.WriteLine("5. Показать все контакты");
                Console.WriteLine("6. Выход");

                Console.Write("Выберите действие: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        consoleService.AddContact();
                        break;
                    case "2":
                        consoleService.RemoveContact();
                        break;
                    case "3":
                        consoleService.EditContact();
                        break;
                    case "4":
                        consoleService.SearchContact();
                        break;
                    case "5":
                        consoleService.FindAllContactsAsync();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор, попробуйте еще раз.");
                        break;
                }
            }
        }
    }
}
