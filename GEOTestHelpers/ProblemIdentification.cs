using AutomationHelpers;
using System;
using System.Collections.Generic;
using System.Windows.Automation;


namespace GEOHelpers
{
    public static class ProblemIdentification
    {       

        public static void Open(Technology technology)
        {
            ElementInteract.MoveToAndClick("OptimizationRibbonTab", GEOLauncher.AutomationElement);
            ElementInteract.MoveToAndClick(" problems ", GEOLauncher.AutomationElement);

            switch (technology)
            {
                case Technology.UMTS:

                    ElementInteract.InvokeElement("UMTS Problem Identification", GEOLauncher.AutomationElement);

                    break;
                default:
                    break;
            }            
        }
        public static void Edit()
        {
            ElementInteract.InvokeElement("Edit", AutomationElement);
        }

        public static void Next()
        {
            ElementInteract.InvokeElement("NextButton", AutomationElement);
        }

        public static AutomationElement AutomationElement
        {
            get
            {
                return ElementFinder.GetParentAutomationElement(ElementFinder.GetElementbyName("UMTS Problem Identification Wizard"));
            }
        }

        public static bool IsVisible
        {
            get
            {
                return !AutomationElement.Current.IsOffscreen;
            }
        }

    }
}
