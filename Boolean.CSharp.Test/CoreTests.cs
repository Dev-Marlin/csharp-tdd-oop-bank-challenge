using System.Text;
using System.Transactions;
using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Core _core;

        public CoreTests()
        {
            _core = new Core();

        }

        [Test]
        public void TestGuid()
        {
            BankAccount ba = new CurrentAccount();

            Assert.That(ba.ID, !Is.EqualTo(null));
        }

        [Test]
        public void TestStatement()
        {
            BankAccount ba = new CurrentAccount();

            ba.Deposit(5000);
            ba.Withdraw(300);
            ba.Deposit(600);
            ba.Withdraw(1400);
            ba.Withdraw(900);
            ba.Withdraw(1627);

            List<ITransaction> statement = ba.GetStatement();
            
            StringBuilder sb = new StringBuilder();

            foreach (MyTransaction t in statement)
            {
                sb.Append(t.Date.ToString() +" "+ t.Amount + " " + t.Balance + " "+t.Type +"\n");
            }

            Console.WriteLine(sb.ToString());

            Assert.That(sb.ToString(), !Is.EqualTo(""));
        }

        [Test]
        public void TestNegativeDeposit()
        {
            BankAccount ba = new CurrentAccount();

            ba.Deposit(-5000);

            Assert.That(ba.Balance, !Is.EqualTo(-5000));
        }

        [Test]
        public void TestPositiveDeposit()
        {
            BankAccount ba = new CurrentAccount();

            ba.Deposit(387);
            double balance = ba.Balance;
            Assert.That(ba.Balance, Is.EqualTo(387));
        }

        [Test]
        public void TestNegativeWithdraw()
        {
            BankAccount ba = new CurrentAccount();

            bool withdraw = ba.Withdraw(-547);

            Assert.That(withdraw, Is.False);
        }

        [Test]
        public void TestPositiveWithdraw()
        {
            BankAccount ba = new CurrentAccount(800);

            bool withdraw = ba.Withdraw(547);

            Assert.That(withdraw, Is.True);
        }

        [Test]
        public void TestNegativeWithdrawBalance()
        {
            BankAccount ba = new CurrentAccount(800);

            ba.Withdraw(-547);

            Assert.That(ba.Balance, Is.EqualTo(800));
        }

        [Test]
        public void TestPositiveWithdrawBalance()
        {
            BankAccount ba = new CurrentAccount(800);

            ba.Withdraw(547);

            Assert.That(ba.Balance, Is.EqualTo(253));
        }

        [Test]
        public void TestTransactionDate()
        {
            ITransaction transaction = (ITransaction)new MyTransaction(500, 2677, TransactionType.Credit);

            Assert.That(transaction.Date, !Is.EqualTo(null));
        }

        [Test]
        public void TestTransactionBalance()
        {
            ITransaction transaction = (ITransaction)new MyTransaction(500, 2677, TransactionType.Credit);

            Assert.That(transaction.Balance, Is.EqualTo(2677));
        }

        [Test]
        public void TestTransactionAmount()
        {
            ITransaction transaction = (ITransaction)new MyTransaction(500, 2677, TransactionType.Credit);

            Assert.That(transaction.Amount, Is.EqualTo(500));
        }
    }
}