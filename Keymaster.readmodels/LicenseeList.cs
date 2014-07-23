using System;
using System.Collections.Generic;
using System.Linq;
using Edument.CQRS;
using Keymaster.Events.LicenseeEvents;

namespace Keymaster.readmodels
{
    public class LicenseeList:ILicenseeQueries,
        ISubscribeTo<LicenseeCreated>,
        ISubscribeTo<ContactAdded>
    {
        private readonly Dictionary<Guid, LicenseCollection> licensesByLicensee =
            new Dictionary<Guid, LicenseCollection>();

        public IList<string> Licensees()
        {
            lock (licensesByLicensee)
            {
                return licensesByLicensee.Select(l => l.Value.CompanyName).OrderBy(c=>c).ToList();
            }
        }

        public LicenseeDetails DetailsForLicensee(string licenseeName)
        {
            KeyValuePair<Guid, LicenseCollection> detail;
            lock (licensesByLicensee)
            {
                detail = licensesByLicensee.First(t => t.Value.CompanyName == licenseeName);
            }
            lock (detail.Value)
            {
                return new LicenseeDetails
                {
                    LicenseeId = detail.Key,
                    LicenseeName = detail.Value.CompanyName,
                    OwenedLicenses = new List<LicenseItem>(detail.Value.OwenedLicenses),
                    Contacts = new List<ContactItem>(detail.Value.Contacts)
                };
            }
        }

 

        public void Handle(LicenseeCreated e)
        {
            lock (licensesByLicensee)
                licensesByLicensee.Add(e.Id, new LicenseCollection
                {
                    CompanyName = e.CompanyName,
                    Address = e.Address,
                    OwenedLicenses = new List<LicenseItem>(),
                    Contacts = new List<ContactItem>() 
                });
        }

        public void Handle(ContactAdded e)
        {
            lock (licensesByLicensee)
            {
                licensesByLicensee.First(l => l.Key == e.Id)
                    .Value.Contacts.Add(new ContactItem() {Name = e.ContactName, Email = e.Email});
            }
        }
    }
}