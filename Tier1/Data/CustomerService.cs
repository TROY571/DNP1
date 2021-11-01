using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Tier1.Model;
using Tier1.Services;

namespace Tier1.Data
{
    public class CustomerService:ICustomerService
    {
        private string customerFile = "customers.json";
        private IList<Customer> customers;

        public void Connect()
        {
            Client.getInstance().Connect();
        }
        public string RegisterCustomer(int id,string name,string mail,string password)
        {
            return Client.getInstance().RegisterCustomer(id, name, mail, password);
        }
        
        
    }
}