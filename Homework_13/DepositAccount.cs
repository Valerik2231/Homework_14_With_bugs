using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_13
{
    public class DepositAccaunt : BankAccount
    {
        public double Percent { get; set; }

        public DepositAccaunt(double startSum, double? percent) : base()
        {
            balance = startSum;
            Percent = percent ?? 0.13;
            Service.OneYearLater += PayPercent;//подписка на событие, обозначающие, что прошел год
        }
        public DepositAccaunt() { }

        /// <summary>
        /// Выплачивает проценты
        /// </summary>
        public void PayPercent()
        {
            if (base.balance != 0)
            {
                balance += balance * Percent;
                NotifyPropertyChanged();
                
                
                //Notification?.Invoke("");
            }
        }
    }
}
