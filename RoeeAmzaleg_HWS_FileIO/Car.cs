using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RoeeAmzaleg_HWS_FileIO
{
    public class Car
    {
        private int Codan;
        protected int NumberOfSeats;
        Car[] cars = new Car[0];    
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }

        public Car()
        {

        }
        public Car(string model, string brand, string color, int year, int numberOfSeats)
        {
            Model = model;
            Brand = brand;
            Color = color;
            Year = year;
            NumberOfSeats = numberOfSeats;
        }
        public Car(string FileName)
        {

        }
        public int GetCodan()
        {
            return Codan;
        }
        public int GetNumberOfSeats()
        {
            return NumberOfSeats;
        }
        protected void ChangeNumberOfSeats(int numOfSeats)
        {
            NumberOfSeats = numOfSeats;
        }
        public static void SerializeACar(string fileName, Car car)
        {
            using (Stream stream = new FileStream(fileName, FileMode.Append))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Car)); 
                xml.Serialize(stream, car);
            }

        }
        public static void SerializeACarArray(string fileName, Car[] car)
        {
            using (Stream stream = new FileStream(fileName, FileMode.Append))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Car[]));
                xml.Serialize(stream, car);
            }

        }
        public static Car DeSerializeCar(string fileName)
        {
            using (Stream stream = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer CarXml = new XmlSerializer(typeof(Car));
                Car deSerializeCar = (Car)CarXml.Deserialize(stream);
                return deSerializeCar;
            }

        }
        public static Car[] DeSerializeCarArray(string fileName)
        {
            using (Stream stream = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer xmlArray = new XmlSerializer(typeof(Car[]));

                Car[] deSerializeCar = (Car[])xmlArray.Deserialize(stream);
                return deSerializeCar;
            }

        }
        //public bool CarCompare(string filename)
        //{


        //}
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
