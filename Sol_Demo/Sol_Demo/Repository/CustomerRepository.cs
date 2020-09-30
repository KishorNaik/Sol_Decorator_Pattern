using Sol_Demo.Cores.Repository;
using Sol_Demo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol_Demo.Repository
{
    public sealed class CustomerRepository : ICustomerRepository
    {
        Task<bool> ICustomerRepository.AddCustomerAsync(CustomerModel customerModel)
        {
            return Task.Run(() =>
            {
                // Some Db Code.

                return true;
            });
        }
    }
}