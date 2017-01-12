

using NUnit.Framework;
using GEOHelpers;

namespace GEOTests
{
    [TestFixture]
    public class ApplicationLauncherTest
    {
        
        [TestFixtureSetUp]
        public void StartGEO()
        {
            GEOLauncher.CloseAllGEOInstances();
            GEOLauncher.LaunchGEO();           
            LogIn.Ok();
        }

        [TestFixtureTearDown]
        public void StopGEO()
        {
            GEOLauncher.CloseAllGEOInstances();
        }

        [Test]
        public void Launched()
        {
            Assert.IsTrue(GEOLauncher.IsRunning);
        }

        [Test]
        public void LoginNotOpen()
        {
            Assert.IsFalse(LogIn.IsOpen);
        }

        [Test]
        public void AppWindowIsVisible()
        {
            Assert.IsTrue(GEOLauncher.IsVisible);
        }

        [Test]
        public void OpenFile()
        {
            GEOFile.OpenGeoDocument(@"C:\test.geo");
            Assert.AreEqual("GSM_Ericsson_MTN_GEBSC2_0001 - test.geo - ariesoGEO", GEOLauncher.WindowTitle);
        }
    }
}
