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
    /// Логика взаимодействия для MyContractsWindow.xaml
    /// </summary>
    public partial class MyContractsWindow : Window
    {
        public ObservableCollection<object> person;
        public ObservableCollection<object> personAuto;
        public ObservableCollection<object> personPrice;
        XDocument doc;
        public MyContractsWindow()
        {
            InitializeComponent();
            doc = XDocument.Load("../../ContractsData.xml");
            var contracts = (from x in doc.Element("contracts").Elements("contract")
                           orderby x.Element("number").Value
                           select new
                           {
                               Number = x.Element("number").Value,
                               Date = x.Element("date").Value,
                               Price = x.Element("price").Value,
                               Type = x.Element("type").Value,
                               Filial = x.Element("filial").Value,
                               FinalPrice = x.Element("finalprice").Value,
                               Agent = x.Element("agent").Value,
                           }).ToList();
            person = new ObservableCollection<object>(contracts);

            ContractsData.ItemsSource = person;
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            NavWindow navWindow = new NavWindow();
            navWindow.Show();
            this.Close();
        }

        private void Button_ToAddContract_Click(object sender, RoutedEventArgs e)
        {
            ContractWindow contractWindow = new ContractWindow();
            contractWindow.Show();
            this.Close();
        }

        private void Button_Reload_Click(object sender, RoutedEventArgs e)
        {
            doc = XDocument.Load("../../ContractsData.xml");
            var contracts = (from x in doc.Element("contracts").Elements("contract")
                             orderby x.Element("number").Value
                             select new
                             {
                                 Number = x.Element("number").Value,
                                 Date = x.Element("date").Value,
                                 Price = x.Element("price").Value,
                                 Type = x.Element("type").Value,
                                 Filial = x.Element("filial").Value,
                                 FinalPrice = x.Element("finalprice").Value,
                                 Agent = x.Element("agent").Value,
                             }).ToList();
            person = new ObservableCollection<object>(contracts);

            ContractsData.ItemsSource = person;
        }

        private void Button_AutoFilter_Click(object sender, RoutedEventArgs e)
        {
            doc = XDocument.Load("../../ContractsData.xml");
            var contracts = (from x in doc.Element("contracts").Elements("contract")
                             where x.Element("type").Value == "Автострахование"
                             orderby x.Element("number").Value
                             select new
                             {
                                 Number = x.Element("number").Value,
                                 Date = x.Element("date").Value,
                                 Price = x.Element("price").Value,
                                 Type = x.Element("type").Value,
                                 Filial = x.Element("filial").Value,
                                 FinalPrice = x.Element("finalprice").Value,
                                 Agent = x.Element("agent").Value,
                             }).ToList();
            personAuto = new ObservableCollection<object>(contracts);

            ContractsData.ItemsSource = personAuto;
        }

        private void Button_3k_Click(object sender, RoutedEventArgs e)
        {
            doc = XDocument.Load("../../ContractsData.xml");
            var contracts = (from x in doc.Element("contracts").Elements("contract")
                             where int.Parse(x.Element("price").Value) >= 3000
                             orderby x.Element("number").Value
                             select new
                             {
                                 Number = x.Element("number").Value,
                                 Date = x.Element("date").Value,
                                 Price = x.Element("price").Value,
                                 Type = x.Element("type").Value,
                                 Filial = x.Element("filial").Value,
                                 FinalPrice = x.Element("finalprice").Value,
                                 Agent = x.Element("agent").Value,
                             }).ToList();
            personPrice = new ObservableCollection<object>(contracts);

            ContractsData.ItemsSource = personPrice;
        }
    }
}
