using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestablityDemo;

namespace UnitTestabilityDemoTests
{
    [TestClass]
    public class GreeterTests
    {
        [TestMethod]
        public void Greeted_With_GoodMorning_When_Greeted_Before_12()
        {
            //Arrange
            var timeService = new FakeTimeServiceForMorning();
            var greeter = new Greeter(timeService);
            var name = "magesh";

            //Act
            var greetMsg = greeter.Greet(name);

            //Assert
            Assert.IsTrue(greetMsg.Contains("Good Morning"));
        }
        [TestMethod]
        public void Greeted_With_GoodEvening_When_Greeted_After_12()
        {
            //Arrange
            var timeService = new FakeTimeServiceForEvening();
            var greeter = new Greeter(timeService);
            var name = "magesh";

            //Act
            var greetMsg = greeter.Greet(name);

            //Assert
            Assert.IsTrue(greetMsg.Contains("Good Evening"));
        }
    }

    public class FakeTimeServiceForMorning : ITimeService
    {
        public DateTime GetCurrentDateTime()
        {
            return new DateTime(2013, 10, 23, 11, 0, 0);
        }
    }

    public class FakeTimeServiceForEvening : ITimeService
    {
        public DateTime GetCurrentDateTime()
        {
            return new DateTime(2013, 10, 23, 21, 0, 0);
        }
    }

}
