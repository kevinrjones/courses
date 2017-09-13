using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;
using FluentAssertions;
using NUnit.Framework;


// BDD - Behaviour Driven Testing
// should - 
// Given, when, then

namespace CalculatorTest
{
    [TestFixture]
    public class Calculator
    {

        private SimpleCalc calc;

        [SetUp]
        public void Setup()
        {
            // Arrange
            calc = new SimpleCalc();
        }

        [Test]
        public void ShouldAddTwoNumbers()
        {

            // Act
            var result = calc.Add(23, 45);

            // Assert
            result.Should().Be(68);
        }

        [Test]
        public void ShouldBeAbleToDivideANonZeroDenominator()
        {
            var result = calc.Divide(12, 2);

            Assert.AreEqual(6, result);
        }

        [Test]
        [ExpectedException(typeof(DivideByZeroException))]
        public void ShouldThrowAnExcptionWhenIntegerDividingByZero()
        {
            var result = calc.Divide(12, 0);
        }

        [Test]
        public void ShouldThrowAnExcptionWhenDoubleDividingByZero()
        {            
            Assert.Throws<DivideByZeroException>(() => calc.Divide(12.0, 0.0));
        }

    }
}
