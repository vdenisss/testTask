using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovoeZadanie.model
{
    public class BuildRecord
    {
        public string Id { get; set; }
        public string cadastralNumber { get; set; }
        public string type { get; set; }
        public string area { get; set; }
        public string purpose { get; set; }
        public Address address { get; set; }
        public string positionDescription { get; set; }
        public string cost { get; set; }
    }
}
