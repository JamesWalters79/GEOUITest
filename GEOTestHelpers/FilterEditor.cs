using AutomationHelpers;
using System;
using System.Collections.Generic;
using System.Windows.Automation;


namespace GEOHelpers
{
    public static class FilterEditor
    {       

        public static void Open()
        {
            ElementInteract.MoveToAndClick("HomeRibbonTab",GEOLauncher.AutomationElement);
            ElementInteract.MoveToAndClick("NewFilterEditor", GEOLauncher.AutomationElement);
        }

        public static void SetFilterValue(Technology technology, Tab tabName, UMTSFilters filterName, string valueToAdd)
        {
            AutomationElement parentTab = null;
            AutomationElement filterItemTabcontrol = ElementFinder.GetElementbyAutomationId("FilterItemTabControl", AutomationElement);
            List<AutomationElement> filterTabs = ElementFinder.GetAllChildElementsByName("Arieso.Gui.Wpf.Resources.Controls.FilterEditor.FilterItemTab", filterItemTabcontrol);

            foreach (AutomationElement tab in filterTabs)
            {
                if (ElementFinder.GetElementbyType(ControlType.Text, tab).Current.Name == tabName.ToString())
                {
                    ElementInteract.MoveToAndClick(tab);
                    parentTab = tab;
                }                
            }

            AutomationElement group = ElementFinder.GetElementbyName(technology.ToString(), parentTab);
            List<AutomationElement> filters = ElementFinder.GetAllChildElementsByName("", group);
            
           


            // select filter item from the list

            // select add

            // ok
        }

        public static void Close()
        {
            ElementInteract.InvokeElement("Close", AutomationElement);
        }

        public static void ApplyToAll()
        {
            ElementInteract.InvokeElement("ApplyToAllButton", AutomationElement);
        }

        public static void ApplyAsNew()
        {
            ElementInteract.InvokeElement("ApplyAsNewButton", AutomationElement);
        }

        public static AutomationElement AutomationElement
        {
            get
            {
                return ElementFinder.GetParentAutomationElement(ElementFinder.GetElementbyName("Filter Editor"));
            }
        }

    }

    public enum UMTSFilters
    {
          CompletionCodeRanap = 4,
    }

    public enum Technology
    {
        UMTS = 5,
    }

    public enum Tab
    {
        All,
        Optional,
        AtLeastOne,
    }
}
