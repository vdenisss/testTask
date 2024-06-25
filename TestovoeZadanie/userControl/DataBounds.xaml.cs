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
    public partial class DataBounds : UserControl
    {
        DataService dataService;
        public DataBounds(Bounds bounds, string fileName)
        {
            InitializeComponent();
            dataService = new DataService(fileName);
            setDataForBounds(bounds);
        }

        public void setDataForBounds(Bounds bounds)
        {
            textBlockRegDate.Text = bounds.registrationDate;
            textBlockRegNumber.Text = bounds.regNumberBorder;
            textBlockTypeBoundary.Text = bounds.typeBoundary;
            dataGridOrdinates.DataContext = new ObservableCollection<SpatialData>
            {
                bounds.contoursLocation
            };
        }

        public void ButtonClickSave(object sender, RoutedEventArgs e)
        {
            dataService.SaveObjectInFile(textBlockRegNumber.Text, "municipal_boundary_record", "b_object_municipal_boundary//reg_numb_border");
        }
    }
}
