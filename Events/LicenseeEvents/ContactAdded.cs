using System;

namespace Keymaster.Events.LicenseeEvents
{
    public class ContactAdded
    {
        public string ContactName { get; set; }
        public string Email { get; set; }
        public Guid LicenseeId { get; set; }
    }
}