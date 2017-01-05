using System;
using System.Windows.Automation;

namespace AutomationHelpers
{
    public class ElementPatterns
    {
        public static InvokePattern GetInvokePattern(AutomationElement element)
        {
            try
            {
                if (element != null)
                {
                    InvokePattern pattern;
                    pattern = element.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                    return pattern;
                }

                return null;
            }
            catch (Exception ex)
            {                
                throw;
            }            
        }        
    }
}
