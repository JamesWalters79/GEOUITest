using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Automation;

namespace AutomationHelpers
{
    public class AssertHelper
    {
       
        public static bool CompareCSV(string expected, string actual)
        {
            
            using (StreamReader f1 = new StreamReader(expected))
            using (StreamReader f2 = new StreamReader(actual))
            {

                var differences = new List<string>();

                int lineNumber = 0;

                while (!f1.EndOfStream)
                {
                    if (f2.EndOfStream)
                    {
                        differences.Add("Differing number of lines - actual has less.");
                        break;
                    }

                    lineNumber++;
                    var line1 = f1.ReadLine();
                    var line2 = f2.ReadLine();

                    if (line1 != line2)
                    {
                        differences.Add(string.Format("Line {0} differs. File 1: {1}, File 2: {2}", lineNumber, line1, line2));
                    }
                }

                if (!f2.EndOfStream)
                {
                    differences.Add("Differing number of lines - expected has less.");
                }

                if (differences.Count == 0)
                {
                    return true;
                }
                return false;
            }

        }

        

    }
}
