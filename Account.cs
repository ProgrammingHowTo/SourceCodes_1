using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    class Account
    {
        private float balance;
        private float minBalance = 10;

        public Account()
        {
        }

        public Account(int value)
        {
            balance = value;
        }

        public void Deposit(float amount)
        {
            balance += amount;
        }

        public void Withdraw(float amount)
        {
            balance -=amount;
        }

        public void TransferFunds(Account destination, float amount)
        {
            destination.Deposit(amount);
            Withdraw(amount);
        }

        public Account TransferMinFunds(Account destination, float amount)
        {
            if (Balance - amount > MinBalance)
            {
                destination.Deposit(amount);
                Withdraw(amount);
            }
            else
            {
                throw new NotEnoughFundsException();
            }

            return destination;
        }


        public float Balance
        {
            get { return balance; }
        }

        public float MinBalance
        {
            get { return minBalance; }
        }

    }
}
