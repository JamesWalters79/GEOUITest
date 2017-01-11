using AutomationHelpers;
using System.Threading;
using System.Windows.Automation;

namespace GEOHelpers
{

    public class GEOLauncher
    {
        private static string fullPath = @"C:\Program Files\Arieso\ariesoGEO\Bin\ariesoGeo.exe";
        private static string exeName = "ariesoGeo";
        

        public static bool LaunchGEO()
        {
            Launcher.LaunchExecutable(fullPath);

            if (ElementFinder.GetElementbyName("ariesoGEO Log In") != null)
            {
                return true;
            }
            return false;          
        }

        public static void CloseAllGEOInstances()
        {
            Launcher.CloseAllExecutableInstances(exeName);
        }

        public static string WindowTitle
        {
            get
            {
                return ElementFinder.GetParentAutomationElement(ElementFinder.GetElementbyAutomationId("HomeRibbonTab")).Current.Name;
            }
        }

        public static AutomationElement AutomationElement
        {
            get
            {
                return ElementFinder.GetParentAutomationElement(ElementFinder.GetElementbyAutomationId("HomeRibbonTab"));
            }
        }

        public static bool IsVisible
        {
            get
            {
                return !ElementFinder.GetParentAutomationElement(ElementFinder.GetElementbyAutomationId("HomeRibbonTab")).Current.IsOffscreen;
            }
        }

        public static bool IsRunning
        {
            get
            {
                return Launcher.IsRunning(exeName);
            }
        }
    }
}
