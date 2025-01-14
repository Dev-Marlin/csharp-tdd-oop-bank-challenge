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

            Assert.That(ba.ID, Is.EqualTo(null));
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

            List<Transaction> statement = ba.GetStatement();
            
            StringBuilder sb = new StringBuilder();

            foreach (Transaction t in statement)
            {
                sb.Append(t.Date.ToString() +" "+ t.Amount + " " + t.Balance +"\n");
            }

            Console.WriteLine(sb.ToString());

            Assert.That(sb.ToString(), !Is.EqualTo(""));
        }

        [Test]
        public void TestNegativeDeposit()
        {
            BankAccount ba = new CurrentAccount();

            ba.Deposit(-5000);

            Assert.That(ba.Balance(), !Is.Equals(-5000));
        }

        [Test]
        public void TestPositiveDeposit()
        {
            BankAccount ba = new CurrentAccount();

            ba.Deposit(387);

            Assert.That(ba.Balance(), Is.Equals(387));
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
            BankAccount ba = new CurrentAccount();

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

            Assert.That(ba.Balance, Is.EqualTo(1347));
        }

        [Test]
        public void TestTransactionDate()
        {
            DateTime dateTime = DateTime.Now;
            ITransaction transaction = new Transaction(dateTime, 500, 2677);

            Assert.That(transaction.Date, Is.EqualTo(dateTime));
        }

        [Test]
        public void TestTransactionBalance()
        {
            DateTime dateTime = DateTime.Now;
            ITransaction transaction = new Transaction(dateTime, 500, 2677);

            Assert.That(transaction.Balance, Is.EqualTo(2677));
        }

        [Test]
        public void TestTransactionAmount()
        {
            DateTime dateTime = DateTime.Now;
            ITransaction transaction = new Transaction(dateTime, 500, 2677);

            Assert.That(transaction.Amount, Is.EqualTo(500));
        }

    }
}