namespace GEOHelpers
{
    public static class LogIn
    {
        public static void Ok()
        {
            AutomationHelpers.ElementInteract.ClickButton(AutomationHelpers.ElementFinder.GetElementbyName("ariesoGEO Log In"), "GeoAreaLogInButton");            
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
