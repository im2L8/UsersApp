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
using static UsersApp.MainWindow;
using static UsersApp.FilialAddWindow;

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для AddAgentWindow.xaml
    /// </summary>
    public partial class AddAgentWindow : Window
    {
        public ObservableCollection<object> person;
        XDocument doc;
        public AddAgentWindow()
        {
            InitializeComponent();
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
                FilialContract.Items.Add(filials[i].Name);
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
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            AgentsWindow agentsWindow = new AgentsWindow();
            agentsWindow.Show();
            this.Close();
        }

        private void Button_AddAgent_Click(object sender, RoutedEventArgs e)
        {
            string fullname = AddName.Text.Trim();
            string phone = AddPhone.Text.Trim();
            string adress = AddAdress.Text.Trim();
            string filial = FilialContract.Text.Trim();

            var fullnamearr = fullname.Split(' ');
            fullnamearr.ToArray();
            int Spaces = 0;
            for (int i = 0; i < fullname.Length; i++)
            {
                if (fullname[i] == ' ')
                {
                    Spaces++;
                }
            }

            if (Spaces != 2)
            {
                MessageBox.Show("Некорректное ФИО");
            }
            else
            {
                string name = fullnamearr[0];
                string surname = fullnamearr[1];
                string secondname = fullnamearr[2];
                AddName.Background = Brushes.Transparent;

                if (!phone.Contains("+"))
                {
                    AddPhone.Background = Brushes.Red;
                    AddError.Text = "Неверный формат телефона";
                    AddError.Visibility = Visibility.Visible;
                }
                else if (phone.Length < 12)
                {
                    AddPhone.Background = Brushes.Red;
                    AddError.Text = "Слишком короткий телефон";
                    AddError.Visibility = Visibility.Visible;
                }
                else if (phone.Length > 12)
                {
                    AddPhone.Background = Brushes.Red;
                    AddError.Text = "Слишком длинный телефон";
                    AddError.Visibility = Visibility.Visible;
                }
                else
                {
                    AddPhone.Background = Brushes.Transparent;
                    AddError.Visibility = Visibility.Hidden;
                }

                if (AddError.Visibility == Visibility.Hidden)
                {
                    if (AdminCode.Text == "12345")
                    {
                        AddError.Visibility = Visibility.Hidden;
                        doc.Element("agents").Add(new XElement("agent",
                                      new XElement("name", name),
                                      new XElement("surname", surname),
                                      new XElement("secondname", secondname),
                                      new XElement("adress", AddAdress.Text),
                                      new XElement("filial", FilialContract.Text),
                                      new XElement("phone", AddPhone.Text)));
                        doc.Save("../../AgentsData.xml");
                        MessageBox.Show("Агент добавлен!");
                        doc = XDocument.Load("../../AgentsSalaryData.xml");
                        var salaris = (from x in doc.Element("salaris").Elements("salary")
                                       orderby x.Element("surname").Value
                                       select new
                                       {
                                           Surname = x.Element("surname").Value,
                                           Val = x.Element("value").Value,
                                       }).ToList();
                        doc.Element("salaris").Add(new XElement("salary",
                                      new XElement("surname", surname),
                                      new XElement("value", 0)));
                        doc.Save("../../AgentsSalaryData.xml");
                    }
                    else
                    {
                        MessageBox.Show("Неверный код!");
                    }
                }
            }

            
        }

        public class Agent
        {
            public string name { get; set; }
            public string surname { get; set; }
            public string secondname { get; set; }
            public string phone { get; set; }
            public string adress { get; set; }
            public string filial { get; set; }
        }
    }
}
