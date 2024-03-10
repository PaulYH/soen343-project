using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SHC.Entities.Room;
namespace SHC.Models
{
    public class FileHomeReader {

        String type;
        String name;
        String pathDB;
        String light;
        String door;
        String Window;
        String line;



        List<IRoom> doors { get; set; } 

      public FileHomeReader()
        {
            
        }
        public void readFile(Stream fileStream)
        {
            try
            {
                // Reset stream position to ensure reading from the beginning
                if (fileStream.CanSeek)
                {
                    fileStream.Position = 0;
                }

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        // Assuming the CSV format is known and consistent
                        // Example: Process the values here, e.g., create IRoom objects
                        // This is where you'd typically parse the values and create room objects or whatever the intended logic is
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }



    }
}
