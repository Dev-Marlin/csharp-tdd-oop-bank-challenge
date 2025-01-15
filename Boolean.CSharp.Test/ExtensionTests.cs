using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Enums;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class ExtensionTests
    {
        private Extension _extension;
        public ExtensionTests()
        {
            _extension = new Extension();
        }
        [Test]
        public void TestCalcBalance()
        {
            BankAccount ba = new NoMemoryAccount(Branch.Oslo, "+15017122661");

            ba.Deposit(5000);
            ba.Withdraw(300);
            ba.Deposit(600);
            ba.Withdraw(1400);
            ba.Withdraw(900);
            ba.Withdraw(1627);
            //1373

            double balance = ba.CalcBalance();

            Assert.Pass();
        }
        [Test]
        public void TestSendSMS()
        {
            BankAccount ba = new CurrentAccount(Branch.Oslo, "+15017122661");

            ba.Deposit(5000);
            ba.Withdraw(300);
            ba.Deposit(600);
            ba.Withdraw(1400);
            ba.Withdraw(900);
            ba.Withdraw(1627);

            string sms = ba.SendSms();

            Assert.That(sms, Is.EqualTo(""));
        }

        [Test]
        public void TestOverdraftPass()
        {
            BankAccount ba = new CurrentAccount(Branch.Oslo, "+15017122661");

            bool overdraft = ba.RequestOverdraft(500, true);

            Assert.That(overdraft, Is.True);
        }

        [Test]
        public void TestOverdraftFail()
        {
            BankAccount ba = new CurrentAccount(Branch.Oslo, "+15017122661");

            bool overdraft = ba.RequestOverdraft(500, false);

            Assert.That(overdraft, Is.True);
        }
    }
}
