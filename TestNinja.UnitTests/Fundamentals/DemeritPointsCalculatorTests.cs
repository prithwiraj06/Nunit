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
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _demeritPointsCalculator;

        [SetUp]
        public void SetUp()
        {
            _demeritPointsCalculator = new DemeritPointsCalculator();
        }

        [Test]
        [TestCase(-1)]
        [TestCase(350)]
        public void CalculateDemeritPoints_SpeedIsLessThanZeroOrSpeedIsGreaterThanZero_ThrowsException(int speed)
        {
            Assert.That(() => _demeritPointsCalculator.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void CalculateDemeritPoints_SpeedIsLessThanEqualToSpeedLimit_ReturnsZero()
        {
            var result = _demeritPointsCalculator.CalculateDemeritPoints(30);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CalculateDemeritPoints_SpeedIsGreaterThanSpeedLimit_ReturnsDemeritPoint()
        {
            var result = _demeritPointsCalculator.CalculateDemeritPoints(130);
            Assert.That(result, Is.GreaterThan(0));
        }

    }
}
