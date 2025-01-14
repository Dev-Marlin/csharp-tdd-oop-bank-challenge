using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public abstract class BankAccount
    {
        protected List<ITransaction> transactions;
        public Guid ID { get; }
        public double Balance { get; set; }

        public BankAccount()
        {
            ID = Guid.NewGuid();
            transactions = new List<ITransaction>();
        }

        public abstract void Deposit(double amount);

        public abstract bool Withdraw(double amount);

        public List<ITransaction> GetStatement()
        {
            return transactions;
        }
          
    }
}
