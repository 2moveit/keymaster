using System;

namespace Keymaster.Events.LicenseeEvents
{
    public class LicenseProvided
    {
        public Guid Id;
        public Guid LicenseeId;
        public Guid ProductCode;
    }
}