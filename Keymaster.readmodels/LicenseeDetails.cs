using System;
using System.Collections.Generic;
using System.Text;

namespace Keymaster.readmodels
{
    public class LicenseeDetails
    {
        public Guid LicenseeId { get; set; }
        public string LicenseeName { get; set; }
        public List<LicenseItem> OwenedLicenses { get; set; }
        public List<ContactItem> Contacts { get; set; }


        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(LicenseeId.ToString());
            sb.AppendLine(LicenseeName);
            sb.AppendLine("---");
            foreach (ContactItem contact in Contacts)
            {
                sb.AppendLine(string.Format("Name: {0}", contact.Name));
                sb.AppendLine(string.Format("Email: {0}", contact.Email));
                sb.AppendLine("---");
            }
            sb.AppendLine("___");
            foreach (LicenseItem owenedLicense in OwenedLicenses)
            {
                sb.AppendLine(string.Format("ProductCode: {0}", owenedLicense.ProductCode));
                foreach (ActivationItem activation in owenedLicense.Activations)
                {
                    sb.AppendLine(string.Format("Activation date: {0}", activation.ActivationDate.ToShortDateString()));
                    sb.AppendLine(string.Format("Registration code: {0}", activation.RegistrationCode));
                    sb.AppendLine("---");
                }
                sb.AppendLine("___");
            }
            sb.AppendLine("###");
            return sb.ToString();
        }
    }
}