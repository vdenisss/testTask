using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovoeZadanie.model
{
    public class Address
    {
        public string okato { get; set; }
        public string kladr { get; set; }
        public string postalCode { get; set; }
        public string region { get; set; }
        public string district { get; set; }
        public string locality { get; set; }
        public string street { get; set; }
        public string level1 { get; set; }
        public string other { get; set; }
        public string readableAddress { get; set; }
        public string relPosition { get; set; }
        public SpatialData contoursLocation { get; set; }
    }
}
