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
    public class OrderServiceTests
    {
        private Mock<IStorage> _storage = new Mock<IStorage>();
        private OrderService _orderService;

        [SetUp]
        public void SetUp()
        {
            _orderService = new OrderService(_storage.Object);
        }

        [Test]
        public void PlaceOrder_WhenCalled_CallsStoreMethod()
        {
            var order = new Order();

            _orderService.PlaceOrder(order);

            // Checking external class method is called or not
            _storage.Verify(s => s.Store(order));
        }
    }
}
