using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BankTransfer
{
    public class Account : AccountBase
    {

        public Account(decimal openingBalance)
        {
            balance = openingBalance;
        }

        private decimal balance;

        public override decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public override void Credit(decimal amount)
        {
            decimal temp = balance + amount;
            Thread.Sleep(2);
            balance = temp;
        }
    }
}
