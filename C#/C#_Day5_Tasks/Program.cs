using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Net.NetworkInformation;
using System.Xml.Serialization;
using System.Xml;

namespace C__Day5_Tasks
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
                        
                       
                            Console.WriteLine(" ---->  Enter Your Details Here  <---- ");
                            Console.Write("Enter Your Name : ");
                            string userName=Convert.ToString( Console.ReadLine());
                            Console.Write("Enter Your Age  "+userName +" : ");
                            int userAge= Convert.ToInt16(Console.ReadLine());
                            Console.Write("Enter Your City : ");
                            string userCityName=Convert.ToString( Console.ReadLine());
                            Console.Write("Enter the Population of " + userCityName + " : ");
                            int userCityPopulation=Convert.ToInt32(Console.ReadLine());
                            Person person = new Person
                            {
                                Name = userName,
                                Age = userAge,
                                City = new City
                                {
                                    CityName = userCityName,
                                    Citypopulation = userCityPopulation
                                }
                            };
                            string file="personData.json";
                            string jsonConverttofile=JsonConvert.SerializeObject(person);
                            File.WriteAllText(file, jsonConverttofile);
                            Program deserial=new Program();
                            Console.WriteLine(deserial.ToString());
                            var xmlserializer = new XmlSerializer(typeof(Person));
                            var stringWriter = new StringWriter();
                            using (var writer = XmlWriter.Create("PersonData.xml"))
                            { xmlserializer.Serialize(writer, person); }
                            Console.ReadLine();


                           
        }
        public override string ToString()
        {
            
            if (File.Exists("personData.json"))
            {
                string texts = File.ReadAllText("personData.json");
                Person personData = JsonConvert.DeserializeObject<Person>(texts);
                return $" --> Your Name is {personData.Name} , You are {personData.Age} Year Old and You Live in {personData.City.CityName} Which has Population Of {personData.City.Citypopulation} .";
            }
            else
            {
                return $" File Don't Exists ";
            }

        }

    }


     public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public City City { get; set; }

      
    }
    public class City
    {
        public string CityName { get; set; }

        public int Citypopulation { get; set; }
    }

}