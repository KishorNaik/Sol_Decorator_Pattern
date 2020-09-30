using Sol_Demo.Cores.Context.Decorate;
using Sol_Demo.Cores.Contexts;
using Sol_Demo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sol_Demo.Contexts.Decorators
{
    public sealed class CustomerContext_SMSNotificationDecorator : ICustomerContext_SMSNotificationDecorator
    {
        private readonly ICustomerContext_MailNotificationDecorator customerContext = null;

        public CustomerContext_SMSNotificationDecorator(ICustomerContext_MailNotificationDecorator customerContext)
        {
            this.customerContext = customerContext;
        }

        private Task SendSmsAsync(string mobileNo) => Task.Run(() => Console.WriteLine($"Send SMS : {mobileNo}"));

        async Task<bool> ICustomerContext.AddCustomerAsync(CustomerModel customerModel)
        {
            var flag = await this.customerContext?.AddCustomerAsync(customerModel);

            if (flag == true) await this.SendSmsAsync(customerModel?.MobileNo);

            return flag;
        }
    }
}