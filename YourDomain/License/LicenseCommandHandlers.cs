using System;
using System.Collections;
using Edument.CQRS;
using Keymaster.Events.LicenseEvents;
using Keymaster.Licensee;

namespace Keymaster.License
{
    //public class LicenseCommandHandlers :  
    //    IHandleCommand<CreateLicense, License>,
    //IHandleCommand<ActivateLicense, License> 
    //{
    //    public IEnumerable Handle(Func<Guid, License> al, ActivateLicense c)
    //    {
    //        yield return new LicenseActivated
    //        {
    //            ProductCode = c.ProductCode,
    //            RegistrationCode = c.RegistrationCode,
    //            Id = c.Id
    //        };
    //    }

    //    public IEnumerable Handle(Func<Guid, License> al, CreateLicense c)
    //    {
    //        yield return new LicenseCreated
    //        {
    //            ProductCode = c.ProductCode,
    //            LicenseeId = c.LicenseeId
    //        };
    //    }
    //}
}