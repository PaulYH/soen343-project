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

        public List<String> type { get; set; }
        public  List<String> name {  get;  set; }
        public List<int> width { get; set; }
        public List<int> height { get; set; }
        public List<int> sLightNum { get; set; }
        public List<int> rLightNum { get; set; }
        public List<int> sDoorNum { get; set; }
        public List<int> rDoorNum { get; set; }
        public List<int> sWindowNum { get; set; }
        public List<int> rWindowNum { get; set; }





        public FileHomeReader()
        {
            type = new List<string>();
            name = new List<string>();
            width = new List<int>();
            height = new List<int>();
            sLightNum = new List<int>();
            rLightNum = new List<int>();
            sDoorNum = new List<int>();
            rDoorNum = new List<int>();
            sWindowNum = new List<int>();
            rWindowNum = new List<int>();
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
                        type.Add(values[0]);
                        name.Add(values[1]);

                        string[] dimensions = values[2].Split('/');
                        width.Add(int.Parse(dimensions[0]));
                        height.Add(int.Parse(dimensions[1]));

                        string[] sLights = values[3].Split('/');
                        sLightNum.Add(int.Parse(sLights[0]));
                        rLightNum.Add(int.Parse(sLights[1]));

                        string[] sDoors = values[4].Split('/');
                        sDoorNum.Add(int.Parse(sDoors[0]));
                        rDoorNum.Add(int.Parse(sDoors[1]));

                        string[] sWindows = values[5].Split('/');
                        sWindowNum.Add(int.Parse(sWindows[0]));
                        rWindowNum.Add(int.Parse(sWindows[1]));
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
