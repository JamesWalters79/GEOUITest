using AutomationHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            ElementInteract.AddToSelectionElement(TimeRangeTab);

            ElementInteract.InvokeElement("EditTimePeriodButton", TimeRangeTab);

            AutomationElement editTimePeriodWindow = ElementFinder.GetElementbyName("Edit Time Period", AutomationElement);
            AutomationElement timePeriodFilterParent = ElementFinder.GetElementbyAutomationId("TimePeriodFilterItemEditorControl", editTimePeriodWindow);

            ElementInteract.AddToSelectionElement("UseSpecificDatesRadioButton", timePeriodFilterParent);

            ElementInteract.SetTextValue("SpecificStartDateTextBox", timePeriodFilterParent, start);

            ElementInteract.SetTextValue("SpecificStartDateTextBox", timePeriodFilterParent, end);

            ElementInteract.InvokeElement("OkButton", editTimePeriodWindow);
        }

        public static void SetCells(CellSelection selectBy, CellVariable cellVariable)
        {
            string listItemContains = string.Empty;

            switch (cellVariable)
            {
                case CellVariable.DocumentBounds:
                    listItemContains = "Document";
                    break;
                case CellVariable.LoadedDataBounds:
                    listItemContains = "Loaded";
                    break;
                case CellVariable.NetworkBounds:
                    listItemContains = "Network";
                    break;
                default:
                    break;
            }

            ElementInteract.AddToSelectionElement(UMTSCellsTab);

            switch (selectBy)
            {
                case CellSelection.Variable:

                    ElementInteract.AddToSelectionElement("Use a variable", UMTSCellsTab);
                    ElementInteract.ExpandElement(ElementFinder.GetElementbyType(ControlType.ComboBox, UMTSCellsTab));

                    foreach (AutomationElement listItem in ElementFinder.GetAllDescendantElementsByType(ControlType.ListItem, UMTSCellsTab))
                    {
                        if (listItem.Current.Name.Contains(listItemContains))
                        {
                            ElementInteract.AddToSelectionElement(listItem);
                        }
                    }                      

                    break;
                default:
                    break;
            }
        }

        public static void SetFrequency(PlanType planType, List<FrequencyPair> frequencyPairs)
        {
            ElementInteract.AddToSelectionElement(FrequencySelectionTab);

            switch (planType)
            {
                case PlanType.Intra:
                    ElementInteract.AddToSelectionElement("Intra-Frequency", FrequencySelectionTab);
                    break;
                case PlanType.Inter:
                    ElementInteract.AddToSelectionElement("Inter-Frequency", FrequencySelectionTab);
                    break;
                default:
                    break;
            }

            AutomationElement arfcnSelection = ElementFinder.GetElementbyName("ARFCN Selection:", FrequencySelectionTab);
            List<AutomationElement> listItems = ElementFinder.GetAllDescendantElementsByType(ControlType.List, ElementFinder.GetAllDescendantElementsByType(ControlType.List, arfcnSelection)[1]);

            foreach (FrequencyPair pair in frequencyPairs)
            {
                List<AutomationElement> subListItems = ElementFinder.GetAllDescendantElementsByType(ControlType.ListItem, listItems[pair.Source]);
                ElementInteract.ToggleElement(ElementFinder.GetElementbyType(ControlType.CheckBox,subListItems[pair.Target]));
            }
        }

        public static void SetParameters(bool forceAddition, bool forceReciprocal, string ecio, string neighborScale, string neighborScore, bool incloseProximity, string proximityDistance, bool keepDominates
            , string signalSumThreshold, bool keepLength, string targetLength, bool keepDelays, string outdoorCells, string indoorCells
            , string maxIntra, string maxIntraInter, string maxIntraIrat, string total)
        {
            ElementInteract.AddToSelectionElement(ParametersTab);

            AutomationElement forceAdditionControl = ElementFinder.GetNextSibling(ElementFinder.GetElementbyName("Reset from Defaults", ParametersTab));


        }

        public static void AddPlanToCanvas()
        {
            throw new NotImplementedException();
        }

        public static bool CheckResult(string expectedPath, string actualPath)
        {
            return AssertHelper.CompareCSV(expectedPath, actualPath);
        }

        public static void ExportPlanToCSV(string planName, string exportToPath)
        {
            throw new NotImplementedException();
        }

        public static void StartCalculation()
        {
            ElementInteract.AddToSelectionElement(StartCalculationTab);
            ElementInteract.InvokeElement("Start calculation", StartCalculationTab);
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

        public static AutomationElement MainTab
        {
            get
            {
                AutomationElement validationTabWizardControl = ElementFinder.GetElementbyAutomationId("ValidationTabWizardControl", AutomationElement);
                AutomationElement mainTabControl = ElementFinder.GetElementbyAutomationId("MainTabControl", validationTabWizardControl);
                return mainTabControl;
            }
        }

        public static AutomationElement TimeRangeTab
        {
            get
            {
                AutomationElement tab = ElementFinder.GetElementbyName("Arieso.Geo.NeighbourPlanning.ViewModels.NbrTimeRangeViewModel", MainTab);
                return tab;
            }
        }

        public static AutomationElement UMTSCellsTab
        {
            get
            {
                AutomationElement tab = ElementFinder.GetElementbyName("Arieso.Geo.NeighbourPlanning.ViewModels.NbrUmtsNetworkZoneViewModel", MainTab);
                return tab;
            }
        }

        public static AutomationElement FrequencySelectionTab
        {
            get
            {
                AutomationElement tab = ElementFinder.GetElementbyName("Arieso.Geo.NeighbourPlanning.ViewModels.NbrUmtsFrequencySelectViewModel", MainTab);
                return tab;
            }
        }

        public static AutomationElement ParametersTab
        {
            get
            {
                AutomationElement tab = ElementFinder.GetElementbyName("Arieso.Geo.NeighbourPlanning.ViewModels.NbrUmtsParametersViewModel", MainTab);
                return tab;
            }
        }

        public static AutomationElement StartCalculationTab
        {
            get
            {
                AutomationElement tab = ElementFinder.GetElementbyName("Arieso.Geo.NeighbourPlanning.ViewModels.NbrUmtsStartCalculationViewModel", MainTab);
                return tab;
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
            public FrequencyPair(int source, int target)
            {
                Source = source;
                Target = target;
            }

            public int Source
            {
                get;
                set;                
            }

            public int Target
            {
                get;
                set;
            }
        }

    }
}
