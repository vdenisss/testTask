using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovoeZadanie.model
{
    public class LandRecord
    {
        public string Id { get; set; }
        public string cadastralNumber { get; set; }
        public string type { get; set; }
        public string subtype { get; set; }
        public string category { get; set; }
        public string byDocument { get; set; }
        public string landUser { get; set; }
        public string area { get; set; }
        public string inaccuracyArea { get; set; }
        public Address address { get; set; }
        public string cost { get; set; }
    }

}
