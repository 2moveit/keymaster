using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Edument.CQRS;
using Events.Something;

namespace YourDomain.Something
{
    public class Customer : Aggregate,
        IApplyEvent<CustomerCreated>
    {
        public bool AlreadyHappened { get; private set; }

        public void Apply(CustomerCreated e)
        {
            AlreadyHappened = true;
        }
    }
}
