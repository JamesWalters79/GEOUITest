using NUnit.Framework;
using GEOHelpers;
using System.Collections.Generic;

namespace GEOTests
{
    [TestFixture]
    public class NeigborPlanningTest
    {
        [TestFixtureSetUp]
        public void StartGEOOpenNeighborPlanning()
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
        public void Scenario1Test()
        {
            NeighborPlanning.Open(Technology.UMTS);

            NeighborPlanning.EditTimeRange("01/01/2016 0:00:00", "01/01/2017 00:00:00");

            NeighborPlanning.SetCells(NeighborPlanning.CellSelection.Variable, NeighborPlanning.CellVariable.DocumentBounds);

            NeighborPlanning.SetFrequency(NeighborPlanning.PlanType.Inter, new List<NeighborPlanning.FrequencyPair> { new NeighborPlanning.FrequencyPair(1, 5) } );

            NeighborPlanning.StartCalculation();

            NeighborPlanning.AddPlanToCanvas();

            NeighborPlanning.ExportPlanToCSV("planame", "exportlocation");

            Assert.True(NeighborPlanning.CheckResult("expectedpath", "exportlocation"));

          }
    }
}
