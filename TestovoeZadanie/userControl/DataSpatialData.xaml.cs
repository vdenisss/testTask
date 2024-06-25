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
    public partial class DataSpatialData : UserControl
    {
        DataService dataService;
        public DataSpatialData(SpatialData spatialData, string fileName)
        {
            InitializeComponent();
            dataService = new DataService(fileName);
            setDataForLandRecord(spatialData);
        }

        public void setDataForLandRecord(SpatialData spatialData)
        {
            textBlockSkId.Text = spatialData.skId;
            dataGridOrdinates.DataContext = new ObservableCollection<SpatialData>
            {
                spatialData
            };
        }

        public void ButtonClickSave(object sender, RoutedEventArgs e)
        {
            dataService.SaveObjectInFile(textBlockSkId.Text, "spatial_data", "entity_spatial/sk_id");
        }
    }
}
