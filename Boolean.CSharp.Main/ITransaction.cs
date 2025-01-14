using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main
{
    public interface ITransaction
    {
        public DateTime Date { get; }
        public double Amount { get; }
        public double Balance { get; }
        public TransactionType Type { get; }
    }
}
