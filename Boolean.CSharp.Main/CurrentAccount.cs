using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Enums;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

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

            foreach(ITransaction t in transactions)
            {

            }

            var message = MessageResource.Create(
                from: new Twilio.Types.PhoneNumber(bankPhone),
                body: sb.ToString(),
                to: new Twilio.Types.PhoneNumber("+15558675310")
            );
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
