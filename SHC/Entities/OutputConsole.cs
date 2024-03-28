using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SHC.Entities
{
    public sealed class OutputConsole
    {
        private static OutputConsole? _instance;
        public List<(DateTime datetime, string deviceId, string eventType, string eventDesc, string details)> outputLog = 
            new List<(DateTime datetime, string deviceId, string eventType, string eventDesc, string details)>();

        private OutputConsole() { }

        public static OutputConsole GetInstance()
        {
            if (_instance == null) { _instance = new OutputConsole(); }
            return _instance;
        }

        public void Log(string deviceId, string eventType, string eventDesc, string details)
        {
            /*            outputLog.Add($"Timestamp: {DateTime.Now}\n" +
                            $"Device Id: {deviceId}\n" +
                            $"Event Type: {eventType}\n" +
                            $"Event Description: {eventDesc}\n" +
                            $"Details: {details}");
            */
            outputLog.Add((DateTime.Now, deviceId, eventType, eventDesc, details));

        }
    }
}
