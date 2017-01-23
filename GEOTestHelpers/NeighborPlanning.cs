using AutomationHelpers;
using System;
using System.Collections.Generic;
using System.Windows.Automation;


namespace GEOHelpers
{
    public static class NeighborPlanning
    {       

        public static void Open(Technology technology)
        {
            ElementInteract.MoveToAndClick("OptimizationRibbonTab", GEOLauncher.AutomationElement);
            ElementInteract.MoveToAndClick(" Planning ", GEOLauncher.AutomationElement);

            switch (technology)
            {
                case Technology.UMTS:

                    ElementInteract.InvokeElement("UMTS Neighbor Planning", GEOLauncher.AutomationElement);

                    break;
                default:
                    break;
            }            
        }
        public static void EditTimeRange(string start, string end)
        {  
            ElementInteract.AddToSelectionElement("Arieso.Geo.NeighbourPlanning.ViewModels.NbrTimeRangeViewModel", MainTabControl);


        }

        public static void SetCells(CellSelection selectBy, CellVariable cellVariable)
        {
            throw new NotImplementedException();
        }

        public static void SetFrequency(PlanType planType, List<FrequencyPair> frequencyPairs)
        {
            throw new NotImplementedException();
        }

        public static void StartCalculation()
        {
            throw new NotImplementedException();
        }

        public static void ExportPlanToCsv()
        {
            throw new NotImplementedException();
        }

        public static AutomationElement AutomationElement
        {
            get
            {
                return ElementFinder.GetParentAutomationElement(ElementFinder.GetElementbyName("UMTS Problem Identification Wizard"));
            }
        }

        public static AutomationElement MainTabControl
        {
            get
            {
                AutomationElement validationTabWizardControl = ElementFinder.GetElementbyAutomationId("ValidationTabWizardControl", AutomationElement);
                AutomationElement mainTabControl = ElementFinder.GetElementbyAutomationId("MainTabControl", validationTabWizardControl);
                return mainTabControl;
            }
        }

        public static bool IsVisible
        {
            get
            {
                return !AutomationElement.Current.IsOffscreen;
            }
        }

        public enum CellVariable
        {
            DocumentBounds,
            LoadedDataBounds,
            NetworkBounds
        }

        public enum CellSelection
        {
            Variable,            
        }

        public enum PlanType
        {
            Intra,
            Inter,
        }

        public class FrequencyPair
        {
            public FrequencyPair(string source, string target)
            {
                Source = source;
                Target = target;
            }

            public static string Source
            {
                get;
                set;                
            }

            public static string Target
            {
                get;
                set;
            }
        }

    }
}
