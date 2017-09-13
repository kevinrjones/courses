using System.Web;
using System.Web.Routing;
using Moq;
using NUnit.Framework;
using TaskList;
using TaskListTests.Helpers;

namespace TaskListTests.Routing
{
    [TestFixture]
    public class OutboundRoutingTests
    {
        private string GetOutboundUrl(object routeValues)
        {
            // Get route configuration and mock request context
            var routes = new RouteCollection();
            routes.RegisterRoutes();
            var mockHttpContext = new Mock<HttpContextBase>();
            var mockRequest = new Mock<HttpRequestBase>();
            var fakeResponse = new FakeResponse();
            mockHttpContext.Setup(x => x.Request).Returns(mockRequest.Object);
            mockHttpContext.Setup(x => x.Response).Returns(fakeResponse);
            mockRequest.Setup(x => x.ApplicationPath).Returns("/");

            // Generate the outbound URL
            var ctx = new RequestContext(mockHttpContext.Object, new RouteData());
            return routes.GetVirtualPath(ctx, new RouteValueDictionary(routeValues))
                .VirtualPath;
        }

        [Test]
        public void ActionWithSpecificControllerAndAction()
        {
            Assert.AreEqual("/", GetOutboundUrl(new
            {
                controller = "List",
                action = "Index",
            }));
        }

        [Test]
        public void GivenACorrectRoutesCollection_WhenIAskToCreateAUrlForANewListItem_ThenIGetTheCorrectUrl()
        {
            Assert.AreEqual("/List/New", GetOutboundUrl(new
                                                            {
                                                                controller = "List",
                                                                action = "New",
                                                            }));
        }

    }
}