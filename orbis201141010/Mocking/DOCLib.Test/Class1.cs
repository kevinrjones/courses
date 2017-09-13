using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace DOCLib.Test
{
    [TestFixture]
    public class HttpAccountServiceTest
    {
        List<Account> _accounts = new List<Account> { new Account(), new Account(), new Account() };
        Mock<IRepository> mockIRepository;
        Mock<ILogger> mockILogger;

        [SetUp]
        public void Setup()
        {
            mockIRepository = new Mock<IRepository>();
            mockILogger = new Mock<ILogger>();
            
        }


        [Test]
        public void ShouldReturnACollectionOfAccounts()
        {
            //mockIRepository.Setup(r => r.GetAccounts()).Returns(_accounts);
            mockIRepository.SetupGet(r => r.Accounts).Returns(_accounts);

            var service = new HttpAccountService(mockIRepository.Object, mockILogger.Object);
            var accounts = service.GetAccounts();
            Assert.AreEqual(3, accounts.Count);
        }

        [Test]
        public void ShouldLogTheCall()
        {
            var service = new HttpAccountService(mockIRepository.Object, mockILogger.Object);
            service.GetAccounts();

            mockILogger.Verify(i => i.Log(It.IsAny<string>()), Times.Once);
        }
    }
}
