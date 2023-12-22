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

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для FilialsWindow.xaml
    /// </summary>
    public partial class AgentsWindow : Window
    {
        public ObservableCollection<object> person;
        public ObservableCollection<object> person1;
        public ObservableCollection<object> person2;
        public ObservableCollection<object> person3;
        XDocument doc;
        public AgentsWindow()
        {
            InitializeComponent();
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
            person = new ObservableCollection<object>(agents);

            AgentsData.ItemsSource = person;
        }
        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            NavWindow navWindow = new NavWindow();
            navWindow.Show();
            this.Close();
        }

        private void Button_ToAddAgents_Click(object sender, RoutedEventArgs e)
        {
            AddAgentWindow addAgentWindow = new AddAgentWindow();
            addAgentWindow.Show();
            this.Close();
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            AgentsEditindow editindow = new AgentsEditindow();
            editindow.Show();
            this.Close();
        }

        private void Button_1st_Click(object sender, RoutedEventArgs e)
        {
            doc = XDocument.Load("../../AgentsData.xml");
            var agents = (from x in doc.Element("agents").Elements("agent")
                          where x.Element("filial").Value == "Первый"
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
            person1 = new ObservableCollection<object>(agents);

            AgentsData.ItemsSource = person1;
        }

        private void Button_2nd_Click(object sender, RoutedEventArgs e)
        {
            doc = XDocument.Load("../../AgentsData.xml");
            var agents = (from x in doc.Element("agents").Elements("agent")
                          where x.Element("filial").Value == "Второй"
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
            person2 = new ObservableCollection<object>(agents);

            AgentsData.ItemsSource = person2;
        }

        private void Button_3rd_Click(object sender, RoutedEventArgs e)
        {
            doc = XDocument.Load("../../AgentsData.xml");
            var agents = (from x in doc.Element("agents").Elements("agent")
                          where x.Element("filial").Value == "Третий"
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
            person3 = new ObservableCollection<object>(agents);

            AgentsData.ItemsSource = person3;
        }

        private void Button_Reload_Click(object sender, RoutedEventArgs e)
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
            person = new ObservableCollection<object>(agents);

            AgentsData.ItemsSource = person;
        }
    }
}
