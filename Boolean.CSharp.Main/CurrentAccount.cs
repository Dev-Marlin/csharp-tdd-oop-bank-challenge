using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main
{
    public class CurrentAccount : BankAccount
    {
        public CurrentAccount(Branch branch, string phoneNumber) 
        {
            Balance = 0;
            OverdraftAmount = 0;
            PhoneNumber = phoneNumber;
            this.branch = branch;
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

        public override bool RequestOverdraft(double amount, bool answer)
        {
            if (answer)
            {
                OverdraftAmount = amount;
            }

            return answer;
        }

        public override string SendSms(string bankPhone)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("date        || credit   || debit   || balance \n");

            foreach(ITransaction t in transactions)
            {
                if (t.Type == TransactionType.Debit)
                {
                    sb.Append(String.Format("{0, -11} ||          || {1,-8}|| {2, -8}\n", t.Date.Date.ToString("d"), t.Amount, t.Balance));
                }
                
                if(t.Type == TransactionType.Credit)
                {
                    sb.Append(String.Format("{0, -11} || {1,-9}||         || {2, -8}\n", t.Date.Date.ToString("d"), t.Amount, t.Balance));
                }
            }

            return sb.ToString();
        }

        public override bool Withdraw(double amount)
        {
            if (amount <= Balance && amount > 0-OverdraftAmount)
            {
                Balance -= amount;
                transactions.Add(new MyTransaction(amount, Balance, TransactionType.Credit));
                return true;
            }
            return false;
        }
    }
}
