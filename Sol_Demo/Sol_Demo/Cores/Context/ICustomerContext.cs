using Sol_Demo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sol_Demo.Cores.Contexts
{
    public interface ICustomerContext
    {
        Task<bool> AddCustomerAsync(CustomerModel customerModel);
    }
}