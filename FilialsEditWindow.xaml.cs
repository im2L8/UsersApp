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
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для FilialsEditWindow.xaml
    /// </summary>
    public partial class FilialsEditWindow : Window
    {
        XDocument FilialsBase;
        public FilialsEditWindow()
        {
            InitializeComponent();

            FilialsBase = XDocument.Load("../../FilialsData.xml");
            var filials = (from x in FilialsBase.Element("filials").Elements("filial")
                           orderby x.Element("code").Value
                           select new
                           {
                               Code = x.Element("code").Value,
                               Name = x.Element("name").Value,
                               Adress = x.Element("adress").Value,
                               Phone = x.Element("phone").Value,
                           }).ToList();

            FilialsChoose.Items.Clear();

            for (int i = 0; i < filials.Count; i++)
            {
                FilialsChoose.Items.Add(filials[i].Name);
            }
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            FilialsWindow filialsWindow = new FilialsWindow();
            filialsWindow.Show();
            this.Close();
        }

        private void Button_Change_Click(object sender, RoutedEventArgs e)
        {
            string setting = Setting.Text;
            string filial = FilialsChoose.Text;
            string value = Value.Text;

            XmlDocument xml = new XmlDocument();
            xml.Load("../../FilialsData.xml");
            FilialsBase = XDocument.Load("../../FilialsData.xml"); /// Подключение БД
            var filials = (from x in FilialsBase.Element("filials").Elements("filial")
                           select new
                           {
                               Code = x.Element("code").Value,
                               Name = x.Element("name").Value,
                               Adress = x.Element("adress").Value,
                               Phone = x.Element("phone").Value,
                           }).ToList();

            for (int j = 0; j < filials.Count; j++)
            {
                if ((filials[j].Name == filial) && (setting == "Имя"))
                {
                    xml.GetElementsByTagName("name")[j].FirstChild.Value = value;
                    xml.Save("../../FilialsData.xml");
                }
                if ((filials[j].Name == filial) && (setting == "Адрес"))
                {
                    xml.GetElementsByTagName("adress")[j].FirstChild.Value = value;
                    xml.Save("../../FilialsData.xml");
                }
                if ((filials[j].Name == filial) && (setting == "Телефон"))
                {
                    xml.GetElementsByTagName("phone")[j].FirstChild.Value = value;
                    xml.Save("../../FilialsData.xml");
                }
            }
        }
    }
}
