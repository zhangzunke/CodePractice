using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignarlrDemo
{
    public class MyLogger
    {
        public static List<LogInfo> GetLogData()
        {
            return null;
        }
    }

    public class LogInfo
    {
        public DateTime DateTime { get; set; }
        public string Content { get; set; }
        public string LogColor { get; set; }
    }
}
