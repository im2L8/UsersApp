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
    public partial class FilialsWindow : Window
    {
        public ObservableCollection<object> person;
        public ObservableCollection<object> personM;
        public ObservableCollection<object> personK;
        XDocument doc;
        public FilialsWindow()
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

            FilialsData.ItemsSource = person;
        }
        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            NavWindow navWindow = new NavWindow();
            navWindow.Show();
            this.Close();
        }

        private void Button_ToAddFil_Click(object sender, RoutedEventArgs e)
        {
            FilialAddWindow filialAddWindow = new FilialAddWindow();
            filialAddWindow.Show();
            this.Close();
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            FilialsEditWindow editWindow = new FilialsEditWindow();
            editWindow.Show();
            this.Close();
        }

        private void Button_MoscowFilter_Click(object sender, RoutedEventArgs e)
        {
            doc = XDocument.Load("../../FilialsData.xml");
            var filials = (from x in doc.Element("filials").Elements("filial")
                           where x.Element("adress").Value == "Москва"
                           orderby x.Element("code").Value
                         select new
                         {
                             Code = x.Element("code").Value,
                             Name = x.Element("name").Value,
                             Adress = x.Element("adress").Value,
                             Phone = x.Element("phone").Value,
                         }).ToList();

            personM = new ObservableCollection<object>(filials);

            FilialsData.ItemsSource = personM;
        }

        private void Button_CodeFilter_Click(object sender, RoutedEventArgs e)
        {
            doc = XDocument.Load("../../FilialsData.xml");
            var filials = (from x in doc.Element("filials").Elements("filial")
                           where int.Parse(x.Element("code").Value) > 5000
                           orderby x.Element("code").Value
                           select new
                           {
                               Code = x.Element("code").Value,
                               Name = x.Element("name").Value,
                               Adress = x.Element("adress").Value,
                               Phone = x.Element("phone").Value,
                           }).ToList();

            personK = new ObservableCollection<object>(filials);

            FilialsData.ItemsSource = personK;
        }

        private void Button_Reload_Click(object sender, RoutedEventArgs e)
        {
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

            FilialsData.ItemsSource = person;
        }
    }
}
