using System;
using System.Windows.Automation;

namespace AutomationHelpers
{
    public class ElementPatterns
    {
        public static TogglePattern GetTogglePattern(AutomationElement element)
        {
            try
            {
                if (element != null)
                {
                    TogglePattern pattern;
                    pattern = element.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
                    return pattern;
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static ExpandCollapsePattern GetExpandPattern(AutomationElement element)
        {
            try
            {
                if (element != null)
                {
                    ExpandCollapsePattern pattern;
                    pattern = element.GetCurrentPattern(ExpandCollapsePattern.Pattern) as ExpandCollapsePattern;
                    return pattern;
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }


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
            catch (Exception)
            {                
                throw;
            }            
        }

        public static ValuePattern GetValuePattern(AutomationElement element)
        {
            try
            {
                if (element != null)
                {
                    ValuePattern pattern;
                    pattern = element.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                    return pattern;
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SelectionItemPattern GetSelectionItemPattern(AutomationElement element)
        {
            try
            {
                if (element != null)
                {
                    SelectionItemPattern pattern;
                    pattern = element.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
                    return pattern;
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
