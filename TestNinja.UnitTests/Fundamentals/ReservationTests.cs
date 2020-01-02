using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            // Arrange
            Reservation reservation = new Reservation();

            // Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            // Assert 
            //Assert.IsTrue(result);
            Assert.That(result, Is.True);
        }
        [Test]
        public void CanBeCancelledBy_MadyByAdminUser_ReturnsTrue()
        {
            Reservation reservation = new Reservation();
            var user = new User{ IsAdmin = true };
            reservation.MadeBy = user;
            // Act
            var result = reservation.CanBeCancelledBy(user);

            // Assert 
            //Assert.IsTrue(result);
            Assert.That(result, Is.True);
        }
        [Test]
        public void CanBeCancelledBy_UserIsNotAdminAndMadyIsNotSameUser_ReturnsFalse()
        {
            Reservation reservation = new Reservation();
            var user = new User { IsAdmin = false };
            // Act
            var result = reservation.CanBeCancelledBy(user);

            // Assert 
            //Assert.IsFalse(result);
            Assert.That(result, Is.False);
        }
    }
}
