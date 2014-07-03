using System;
using System.Collections.Generic;
using Edument.CQRS;
using Keymaster.Events.LicenseeEvents;
using Keymaster.Events.LicenseEvents;

namespace Keymaster.License
{
    public class License : Aggregate,
        IApplyEvent<LicenseCreated>,
    IApplyEvent<LicenseActivated>
    {

        public Guid ProductCode { get; set; }
        public Guid LicenseeId { get; set; }

        public List<Activation>Activations = new List<Activation>(); 
        public void Apply(LicenseActivated e)
        {
            Activations.Add(new Activation {RegistrationCode = e.RegistrationCode, ActivationDate = e.ActivationDate});
        }

        public void Apply(LicenseCreated e)
        {
            ProductCode = e.ProductCode;
            LicenseeId = e.LicenseeId;
        }
    }
}