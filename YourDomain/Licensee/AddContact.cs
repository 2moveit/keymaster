using System;

namespace Keymaster.Licensee
{
    public class AddContact
    {
        public Guid Id { get; set; }
        public Guid LicenseeId   { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
    }
}