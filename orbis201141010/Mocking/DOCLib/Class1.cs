using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOCLib
{

    public interface IRepository
    {
        List<Account> GetAccounts();
        List<Account> Accounts { get; set; }
    }

    public class EFRepository : IRepository
    {
        private readonly ILogger _logger;

        public EFRepository(ILogger logger)
        {
            _logger = logger;
        }

        public List<Account> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public List<Account> Accounts { get; set; }
    }

    public class Account
    {

    }

    public interface ILogger
    {
        void Log(string message);
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public interface IAccountService
    {
        List<Account> GetAccounts();
        Account GetAccount(int id);
    }

    public class HttpAccountService : IAccountService
    {
        private readonly IRepository _repository;
        private readonly ILogger _logger;

        public HttpAccountService(IRepository repository, ILogger logger, IFoo foo)
        {
            _repository = repository;
            _logger = logger;
        }

        public HttpAccountService(IRepository repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        //IRepository 
        public List<Account> GetAccounts()
        {
            _logger.Log("Some message");
            return _repository.Accounts;
        }

        public Account GetAccount(int id)
        {
            throw new NotImplementedException();
        }
    }

    public interface IFoo
    {

    }
}
