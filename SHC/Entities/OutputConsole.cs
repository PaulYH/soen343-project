using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
       public void writeToFile(string caller, string even, string status, string details)
    {
        
        string sentence = caller + " " + even + " " + status+ " " + details;
        string fileName = "OutputConsoleFile.txt";


        try
        {
            // Check if the file exists
            bool fileExists = File.Exists(fileName);

            // If the file doesn't exist, create it
            if (!fileExists)
            {
                using (StreamWriter sw = File.CreateText(fileName))
                {
                    sw.WriteLine(sentence);
                }
}
            else
{
    // If the file exists, append data to it
    using (StreamWriter sw = File.AppendText(fileName))
    {
        sw.WriteLine(sentence);
    }
}
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }


    }

    

}
