using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;
using TestovoeZadanie.model;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

namespace TestovoeZadanie
{
    public class DataService
    {
        public XDocument xmlDocument;

        public DataService(string fileName)
        {
            this.xmlDocument = XDocument.Load(fileName);
        }

        public XElement getXElementById(string id, string typeElement, string pathId)
        {
            XElement xElement = xmlDocument.Descendants(typeElement)
                .Where(x => x.XPathSelectElement(pathId).Value == id)
                .FirstOrDefault();
            return xElement;
        }

        public void SaveObjectInFile(string id, string type, string pathId)
        {
            XDocument document = new XDocument(getXElementById(id, type, pathId));
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Xml (*.xml)|*.xml";
            saveFileDialog.FileName = $"{id.Replace(':', '_')}.xml";
            if (saveFileDialog.ShowDialog().Value)
            {
                document.Save(saveFileDialog.FileName);
            }
        }

        public string checkIsNull(XElement xElement, string xPath)
        {
            try
            {
                return xElement.XPathSelectElement(xPath).Value;
            }
            catch
            {
                return "-";
            }
        }
    }
}
