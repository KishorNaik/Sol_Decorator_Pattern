using Sol_Demo.Contexts;
using Sol_Demo.Contexts.Decorators;
using Sol_Demo.Cores.Context.Decorate;
using Sol_Demo.Cores.Contexts;
using Sol_Demo.Cores.Repository;
using Sol_Demo.Models;
using Sol_Demo.Repository;
using System;
using System.Threading.Tasks;

namespace Sol_Demo
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Day 1 :
            // Client : I want to store customer information in database.
            // Bad Developer : Ok, I will do it.
            // Good Developer : No Problem Sir, will do it.

            CustomerModel customerModel = new CustomerModel()
            {
                CustomerName = "Kishor",
                EmailId = "kishor.naik011.net@gmail.com",
                MobileNo = "9199999999"
            };

            ICustomerRepository customerRepository = new CustomerRepository();
            ICustomerContext customerContext = new CustomerContext(customerRepository);

            // Day 2:
            // Client : Once the data is stored in the database, the system would send a mail notification to the customer.
            // Bad Developer : What!!! A new requirement, Why you are not told earlier for this new requirement.
            // Good Developer : I heard you, will do it no problem.
            // Client : Oh. Sorry i almost forgot.
            // Bad Developer : Ok. I need to change the code. (In his mind : What the f**k)

            // Note :
            // The changes keep coming from the client saying this change I want, that one I want. Developers should always be adapting the changes coming in his way.
            // Real challenge is to extend the functionality without hurting the existing code. So here is come decorator Pattern.

            // voila : Just create Mail Notification decorator object without hurting any code in context class.
            customerContext = new CustomerContext_MailNotificationDecorator(customerContext);

            // Day 3:
            // Client: I need sms notification too for my customer.
            // Bad Developer : Again new requirement. Why you are not told earlier sir. (In his mind : i will kill him, mother f***er)
            // Good Developer : I heard you sir, No problem i will make this feature for you.

            // voila : just create sms notification decorator object without hurting any code in context class.
            customerContext = new CustomerContext_SMSNotificationDecorator(customerContext as ICustomerContext_MailNotificationDecorator);

            // Here i did not change single code. Keep as it is.
            var flag = await customerContext.AddCustomerAsync(customerModel);
            if (flag == true) Console.WriteLine("Data Save");
        }
    }
}