using System.Collections.Generic;

namespace Keymaster.readmodels
{
    public class LicenseCollection
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public List<LicenseItem> OwenedLicenses { get; set; }
    }
}