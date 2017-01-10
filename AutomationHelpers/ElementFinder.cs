using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Automation;

namespace AutomationHelpers
{
    public class ElementFinder
    {
        public static AutomationElement GetElementByNameOrAutomationId(string elementNameOrAutomationId, AutomationElement rootElement = null, int waitForSeconds = 10)
        {
            Console.WriteLine("GetElementByNameOrAutomationId " + DateTime.Now.ToLongTimeString() + " " + elementNameOrAutomationId);

            AutomationElement element = null;
                
            element = GetElementbyName(elementNameOrAutomationId, rootElement ,  waitForSeconds);

            Console.WriteLine("GetElementByNameOrAutomationId " + DateTime.Now.ToLongTimeString());

            if (element == null)
            {
                element = GetElementbyAutomationId(elementNameOrAutomationId, rootElement, waitForSeconds);
            }

            return element;
        }


        public static AutomationElement GetElementbyName(string name, AutomationElement rootElement = null, int waitForSeconds = 10)
        {

            Console.WriteLine("GetElementbyName " + DateTime.Now.ToLongTimeString() + " " + name);

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

                            Console.WriteLine("GetElementbyName " + DateTime.Now.ToLongTimeString());

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

            Console.WriteLine("GetElementbyName " + DateTime.Now.ToLongTimeString());

            return foundElement;
        }

        public static AutomationElement GetElementbyAutomationId(string automationID, AutomationElement rootElement = null, int waitForSeconds = 10)
        {
            Console.WriteLine("GetElementbyAutomationId " + DateTime.Now.ToLongTimeString() + " " + automationID);

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

                            Console.WriteLine("GetElementbyAutomationId " + DateTime.Now.ToLongTimeString());

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

            Console.WriteLine("GetElementbyAutomationId " + DateTime.Now.ToLongTimeString());

            return foundElement;                                      
        }

        public static AutomationElement GetElementbyType(ControlType controlType, AutomationElement rootElement = null, int waitForSeconds = 10)
        {
            Console.WriteLine("GetElementbyType " + DateTime.Now.ToLongTimeString());

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
                        if (element.Current.ControlType == controlType)
                        {
                            foundElement = element;

                            Console.WriteLine("GetElementbyType " + DateTime.Now.ToLongTimeString());

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

            Console.WriteLine("GetElementbyType " + DateTime.Now.ToLongTimeString());

            return foundElement;
        }

        public static List<AutomationElement> GetAllChildElementsByName(string elementName, AutomationElement rootElement = null, int waitForSeconds = 10)
        {
            Console.WriteLine("GetAllChildElementsByName " + DateTime.Now.ToLongTimeString());

            List<AutomationElement> foundElements = new List<AutomationElement>();
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
                        if (element.Current.Name == elementName)
                        {
                            foundElements.Add(element);                            
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

            Console.WriteLine("GetAllChildElementsByName " + DateTime.Now.ToLongTimeString());

            return foundElements;
        }


        public static AutomationElement GetParentAutomationElement(AutomationElement child)
        {
            Console.WriteLine("GetParentAutomationElement " + DateTime.Now.ToLongTimeString());
            
            try
            {
                if (child != null)
                {
                    TreeWalker treeWalker = TreeWalker.ControlViewWalker;

                    Console.WriteLine("GetParentAutomationElement " + DateTime.Now.ToLongTimeString());

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
