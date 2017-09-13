using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using TodoList.Controllers;
using TodoList.Models;

namespace UnitTests.ControllerTests
{
    [TestFixture]
    public class TodoControllerTest
    {
        [Test]
        public void GivenAValidSetOfParameters_WhenICreateATodoItem_ThenTheListOfItemsIsShown()
        {
            var controller = new TodoController();
            var result = controller.Create(new NewTodoModel());
            Assert.That(result, Is.TypeOf<RedirectToRouteResult>());
        }


        [Test]
        public void GivenAnInValidSetOfParameters_WhenICreateATodoItem_ThenTheNewViewIsShown()
        {
            var controller = new TodoController();
            controller.ModelState.AddModelError("foo", "bar");
            ViewResult result = controller.Create(new NewTodoModel()) as ViewResult;
            Assert.That(result.ViewName, Is.EqualTo("New").IgnoreCase);
        }
    }

}
