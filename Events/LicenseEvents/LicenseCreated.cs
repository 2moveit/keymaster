using System;

namespace Keymaster.Events.LicenseEvents
{
    public class LicenseCreated
    {
        public Guid Id;
        public Guid LicenseeId;
        public Guid ProductCode;
    }
}