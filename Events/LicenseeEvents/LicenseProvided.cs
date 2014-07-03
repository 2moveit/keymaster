using System;

namespace Keymaster.Events.LicenseeEvents
{
    public class LicenseProvided
    {
        public Guid LicenseeId { get; set; }
        public Guid ProductCode { get; set; }
    }
}