using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestovoeZadanie.model;

namespace TestovoeZadanie.userControl
{
    public partial class DataZones : UserControl
    {
        DataService dataService;
        public DataZones(Zones zones, string fileName)
        {
            InitializeComponent();
            dataService = new DataService(fileName);
            SetDataForZones(zones);
        }
        public void SetDataForZones(Zones zones)
        {
            textBlockRegDate.Text = zones.registrationDate;
            textBlockRegNumber.Text = zones.regNumberBorder;
            textBlockTypeBoundary.Text = zones.typeBoundary;
            textBlockTypeZone.Text = zones.typeZone;
            textBlockNumber.Text = zones.number;
            dataGridOrdinates.DataContext = new ObservableCollection<SpatialData>
            {
                zones.contoursLocation
            };
        }

        public void ButtonClickSave(object sender, RoutedEventArgs e)
        {
            dataService.SaveObjectInFile(textBlockRegNumber.Text, "zones_and_territories_record", "b_object_zones_and_territories/b_object/reg_numb_border");
        }
    }
}
