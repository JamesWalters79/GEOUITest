using System;
using System.Diagnostics;
using System.Windows.Automation;

namespace AutomationHelpers
{
    public class Launcher
    {
        private static Process proc = new Process();
   

        public static void LaunchExecutable(string path)
        {
            proc.StartInfo.FileName = path;            
            proc.Start();
        }

        public static bool CloseAllExecutableInstances(string exeName)
        {
            try
            {
                foreach (Process exe in Process.GetProcessesByName(exeName))
                {
                    exe.Kill();                   
                }
                return true;

            }
            catch (Exception)
            {
                return false;
            }         
        }

    }
}
