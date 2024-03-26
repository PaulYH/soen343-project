using System;
using System.Globalization;
using System.IO;
using System.Collections.Generic;

public class TemperatureFileReader
{
    public List<(DateTime, double)> Temperatures { get; private set; } = new List<(DateTime, double)>();

    public void ReadFile(Stream fileStream)
    {
        try
        {
         
            if (fileStream.CanSeek)
            {
                fileStream.Position = 0;
            }

            using (StreamReader reader = new StreamReader(fileStream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                   
                    string[] parts = line.Split(',');

                   
                    if (parts.Length == 3)
                    {
                       
                        DateTime dateTime;
                        if (DateTime.TryParseExact(parts[0] + " " + parts[1], "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                        {
                         
                            string tempStr = parts[2].Replace('−', '-'); 
                            double temperature;
                            if (double.TryParse(tempStr, NumberStyles.Any, CultureInfo.InvariantCulture, out temperature))
                            {
                              
                                Temperatures.Add((dateTime, temperature));
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
