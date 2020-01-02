using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.Fundamentals
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        public void GetOutput_NumnberIsDivisibleBy3And5_ReturnsFizzBuzz()
        {
            var result = FizzBuzz.GetOutput(15);
            Assert.That(result, Is.EqualTo("FizzBuzz").IgnoreCase);
        }

        [Test]
        public void GetOutput_NumberIsDivisibleBy3_ReturnsFizz()
        {
            var result = FizzBuzz.GetOutput(3);
            Assert.That(result, Is.EqualTo("Fizz").IgnoreCase);
        }

        [Test]
        public void GetOutput_NumberIsDivisibleBy5_ReturnsBuzz()
        {
            var result = FizzBuzz.GetOutput(10);
            Assert.That(result, Is.EqualTo("Buzz").IgnoreCase);
        }

        [Test]
        public void GetOutput_NumerIsNotDivisibleBy3Or5_RetrunsTheSameNumber()
        {
            var result = FizzBuzz.GetOutput(2);
            Assert.That(result, Is.EqualTo("2").IgnoreCase);
        }

    }
}
