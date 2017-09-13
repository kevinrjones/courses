using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using BGServices;
using DataModels;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using SimpleAppWeb.Controllers;
using SimpleAppWeb.Models;

namespace SimpleWebAppTests
{
    [TestFixture]
    public class TodosControllerTests
    {
        private Mock<ITodoService> service;
        User _user = new User();
 
        [SetUp]
        public void Setup()
        {
            service = new Mock<ITodoService>();
            _user = new User();
            _user.Name = "Alice";
            _user.EMail = "alice@example.com";
            _user.Todos = new List<Todo>();

            _user.Todos.Add(new Todo { Description = "Get lunch", Priority = 1, DoBy = DateTime.Now });
            _user.Todos.Add(new Todo { Description = "Get tea", Priority = 1, DoBy = DateTime.Now });
            _user.Todos.Add(new Todo { Description = "Get dinner", Priority = 1, DoBy = DateTime.Now });
        }

        [Test]
        public void GivenATodosController_WhenIAskForAUserWithTodos_ThenTheTodosArePassedToTheView()
        {
            // Arrange
            service.Setup(s => s.GetTodoItemsForUser(1))
                .Returns(_user);
            var controller = new TodosController(service.Object);

            // Act
            var result = (ViewResult)controller.Index();

            // Assert
            var model = (UserTodos)result.Model;
            model.Todos.Should().NotBeNull();
            model.Todos.Count.Should().Be(3);
        }

        [Test]
        public void GivenATodosController_WhenIAskForAUserWithNoTodos_ThenNoTodosArePassedToTheView()
        {
            _user.Todos = new List<Todo>();
            service.Setup(s => s.GetTodoItemsForUser(1)).Returns(_user);
            var controller = new TodosController(service.Object);
            
            var result = (ViewResult)controller.Index();
            
            var model = (UserTodos)result.Model;
            model.Todos.Count.Should().Be(0);
        }
    }
}

/*

*/