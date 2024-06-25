using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace TestovoeZadanie.userControl
{
    public partial class DataBuildRecord : UserControl
    {
        DataService dataService;
        public DataBuildRecord(BuildRecord buildRecord, string fileName)
        {
            InitializeComponent();
            dataService = new DataService(fileName);
            setDataForBuildRecord(buildRecord);
        }

        public void setDataForBuildRecord(BuildRecord buildRecord)
        {
            textBlockCudNumber.Text = buildRecord.cadastralNumber;
            textBlockType.Text = buildRecord.type;
            textBlockPurpose.Text = buildRecord.purpose;
            textBlockArea.Text = buildRecord.area;
            textBlockAddress.Text = buildRecord.address.readableAddress;
            textBlockOKATO.Text = buildRecord.address.okato;
            textBlockKLADR.Text = buildRecord.address.kladr;
            textBlockPostalCode.Text = buildRecord.address.postalCode;
            textBlockRegion.Text = buildRecord.address.region;
            textBlockDistrict.Text = buildRecord.address.district;
            textBlockLocality.Text = buildRecord.address.locality;
            textBlockStreet.Text = buildRecord.address.street;
            textBlockLevel1.Text = buildRecord.address.level1;
            textBlockOther.Text = buildRecord.address.other;
            textBlockPositionDescription.Text = buildRecord.positionDescription;
            textBlockCost.Text = buildRecord.cost;
        }

        public void ButtonClickSave(object sender, RoutedEventArgs e)
        {
            dataService.SaveObjectInFile(textBlockCudNumber.Text, "build_record", "object//cad_number");
        }
    }
}
