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

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для FilialAddWindow.xaml
    /// </summary>
    public partial class FilialAddWindow : Window
    {
        public ObservableCollection<object> person;
        XDocument doc;
        public FilialAddWindow()
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
            person = new ObservableCollection<object>(filials);
        }

        private void Button_AddFil_Click(object sender, RoutedEventArgs e)
        {
            string code = AddCode.Text.Trim();
            string name = AddName.Text.Trim();
            string adress = AddAdress.Text.Trim();
            string phone = AddPhone.Text.Trim();

            if (!phone.Contains("+"))
            {
                AddPhone.Background = Brushes.Red;
                AddError.Text = "Неверный формат телефона";
                AddError.Visibility = Visibility.Visible;
            }
            else if (phone.Length != 12)
            {
                AddPhone.Background = Brushes.Red;
                AddError.Text = "Слишком короткий телефон";
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
                    doc.Element("filials").Add(new XElement("filial",
                                  new XElement("code", AddCode.Text),
                                  new XElement("name", AddName.Text),
                                  new XElement("adress", AddAdress.Text),
                                  new XElement("phone", AddPhone.Text)));
                    doc.Save("../../FilialsData.xml");
                    MessageBox.Show("Филиал добавлен!");
                    person.Add(new Filial { code = AddCode.Text, name = AddName.Text, adress = AddAdress.Text, phone = AddPhone.Text });
                }
                else
                {
                    MessageBox.Show("Неверный код!");   
                }
            }
            
        }

        public class Filial
        {
            public string code { get; set; }
            public string name { get; set; }
            public string adress { get; set; }
            public string phone { get; set; }
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            FilialsWindow filialsWindow = new FilialsWindow();
            filialsWindow.Show();
            this.Close();
        }
    }
}
