using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CustomerManagementSystem.DataAccess
{
    public class CustomerDataAccess
    {
        private readonly string connectionString;

        public CustomerDataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            var customers = new List<Customer>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand("SELECT * FROM Customers", connection))
            {
                connection.Open();
                var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    var customer = new Customer
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Name = reader.GetString(reader.GetOrdinal("Name")),
                        Email = reader.GetString(reader.GetOrdinal("Email")),
                        Phone = reader.GetString(reader.GetOrdinal("Phone"))
                    };
                    customers.Add(customer);
                }
            }
            return customers;
        }

        public void SaveCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand("INSERT INTO Customers (Name, Email, Phone) VALUES (@Name, @Email, @Phone)", connection))
            {
                command.Parameters.AddWithValue("@Name", customer.Name);
                command.Parameters.AddWithValue("@Email", customer.Email);
                command.Parameters.AddWithValue("@Phone", customer.Phone);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
