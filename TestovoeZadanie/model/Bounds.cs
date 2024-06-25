using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovoeZadanie.model
{
    public class Bounds
    {
        public string Id { get; set; }
        public string registrationDate { get; set; }
        public string regNumberBorder { get; set; }
        public string typeBoundary { get; set; }
        public SpatialData contoursLocation { get; set; }
    }
}
