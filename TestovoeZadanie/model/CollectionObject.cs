using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovoeZadanie.model.collection
{
    public class CollectionObject
    {
        public string Name { get; set; }
        public ObservableCollection<object> Records { get; set; }
    }
}
