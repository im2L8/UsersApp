using System;
using System.Xml;
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
using System.Collections.ObjectModel;
using static UsersApp.FilialAddWindow;

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для AgentsSalaryWindow.xaml
    /// </summary>
    public partial class AgentsSalaryWindow : Window
    {
        public ObservableCollection<object> person;
        XDocument doc;
        public AgentsSalaryWindow()
        {
            InitializeComponent();
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            NavWindow navWindow = new NavWindow();
            navWindow.Show();
            this.Close();
        }

        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            doc = XDocument.Load("../../AgentsData.xml");
            var agents = (from x in doc.Element("agents").Elements("agent")
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
            int AgentsLength = agents.Count;
            doc = XDocument.Load("../../AgentsSalaryData.xml");
            var salaris = (from x in doc.Element("salaris").Elements("salary")
                          orderby x.Element("surname").Value
                          select new
                          {
                              Surname = x.Element("surname").Value,
                              Val = x.Element("value").Value,
                          }).ToList();
            person = new ObservableCollection<object>(salaris);

            AgentsData.ItemsSource = person;
            if (AgentsLength != salaris.Count)
            {
                for (int i = 0; i < agents.Count; i++)
                {
                    doc.Element("salaris").Add(new XElement("salary",
                                  new XElement("surname", agents[i].Surname),
                                  new XElement("value", 0)));
                    doc.Save("../../AgentsSalaryData.xml");
                }
            }
        }
    }
}
