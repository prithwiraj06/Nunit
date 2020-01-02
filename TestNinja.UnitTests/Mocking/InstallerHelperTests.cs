using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private Mock<IFileDownloader> _fileDownloader;
        private InstallerHelper _installerHelper;
        [SetUp]
        public void SetUp()
        {
            _fileDownloader = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper(_fileDownloader.Object);
        }

        [Test] 
        public void DownloadInstaller_DownloadsFails_ReturnsFalse()
        {
            _fileDownloader.Setup(fd => fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();

            var result = _installerHelper.DownloadInstaller("Customer", "Installer");

            Assert.That(result, Is.False);
        }

        [Test]
        public void DownloadInstaller_DownloadsCompletes_ReturnsTrue()
        {
            var result = _installerHelper.DownloadInstaller("Customer", "Installer");

            Assert.That(result, Is.True);
        }
    }
}
