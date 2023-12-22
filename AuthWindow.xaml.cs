using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static UsersApp.MainWindow;
using System.Xml.Linq;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        XDocument doc;
        
        public AuthWindow()
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

        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginText.Text;
            string email = EmailText.Text;
            string password = PasswordText.Text;
            int point1 = 0;
            int point1end = 0;
            int point2 = 0;
            int point2end = 0;
            int point3 = 0;
            int point3end = 0;

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("../../UsersData.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "login")
                    {
                        point1 += 1;
                        if (childnode.InnerText == login)
                        {
                            point1end = point1;
                        }
                    }
                    if (childnode.Name == "email")
                    {
                        point2 += 1;
                        if (childnode.InnerText == email)
                        {
                            point2end = point2;
                        }
                    }
                    if (childnode.Name == "password")
                    {
                        point3 += 1;
                        if(childnode.InnerText == password)
                        {
                            point3end = point3;
                        }
                    }
                }
            }
            if ((point1end == point2end & point3end == point2end) & (point1end != 0) & (point2end != 0) & (point3end != 0))
            {
                MessageBox.Show("Вход выполнен!");
                AuthError.Visibility = Visibility.Hidden;
                NavWindow navWindow = new NavWindow();
                navWindow.Show();
                this.Close();
            }
            else
            {
                AuthError.Visibility = Visibility.Visible;
            }
        }

        private void Button_Window_Reg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
