using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using ServiceModels;
using TodoServices;
using TodoWeb.Controllers;
using TodoWeb.Models;

namespace TodoWebTests
{
    [TestFixture]
    public class TodoControllerTests
    {
        private Mock<ITodoService> todoService;

        [SetUp]
        public void Setup()
        {
            todoService = new Mock<ITodoService>();
        }

        //[Test]
        //public void GivenThreeTodosInTheDatabase_WhenIViewThePage_ThenThePageShouldShowThreeTodos()
        //{
        //    todoService.Setup(t => t.GetTodos(1)).Returns(new List<Todo>{new Todo(), new Todo(), new Todo()});
        //    var controller = new TodoController(todoService.Object);
        //    var result = (ViewResult) controller.Index();
        //    var model = (IList<TodoViewModel>) result.Model;

        //    model.Count.Should().Be(3);
        //}

        //[Test]
        //public void GivenNoTodosInTheDatabase_WhenIViewThePage_ThenThePageShouldShowNoTodos()
        //{
        //    todoService.Setup(t => t.GetTodos(1)).Returns(new List<Todo>());
        //    var controller = new TodoController(todoService.Object);
        //    var result = (ViewResult)controller.Index();
        //    var model = (IList<TodoViewModel>)result.Model;

        //    model.Count.Should().Be(0);
        //}
    }

}
