using System;
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
using System.Windows.Shapes;

namespace Homework_13
{
    /// <summary>
    /// Логика взаимодействия для OpenAccount.xaml
    /// </summary>
    public partial class OpenAccount : Window
    {
        public BankAccount bankAccount;
        public OpenAccount()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            double startBalanse;
            try
            {
                startBalanse = double.Parse(tboxStartBalance.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сумма введена не верно");
                return;
            }

            if (radiobtnDeposit.IsChecked ?? false)
            {
                bankAccount = new DepositAccaunt(startBalanse, 0.10);
                this.Close();
            }
            else if (radiobtnSaving.IsChecked??false)
            {
                bankAccount = new SavingAccount(startBalanse);
                this.Close();
            }
            else
            {
                MessageBox.Show("Что-то пошло не так");
                return;
            }

        }

        private void tboxStartBalance_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")
               && (!tboxStartBalance.Text.Contains(".")
               && tboxStartBalance.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }
    }
}
