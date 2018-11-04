using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    [TestFixture]
    class AccountTest
    {
        Account source;
        Account destination;

        [SetUp]
        public void InitAccount()
        {
            //arrange
            source = new Account();
            source.Deposit(200.00F);
            destination = new Account();
            destination.Deposit(150.00F);
        }

        [Test]
        [Category("pass")]
        public void TransferFunds()
        {
            //act
            source.TransferFunds(destination, 100.00F);

            //assert - verify
            Assert.AreEqual(250.00F, destination.Balance);
            Assert.AreEqual(100.00F, source.Balance);
        }


        [Test, Category("pass")]
        [TestCase(200,0,78)]
        [TestCase(200, 0, 189)]
        [TestCase(200, 0, 1)]
        public void TransferMinFunds(int a, int b, int c)
        {
            Account source = new Account();
            source.Deposit(a);
            Account destination = new Account();
            destination.Deposit(b);

            source.TransferMinFunds(destination, c);
            Assert.AreEqual(c,destination.Balance );
        }

        [Test, ExpectedException(typeof(NotEnoughFundsException))]
        [Category("fail")]
        [TestCase(200,150,200)]
        [TestCase(200, 150, 300)]
        [TestCase(200, 150, 500)]
        [TestCase(200, 150, 1000)]
        public void TransferMinFundsFail(int a, int b, int c)
        {
            Account source = new Account();
            source.Deposit(a);
            Account destination = new Account();
            destination.Deposit(b);

            destination = source.TransferMinFunds(destination, c);
        }


        [Test]//, ExpectedException(typeof(NotEnoughFundsException))]
        [Category("fail")]
        [Combinatorial]
        public void TransferMinFundsFailAll([Values (200,500)] int a, [Values(0,20)]int b, 
            [Values(140,135)]int c)
        {
            Account source = new Account();
            source.Deposit(a);
            Account destination = new Account();
            destination.Deposit(b);

            destination = source.TransferMinFunds(destination, c);
        }

    }

    public class NotEnoughFundsException:ApplicationException
    {

    }
}
