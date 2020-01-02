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
    public class HtmlFormatterTests
    {

        [Test]
        public void FormatAsBold_WhenCalled_RetrunsStringWithStrongTag()
        {
            var htmlFormatter = new HtmlFormatter();
            var result = htmlFormatter.FormatAsBold("Abc");

            // Specific
            Assert.That(result, Is.EqualTo("<strong>Abc</strong>").IgnoreCase);

            // General
            Assert.That(result, Does.StartWith("<strong>").IgnoreCase);
            Assert.That(result, Does.EndWith("</strong>").IgnoreCase);
            Assert.That(result, Does.Contain("Abc").IgnoreCase);
        }
    }
}
