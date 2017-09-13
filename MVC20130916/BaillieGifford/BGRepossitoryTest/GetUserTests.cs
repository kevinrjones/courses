using System.Linq;
using System.Transactions;
using AtriumRepository;
using DataModels;
using FluentAssertions;
using NUnit.Framework;

namespace BGRepossitoryTest
{
    [TestFixture]
    public class GetUserTests
    {
        private TransactionScope scope;

        [SetUp]
        public void Setup()
        {
            scope = new TransactionScope();    
        }

        [Test]
        public void GivenAUserRepository_WhenIAskForUsers_UsersAreReturned()
        {
            var ctx = new BaillieGiffordEntities();
            var repo = new UserRepository(ctx);
            repo.Create(new User { EMail = "foo.com", Name = "bar" });
            repo.Create(new User { EMail = "foo.com", Name = "bar" });
            repo.Save();
            var users = repo.Entities.ToList();

            users.Count.Should().Be(2);
        }

        [TearDown]
        public void Teardown()
        {
            //scope.Dispose();
        }
    }
}
