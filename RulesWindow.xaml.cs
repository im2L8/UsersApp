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
    /// Логика взаимодействия для QuestionsWindow.xaml
    /// </summary>
    public partial class RulesWindow : Window
    {
        public RulesWindow()
        {
            InitializeComponent();
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            NavWindow navWindow = new NavWindow();
            navWindow.Show();
            this.Close();
        }
    }
}
