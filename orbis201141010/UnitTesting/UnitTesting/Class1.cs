using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

// DRY
namespace Calc
{
    namespace Add
    {
        [TestFixture]
        public class Should
        {
            Calculator.Calc calc;

            [Test]
            public void AddTwoNumbers()
            {
                // Arrange
                InitialCalculator();                

                // Act
                var result = calc.Add(23, 32);

                // Assert
                result.Should().Be(55);
            }

            private void InitialCalculator()
            {
                calc = new Calculator.Calc();
            }
        }
    }

    namespace Divide
    {
        [TestFixture]
        public class Should
        {
            [Test] 
            public void ThrowAnException()
            {
                // Arrange
                var calc = new Calculator.Calc();

                Assert.Throws<ArgumentException>(() => calc.Divide(100, 0));                

            }
        }
    }
}











