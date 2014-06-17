using System;
using System.Collections;
using Edument.CQRS;
using Keymaster.Events.LicenseeEvents;

namespace Keymaster.Licensee
{
    public class LicenseeCommandHandlers :
        IHandleCommand<CreateLicensee, Licensee>
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
    }
}