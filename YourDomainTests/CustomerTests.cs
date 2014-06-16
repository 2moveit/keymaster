using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using YourDomain.Something;
using Edument.CQRS;
using Events.Something;

namespace YourDomainTests
{
    public class CustomerTests : BDDTest<CustomerCommandHandlers, Customer>
    {
        private Guid testId;

        public CustomerTests()
        {
            testId = Guid.NewGuid();
        }

        [Fact]
        public void CreateCustomerCanHappen()
        {
            Test(
                Given(),
                When(new CreateCustomer
                {
                    Id = testId,
                    What = "Boom!"
                }),
                Then(new CustomerCreated
                {
                    Id = testId,
                    What = "Boom!"
                }));
        }

        [Fact]
        public void CreateCustomerCanHappenOnlyOnce()
        {
            Test(
                Given(new CustomerCreated
                {
                    Id = testId,
                    What = "Boom!"
                }),
                When(new CreateCustomer
                {
                    Id = testId,
                    What = "Boom!"
                }),
                ThenFailWith<CustomerAlreadyExists>());
        }
    }
}
