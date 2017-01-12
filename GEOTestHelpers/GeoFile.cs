using AutomationHelpers;
using System.Threading;
using System.Windows.Automation;

namespace GEOHelpers
{

    public class GEOFile
    {
       public static void OpenGeoDocument(string fullPath)
        {
            ElementInteract.MoveToAndClick("File", GEOLauncher.AutomationElement);
            ElementInteract.InvokeElement("OpenDocumentButton", GEOLauncher.AutomationElement);
            ElementInteract.SetTextValue("1148", AutomationElement, fullPath);
            ElementInteract.InvokeElement("Open", AutomationElement);
            Thread.Sleep(2000);
        }

        public static AutomationElement AutomationElement
        {
            get
            {
                return ElementFinder.GetParentAutomationElement(ElementFinder.GetElementbyName("Files of type:"));
            }
        }
    }
}
