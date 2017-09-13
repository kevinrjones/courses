using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;

namespace IoCDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            var builder = new ContainerBuilder();

            builder.RegisterType<ConsoleLogger>().As<ILogger>();
            builder.RegisterType<EFRepository>().As<IRepository>();
            builder.RegisterType<HttpAccountService>().As<IAccountService>();

            IContainer container = builder.Build();

            var service = container.Resolve<IAccountService>();

            service.GetAccount(1);
        }
    }

    public interface IRepository
    {
        List<Account> Accounts { get; set; }
    }

    public class EFRepository : IRepository
    {
        private readonly ILogger _logger;

        public EFRepository(ILogger logger)
        {
            _logger = logger;
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
