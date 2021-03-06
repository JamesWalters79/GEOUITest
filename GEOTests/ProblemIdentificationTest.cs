﻿using NUnit.Framework;
using GEOHelpers;

namespace GEOTests
{
    [TestFixture]
    public class ProblemIdentificationTest
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
        public void OpenPIW()
        {
            NeighborPlanning.Open(Technology.UMTS);
            Assert.True(NeighborPlanning.IsVisible);
        }
    }
}
