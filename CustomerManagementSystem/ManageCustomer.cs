using System;
using CustomerManagementSystem.BusinessLogic;
using CustomerManagementSystem.DataAccess;

namespace CustomerManagementSystem
{
    public partial class Form : System.Windows.Forms.Form
    {
        private readonly CustomerManager _customerManager;
        private readonly CustomerDataAccess _customerDataAccess;
        private readonly string _connectionString = @"Data Source=NADUN-PC;Initial Catalog=TestDB;User ID=sa;Password=sa@123;";
        public Form()
        {
            InitializeComponent();

            // Initialize the CustomerManager with a new instance of CustomerDataAccess
            _customerDataAccess = new CustomerDataAccess(_connectionString);
            _customerManager = new CustomerManager(_customerDataAccess);
        }

        private void RefreshCustomerList()
        {
            dgvCustomers.Rows.Clear();
            var customers = _customerManager.GetCustomers();
            foreach (var customer in customers)
            {
                dgvCustomers.Rows.Add(customer.Id, customer.Name, customer.Email, customer.Phone);
            }
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            RefreshCustomerList();            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Create a new Customer object with the values from the text boxes
            var customer = new DataAccess.Customer
            {
                Name = txtName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text
            };

            // Save the new customer to the database
            _customerManager.SaveCustomer(customer);

            // Refresh the list of customers
            RefreshCustomerList();
        }
    }
}
