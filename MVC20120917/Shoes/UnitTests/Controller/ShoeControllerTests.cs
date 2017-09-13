using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using ShoeInMemoryRepository.Interfaces;
using ShoeServices;
using Shoes.Controllers;
using Shoes.Models;
using ShoesModel;

namespace UnitTests.Controller
{
    [TestFixture]
    public class ShoeControllerTests
    {
        Mock<IShoeService> _service;

        [SetUp]
        public void Setup()
        {
            _service = new Mock<IShoeService>();
        }

        [Test]
        public void GivenAnEmptyDatabase_WhenIAskForAllShoes_ThenIGetAViewWithNoShoes()
        {
            _service.Setup(s => s.GetShoes()).Returns(new List<Shoe>());
            var controller = new ShoeController(_service.Object);
            var result = (ViewResult) controller.Index();
            result.Model.As<List<DisplayShoeVM>>().Count.Should().Be(0);
        }

        [Test]
        public void GivenValidInput_WhenAShoeIsCreated_ThenISeeAListOfShoes()
        {
            var controller = new ShoeController(null);
            var result = (RedirectToRouteResult) controller.Create(new DisplayShoeVM());

            result.RouteValues["action"].As<string>().Should().BeEquivalentTo("index");
        }
    }
}
