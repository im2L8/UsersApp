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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<object> person;
        XDocument doc;
        public MainWindow()
        {
            InitializeComponent();
            doc = XDocument.Load("../../UsersData.xml");
            var users = (from x in doc.Element("users").Elements("user")
                         orderby x.Element("login").Value
                         select new
                         {
                             Login = x.Element("login").Value,
                             Password = x.Element("password").Value,
                             Email = x.Element("email").Value
                         }).ToList();

            person = new ObservableCollection<object>(users);
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string Login = LoginText.Text.Trim();
            string Password = PasswordText.Text.Trim();
            string Email = EmailText.Text.Trim();

            if (!Email.Contains("@"))
            {
                EmailText.Background = Brushes.Red;
                EmailError.Visibility = Visibility.Visible;
            }
            else if (!Email.Contains("."))
            {
                EmailText.Background = Brushes.Red;
                EmailError.Visibility = Visibility.Visible;
            }
            else
            {
                EmailText.Background = Brushes.Transparent;
                EmailError.Visibility = Visibility.Hidden;
            }

            if (Login.Length < 5)
            {
                LoginText.Background = Brushes.Red;
                LoginError.Visibility = Visibility.Visible;
            }
            else
            {
                LoginText.Background = Brushes.Transparent;
                LoginError.Visibility = Visibility.Hidden;
            }

            if (Password.Length < 5)
            {
                PasswordText.Background = Brushes.Red;
                PasswordError.Visibility = Visibility.Visible;
            }
            else
            {
                PasswordText.Background = Brushes.Transparent;
                PasswordError.Visibility = Visibility.Hidden;
            }

            if (EmailError.Visibility == Visibility.Hidden & LoginError.Visibility == Visibility.Hidden & PasswordError.Visibility == Visibility.Hidden)
            {
                doc.Element("users").Add(new XElement("user",
                              new XElement("login", LoginText.Text),
                              new XElement("password", PasswordText.Text),
                              new XElement("email", EmailText.Text)));
                doc.Save("../../UsersData.xml");
                MessageBox.Show("Регистрация выполнена!");
                person.Add(new Person { login = LoginText.Text, password = PasswordText.Text, email = EmailText.Text });
            }
        }

        public class Person
        {
            public string login { get; set; }
            public string password { get; set; }
            public string email { get; set; }
        }

        private void Button_Window_Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Close();
        }
    }
}
