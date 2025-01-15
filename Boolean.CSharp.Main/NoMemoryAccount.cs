using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class NoMemoryAccount : BankAccount
    {


        public override void Deposit(double amount)
        {
            throw new NotImplementedException();
        }

        public override bool RequestOverdraft(double amount, bool answer)
        {
            throw new NotImplementedException();
        }

        public override string SendSms(string bankPhone)
        {
            throw new NotImplementedException();
        }

        public override bool Withdraw(double amount)
        {
            throw new NotImplementedException();
        }
    }
}
