using System;
using System.Collections.Generic;
using Tier1.Model;

namespace Tier1.Data
{
    public interface ICustomerService
    {
        void Connect();
        string RegisterCustomer(int id,string name,string mail,string password);
    }
}