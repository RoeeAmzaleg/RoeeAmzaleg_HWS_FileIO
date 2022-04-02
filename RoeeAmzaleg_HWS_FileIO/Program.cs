using RoeeAmzaleg_HWS_FileIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RoeeAmzaleg_HWS_FileIO
{

    public class Program
    {
        static void Main(string[] args)
        {
            //EXR 16 - Print 10 files from your computer
            string[] allFiles = Directory.GetDirectories(@"C:\3uTools", "*.*", SearchOption.AllDirectories);
            try
            {
                for (int i = 0; i < allFiles.Length; i++)
                {
                    Console.WriteLine(allFiles[i]);
                }
            }
            catch (IndexOutOfRangeException) when (allFiles.Length < 10)
            {
                Console.WriteLine("there is no 10 files !");
            }
            //EXR 17  

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Car));

            //Serialize to computer file
            using (Stream myFile = new FileStream(@"C:\MyFile\Car.txt", FileMode.Create))
            {
                Car c1 = new Car { Model = "Forester", Brand = "Subaru", Color = "Black", Year = 2022 };
                xmlSerializer.Serialize(myFile, c1);
            }
            //Deserialize from computer file
            using (Stream myFile = new FileStream(@"C:\MyFile\Car.txt", FileMode.Open))
            {
                Car ReadCarFromXml = (Car)xmlSerializer.Deserialize(myFile);
            }
            //Changing file with Xml
            using (Stream myFile = new FileStream(@"C:\MyFile\Car.txt", FileMode.Append))
            {
                Car c2 = new Car { Model = "Monza SP2", Brand = "Ferrari", Color = "Red", Year = 2022 };
                xmlSerializer.Serialize(myFile, c2);
            }
            //creating car array + Serialize to file
            using (Stream arrayOfCar = new FileStream(@"C:\MyFile\Car.txt", FileMode.Open))
            {
                XmlSerializer arrayXmlSerializer = new XmlSerializer(typeof(Car[]));
                Car[] carArray = new Car[3];
                carArray[0] = new Car { Model = "F8 Spider", Brand = "Ferrri", Color = "Yellow", Year = 2021 };
                carArray[1] = new Car { Model = "Virage", Brand = "Aston Martin", Color = "Black", Year = 2012 };
                carArray[2] = new Car { Model = "Continental GT V8", Brand = "Bentley", Color = "Blue", Year = 2022 };

                arrayXmlSerializer.Serialize(arrayOfCar, carArray);
            }
            //Deserialize from file
            using (Stream arrayOfCar = new FileStream(@"C:\MyFile\Car.txt", FileMode.Open))
            {
                Car carsReadFromFile = (Car)xmlSerializer.Deserialize(arrayOfCar);
            }

            //EXR 17 - Print files methods
        }
        public static void PrintFilesMethods(string path)
        {

           
            //FileInfo[] filesInfo = dir.GetFiles();,
            DirectoryInfo dir = new DirectoryInfo(path);
            List<FileInfo> files = dir.GetFiles().ToList();
            foreach (var item in files)
            {
                var theBigestFile = dir.GetFiles().OrderByDescending(x => x.Length).Take(3).ToList();
                var theLastUpdatedFiles = File.GetLastWriteTime(path);       
            }
        }
    }
}

