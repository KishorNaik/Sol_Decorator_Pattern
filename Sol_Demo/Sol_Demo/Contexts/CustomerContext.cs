using Sol_Demo.Cores.Contexts;
using Sol_Demo.Cores.Repository;
using Sol_Demo.Models;
using Sol_Demo.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sol_Demo.Contexts
{
    public sealed class CustomerContext : ICustomerContext
    {
        private readonly ICustomerRepository customerRepository = null;

        public CustomerContext(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        async Task<bool> ICustomerContext.AddCustomerAsync(CustomerModel customerModel)
        {
            return await this.customerRepository.AddCustomerAsync(customerModel);
        }
    }
}