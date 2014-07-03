using System;
using Edument.CQRS;
using Keymaster.Events.LicenseeEvents;
using Keymaster.Events.LicenseEvents;
using Keymaster.License;
using Keymaster.Licensee;
using Xunit;

namespace Keymaster.Tests
{
    public class LicenseTests : BDDTest<LicenseCommandHandlers, License.License>
    {
        private readonly Guid licenseeId;
        private readonly Guid productCode;
        private readonly Guid registrationCode;

        public LicenseTests()
        {
            licenseeId = Guid.NewGuid();
            productCode = Guid.NewGuid();
            registrationCode = Guid.NewGuid();
        }


        [Fact]
        public void LicenseCreatedCanHappen()
        {
            Test(
                Given(),
                When(new CreateLicense()
                {
                    ProductCode = productCode,
                    LicenseeId = licenseeId
                }),
                Then(new LicenseCreated
                {
                    LicenseeId = licenseeId,
                    ProductCode = productCode,
                }));
        }

         [Fact]
        public void ActivateLicenseCanHappen()
        {
            Test(
                Given(new LicenseCreated()
                {
                    ProductCode = productCode,
                    LicenseeId = licenseeId
                }),
                When(new ActivateLicense()
                {
                    LicenseeId = licenseeId,
                    ProductCode = productCode,
                    RegistrationCode = registrationCode

                }),
                Then(new LicenseActivated
                {
                    LicenseeId = licenseeId,
                    ProductCode = productCode,
                     RegistrationCode = registrationCode
                }));
        }

        //Wie testet man ob events auf aggegate applied wurden?


        
    }
}