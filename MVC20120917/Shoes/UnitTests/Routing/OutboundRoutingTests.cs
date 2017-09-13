using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Shoes.App_Start;
using MBlogUnitTest.Helpers;
using Moq;
using NUnit.Framework;

namespace UnitTests.Routing
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

        private static UrlHelper GetUrlHelper(string appPath = "/", RouteCollection routes = null)
        {
            if (routes == null)
            {
                routes = new RouteCollection();
                routes.RegisterRoutes();
            }

            HttpContextBase httpContext = new StubHttpContextForRouting(appPath);
            var routeData = new RouteData();
            routeData.Values.Add("controller", "defaultcontroller");
            routeData.Values.Add("action", "defaultaction");
            var requestContext = new RequestContext(httpContext, routeData);
            var helper = new UrlHelper(requestContext, routes);
            return helper;
        }

        public class StubHttpContextForRouting : HttpContextBase
        {
            private readonly StubHttpRequestForRouting _request;
            private readonly StubHttpResponseForRouting _response;

            public StubHttpContextForRouting(string appPath = "/", string requestUrl = "~/")
            {
                _request = new StubHttpRequestForRouting(appPath, requestUrl);
                _response = new StubHttpResponseForRouting();
            }

            public override HttpRequestBase Request
            {
                get { return _request; }
            }

            public override HttpResponseBase Response
            {
                get { return _response; }
            }
        }

        public class StubHttpRequestForRouting : HttpRequestBase
        {
            private readonly string _appPath;
            private readonly string _requestUrl;

            public StubHttpRequestForRouting(string appPath, string requestUrl)
            {
                _appPath = appPath;
                _requestUrl = requestUrl;
            }

            public override string ApplicationPath
            {
                get { return _appPath; }
            }

            public override string AppRelativeCurrentExecutionFilePath
            {
                get { return _requestUrl; }
            }

            public override string PathInfo
            {
                get { return ""; }
            }

            public override NameValueCollection ServerVariables
            {
                get { return new NameValueCollection(); }
            }
        }

        public class StubHttpResponseForRouting : HttpResponseBase
        {
            public override string ApplyAppPathModifier(string virtualPath)
            {
                return virtualPath;
            }
        }

        [Test]
        public void GivenACorrectRoutesCollection_WhenIAskToCreateAUrlForAListOfShoes_ThenIGetTheCorrectUrl()
        {
            Assert.AreEqual("/", GetOutboundUrl(new
                                                {
                                                    controller = "Shoe",
                                                    action = "Index",
                                                }));
        }

   }
}