using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class BookingHelperTests
    {
        private Mock<IBookingRepository> _bookingRepository;
        private Booking _exsistingBooking;

        [SetUp]
        public void SetUp()
        {
            _exsistingBooking = new Booking
            {
                Id = 2,
                ArrivalDate = ArriveOn(2017, 1, 15),
                DepartureDate = DepartOn(2017, 1, 20),
                Reference = "a"
            };
            _bookingRepository = new Mock<IBookingRepository>();
        }

        [Test]
        public void OverlappingBookingsExist_BookingStartsAndFinishsBeforeExistingBooking_ReturnsEmptyString()
        {
            _bookingRepository.Setup(x => x.GetActiveBookings(1)).Returns(new List<Booking>
            {
                _exsistingBooking
            }.AsQueryable());


            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(_exsistingBooking.ArrivalDate, days: 2),
                DepartureDate = Before(_exsistingBooking.ArrivalDate),
                Reference = "a"
            }, _bookingRepository.Object);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void OverlappingBookingsExist_BookingStartBeforesAndFinishsInTheMiddleOfAnExistingBooking_ReturnsExistingBookingRefrence()
        {
            _bookingRepository.Setup(x => x.GetActiveBookings(1)).Returns(new List<Booking>
            {
                _exsistingBooking
            }.AsQueryable());


            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(_exsistingBooking.ArrivalDate, days: 2),
                DepartureDate = After(_exsistingBooking.ArrivalDate),
                Reference = "a"
            }, _bookingRepository.Object);

            Assert.That(result, Is.EqualTo(_exsistingBooking.Reference));
        }

        [Test]
        public void OverlappingBookingsExist_BookingStartBeforesAndFinishsAfterAnExistingBooking_ReturnsExistingBookingRefrence()
        {
            _bookingRepository.Setup(x => x.GetActiveBookings(1)).Returns(new List<Booking>
            {
                _exsistingBooking
            }.AsQueryable());


            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(_exsistingBooking.ArrivalDate),
                DepartureDate = After(_exsistingBooking.DepartureDate),
                Reference = "a"
            }, _bookingRepository.Object);

            Assert.That(result, Is.EqualTo(_exsistingBooking.Reference));
        }

        [Test]
        public void OverlappingBookingsExist_BookingStartAndFinishsInMiddleOfAnExistingBooking_ReturnsExistingBookingRefrence()
        {
            _bookingRepository.Setup(x => x.GetActiveBookings(1)).Returns(new List<Booking>
            {
                _exsistingBooking
            }.AsQueryable());


            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = After(_exsistingBooking.ArrivalDate),
                DepartureDate = Before(_exsistingBooking.DepartureDate),
                Reference = "a"
            }, _bookingRepository.Object);

            Assert.That(result, Is.EqualTo(_exsistingBooking.Reference));
        }

        [Test]
        public void OverlappingBookingsExist_BookingStartInMiddleOfAnExistingBookingButFinishesAfter_ReturnsExistingBookingRefrence()
        {
            _bookingRepository.Setup(x => x.GetActiveBookings(1)).Returns(new List<Booking>
            {
                _exsistingBooking
            }.AsQueryable());


            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = After(_exsistingBooking.ArrivalDate),
                DepartureDate = After(_exsistingBooking.DepartureDate),
                Reference = "a"
            }, _bookingRepository.Object);

            Assert.That(result, Is.EqualTo(_exsistingBooking.Reference));
        }

        [Test]
        public void OverlappingBookingsExist_BookingStartAndFinishsAfterAnExistingBooking_ReturnsEmptyString()
        {
            _bookingRepository.Setup(x => x.GetActiveBookings(1)).Returns(new List<Booking>
            {
                _exsistingBooking
            }.AsQueryable());


            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = After(_exsistingBooking.DepartureDate),
                DepartureDate = Before(_exsistingBooking.DepartureDate, days: 2),
                Reference = "a"
            }, _bookingRepository.Object);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void OverlappingBookingsExist_BookingOverlapsButNewBookingIsCanclled_ReturnsEmptyString()
        {
            _bookingRepository.Setup(x => x.GetActiveBookings(1)).Returns(new List<Booking>
            {
                _exsistingBooking
            }.AsQueryable());


            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = After(_exsistingBooking.ArrivalDate),
                DepartureDate = After(_exsistingBooking.DepartureDate),
                Reference = "a",
                Status = "Cancelled"
            }, _bookingRepository.Object);

            Assert.That(result, Is.Empty);
        }

        private DateTime Before(DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(-days);
        }

        private DateTime After(DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(days);
        }

        private DateTime ArriveOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 14, 0, 0);
        }

        private DateTime DepartOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 10, 0, 0);
        }
    }
}
