using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Tier1.Model;

namespace Tier1.Data
{
    public class CustomerService:ICustomerService
    {
        private string customerFile = "customers.json";
        private IList<Customer> customers;
        
        public void RegisterCustomer(Customer customer)
        {
            int max = customers.Max(adult => adult.Id);
            customer.Id = (++max);
            customers.Add(customer);
            WriteAdultsToFile();
        }
        
        private void WriteAdultsToFile()
        {
            string customerAsJson = JsonSerializer.Serialize(customers);
            File.WriteAllText(customerFile,customerAsJson);
        }
    }
}