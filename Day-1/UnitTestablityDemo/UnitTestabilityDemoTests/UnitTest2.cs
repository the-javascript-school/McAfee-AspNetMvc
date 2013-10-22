using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GreeterMVCApp.Controllers;
using UnitTestablityDemo;
using System.Web.Mvc;

namespace UnitTestabilityDemoTests
{
    [TestClass]
    public class GreetingControllerTest
    {
        [TestMethod]
        public void Returns_Morning_View_Before_12_Noon()
        {
            //Arrange
            var timerService = new FakeTimeServiceForMorning();
            var greeter = new Greeter(timerService);
            var controller = new GreetingController(timerService, greeter);

            //Act
            var result = (ViewResult) controller.Greet("magesh");

            //Assert
            Assert.IsTrue(result.ViewName.Equals("Morning"));
        }

        [TestMethod]
        public void Returns_Evening_View_After_12_Noon()
        {
            //Arrange
            var timerService = new FakeTimeServiceForEvening();
            var greeter = new Greeter(timerService);
            var controller = new GreetingController(timerService, greeter);

            //Act
            var result = (ViewResult)controller.Greet("magesh");

            //Assert
            Assert.IsTrue(result.ViewName.Equals("Evening"));
        }
    }
}
