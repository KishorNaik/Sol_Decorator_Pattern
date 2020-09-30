using Sol_Demo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sol_Demo.Cores.Repository
{
    public interface ICustomerRepository
    {
        Task<bool> AddCustomerAsync(CustomerModel customerModel);
    }
}