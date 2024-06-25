using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using TestovoeZadanie.model;

namespace TestovoeZadanie.service
{
    public class DataServiceLandRecord : DataService
    {
        public DataServiceLandRecord(string fileName) : base(fileName) { }

        public ObservableCollection<LandRecord> getRecords()
        {
            List<LandRecord> records = xmlDocument.Descendants("land_record")
                .Select(x => new LandRecord
                {
                    Id = checkIsNull(x, "object//cad_number"),
                    cadastralNumber = checkIsNull(x, "object//cad_number"),
                    type = checkIsNull(x, "object//type/value"),
                    subtype = checkIsNull(x, "object/subtype/value"),
                    category = checkIsNull(x, "params/category/type/value"),
                    byDocument = checkIsNull(x, "params//permitted_use_established/by_document"),
                    landUser = checkIsNull(x, "params//land_use/value"),
                    area = checkIsNull(x, "params/area/value"),
                    inaccuracyArea = checkIsNull(x,"params/area/inaccuracy"),
                    address = new Address
                    {
                        okato = checkIsNull(x, "address_location//level_settlement/okato"),
                        kladr = checkIsNull(x, "address_location//level_settlement/kladr"),
                        postalCode = checkIsNull(x, "address_location//level_settlement/postal_code"),
                        region = checkIsNull(x, "address_location//level_settlement/region/value"),
                        district = checkIsNull(x, "address_location//level_settlement/district/name_district"),
                        locality = checkIsNull(x, "address_location//level_settlement/locality/name_locality"),
                        street = checkIsNull(x, "address_location//detailed_level/street/name_street"),
                        level1 = checkIsNull(x, "address_location//detailed_level/level1/name_level1"),
                        readableAddress = checkIsNull(x, "address_location/address/readable_address"),
                        relPosition = checkIsNull(x, "address_location/rel_position/in_boundaries_mark"),
                        contoursLocation = new SpatialData
                        {
                            skId = checkIsNull(x, "contours_location//entity_spatial/sk_id"),
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
                        }
                    },
                    cost = checkIsNull(x, "cost/value")
                })
                .ToList();
            return new ObservableCollection<LandRecord>(records);
        }
    }
}
