using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BankTransfer
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = Bank.GetInstance();

            bank.CreateAccounts(1000);
            decimal initialBalance = bank.GetBalance();
            Console.WriteLine(initialBalance);

            TransferMoney(bank, 100);
            Console.WriteLine(bank.GetBalance());

            if(initialBalance != bank.GetBalance())
                Console.WriteLine("Ooops!!");
        }

        private static void TransferMoney(Bank bank, int nThreads)
        {
            Thread[] threads = new Thread[nThreads];

            for (int i = 0; i < nThreads; i++)
            {
                threads[i] = new Thread(ThreadTransferProc);
                threads[i].Start(bank);
            }
            for (int i = 0; i < nThreads; i++)
            {
                threads[i].Join();
            }
        }

        public static void ThreadTransferProc(object arg)
        {
            Bank bank = (Bank)arg;
            Random r = new Random();

            for (int i = 0; i < 100; i++)
            {
                AccountBase to = bank.GetAuditAccount(r.Next(bank.Length));
                AccountBase from = bank.GetAuditAccount(r.Next(bank.Length));
                decimal credit = (decimal)r.NextDouble() * 100;
                to.Credit(credit);
                from.Credit(-credit);
            }
        }
    }
}
