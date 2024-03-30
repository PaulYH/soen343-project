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

        public List<string> Type { get; set; } = new List<string>();
        public  List<string> Name {  get;  set; } = new List<string>();
        public List<int> Width { get; set; } = new List<int>();
        public List<int> Height { get; set; } = new List<int>();
        public List<int> LightQty { get; set; } = new List<int>();
        public List<int> DoorQty { get; set; } = new List<int>();
        public List<int> WindowQty { get; set; } = new List<int>();

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
                        Type.Add(values[0]);

                        switch (values[0])
                        {
                            case "Entrance":
                                Name.Add("Entrance");
                                Width.Add(1);
                                Height.Add(1);
                                LightQty.Add(int.Parse(values[1]));
                                DoorQty.Add(int.Parse(values[2]));
                                WindowQty.Add(int.Parse(values[3]));
                                break;
                            case "Garage":
                                Name.Add("Garage");

                                string[] gDimensions = values[2].Split('/');
                                Width.Add(int.Parse(gDimensions[0]));
                                Height.Add(int.Parse(gDimensions[1]));

                                LightQty.Add(int.Parse(values[3]));
                                DoorQty.Add(int.Parse(values[4]));
                                WindowQty.Add(int.Parse(values[5]));
                                break;
                            case "Backyard":
                                Name.Add("Backyard");
                                Width.Add(1);
                                Height.Add(1);
                                LightQty.Add(int.Parse(values[2]));
                                DoorQty.Add(0);
                                WindowQty.Add(0);
                                break;
                            case "CommonRoom":
                                Name.Add(values[1]);

                                string[] rDimensions = values[2].Split('/');
                                Width.Add(int.Parse(rDimensions[0]));
                                Height.Add(int.Parse(rDimensions[1]));

                                LightQty.Add(int.Parse(values[3]));
                                DoorQty.Add(int.Parse(values[4]));
                                WindowQty.Add(int.Parse(values[5]));
                                break;
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
}
