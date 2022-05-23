using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Homework_13
{
    [Serializable]
    public class Client : INotifyPropertyChanged
    {
        private static int nextId = 0;
        private string? name;

        public event PropertyChangedEventHandler? PropertyChanged;

        public int Id { get; private set; }
        public string? Name
        {
            get { return name; }
            set { name = value; NotifyPropertyChanged(); }
        }
        public ObservableCollection<BankAccount> Accounts { get; private set; }

        public Client(string Name)
        {
            Id = ++nextId;
            this.Name = Name ?? "ThisIsName_" + Id;
            Accounts = new() {null,null }; //null - заглушка, чтобы корректно работали методы открытия и закрытия
        }
        public Client()
        {
            Id = ++nextId;
            Name = "ThisIsName_" + Id;
            Accounts = new();
        }

        /// <summary>
        /// Открывает счёт и добавляет его в определённое поле массива в зависимости от типа
        /// </summary>
        /// <param name="bankAccount"></param>
        public void OpenAccoun(BankAccount bankAccount)
        {
            // В зависимости от типа счёта добавляет его в определённую ячейку массива
            switch (bankAccount)
            {
                case DepositAccaunt:
                    Accounts[0] = bankAccount;
                    break;
                case SavingAccount:
                    Accounts[1] = bankAccount;
                    break;
            }
            NotifyPropertyChanged();
        }
        
        /// <summary>
        /// Закрывает переданный счёт
        /// </summary>
        /// <param name="bankAccount"></param>
        public void CloseAccount(BankAccount bankAccount)
        {
            // В зависимости от типа счёта очищает его в определённую ячейку массива
            switch (bankAccount)
            {
                case DepositAccaunt:
                    Accounts[0] = null;
                    break;
                case SavingAccount:
                    Accounts[1] = null;
                    break;
            }
            NotifyPropertyChanged();
        }
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        /// <summary>
        /// Ищет счёт по его номеру
        /// </summary>
        /// <param name="client"></param>
        /// <param name="numberOfAccount"></param>
        /// <returns></returns>
        public static BankAccount? FindAccount(Client client, int numberOfAccount)
        {
            BankAccount? result = null;
            foreach (var account in client.Accounts)
            {
                if (account == null) continue;
                if (account.NumberOfAccaunt == numberOfAccount) { result = account; return account; }
            }
            return null;
        }
    }
}
