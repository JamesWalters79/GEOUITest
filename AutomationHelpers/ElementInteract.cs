using System;
using System.Windows.Automation;

namespace AutomationHelpers
{
    public class ElementInteract
    {
        public static void ClickButton(AutomationElement parent, string elementNameOrAutomationId)
        {
            try
            {
                 ElementPatterns.GetInvokePattern(ElementFinder.GetElementByNameOrAutomationId(elementNameOrAutomationId, parent)).Invoke();
            }
            catch (Exception)
            {
                throw;
            }           
        }


    }
}
