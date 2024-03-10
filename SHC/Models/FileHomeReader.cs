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

        List <String> type;
        List <String> name;
        String pathDB;
        List <String> light;
        List <String> door;
        List <String> Windwo;
        String line;
        

        List<IRoom> doors { get; set; } 

      public FileHomeReader(String path)
        {
            pathDB = path;
        }
        public void readFile()
        {
            try
            {
                string[] lines = File.ReadAllLines(pathDB);

                foreach (string line in lines)
                {
                    string[] values = line.Split(',');

                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }



    }
}
