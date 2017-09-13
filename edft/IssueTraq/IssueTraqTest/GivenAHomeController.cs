using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using IssueRepository.Interfaces;
using IssueTraq.Controllers;
using IssueTraq.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IssueTraqTest
{
    [TestClass]
    public class GivenAHomeController
    {

        private Mock<IIssueRepository> mockIIssueRepo;

        [TestInitialize]
        public void Setup()
        {
            mockIIssueRepo = new Mock<IIssueRepository>();
        }

        [TestMethod]
        public void ShouldReturnAViewResult()
        {
            IQueryable<Entities.Issue> issues = new List<Entities.Issue>().AsQueryable();
            mockIIssueRepo.SetupGet(i => i.Entities).Returns(() => issues);
            HomeController controller = new HomeController(mockIIssueRepo.Object);
            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }
    }

}
