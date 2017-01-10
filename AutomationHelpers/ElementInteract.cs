using Microsoft.Test.Input;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Automation;

namespace AutomationHelpers
{
    public class ElementInteract
    {
        public static void InvokeElement(string elementNameOrAutomationId, AutomationElement parent)
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
                Rect rect = ElementFinder.GetElementByNameOrAutomationId(elementNameOrAutomationId, parent).Current.BoundingRectangle;
                Mouse.MoveTo(new System.Drawing.Point((int)rect.Left + 10, (int)rect.Bottom - 10));
                Thread.Sleep(500);
                Mouse.Click(MouseButton.Left);
                Thread.Sleep(500);
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
                Rect rect = element.Current.BoundingRectangle;
                Mouse.MoveTo(new System.Drawing.Point((int)rect.Left + 10, (int)rect.Bottom - 10));
                Thread.Sleep(500);
                Mouse.Click(MouseButton.Left);
                Thread.Sleep(500);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
