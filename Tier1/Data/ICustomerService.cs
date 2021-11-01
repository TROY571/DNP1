using System;
using System.Collections.Generic;
using Tier1.Model;

namespace Tier1.Data
{
    public interface ICustomerService
    {
        void RegisterCustomer(Customer customer);
    }
}