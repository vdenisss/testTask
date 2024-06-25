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
    public class DataServiceBuildRecord : DataService
    {
        public DataServiceBuildRecord(string fileName) : base(fileName) { }
        public ObservableCollection<BuildRecord> getRecords()
        {
            List<BuildRecord> buildRecords = xmlDocument.Descendants("build_record")
                .Select(x => new BuildRecord
                {
                    Id = checkIsNull(x, "object//cad_number"),
                    cadastralNumber = checkIsNull(x, "object//cad_number"),
                    type = checkIsNull(x, "object//type/value"),
                    purpose = checkIsNull(x, "params/purpose/value"),
                    area = checkIsNull(x, "params/area"),
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
                        other = checkIsNull(x, "address_location//detailed_level/other"),
                        readableAddress = checkIsNull(x, "address_location/address/readable_address"),
                    },
                    positionDescription = checkIsNull(x, "address_location//position_description"),
                    cost = checkIsNull(x, "cost/value")
                })
                .Concat(xmlDocument.Descendants("construction_record")
                    .Select(x => new BuildRecord
                    {
                        Id = checkIsNull(x, "object//cad_number"),
                        cadastralNumber = checkIsNull(x, "object//cad_number"),
                        type = checkIsNull(x, "object//type/value"),
                        purpose = checkIsNull(x, "params/purpose"),
                        area = checkIsNull(x, "params/area"),
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
                            other = checkIsNull(x, "address_location//detailed_level/other"),
                            readableAddress = checkIsNull(x, "address_location/address/readable_address"),
                        },
                        positionDescription = checkIsNull(x, "address_location//position_description"),
                        cost = checkIsNull(x, "cost/value")
                    })
                    .ToList())
                .ToList();

            return new ObservableCollection<BuildRecord>(buildRecords);
        }
    }
}
