using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main
{
    public class NoMemoryAccount : BankAccount
    {

        public NoMemoryAccount(Branch branch, string phoneNumber)
        {
            Balance = 0;
            OverdraftAmount = 0;
            PhoneNumber = phoneNumber;
            this.branch = branch;
        }

        public override void Deposit(double amount)
        {
            if (amount > 0)
            {
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

            foreach (ITransaction t in transactions)
            {

            }

            /*
            var message = MessageResource.Create(
                from: new Twilio.Types.PhoneNumber(bankPhone),
                body: sb.ToString(),
                to: new Twilio.Types.PhoneNumber("+15558675310")
            );*/

            return sb.ToString();
        }

        public override bool Withdraw(double amount)
        {
            if (amount <= CalcBalance() && amount > 0 - OverdraftAmount)
            {
                transactions.Add(new MyTransaction(amount, CalcBalance(), TransactionType.Credit));
                return true;
            }
            return false;
        }

        public double CalcBalance()
        {
            double balance = 0;

            foreach(ITransaction t in transactions)
            {
                if (t.Type == TransactionType.Credit)
                    balance -= t.Amount;
                else if(t.Type == TransactionType.Debit)
                    balance += t.Amount;
            }

            return balance;
        }
    }
}
