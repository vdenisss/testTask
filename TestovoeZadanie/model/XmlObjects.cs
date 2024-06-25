using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestovoeZadanie.model.collection;

namespace TestovoeZadanie.model
{
    public class XmlObjects<T> : CollectionObject
    {
        public new ObservableCollection<T> Records { get; set; }

    }
}
