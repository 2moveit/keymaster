using System;
using Edument.CQRS;
using Keymaster.Events.LicenseeEvents;
using Keymaster.Licensee;
using Xunit;

namespace Keymaster.Tests
{
    public class LicenseeTests : BDDTest<LicenseeCommandHandlers, Licensee.Licensee>
    {
        private readonly Guid licenseeId;
        private readonly Guid productCode;
        private readonly Guid registrationCode;

        public LicenseeTests()
        {
            licenseeId = Guid.NewGuid();
            productCode = Guid.NewGuid();
            registrationCode = Guid.NewGuid();
        }

        [Fact]
        public void CreateLicenseeCanHappen()
        {
            Test(
                Given(),
                When(new CreateLicensee
                {
                    Id = licenseeId,
                    CompanyName = "MyCompany",
                    Address = "MyAddress"
                }),
                Then(new LicenseeCreated
                {
                    Id = licenseeId,
                    CompanyName = "MyCompany",
                    Address = "MyAddress"
                }));
        }

        [Fact]
        public void CreateLicenseeCanHappenOnlyOnce()
        {
            Test(
                Given(new LicenseeCreated
                {
                    Id = licenseeId,
                    CompanyName = "MyCompany",
                    Address = "MyAddress"
                }),
                When(new CreateLicensee
                {
                    Id = licenseeId,
                    CompanyName = "Does not matter",
                    Address = "Does not matter"
                }),
                ThenFailWith<LicenseeAlreadyExists>());
        }

        [Fact]
        public void AddContactCanHappen()
        {
            Test(
                Given(new LicenseeCreated
                {
                    Id = licenseeId,
                    CompanyName = "MyCompany",
                    Address = "MyAddress"
                }),
                When(new AddContact()
                {
                    ContactName = "MyName",
                    Email = "MyEmail",
                    LicenseeId = licenseeId
                }),
                Then(new ContactAdded
                {
                    ContactName = "MyName",
                    Email = "MyEmail",
                    LicenseeId = licenseeId
                }));
        }

        [Fact]
        public void AddLicenseCanHappen()
        {
            Test(
                Given(new LicenseeCreated
                {
                    Id = licenseeId,
                    CompanyName = "MyCompany",
                    Address = "MyAddress"
                }),
                When(new ProvideLicense()
                {
                    LicenseeId = licenseeId,
                    ProductCode = productCode
                }),
                Then(new LicenseProvided
                {
                    LicenseeId = licenseeId,
                    ProductCode = productCode
                }));
        }



        
    }


}