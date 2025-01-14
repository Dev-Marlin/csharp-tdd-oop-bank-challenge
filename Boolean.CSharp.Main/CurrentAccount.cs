using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class CurrentAccount : BankAccount
    {
        public CurrentAccount() 
        {
            Balance = 0;
        }

        public CurrentAccount(double startBalance)
        {
            Balance = startBalance;
        }

        public override void Deposit(double amount)
        {
            if(amount > 0)
            {
                Balance += amount;
                transactions.Add(new MyTransaction(amount, Balance, TransactionType.Debit));
            }
        }

        public override bool Withdraw(double amount)
        {
            if (amount <= Balance && amount > 0)
            {
                Balance -= amount;
                transactions.Add(new MyTransaction(amount, Balance, TransactionType.Credit));
                return true;
            }
            return false;
        }
    }
}
