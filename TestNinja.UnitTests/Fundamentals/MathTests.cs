using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.Fundamentals
{
    [TestFixture]
    public class MathTests
    {
        private Math _math;
        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]
        public void Add_WhenCalledShouldReturnSumOfArguments()
        {
            var result = _math.Add(1, 2);
            Assert.That(result, Is.EqualTo(3));
        }
        [Test]
        [TestCase(2,1,2)]
        [TestCase(1,2,2)]
        [TestCase(2,2,2)]
        public void Max_WhenCalled_ReturnGreatestArgument(int a, int b, int expected)
        {            
            var result = _math.Max(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetOddNumbers_WhenLimitIsPositive_ReturnsOddNumbersUptoLimit()
        {
            var result = _math.GetOddNumbers(5);

            // General
            Assert.That(result, Is.Not.Empty);

            // Specific
            Assert.That(result, Does.Contain(1));
            Assert.That(result, Does.Contain(3));
            Assert.That(result, Does.Contain(5));

            // For arrays and collection
            Assert.That(result, Is.EquivalentTo(new int[] { 1, 3, 5 }));

            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.Unique);
        }
    }
}
