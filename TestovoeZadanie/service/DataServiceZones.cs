using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestovoeZadanie.model;

namespace TestovoeZadanie.service
{
    public class DataServiceZones : DataService
    {
        public DataServiceZones(string fileName) : base(fileName){}

        public ObservableCollection<Zones> getZones()
        {
            List<Zones> zones = xmlDocument.Descendants("zones_and_territories_record")
                .Select(x => new Zones
                {
                    Id = checkIsNull(x, "b_object_zones_and_territories/b_object/reg_numb_border"),
                    registrationDate = checkIsNull(x, "record_info/registration_date"),
                    regNumberBorder = checkIsNull(x, "b_object_zones_and_territories//reg_numb_border"),
                    typeBoundary = checkIsNull(x, "b_object_zones_and_territories//type_boundary/value"),
                    typeZone = checkIsNull(x, "b_object_zones_and_territories/type_zone/value"),
                    number = checkIsNull(x, "b_object_zones_and_territories/number"),
                    contoursLocation = new SpatialData
                    {
                        skId = checkIsNull(x, "b_contours_location//entity_spatial/sk_id"),
                        ordinates = new ObservableCollection<Ordinate>(x.Descendants("ordinate")
                                .Select(y => new Ordinate
                                {
                                    x = checkIsNull(y, "x"),
                                    y = checkIsNull(y, "y"),
                                    ordNumber = checkIsNull(y, "ord_nmb"),
                                    numberGeopoint = checkIsNull(y, "num_geopoint"),
                                    geopointOpred = checkIsNull(y, "geopoint_opred/value"),
                                    deltaGeopoint = checkIsNull(y, "delta_geopoint")
                                })
                                .ToList())
                    }
                })
                .ToList();
            return new ObservableCollection<Zones>(zones);
        }
    }
}
