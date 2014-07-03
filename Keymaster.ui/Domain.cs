using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edument.CQRS;
using Keymaster.License;
using Keymaster.Licensee;

namespace Keymaster.ui
{
    public static class Domain
    {
        public static MessageDispatcher Dispatcher;
        //public static ICustomerQueries CustomerQueries;
        //public static IChefTodoListQueries ChefTodoListQueries;

        public static void Setup()
        {
            Dispatcher = new MessageDispatcher(new InMemoryEventStore());

            Dispatcher.ScanInstance(new LicenseeCommandHandlers());
            Dispatcher.ScanInstance(new LicenseCommandHandlers());

            //CustomerQueries = new Customers();
            //Dispatcher.ScanInstance(CustomerQueries);

            //ChefTodoListQueries = new ChefTodoList();
            //Dispatcher.ScanInstance(ChefTodoListQueries);
        }
    }
}
