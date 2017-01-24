using Microsoft.Test.Input;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Automation;

namespace AutomationHelpers
{
    public class ElementInteract
    {
        public static void ExpandElement(AutomationElement element)
        {
            try
            {
                AutomationElement target = element;

                if (target != null)
                {
                    ElementPatterns.GetExpandPattern(target).Expand();
                }
                else
                {
                    throw new ElementNotAvailableException("element with name or automationID " + element.Current.Name + " could not be found in ExpandElement");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void ExpandElement(string elementNameOrAutomationId, AutomationElement parent)
        {
            try
            {
                AutomationElement target = ElementFinder.GetElementByNameOrAutomationId(elementNameOrAutomationId, parent);

                if (target != null)
                {
                    ElementPatterns.GetExpandPattern(target).Expand();
                }
                else
                {
                    throw new ElementNotAvailableException("element with name or automationID " + elementNameOrAutomationId + " could not be found in ExpandElement");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void SetCheckBoxChecked(AutomationElement element, bool ischecked)
        {
            try
            {
                AutomationElement target = element;

                if (target != null)
                {
                    TogglePattern pattern = ElementPatterns.GetTogglePattern(target);

                    if (pattern.Current.ToggleState == ToggleState.On)
                    {
                        if (!ischecked)
                        {
                            ElementPatterns.GetTogglePattern(target).Toggle();
                        }
                    }

                    if (pattern.Current.ToggleState == ToggleState.Off)
                    {
                        if (ischecked)
                        {
                            ElementPatterns.GetTogglePattern(target).Toggle();
                        }
                    }
                }
                else
                {
                    throw new ElementNotAvailableException("element with name or automationID " + element.Current.Name + " could not be found in ExpandElement");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void ToggleElement(AutomationElement element)
        {
            try
            {
                AutomationElement target = element;

                if (target != null)
                {
                    ElementPatterns.GetTogglePattern(target).Toggle();
                }
                else
                {
                    throw new ElementNotAvailableException("element with name or automationID " + element.Current.Name + " could not be found in ExpandElement");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void ToggleElement(string elementNameOrAutomationId, AutomationElement parent)
        {
            try
            {
                AutomationElement target = ElementFinder.GetElementByNameOrAutomationId(elementNameOrAutomationId, parent);

                if (target != null)
                {
                    ElementPatterns.GetTogglePattern(target).Toggle();
                }
                else
                {
                    throw new ElementNotAvailableException("element with name or automationID " + elementNameOrAutomationId + " could not be found in ExpandElement");
                }

            }
            catch (Exception)
            {
                throw;
            }

        }



        public static void InvokeElement(string elementNameOrAutomationId, AutomationElement parent)
        {
            try
            {
                AutomationElement target = ElementFinder.GetElementByNameOrAutomationId(elementNameOrAutomationId, parent);

                if (target != null)
                {
                    ElementPatterns.GetInvokePattern(target).Invoke();
                }
                else
                {
                    throw new ElementNotAvailableException("element with name or automationID " + elementNameOrAutomationId + " could not be found in InvokeElement");
                }

            }
            catch (Exception)
            {
                throw;
            }           
        }

        public static void AddToSelectionElement(AutomationElement element)
        {
            try
            {
                AutomationElement target = element;

                if (target != null)
                {
                    ElementPatterns.GetSelectionItemPattern(target).AddToSelection();
                }
                else
                {
                    throw new ElementNotAvailableException("element with name or automationID " + element.Current.AutomationId + " could not be found in InvokeElement");
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        public static void AddToSelectionElement(string elementNameOrAutomationId, AutomationElement parent)
        {
            try
            {
                AutomationElement target = ElementFinder.GetElementByNameOrAutomationId(elementNameOrAutomationId, parent);

                if (target != null)
                {
                    ElementPatterns.GetSelectionItemPattern(target).AddToSelection();
                }
                else
                {
                    throw new ElementNotAvailableException("element with name or automationID " + elementNameOrAutomationId + " could not be found in InvokeElement");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void SetTextValue(string elementNameOrAutomationId, AutomationElement parent, string value)
        {
            try
            {
                MoveToAndClick(elementNameOrAutomationId, parent);
                Keyboard.Type(value);
            }
            catch (System.InvalidOperationException)
            {

                throw;
            }
        }

        public static void MoveToAndClick(string elementNameOrAutomationId, AutomationElement parent)
        {
            try
            {
                AutomationElement target = ElementFinder.GetElementByNameOrAutomationId(elementNameOrAutomationId, parent);

                if (target != null)
                {
                    Rect rect = target.Current.BoundingRectangle;
                    Mouse.MoveTo(new System.Drawing.Point((int)rect.Left + 10, (int)rect.Bottom - 10));
                    Thread.Sleep(500);
                    Mouse.Click(MouseButton.Left);
                    Thread.Sleep(500);
                }
                else
                {
                    throw new ElementNotAvailableException("element with name or automationID " + elementNameOrAutomationId + " could not be found in MoveToAndClick");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void MoveToAndClick(AutomationElement element)
        {
            try
            {

                if (element != null)
                {
                    Rect rect = element.Current.BoundingRectangle;
                    Mouse.MoveTo(new System.Drawing.Point((int)rect.Left + 10, (int)rect.Bottom - 10));
                    Thread.Sleep(500);
                    Mouse.Click(MouseButton.Left);
                    Thread.Sleep(500);
                }
                else
                {
                    throw new ElementNotAvailableException("element with name or automationID could not be found in MoveToAndClick");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
