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

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(LicenseeId.ToString());
            sb.AppendLine(LicenseeName);
            sb.AppendLine("---");
            foreach (LicenseItem owenedLicense in OwenedLicenses)
            {
                sb.AppendLine("TODO: ProductCode");
            }
            return sb.ToString();
        }
    }
}