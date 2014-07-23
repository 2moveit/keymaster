using System.Collections.Generic;
using Edument.CQRS;
using Keymaster.Events.LicenseeEvents;

namespace Keymaster.Licensee
{
    public class Licensee : Aggregate,
        IApplyEvent<LicenseeCreated>,
        IApplyEvent<ContactAdded>,
        IApplyEvent<LicenseProvided>
    {
        public bool IsRegistered { get; private set; }

        public string Address { get; set; }

        public string CompanyName { get; set; }

        public List<Contact>Contacts = new List<Contact>();
 
        public List<License.License>Licenses = new List<License.License>(); 
        public void Apply(ContactAdded e)
        {
            Contacts.Add(new Contact {ContactName = e.ContactName, Email = e.Email});
        }

        public void Apply(LicenseeCreated e)
        {
            IsRegistered = true;
            CompanyName = e.CompanyName;
            Address = e.Address;
        }

        public void Apply(LicenseProvided e)
        {
            Licenses.Add(new License.License{ProductCode = e.ProductCode, LicenseeId = e.LicenseeId});
        }
    }
}