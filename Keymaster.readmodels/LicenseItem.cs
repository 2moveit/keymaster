using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Keymaster.readmodels
{
    public class LicenseItem
    {
        public LicenseItem()
        {
         Activations = new List<ActivationItem>();   
        }
        public Guid ProductCode { get; set; }
        public IList<ActivationItem> Activations { get; set; }
    }
}
