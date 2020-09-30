using Sol_Demo.Cores.Context.Decorate;
using Sol_Demo.Cores.Contexts;
using Sol_Demo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sol_Demo.Contexts.Decorators
{
    public sealed class CustomerContext_MailNotificationDecorator : ICustomerContext_MailNotificationDecorator
    {
        private readonly ICustomerContext customerContext = null;

        public CustomerContext_MailNotificationDecorator(ICustomerContext customerContext)
        {
            this.customerContext = customerContext;
        }

        private Task SendMailAsync(string mailId) => Task.Run(() => Console.WriteLine($"Send Mail : {mailId}"));

        async Task<bool> ICustomerContext.AddCustomerAsync(CustomerModel customerModel)
        {
            var flag = await customerContext?.AddCustomerAsync(customerModel);

            if (flag == true) await SendMailAsync(customerModel?.EmailId);

            return true;
        }
    }
}