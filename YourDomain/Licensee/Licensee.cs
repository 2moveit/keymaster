using System.Collections.Generic;
using System.Linq;
using Edument.CQRS;
using Keymaster.Events.LicenseeEvents;
using Keymaster.License;

namespace Keymaster.Licensee
{
    public class Licensee : Aggregate,
        IApplyEvent<LicenseeCreated>,
        IApplyEvent<ContactAdded>,
        IApplyEvent<LicenseProvided>,
        IApplyEvent<LicenseActivated>
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
            Licenses.Add(new License.License{Id = e.Id, ProductCode = e.ProductCode});
        }

        public void Apply(LicenseActivated e)
        {
            var license = Licenses.First(l => l.ProductCode == e.ProductCode);
            license.Activations.Add(new Activation{ActivationDate = e.ActivationDate, RegistrationCode = e.RegistrationCode});
        }
    }
}