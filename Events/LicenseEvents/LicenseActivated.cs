using System;

namespace Keymaster.License
{
    public class LicenseActivated
    {
        public Guid ProductCode { get; set; }
        public Guid RegistrationCode { get; set; }
        public Guid LicenseeId { get; set; }
        public DateTime ActivationDate { get; set; }
    }
}