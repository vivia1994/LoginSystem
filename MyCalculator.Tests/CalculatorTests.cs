using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCalculator;

namespace MyCalculator.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        //- Description allows you to specify a description for the test. 
        //- Owner specifies the owner of the test. 
        //- HostType allows you to specify the type of host the test can run on. 
        //- Priority specifies the priority at which this test should run. 
        //- Timeout specifies how long the test may run until it times out. 
        //- WorkItem allows you to specify the work item IDs the test is associated with. 
        //- CssProjectStructure represents the node in the team project hierarchy to which this test corresponds. 
        //- CssIteration represents the project iteration to which this test corresponds.
        [TestMethod]
        [TestCategory("Add")]
        [Ignore]
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
        [TestCategory("Divide")]
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
        [TestCategory("Divide")]
        public void DivideByZero()
        {
            Calculator calculator = new Calculator();

            calculator.Divide(10, 0);
        }

    }
}
