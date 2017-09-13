using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Moq;
using NUnit.Framework;
using TodoRepository.Interfaces;
using TodoWeb.Controllers;

namespace TodoWebTests
{
    [TestFixture]
    public class TodoControllerTests
    {
        Mock<ITodoRepository> repo = null;

        [SetUp]
        public void Setup()
        {
            repo = new Mock<ITodoRepository>();
        }

        [Test]
        public void GivenAValidTodoModel_WhenNewIsCalled_ThenTheTodoIsAddedToTheDatabase()
        {
            //var controller = new TodoController(repo.Object);
            //controller.Create("New todo");
            //repo.Verify(r => r.Create(It.IsAny<Todo>()), Times.Once());
        }
    }

}
