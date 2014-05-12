using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portfolio.Business;

namespace Portfolio.Common
{
    public class LogHelper
    {
        public static void LogEvent(string message)
        {
            EventLog log = EventLog.NewEventLog();
            log.EventType = "Event";
            log.Message = message;
            log.LogTimestamp = DateTime.Now;
            log.Save();
        }

        public static void LogException(Exception ex)
        {
            EventLog log = EventLog.NewEventLog();
            log.EventType = "Exception";
            log.Message = ex.ToString();
            log.LogTimestamp = DateTime.Now;
            log.Save();
        }
    }
}
