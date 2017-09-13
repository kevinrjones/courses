using System.Web.Routing;
using NUnit.Framework;
using RoutingTests.Extensions;

namespace RoutingTests.Routing
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
        public void GivenACorrectRoutesCollection_WhenIAskForANewTodo_ThenIGetTheNewActionForTodos()
        {
            TestRoute("~/todo/new", new
            {
                controller = "Todo",
                action = "New"
            },
                      "GET");
        }
        [Test]
        public void GivenACorrectRoutesCollection_WhenIAskForAListOfTodos_ThenIGetTheIndexActionForTodos()
        {
            TestRoute("~/", new
            {
                controller = "Todo",
                action = "Index"
            },
                      "GET");
        }
    }
}