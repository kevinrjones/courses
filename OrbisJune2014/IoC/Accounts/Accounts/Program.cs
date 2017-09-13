using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Accounts
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountService service = new AccountService();
            service.AddAccount(new Account());
        }
    }

    public class AccountDao
    {
        public void Add(Account account)
        {
            Console.WriteLine("Adding");
            Thread.Sleep(2000);
            Console.WriteLine("Added");
        }
    }

    public class AccountService
    {
        public void AddAccount(Account account)
        {
            AccountDao dao = new AccountDao();
            dao.Add(account);
        }
    }

    public class Account
    {
    }
}
