using NUnit.Framework;
using GEOHelpers;

namespace GEOTests
{
    [TestFixture]
    public class ApplicationLauncherTest
    {
        private static bool isLaunched ;
        
        [TestFixtureSetUp]
        public void StartGEO()
        {
            isLaunched = GEOLauncher.LaunchGEO();           
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
            Assert.IsTrue(isLaunched);
        }

        [Test]
        public void LoginNotOpen()
        {
            Assert.IsFalse(LogIn.IsOpen);
        }

        [Test]
        public void WindowTitleSet()
        {
            Assert.AreEqual("UMTS_Ericsson_AirTelIndia_0014 - Document1 - ariesoGEO", GEOLauncher.WindowTitle);
        }

        [Test]
        public void AppWindowIsVisible()
        {
            Assert.IsTrue(GEOLauncher.IsVisible);
        }
    }
}
