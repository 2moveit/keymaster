using System;
using System.Collections;
using Edument.CQRS;
using Keymaster.Events.LicenseeEvents;

namespace Keymaster.Licensee
{
    public class LicenseeCommandHandlers :
        IHandleCommand<CreateLicensee, Licensee>,
        IHandleCommand<AddContact, Licensee>,
        IHandleCommand<ProvideLicense, Licensee>
    {
        public IEnumerable Handle(Func<Guid, Licensee> al, CreateLicensee c)
        {
            Licensee agg = al(c.Id);

            if (agg.AlreadyHappened)
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
            yield return new ContactAdded()
            {
                Id = c.Id,
                LicenseeId = c.LicenseeId,
                ContactName= c.ContactName,
                Email= c.Email
            };
        }

        public IEnumerable Handle(Func<Guid, Licensee> al, ProvideLicense c)
        {
            yield return new LicenseProvided()
            {
                LicenseeId = c.LicenseeId,
                ProductCode = c.ProductCode
            };
        }
    }
}