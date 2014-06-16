using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edument.CQRS;
using YourDomain.Something;

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

            Dispatcher.ScanInstance(new CustomerCommandHandlers());

            //CustomerQueries = new Customers();
            //Dispatcher.ScanInstance(CustomerQueries);

            //ChefTodoListQueries = new ChefTodoList();
            //Dispatcher.ScanInstance(ChefTodoListQueries);
        }
    }
}
