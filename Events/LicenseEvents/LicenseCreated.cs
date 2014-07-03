using System;

namespace Keymaster.Events.LicenseEvents
{
    public class LicenseCreated
    {
        public Guid LicenseeId { get; set; }
        public Guid ProductCode { get; set; }
    }
}