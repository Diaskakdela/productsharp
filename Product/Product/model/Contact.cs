using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{

    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public Contact(string firstName, string lastName, string phoneNumber, string email, string address = "")
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, Тел: {PhoneNumber}, Email: {Email}, Адрес: {Address}";
        }
    }
}
