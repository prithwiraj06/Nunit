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
    public class ProductTests
    {
        private Product product;
        private Customer _customer;
        [SetUp]
        public void SetUp()
        {
            product = new Product();
            _customer = new Customer();
        }

        [Test]
        public void GetPrice_CustomerIsGoldUser_Gets30PercentDiscount()
        {
            product.ListPrice = 100;
            _customer.IsGold = true;

            var result = product.GetPrice(_customer);

            Assert.That(result, Is.EqualTo(70));
        }

        [Test]
        public void GetPrice_CustomerIsNotGoldUser_DoesNotGetAnyDiscount()
        {
            product.ListPrice = 100;
            _customer.IsGold = false;

            var result = product.GetPrice(_customer);

            Assert.That(result, Is.EqualTo(100));
        }
    }
}
