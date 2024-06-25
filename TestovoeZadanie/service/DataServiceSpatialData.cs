using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestovoeZadanie.model;

namespace TestovoeZadanie.service
{
    public class DataServiceSpatialData : DataService
    {
        public DataServiceSpatialData(string fileName) : base(fileName) {}

        public ObservableCollection<SpatialData> GetSpatialDatas()
        {
            List<SpatialData> spatialDatas = xmlDocument.Descendants("spatial_data")
                .Select(x => new SpatialData
                {
                    Id = checkIsNull(x, "entity_spatial/sk_id"),
                    skId = checkIsNull(x, "entity_spatial/sk_id"),
                    ordinates = new ObservableCollection<Ordinate>(x.Descendants("ordinate")
                                .Select(y => new Ordinate
                                {
                                    x = checkIsNull(y, "x"),
                                    y = checkIsNull(y, "y"),
                                    ordNumber = checkIsNull(y, "ord_nmb"),
                                    numberGeopoint = checkIsNull(y, "num_geopoint"),
                                    deltaGeopoint = checkIsNull(y, "delta_geopoint")

                                })
                                .ToList())
                })
                .ToList();
            return new ObservableCollection<SpatialData>(spatialDatas);
        }
    }
}
