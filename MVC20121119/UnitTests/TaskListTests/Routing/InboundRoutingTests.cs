using System.Web.Routing;
using NUnit.Framework;
using TaskListTests.Extensions;

namespace TaskListTests.Routing
{
    [TestFixture]
    public class InboundRoutingTests
    {
        private void TestRoute(string url, object expectedValues, string httpMethod)
        {
            RouteData routeData = url.GetRouteData(httpMethod);

            // Assert: Test the route values against expectations
            Assert.That(routeData, Is.Not.Null);
            var routeValueDictionaryExpected = new RouteValueDictionary(expectedValues);
            foreach (var expectedRouteValue in routeValueDictionaryExpected)
            {
                if (expectedRouteValue.Value == null)
                {
                    Assert.That(routeData.Values[expectedRouteValue.Key], Is.Null);
                }
                else
                {
                    Assert.That(expectedRouteValue.Value.ToString(), Is.EqualTo(
                        routeData.Values[expectedRouteValue.Key].ToString()).IgnoreCase);
                }
            }
        }

        [Test]
        public void GivenACorrectRoutesCollection_WhenIAskForANewTodo_ThenIGetTheEditActionForLogin()
        {
            TestRoute("~/list/new", new
                                        {
                                            controller = "List",
                                            action = "New",
                                        },
                      "GET");
        }

        [Test]
        public void GivenACorrectRoutesCollection_WhenIAskForSlash_ThenIGetTheHomeControllerIndexView()
        {
            TestRoute("~/", new
                                {
                                    controller = "List",
                                    action = "Index"
                                },
                      "GET");
        }

    }
}