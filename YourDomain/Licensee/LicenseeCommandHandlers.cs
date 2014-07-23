using System;
using System.Collections;
using System.Linq;
using Edument.CQRS;
using Keymaster.Events.LicenseeEvents;
using Keymaster.License;

namespace Keymaster.Licensee
{
    public class LicenseeCommandHandlers :
        IHandleCommand<CreateLicensee, Licensee>,
        IHandleCommand<AddContact, Licensee>,
        IHandleCommand<ProvideLicense, Licensee>,
        IHandleCommand<ActivateLicense, Licensee>
    {
        public IEnumerable Handle(Func<Guid, Licensee> al, CreateLicensee c)
        {
            Licensee agg = al(c.Id);

            if (agg.IsRegistered)
                throw new LicenseeAlreadyExists();

            yield return new LicenseeCreated
            {
                Id = c.Id,
                CompanyName = c.CompanyName,
                Address = c.Address
            };
        }

        public IEnumerable Handle(Func<Guid, Licensee> al, AddContact c)
        {
            Licensee agg = al(c.Id);
            if (!agg.IsRegistered)
                throw new LicenseeNotRegistered();
            yield return new ContactAdded()
            {
                Id = c.Id,
                ContactName= c.ContactName,
                Email= c.Email
            };
        }

        public IEnumerable Handle(Func<Guid, Licensee> al, ProvideLicense c)
        {
            Licensee agg = al(c.Id);
            if (!agg.IsRegistered)
                throw new LicenseeNotRegistered();
            yield return new LicenseProvided()
            {
                Id = c.Id,
                ProductCode = c.ProductCode
            };
        }


        public IEnumerable Handle(Func<Guid, Licensee> al, ActivateLicense c)
        {
            Licensee agg = al(c.Id);
            if (!agg.Licenses.Exists(l => l.ProductCode == c.ProductCode))
                throw new LicenseNotProvidedForLicensee();
            yield return
                new LicenseActivated
                {
                    Id = c.Id,
                    ActivationDate = DateTime.Now,
                    ProductCode = c.ProductCode,
                    RegistrationCode = c.RegistrationCode
                };
        }
    }
}