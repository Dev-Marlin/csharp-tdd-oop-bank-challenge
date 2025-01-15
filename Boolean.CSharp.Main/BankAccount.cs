using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main
{
    public abstract class BankAccount
    {
        protected List<ITransaction> transactions;
        public Guid ID { get; }
        public double Balance { get; set; }
        public Branch branch { get; set; }
        public double OverdraftAmount { get; set; }

        public string PhoneNumber { get; set; }

        public BankAccount()
        {
            ID = Guid.NewGuid();
            transactions = new List<ITransaction>();
        }

        public abstract void Deposit(double amount);

        public abstract bool Withdraw(double amount);

        public abstract string SendSms(string bankPhone);

        public abstract bool RequestOverdraft(double amount, bool answer);
        public List<ITransaction> GetStatement()
        {
            return transactions;
        }
          
    }
}
