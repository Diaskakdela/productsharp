using Product.repo.impl;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product;

namespace Product.repo
{
    internal class ContactRepoImpl : IContactRepo
    {

        private readonly string _connectionString = "Server=DESKTOP-KHJTSUE;Database=Contact;Trusted_Connection=True;";
        public async Task AddContact(Contact contact)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string insertQuery = @"INSERT INTO Contacts (FirstName, LastName, PhoneNumber, Email, Address) 
                               VALUES (@FirstName, @LastName, @PhoneNumber, @Email, @Address)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@FirstName", contact.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", contact.LastName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", contact.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", contact.Email);
                    cmd.Parameters.AddWithValue("@Address", contact.Address ?? (object)DBNull.Value);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EditContact(string phoneNumber, Contact newContact)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string sql = "UPDATE Contacts SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Address = @Address WHERE PhoneNumber = @PhoneNumber";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@FirstName", newContact.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", newContact.LastName);
                    cmd.Parameters.AddWithValue("@Email", newContact.Email);
                    cmd.Parameters.AddWithValue("@Address", newContact.Address);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<Contact>> FindAll()
        {
            var contacts = new List<Contact>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string sql = "SELECT * FROM Contacts";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            var contact = new Contact(
                                reader["FirstName"].ToString(),
                                reader["LastName"].ToString(),
                                reader["PhoneNumber"].ToString(),
                                reader["Email"].ToString(),
                                reader["Address"].ToString()
                            );
                            contacts.Add(contact);
                        }
                    }
                }
            }
            return contacts;
        }

        public async Task RemoveContact(string phoneNumber)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string sql = "DELETE FROM Contacts WHERE PhoneNumber = @PhoneNumber";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<Contact> SearchContact(string searchTerm)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string sql = "SELECT * FROM Contacts WHERE PhoneNumber = @PhoneNumber OR FirstName LIKE @Search OR LastName LIKE @Search";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@PhoneNumber", searchTerm);
                    cmd.Parameters.AddWithValue("@Search", $"%{searchTerm}%");
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            return new Contact(
                                reader["FirstName"].ToString(),
                                reader["LastName"].ToString(),
                                reader["PhoneNumber"].ToString(),
                                reader["Email"].ToString(),
                                reader["Address"].ToString()
                            );
                        }
                    }
                }
            }
            return null;
        }
    }
}
