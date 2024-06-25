using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using TestovoeZadanie.model;
using TestovoeZadanie.model.collection;
using TestovoeZadanie.service;
using TestovoeZadanie.usercontrol;
using TestovoeZadanie.userControl;
using MessageBox = System.Windows.Forms.MessageBox;

namespace TestovoeZadanie
{
    public partial class MainWindow : Window
    {
        DataServiceLandRecord dataServiceLandRecords;
        DataServiceBuildRecord dataServiceBuildRecord;
        DataServiceSpatialData dataServiceSpatialData;
        DataServiceBounds dataServiceBounds;
        DataServiceZones dataServiceZones;

        public string fileName { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void getDataTree()
        {
            dataServiceLandRecords = new DataServiceLandRecord(fileName);
            dataServiceBuildRecord = new DataServiceBuildRecord(fileName);
            dataServiceSpatialData = new DataServiceSpatialData(fileName);
            dataServiceBounds = new DataServiceBounds(fileName);
            dataServiceZones = new DataServiceZones(fileName);
            treeTest.ItemsSource = new ObservableCollection<CollectionObject> {
                new XmlObjects<LandRecord>
                {
                    Name = "Parcels",
                    Records = dataServiceLandRecords.getRecords(),
                },
                new XmlObjects<BuildRecord>
                {
                    Name = "ObjectRealty",
                    Records = dataServiceBuildRecord.getRecords()
                },
                new XmlObjects<SpatialData>
                {
                    Name = "SpatialData",
                    Records = dataServiceSpatialData.GetSpatialDatas()
                },
                new XmlObjects<Bounds>
                {
                    Name = "Bounds",
                    Records = dataServiceBounds.GetBounds()
                },
                new XmlObjects<Zones>
                {
                    Name = "Zones",
                    Records = dataServiceZones.getZones()
                }
            };
        }

        private void tree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Type type = e.NewValue.GetType();
            stackPanelData.Children.Clear();
            switch (type.Name)
            {
                case "XmlObjects`1":
                    string genericType = type.GetGenericArguments().Single().Name;
                    ListBoxRecords listBoxRecords = new ListBoxRecords();
                    listBoxRecords.listBoxObject.SelectionChanged += getDataForRecord_Selected;
                    if (genericType.Equals("LandRecord"))
                    {
                        listBoxRecords.listBoxObject.ItemsSource = ((XmlObjects<LandRecord>)e.NewValue).Records;
                    }
                    else if(genericType.Equals("BuildRecord"))
                    {
                        listBoxRecords.listBoxObject.ItemsSource = ((XmlObjects<BuildRecord>)e.NewValue).Records;
                    }
                    else if (genericType.Equals("SpatialData"))
                    {
                        listBoxRecords.listBoxObject.ItemsSource = ((XmlObjects<SpatialData>)e.NewValue).Records;
                    }
                    else if (genericType.Equals("Bounds"))
                    {
                        listBoxRecords.listBoxObject.ItemsSource = ((XmlObjects<Bounds>)e.NewValue).Records;
                    }
                    else if (genericType.Equals("Zones"))
                    {
                        listBoxRecords.listBoxObject.ItemsSource = ((XmlObjects<Zones>)e.NewValue).Records;
                    }
                    stackPanelData.Children.Add(listBoxRecords);
                    break;
                case "LandRecord":
                    DataLandRecored viewLandRecord = new DataLandRecored((LandRecord)e.NewValue, fileName);
                    stackPanelData.Children.Add(viewLandRecord);
                    break;
                case "BuildRecord":
                    DataBuildRecord viewBuildRecord = new DataBuildRecord((BuildRecord)e.NewValue, fileName);
                    stackPanelData.Children.Add(viewBuildRecord);
                    break;
                case "SpatialData":
                    DataSpatialData dataSpatialData = new DataSpatialData((SpatialData)e.NewValue, fileName);
                    stackPanelData.Children.Add(dataSpatialData);
                    break;
                case "Bounds":
                    DataBounds dataBounds = new DataBounds((Bounds)e.NewValue, fileName);
                    stackPanelData.Children.Add(dataBounds);
                    break;
                case "Zones":
                    DataZones dataZones = new DataZones((Zones)e.NewValue, fileName);
                    stackPanelData.Children.Add(dataZones);
                    break;

            }           
        }

        public void getDataForRecord_Selected(object sender, SelectionChangedEventArgs e)
        {
            stackPanelData.Children.Clear();
            switch (e.AddedItems[0].GetType().Name)
            {
                case "LandRecord":
                    DataLandRecored dataLandRecord = new DataLandRecored((LandRecord)e.AddedItems[0], fileName);
                    stackPanelData.Children.Add(dataLandRecord);
                    break;
                case "BuildRecord":
                    DataBuildRecord dataBuildRecord = new DataBuildRecord((BuildRecord)e.AddedItems[0], fileName);
                    stackPanelData.Children.Add(dataBuildRecord);
                    break;
                case "SpatialData":
                    DataSpatialData dataSpatialData = new DataSpatialData((SpatialData)e.AddedItems[0], fileName);
                    stackPanelData.Children.Add(dataSpatialData);
                    break;
                case "Bounds":
                    DataBounds dataBouns = new DataBounds((Bounds)e.AddedItems[0], fileName);
                    stackPanelData.Children.Add(dataBouns);
                    break;
                case "Zones":
                    DataZones dataZones = new DataZones((Zones)e.AddedItems[0], fileName);
                    stackPanelData.Children.Add(dataZones);
                    break;
            }
        }
        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "XML Files (*.xml)|*.xml";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileName = dialog.FileName;
                getDataTree();
            }
        }

        private void Faq_Click(object sender, RoutedEventArgs e)
        {
            Faq faq = new Faq();
            stackPanelData.Children.Clear();
            stackPanelData.Children.Add(faq);
        }
    }
}
