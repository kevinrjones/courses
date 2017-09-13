using System;
using System.Collections.Generic;
using System.Text;

namespace BankTransfer
{
    public class Bank
    {
        static Bank instance = null;
        Account[] accounts = null;

        static Bank()
        {
            instance = new Bank();
        }

        public static Bank GetInstance()
        {
            return instance;
        }

        public int Length
        {
            get { return accounts.Length; }
        }


        public void CreateAccounts(int number)
        {
            Random r = new Random();

            accounts = new Account[number];

            for (int i = 0; i < number; i++)
            {
                Account a = new Account((decimal)r.NextDouble() * 100);
                accounts[i] = a;
            }
        }

        public AccountBase GetAccount(int index)
        {
            return accounts[index];
        }

        public AccountBase GetSynchronisedAccount(int index)
        {
            return new SynchronisedAccount(accounts[index]);
        }

        public AccountBase GetAuditAccount(int index)
        {
            AccountBase account = new SynchronisedAccount(accounts[index]);
            AuditProxy<AccountBase> proxy = new AuditProxy<AccountBase>(account);

            return (AccountBase) proxy.GetTransparentProxy();

        }


        public decimal GetBalance()
        {
            decimal total = 0;
            foreach (Account account in accounts)
            {
                total += account.Balance;
            }

            return total;
        }
    }
}
