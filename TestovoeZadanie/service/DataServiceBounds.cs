using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestovoeZadanie.model;

namespace TestovoeZadanie.service
{
    public class DataServiceBounds : DataService
    {
        public DataServiceBounds(string fileName) : base(fileName) {}

        public ObservableCollection<Bounds> GetBounds()
        {
            List<Bounds> bounds = xmlDocument.Descendants("municipal_boundary_record")
                .Select(x => new Bounds
                {
                    Id = checkIsNull(x, "b_object_municipal_boundary//reg_numb_border"),
                    registrationDate = checkIsNull(x, "record_info/registration_date"),
                    regNumberBorder = checkIsNull(x, "b_object_municipal_boundary//reg_numb_border"),
                    typeBoundary = checkIsNull(x, "b_object_municipal_boundary//type_boundary/value"),
                    contoursLocation = new SpatialData
                    {
                        skId = checkIsNull(x, "b_contours_location//entity_spatial/sk_id"),
                        ordinates = new ObservableCollection<Ordinate>(x.Descendants("ordinate")
                                .Select(y => new Ordinate
                                {
                                    x = checkIsNull(y, "x"),
                                    y = checkIsNull(y, "y"),
                                    ordNumber = checkIsNull(y, "ord_nmb"),
                                })
                                .ToList())
                    }
                })
                .ToList();
            return new ObservableCollection<Bounds>(bounds);
        }
    }
}
