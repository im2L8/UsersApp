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
using System.Xml.XPath;

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для ContractWindow.xaml
    /// </summary>
    public partial class ContractWindow : Window
    {
        XDocument doc;
        public ContractWindow()
        {
            InitializeComponent();
            var Date = DateTime.Now.ToString("d/M/yyyy");
            ContractDate.Text = Date;
            
            doc = XDocument.Load("../../FilialsData.xml");
            var filials = (from x in doc.Element("filials").Elements("filial")
                           orderby x.Element("code").Value
                           select new
                           {
                               Code = x.Element("code").Value,
                               Name = x.Element("name").Value,
                               Adress = x.Element("adress").Value,
                               Phone = x.Element("phone").Value,
                           }).ToList();
            for (int i = 0; i < filials.Count; i++)
            {
                FilialContract.Items.Add(filials[i].Name);
            }

            doc = XDocument.Load("../../ContractsData.xml");
            var contracts = (from x in doc.Element("contracts").Elements("contract")
                             orderby x.Element("number").Value
                             select new
                             {
                                 Number = x.Element("number").Value,
                                 Price = x.Element("price").Value,
                                 Date = x.Element("date").Value,
                                 Type = x.Element("type").Value,
                                 Filial = x.Element("filial").Value,
                                 FinalPrice = x.Element("finalprice").Value,
                                 Agent = x.Element("agent").Value,
                             }).ToList();
            var lastItem = contracts.Count + 1;
            ContractNumField.Text = lastItem.ToString();
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            NavWindow navWindow = new NavWindow();
            navWindow.Show();
            this.Close();
        }

        private void Button_ContractDone_Click(object sender, RoutedEventArgs e)
        {
            string number = ContractNumField.Text.Trim();
            string price = ContractPrice.Text.Trim();
            string date = ContractDate.Text.Trim();
            string type = TypeContract.Text.Trim();
            string filial = FilialContract.Text.Trim();
            string finalprice = FinalPrice.Text.Trim();
            string agent = AgentContract.Text.Trim();

            if (ContractPrice.Background == Brushes.Transparent)
            {
                doc.Element("contracts").Add(new XElement("contract",
                                  new XElement("number", number),
                                  new XElement("price", price),
                                  new XElement("date", date),
                                  new XElement("type", type),
                                  new XElement("filial", filial),
                                  new XElement("agent", agent),
                                  new XElement("finalprice", finalprice)));
                doc.Save("../../ContractsData.xml");
                MessageBox.Show("Договор заключен!");

                XmlDocument xml = new XmlDocument();
                xml.Load("../../AgentsSalaryData.xml");
                doc = XDocument.Load("../../AgentsSalaryData.xml");
                var salaris = (from x in doc.Element("salaris").Elements("salary")
                               orderby x.Element("surname").Value
                               select new
                               {
                                   Surname = x.Element("surname").Value,
                                   Val = x.Element("value").Value,
                               }).ToList();
                for (int i = 0; i < salaris.Count; i++)
                {
                    if (salaris[i].Surname == agent)
                    {
                        xml.GetElementsByTagName("value")[i].FirstChild.Value = (int.Parse(finalprice) * 0.2 + int.Parse(xml.GetElementsByTagName("value")[i].FirstChild.Value)).ToString();
                        xml.Save("../../AgentsSalaryData.xml");
                    }
                }
                
                

                NavWindow navWindow = new NavWindow();
                navWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Проверьте данные!");
            }
        }

        private void TypeFilial_SelectionChanged(object sender, EventArgs e)
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
            for (int i = 0; i < agents.Count; i++)
            {
                if (agents[i].Filial == FilialContract.Text)
                {
                    AgentContract.Items.Clear();
                    AgentContract.Items.Add(agents[i].Surname);
                }
            }
            doc = XDocument.Load("../../ContractsData.xml");
            var contracts = (from x in doc.Element("contracts").Elements("contract")
                             orderby x.Element("number").Value
                             select new
                             {
                                 Number = x.Element("number").Value,
                                 Price = x.Element("price").Value,
                                 Date = x.Element("date").Value,
                                 Type = x.Element("type").Value,
                                 Filial = x.Element("filial").Value,
                                 FinalPrice = x.Element("finalprice").Value,
                                 Agent = x.Element("agent").Value,
                             }).ToList();
        }

        private void TypeContract_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var finalPrice = 0;
            var price = ContractPrice.Text;
            int getprice;
            bool Check = int.TryParse(price, out getprice);
            if (Check)
            {
                if (TypeContract.SelectedIndex == 0)
                {
                    TarifPercent.Text = "Тарифная ставка 5%";
                    TarifPercent.Visibility = Visibility.Visible;
                    finalPrice = getprice + (getprice * 5 / 100);
                    FinalPrice.Text = finalPrice.ToString();
                    ContractPrice.Background = Brushes.Transparent;
                }
                else if (TypeContract.SelectedIndex == 1)
                {
                    TarifPercent.Text = "Тарифная ставка 3%";
                    TarifPercent.Visibility = Visibility.Visible;
                    finalPrice = getprice + (getprice * 3 / 100);
                    FinalPrice.Text = finalPrice.ToString();
                    ContractPrice.Background = Brushes.Transparent;
                }
                else if (TypeContract.SelectedIndex == 2)
                {
                    TarifPercent.Text = "Тарифная ставка 10%";
                    TarifPercent.Visibility = Visibility.Visible;
                    finalPrice = getprice + (getprice * 10 / 100);
                    FinalPrice.Text = finalPrice.ToString();
                    ContractPrice.Background = Brushes.Transparent;
                }
                else if (TypeContract.SelectedIndex == 3)
                {
                    TarifPercent.Text = "Тарифная ставка 8%";
                    TarifPercent.Visibility = Visibility.Visible;
                    finalPrice = getprice + (getprice * 8 / 100);
                    FinalPrice.Text = finalPrice.ToString();
                    ContractPrice.Background = Brushes.Transparent;
                }
                else if (TypeContract.SelectedIndex == 4)
                {
                    TarifPercent.Text = "Тарифная ставка 12%";
                    TarifPercent.Visibility = Visibility.Visible;
                    finalPrice = getprice + (getprice * 12 / 100);
                    FinalPrice.Text = finalPrice.ToString();
                    ContractPrice.Background = Brushes.Transparent;
                }
                else if (TypeContract.SelectedIndex == 5)
                {
                    TarifPercent.Text = "Тарифная ставка 1%";
                    TarifPercent.Visibility = Visibility.Visible;
                    finalPrice = getprice + (getprice * 1 / 100);
                    FinalPrice.Text = finalPrice.ToString();
                    ContractPrice.Background = Brushes.Transparent;
                }
            }
            else
            {
                ContractPrice.Background = Brushes.Red;
            }
        }

        private void ContractPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            var finalPrice = 0;
            var price = ContractPrice.Text;
            int getprice;
            bool Check = int.TryParse(price, out getprice);
            if (Check)
            {
                if (TypeContract.SelectedIndex == 0)
                {
                    finalPrice = getprice + (getprice * 5 / 100);
                    FinalPrice.Text = finalPrice.ToString();
                    ContractPrice.Background = Brushes.Transparent;
                }
                else if (TypeContract.SelectedIndex == 1)
                {
                    finalPrice = getprice + (getprice * 3 / 100);
                    FinalPrice.Text = finalPrice.ToString();
                    ContractPrice.Background = Brushes.Transparent;
                }
                else if (TypeContract.SelectedIndex == 2)
                {
                    finalPrice = getprice + (getprice * 10 / 100);
                    FinalPrice.Text = finalPrice.ToString();
                    ContractPrice.Background = Brushes.Transparent;
                }
                else if (TypeContract.SelectedIndex == 3)
                {
                    finalPrice = getprice + (getprice * 8 / 100);
                    FinalPrice.Text = finalPrice.ToString();
                    ContractPrice.Background = Brushes.Transparent;
                }
                else if (TypeContract.SelectedIndex == 4)
                {
                    finalPrice = getprice + (getprice * 12 / 100);
                    FinalPrice.Text = finalPrice.ToString();
                    ContractPrice.Background = Brushes.Transparent;
                }
                else if (TypeContract.SelectedIndex == 5)
                {
                    finalPrice = getprice + (getprice * 1 / 100);
                    FinalPrice.Text = finalPrice.ToString();
                    ContractPrice.Background = Brushes.Transparent;
                }
            }
            else
            {
                ContractPrice.Background = Brushes.Red;
            }
        }
    }
}
