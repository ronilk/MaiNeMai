using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace MaiNeMai
{
    public class Logger
    {
        private static object locker = new object();

        public static void LogMessage(string message)
        {            
            lock (locker)
            {
                using (StreamWriter sw = new StreamWriter(@"F:\WinAppProjects\MaiNeMai\maiLog.txt", true))
                {
                    sw.WriteLine(message + " " + DateTime.Now.ToString());
                }
            }
        }
    }
}
