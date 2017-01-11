using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Automation;

namespace AutomationHelpers
{
    public class Launcher
    {
        private static Process proc = new Process();
        private const int SW_SHOWMAXIMIZED = 3;

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public static void LaunchExecutable(string path)
        {
            proc.StartInfo.FileName = path;            
            proc.Start();
            ShowWindow(proc.MainWindowHandle, SW_SHOWMAXIMIZED);
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

        public static bool IsRunning(string exeName)
        {
            try
            {
                foreach (Process exe in Process.GetProcessesByName(exeName))
                {
                    return true;
                }
                return false;

            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
