using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class MyTransaction : ITransaction
    {
        public DateTime Date { get; } 

        public double Amount { get; }

        public double Balance { get; }

        public MyTransaction(double amount, double balance)
        {
            Date = DateTime.Now;
            Amount = amount;
            Balance = balance;
        }

    }
}
