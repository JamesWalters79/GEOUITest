namespace GEOHelpers
{
    public static class LogIn
    {
        public static void Ok()
        {
            AutomationHelpers.ElementInteract.InvokeElement("GeoAreaLogInButton", AutomationHelpers.ElementFinder.GetElementbyName("ariesoGEO Log In"));            
        }
        public static bool IsOpen
        {
            get
            {
                if (AutomationHelpers.ElementFinder.GetElementbyName("ariesoGEO Log In") == null)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
