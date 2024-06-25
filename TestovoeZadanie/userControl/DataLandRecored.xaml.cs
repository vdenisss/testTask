using Microsoft.Win32;
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
using System.Xml.Linq;
using TestovoeZadanie.model;

namespace TestovoeZadanie.usercontrol
{
    public partial class DataLandRecored : UserControl
    {
        DataService dataService;
        public DataLandRecored(LandRecord landRecord, string fileName)
        {
            InitializeComponent();
            dataService = new DataService(fileName);
            setDataForLandRecord(landRecord);
        }

        public void setDataForLandRecord(LandRecord landRecord)
        {
            textBlockCudNumber.Text = landRecord.cadastralNumber;
            textBlockType.Text = landRecord.type;
            textBlockSubtype.Text = landRecord.subtype;
            textBlockByDocument.Text = landRecord.byDocument;
            textBlockLandUse.Text = landRecord.landUser;
            textBlockCategory.Text = landRecord.category;
            textBlockArea.Text = landRecord.area;
            textBlockInAccuracyArea.Text = landRecord.inaccuracyArea;
            textBlockAddress.Text = landRecord.address.readableAddress;
            textBlockOKATO.Text =  landRecord.address.okato;
            textBlockKLADR.Text = landRecord.address.kladr;
            textBlockPostalCode.Text = landRecord.address.postalCode;
            textBlockRegion.Text = landRecord.address.region;
            textBlockDistrict.Text = landRecord.address.district;
            textBlockLocality.Text = landRecord.address.locality;
            textBlockStreet.Text = landRecord.address.street;
            textBlockLevel1.Text = landRecord.address.level1;
            textBlockRelPosition.Text = landRecord.address.relPosition;
            textBlockSkId.Text = landRecord.address.contoursLocation.skId;
            dataGridOrdinates.DataContext = new ObservableCollection<SpatialData>
            {
                landRecord.address.contoursLocation
            };
            textBlockCost.Text = landRecord.cost;
        }

        public void ButtonClickSave(object sender, RoutedEventArgs e)
        {
            dataService.SaveObjectInFile(textBlockCudNumber.Text, "land_record", "object//cad_number");
        }
    }
}
