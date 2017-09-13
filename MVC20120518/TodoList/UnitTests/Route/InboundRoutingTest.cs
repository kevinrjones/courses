using System.Web.Routing;
using NUnit.Framework;
using UnitTests.Extensions;

namespace UnitTests.Route
{
    [TestFixture]
    public class InboundRoutingTests
    {
        private void TestRoute(string url, object expectedValues, string httpMethod)
        {
            RouteData routeData = url.GetRouteData(httpMethod);

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
        public void GivenACorrectRoutesCollection_WhenIAskForAListOfMedia_ThenIGetTheIndexActionForMedia()
        {
            TestRoute("~/todo", new
            {
                controller = "Todo",
                action = "Index"
            },"GET");
        }


    }
}