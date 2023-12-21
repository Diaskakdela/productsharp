using Product.repo;
using Product.repo.impl;
using Product.service;
using Product.view.console;

namespace Product
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ContactConsoleView contactConsoleView = new ContactConsoleView(contactConsoleService());
            contactConsoleView.start();
        }

        static ContactConsoleService contactConsoleService()
        {
            return new ContactConsoleService(contactService());
        }

        static IContactService contactService()
        {
            return new ContactServiceImpl(contactRepo());
        }

        static IContactRepo contactRepo()
        {
            return new ContactRepoImpl();
        }
    }
}