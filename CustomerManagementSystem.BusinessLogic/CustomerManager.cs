using System.Collections.Generic;
using System.Linq;
using CustomerManagementSystem.DataAccess;

namespace CustomerManagementSystem.BusinessLogic
{
    public class CustomerManager
    {
        private readonly CustomerDataAccess customerDataAccess;

        public CustomerManager(CustomerDataAccess customerDataAccess)
        {
            this.customerDataAccess = customerDataAccess;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return customerDataAccess.GetCustomers();
        }

        public void SaveCustomer(Customer customer)
        {
            customerDataAccess.SaveCustomer(customer);
        }

        public Customer GetCustomerById(int id)
        {
            return customerDataAccess.GetCustomers().FirstOrDefault(c => c.Id == id);
        }

        public string GetCustomerDetailsAsXml()
        {
            string json = Helper.GetJsonString(customerDataAccess.GetCustomers());
            var xmlDoc = JsonToXmlConverter.Convert(json);
            return JsonXmlHandler.XmlStructure.GetXmlString(xmlDoc);
        }

        public string GetCustomerDetailsAsXmlTreeView()
        {
            string json = Helper.GetJsonString(customerDataAccess.GetCustomers());
            var xmlDoc = JsonToXmlConverter.Convert(json);
            return JsonXmlHandler.XmlStructure.PrintXmlTreeStructure(xmlDoc.DocumentElement);
        }

        public string GetCustomerDetailsAsJson()
        {
            return Helper.GetJsonString(customerDataAccess.GetCustomers());
        }
    }
}
