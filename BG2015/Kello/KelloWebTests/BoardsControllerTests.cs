using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Kello.Controllers;
using KelloData;
using KelloServiceInterfaces;
using Moq;
using NUnit.Framework;

namespace KelloWebTests
{
    [TestFixture]
    public class BoardsControllerTests
    {
        private Mock<IBoardService> _service;

        [SetUp]
        public void Init()
        {
            _service = new Mock<IBoardService>();
        }

        [Test]
        public void IndexShouldReturnAViewResult()
        {
            _service.Setup(s => s.GetBoards()).Returns(new List<Board>());
            BoardsController controller = new BoardsController(_service.Object);

            var result = controller.Index() as ViewResult;

            Assert.That(result, Is.Not.Null);
        }
    }    
}
