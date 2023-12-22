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
    /// Логика взаимодействия для NavWindow.xaml
    /// </summary>
    public partial class NavWindow : Window
    {
        public NavWindow()
        {
            InitializeComponent();
        }

        private void Button_Insur_Click(object sender, RoutedEventArgs e)
        {
            ContractWindow contractWindow = new ContractWindow();
            contractWindow.Show();
            this.Close();
        }

        private void Button_Salarys_Click(object sender, RoutedEventArgs e)
        {
            AgentsSalaryWindow agentsSalaryWindow = new AgentsSalaryWindow();
            agentsSalaryWindow.Show();
            this.Close();
        }

        private void Button_Tarif_Click(object sender, RoutedEventArgs e)
        {
            TarifsWindow tarifsWindow = new TarifsWindow();
            tarifsWindow.Show();
            this.Close();
        }

        private void Button_Filial_Click(object sender, RoutedEventArgs e)
        {
            FilialsWindow filialsWindow = new FilialsWindow();
            filialsWindow.Show();
            this.Close();
        }

        private void Button_Agents_Click(object sender, RoutedEventArgs e)
        {
            AgentsWindow agentsWindow = new AgentsWindow();
            agentsWindow.Show();
            this.Close();
        }

        private void Button_MyInsurens_Click(object sender, RoutedEventArgs e)
        {
            MyContractsWindow myContractsWindow = new MyContractsWindow();
            myContractsWindow.Show();
            this.Close();
        }

        private void Button_Rules_Click(object sender, RoutedEventArgs e)
        {
            RulesWindow rulesWindow = new RulesWindow();
            rulesWindow.Show();
            this.Close();
        }

        private void Button_Questions_Click(object sender, RoutedEventArgs e)
        {
            FAQWindow faqWindow = new FAQWindow();
            faqWindow.Show();
            this.Close();
        }
    }
}
