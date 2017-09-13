using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Entities;
using Moq;
using NUnit.Framework;
using TaskList.Controllers;
using TaskList.Models;
using TodoRepository.interfaces;

namespace TaskListTests
{
    [TestFixture]
    public class ListControllerTests
    {
        Mock<ITodoRepository> repository;

        [SetUp]
        public void Setup()
        {
            repository = new Mock<ITodoRepository>();
        }

        [Test]
        public void GivenATodoItem_WhenICreateIt_ThenItIsAddedToTheDatabase()
        {
            ListController controller = new ListController(repository.Object);
            controller.Create(new TodoViewModel());
            repository.Verify(r => r.Create(It.IsAny<Todo>()), Times.Once());
        }
        
        [Test]
        public void GivenAnInvalidModel_WhenITryAndCreateATodoItem_ThenTheNewViewIsDisplayed()
        {
            var controller = new ListController(repository.Object);
            controller.ModelState.AddModelError("error","value");
            var result = controller.Create(new TodoViewModel()) as ViewResult;

            Assert.That(result, Is.Not.Null);
        }
    }
}
