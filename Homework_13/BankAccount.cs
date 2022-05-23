using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;

namespace Homework_13
{
    [Serializable]
    public class BankAccount : INotifyPropertyChanged
    {
        #region Поля
        private Random random = new Random();
        private protected static int nextId = 1;
        private protected int id;
        private protected int numberOfAccount;
        private protected double balance;

        public static event Action<string>? Notification;
        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion
        #region Свойства
        public int Id { get; }
        public int NumberOfAccaunt { get => numberOfAccount; }
        public double Balance { get { return balance; } }
        #endregion


        public BankAccount()
        {
            id = nextId++;
            numberOfAccount = int.Parse($"1234{(random.Next(1000, 10000)).ToString()}");
            Notification?.Invoke($"Создан счёт {numberOfAccount}");
        }

        /// <summary>
        /// Добавление средств на счёт
        /// </summary>
        /// <param name="sum"></param>
        public void Add(double sum)
        {
            balance += sum;
            NotifyPropertyChanged();
            Notification?.Invoke($"На счёт {this.NumberOfAccaunt} поступило: " + sum);
        }

        /// <summary>
        /// Снятие средств со счета. Возвращает true, если операция прошла успешно.
        /// </summary>
        /// <param name="sum"></param>
        public bool Withdraw(double sum)
        {
            if (balance - sum < 0) { Notification?.Invoke("Не достаточно средств"); return false; }
            balance -= sum;
            NotifyPropertyChanged();
            Notification?.Invoke($"Со счёта {this.NumberOfAccaunt} списано: " + sum);
            return true;
        }

        /// <summary>
        /// Перевод средств на другой счёт
        /// </summary>
        /// <param name="account">Счёт назначения</param>
        /// <param name="sum">Сумма перевода</param>
        public void Tranfer(BankAccount account, double sum)
        {
            if (!Withdraw(sum)) return;
            account.Add(sum);
            NotifyPropertyChanged();
            Notification?.Invoke("Перевод на сумму: " + sum + "на счёт " + account.NumberOfAccaunt);
        }
        //internal double GetBalance()
        //{
        //    return balance;
        //}

        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            
        }


    }
}
