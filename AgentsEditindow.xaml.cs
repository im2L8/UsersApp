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
using static UsersApp.FilialAddWindow;

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для AgentsEditindow.xaml
    /// </summary>
    public partial class AgentsEditindow : Window
    {
        XDocument AgentsBase;
        public AgentsEditindow()
        {
            InitializeComponent();

            AgentsBase = XDocument.Load("../../AgentsData.xml");
            var agents = (from x in AgentsBase.Element("agents").Elements("agent")
                          orderby x.Element("surname").Value
                          select new
                          {
                              Name = x.Element("name").Value,
                              Surname = x.Element("surname").Value,
                              SecondName = x.Element("secondname").Value,
                              Phone = x.Element("phone").Value,
                              Adress = x.Element("adress").Value,
                              Filial = x.Element("filial").Value,
                          }).ToList();

            SurnameChoose.Items.Clear();

            for (int i = 0; i < agents.Count; i++)
            {
                SurnameChoose.Items.Add(agents[i].Surname);
            }
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            AgentsWindow agentsWindow = new AgentsWindow();
            agentsWindow.Show();
            this.Close();
        }

        private void Button_Change_Click(object sender, RoutedEventArgs e)
        {
            string setting = Setting.Text;
            string surname = SurnameChoose.Text;
            string value = Value.Text;

            XmlDocument xml = new XmlDocument();
            xml.Load("../../AgentsData.xml");
            AgentsBase = XDocument.Load("../../AgentsData.xml");
            var agents = (from x in AgentsBase.Element("agents").Elements("agent")
                          orderby x.Element("surname").Value
                          select new
                          {
                              Name = x.Element("name").Value,
                              Surname = x.Element("surname").Value,
                              SecondName = x.Element("secondname").Value,
                              Phone = x.Element("phone").Value,
                              Adress = x.Element("adress").Value,
                              Filial = x.Element("filial").Value,
                          }).ToList();

            for (int j = 0; j < agents.Count; j++)
            {
                if ((agents[j].Surname == surname) && (setting == "Филиал"))
                {
                    xml.GetElementsByTagName("filial")[j].FirstChild.Value = value;
                    xml.Save("../../AgentsData.xml");
                }
                if ((agents[j].Surname == surname) && (setting == "Адрес"))
                {
                    xml.GetElementsByTagName("adress")[j].FirstChild.Value = value;
                    xml.Save("../../AgentsData.xml");
                }
                if ((agents[j].Surname == surname) && (setting == "Телефон"))
                {
                    xml.GetElementsByTagName("phone")[j].FirstChild.Value = value;
                    xml.Save("../../AgentsData.xml");
                }
            }
        }
    }
}
