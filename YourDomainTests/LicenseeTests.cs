using System;
using Edument.CQRS;
using Keymaster.Events.LicenseeEvents;
using Keymaster.Licensee;
using Xunit;

namespace Keymaster.Tests
{
    public class LicenseeTests : BDDTest<LicenseeCommandHandlers, Licensee.Licensee>
    {
        private readonly Guid testId;

        public LicenseeTests()
        {
            testId = Guid.NewGuid();
        }

        [Fact]
        public void CreateCustomerCanHappen()
        {
            Test(
                Given(),
                When(new CreateLicensee
                {
                    Id = testId,
                    CompanyName = "MyCompany",
                    Address = "MyAddress"
                }),
                Then(new LicenseeCreated
                {
                    Id = testId,
                    CompanyName = "MyCompany",
                    Address = "MyAddress"
                }));
        }

        [Fact]
        public void CreateCustomerCanHappenOnlyOnce()
        {
            Test(
                Given(new LicenseeCreated
                {
                    Id = testId,
                    CompanyName = "MyCompany",
                    Address = "MyAddress"
                }),
                When(new CreateLicensee
                {
                    Id = testId,
                    CompanyName = "Does not matter",
                    Address = "Does not matter"
                }),
                ThenFailWith<LicenseeAlreadyExists>());
        }
    }
}