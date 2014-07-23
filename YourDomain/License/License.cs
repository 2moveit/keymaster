using System;
using System.Collections.Generic;

namespace Keymaster.License
{
    public class License
    {
        public List<Activation> Activations = new List<Activation>();
        public Guid ProductCode { get; set; }
        public Guid Id { get; set; }
    }
}