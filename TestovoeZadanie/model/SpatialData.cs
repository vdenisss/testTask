using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovoeZadanie.model
{
    public class SpatialData
    {
        public string Id { get; set; }
        public string skId { get; set; }
        public ObservableCollection<Ordinate> ordinates { get; set; }
    }
}
