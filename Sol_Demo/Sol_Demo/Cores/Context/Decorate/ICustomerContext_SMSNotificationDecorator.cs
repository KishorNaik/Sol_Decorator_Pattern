using System;
using System.Collections.Generic;
using System.Text;

namespace Sol_Demo.Cores.Context.Decorate
{
    public interface ICustomerContext_SMSNotificationDecorator : ICustomerContext_MailNotificationDecorator
    {
    }
}