using System;

namespace Keymaster.License
{
    public class LicenseActivated
    {
        public Guid Id;
        public Guid ProductCode;
        public Guid RegistrationCode;
        public Guid LicenseeId;
        public DateTime ActivationDate;
    }
}