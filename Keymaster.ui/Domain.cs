using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edument.CQRS;
using Keymaster.License;
using Keymaster.Licensee;
using Keymaster.readmodels;

namespace Keymaster.ui
{
    public static class Domain
    {
        public static MessageDispatcher Dispatcher;
        public static ILicenseeQueries LicenseeQueries;
        //public static IChefTodoListQueries ChefTodoListQueries;

        public static void Setup(object instance)
        {
            Dispatcher = new MessageDispatcher(new InMemoryEventStore());

            

            Dispatcher.ScanInstance(new LicenseeCommandHandlers());
            Dispatcher.ScanInstance(new LicenseCommandHandlers());

            LicenseeQueries = new LicenseeList();
            Dispatcher.ScanInstance(LicenseeQueries);

            //ChefTodoListQueries = new ChefTodoList();
            //Dispatcher.ScanInstance(ChefTodoListQueries);

            Dispatcher.ScanInstance(instance);
        }
    }
}
