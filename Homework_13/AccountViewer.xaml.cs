using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Homework_13
{
    /// <summary>
    /// Логика взаимодействия для AccountViewer.xaml
    /// </summary>
    public partial class AccountViewer : Page, INotifyPropertyChanged
    {
        private BankAccount bankAccount;
        public event PropertyChangedEventHandler? PropertyChanged;
        public BankAccount Account
        {
            get { return bankAccount; }
            set { bankAccount = value; NotifyPropertyChanged(); }
        }
        public AccountViewer()
        {
            InitializeComponent();
            tbBalance.Text = Account?.Balance.ToString();
            tbNumberAccount.Text = Account?.NumberOfAccaunt.ToString();
            
        }
        


        private void tboxTranserTo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")
               && (!tboxTranserSum.Text.Contains(".")
               && tboxTranserSum.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }

        private void tboxTranserSum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")
               && (!tboxTranserSum.Text.Contains(".")
               && tboxTranserSum.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }

        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            tbBalance.Text = Account?.Balance.ToString();
            tbNumberAccount.Text = Account?.NumberOfAccaunt.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int numOfAccount;
            double sum;
            try
            {
                 numOfAccount= int.Parse(tboxTranserTo.Text);
                sum = double.Parse(tboxTranserSum.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Номер счёта и/или сумма введены не верно");
                return;
            }

            if (Account.Balance < sum) { MessageBox.Show("Недостаточно средств"); return; }

            var clients = Bank.bdBank.Clients;
            foreach (var client in clients)
            {
                var AccointIsFinde = Client.FindAccount(client, numOfAccount);
                if (AccointIsFinde != null)
                {
                    Account.Tranfer(AccointIsFinde, sum);
                }
            }
        }
    }
}
