using System.Threading;
using System.Windows.Automation;

namespace AutomationHelpers
{
    public class ElementFinder
    {
        public static AutomationElement GetElementByNameOrAutomationId(string elementNameOrAutomationId, AutomationElement rootElement = null, int waitForSeconds = 10)
        {
            AutomationElement element = null;
                
            element = GetElementbyName(elementNameOrAutomationId, rootElement ,  waitForSeconds);

            if (element == null)
            {
                element = GetElementbyAutomationId(elementNameOrAutomationId, rootElement, waitForSeconds);
            }

            return element;
        }


        public static AutomationElement GetElementbyName(string name, AutomationElement rootElement = null, int waitForSeconds = 10)
        {              
            AutomationElement foundElement;
            foundElement = null;
            int count = 0;
            do
            {
                AutomationElementCollection elements;
                if (rootElement == null)
                {
                    elements = AutomationElement.RootElement.FindAll(TreeScope.Descendants, Condition.TrueCondition);
                }
                else
                {
                    elements = rootElement.FindAll(TreeScope.Descendants, Condition.TrueCondition);
                }

                foreach (AutomationElement element in elements)
                {
                    try
                    {
                        if (element.Current.Name == name)
                        {
                            foundElement = element;
                            return foundElement;
                        }
                    }
                    catch (System.Windows.Automation.ElementNotAvailableException)
                    {
                        Thread.Sleep(5000);//nom nom nom
                    }
                }
                Thread.Sleep(1000);
                count++;

            } while (count < waitForSeconds);
            return foundElement;
        }

        public static AutomationElement GetElementbyAutomationId(string automationID, AutomationElement rootElement = null, int waitForSeconds = 10)
        {           
            AutomationElement foundElement;
            foundElement = null;
            int count = 0;
            do
            {
                AutomationElementCollection elements;
                if (rootElement == null)
                {
                    elements = AutomationElement.RootElement.FindAll(TreeScope.Descendants, Condition.TrueCondition);
                }
                else
                {
                    elements = rootElement.FindAll(TreeScope.Descendants, Condition.TrueCondition);
                }

                foreach (AutomationElement element in elements)
                {
                    try
                    {
                        if (element.Current.AutomationId == automationID)
                        {
                            foundElement = element;
                            return foundElement;
                        }
                    }
                    catch (System.Windows.Automation.ElementNotAvailableException)
                    {
                        Thread.Sleep(5000);
                    }
                }

                Thread.Sleep(1000);
                count++;

            } while (count < waitForSeconds);
            return foundElement;                                      
        }

        public static AutomationElement GetParentAutomationElement(AutomationElement child)
        {
            try
            {
                if (child != null)
                {
                    TreeWalker treeWalker = TreeWalker.ControlViewWalker;
                    return treeWalker.GetParent(child);
                }
                return null;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

    }
}
