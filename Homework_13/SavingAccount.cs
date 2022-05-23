using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_13
{
    public class SavingAccount : BankAccount
    {
        public SavingAccount()
        {

        }
        public SavingAccount(double startBalanse)
        {
            base.balance = startBalanse;
        }
    }
}
