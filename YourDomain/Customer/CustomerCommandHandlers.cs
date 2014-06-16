using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Edument.CQRS;
using System.Collections;
using Events.Something;

namespace YourDomain.Something
{
    public class CustomerCommandHandlers :
        IHandleCommand<CreateCustomer, Customer>
    {
        public IEnumerable Handle(Func<Guid, Customer> al, CreateCustomer c)
        {
            var agg = al(c.Id);

            if (agg.AlreadyHappened)
                throw new CustomerAlreadyExists();
            
            yield return new CustomerCreated
            {
                Id = c.Id,
                What = c.What
            };
        }
    }
}
