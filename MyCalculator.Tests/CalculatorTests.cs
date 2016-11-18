using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCalculator;

namespace MyCalculator.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void AddSimple()
        {
            //Arrange: initialize the environment
            Calculator calculator = new Calculator();
            //Act:perform the target action
            int sum = calculator.Add(1, 2);
            //Assert: assert that the action resulted the way you intended
            Assert.AreEqual(3,sum);
        }

        [TestMethod]
        public void DivideSimple()
        {
            //Arrange
            Calculator calculator = new Calculator();

            //Act
            int quotient = calculator.Divide(10, 5);

            //Assert
            Assert.AreEqual(2,quotient);
        }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZero()
        {
            Calculator calculator = new Calculator();

            calculator.Divide(10, 0);
        }

    }
}
