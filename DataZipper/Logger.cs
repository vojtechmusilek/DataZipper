using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataZipper
{
    public class Logger
    {
        private string logPath { get; set; }

        public Logger(string logPath)
        {
            this.logPath = logPath;

            Log("Data Zipper started.");
        }

        public void Log(string text)
        {
            using (StreamWriter sw = new StreamWriter(logPath, true))
            {
                sw.WriteLine(GetTimestamp() + text);
            }
        }

        private string GetTimestamp()
        {
            return DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]: ");
        }
    }
}
