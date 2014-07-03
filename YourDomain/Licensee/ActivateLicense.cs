using System;

namespace Keymaster.Licensee
{
    public class ActivateLicense
    {
        public Guid RegistrationCode { get; set; }
        public Guid LicenseeId { get; set; }
        public Guid ProductCode { get; set; }
    }
}