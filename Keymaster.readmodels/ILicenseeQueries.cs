using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keymaster.readmodels
{
    public interface ILicenseeQueries
    {
        IList<string> Licensees();
        LicenseeDetails DetailsForLicensee(string licenseeName);
        IList<string> ProvidedProductCodes(Guid licenseeId);
    }
}
