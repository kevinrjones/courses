using System.Web.Routing;
using MBlogUnitTest.Extensions;
using NUnit.Framework;

namespace MBlogUnitTest.Routing
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
        public void GivenACorrectRoutesCollection_WhenIAskForAListOfShoes_ThenIGetTheIndexActionForShoes()
        {
            TestRoute("~/", new
            {
                controller = "Shoe",
                action = "Index"
            },
            "GET");
        }

        [Test]
        public void GivenACorrectRoutesCollection_WhenIAskForANewShoe_ThenIGetTheIndexActionForANewShoe()
        {
            TestRoute("~/shoe/new", new
            {
                controller = "Shoe",
                action = "new"
            },
            "GET");
        }

    }
}