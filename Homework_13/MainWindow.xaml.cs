using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
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
using System.IO;

namespace Homework_13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Bank bank;
        private ObservableCollection<Client> clients;
        private BankAccount selectedBankAccount;
        private AccountViewer viewer;
        public MainWindow()
        {
            InitializeComponent();
            Load();
            if (bank is null) bank = new("Банк");
            if (bank.Clients is null)
            {
                bank.Clients = new();
                bank.Clients.Add(new Client("Test"));
            }
            clients = bank.Clients;
            lbClients.ItemsSource = clients;

            BankAccount.Notification += Service.ShowNotification; //Показывает уведомление
            Logging.NameUser = "Пользователь_1";
            //lbAccountsOfClient.ItemsSource = (lbClients.SelectedItem as Client)?.Accounts;
            viewer = new AccountViewer();
            frameForAccount.Navigate(viewer);


        }

        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            var addClient = new AddClient();
            addClient.ShowDialog();
            if (addClient.Client is null)
            {
                MessageBox.Show("Ошибка");
                return;
            }
            clients.Add(addClient.Client);
            addClient.Close();
        }

        private void btnOpenAccount_Click(object sender, RoutedEventArgs e)
        {
            if (lbClients.SelectedItem is null)
            {
                return;
            }
            var openAccount = new OpenAccount();
            openAccount.ShowDialog();
            var account = (lbClients.SelectedItem as Client);
            account?.OpenAccoun(openAccount.bankAccount);
            
        }

        private void lbClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbAccountsOfClient.ItemsSource = (lbClients.SelectedItem as Client)?.Accounts;
            //lbAccountsOfClient?.Items.Refresh();
        }

        private void lbAccountsOfClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           viewer.Account = lbAccountsOfClient.SelectedItem as BankAccount;
        }

        private void Load()
        {
            if (!File.Exists("bank.json"))
            {
                return;
            }
            var json = File.ReadAllText("bank.json");
            if (json is null)
            {
                return;
            }
           bank = JsonConvert.DeserializeObject<Bank>(json);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var json = JsonConvert.SerializeObject(bank);
            File.WriteAllText("bank.json",json);
        }

        private void btnCAlculatePercent_Click(object sender, RoutedEventArgs e)
        {
            Service.SkipYear();
        }
    }
}
