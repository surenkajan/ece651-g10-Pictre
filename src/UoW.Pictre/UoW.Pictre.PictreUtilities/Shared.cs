using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace UoW.Pictre.PictreUtilities
{
    public class Shared
    {
        public static void LogEvents(string eventName, string source, string writeEntry, EventLogEntryType type)
        {

            EventLog eventLog = new EventLog(eventName);
            eventLog.Source = source;
            eventLog.WriteEntry(writeEntry, type);
        }
    }
}
