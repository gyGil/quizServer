/// \file ServiceLogger.cs
///
/// \class ServiceLogger
/// 
/// \brief 
/// - This source file creates an Event Log for logging actions that occur with the
///   Service Application during specific events.
///   
/// \author
/// - Marcus Rankin, Geun Young Gil, Ibrahim Naamani
/// 
/// \reference
/// - Norbert Mika: SET - Windows Mobile Programming - Modules 08.
/// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MultiChoiceService
{
    public static class ServiceLogger
    {
        /// \brief  Log
        ///
        /// \details <b>Details</b>
        /// - Static function for the Service Application to call upon for writing log messages to the 
        ///   Event Log. On first run, checks for existence of the Event Log and creates it. 
        ///
        /// \param message - <b>string</b> - Service message
        /// 
        /// \return <b>N/A</b> - N/A
        public static void Log(string message)
        {
            EventLog serviceEventLog = new EventLog();
            if (!EventLog.SourceExists("MultiChoiceEventSource"))
            {
                EventLog.CreateEventSource("MultiChoiceEventSource", "MultiChoiceEventLog");
            }
            serviceEventLog.Source = "MultiChoiceEventSource";
            serviceEventLog.Log = "MultiChoiceEventLog";
            serviceEventLog.WriteEntry(message);
        }
    }
}
