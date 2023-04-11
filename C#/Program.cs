using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string json = "";
            string fileDetail = ConfigurationManager.AppSettings["file"];
             json = File.ReadAllText(fileDetail);
            var data = JsonConvert.DeserializeObject<Data>(json);
            // deserialize the JSON into a Data object

            Console.WriteLine("Enter a state:");
            string state = Console.ReadLine();

            bool isValidState = data.States.Any(s => s.Name == state);

            if (!isValidState)
            {
                Console.WriteLine("Error: Invalid state.");
                return; // stop further execution of the program
            }

            Console.WriteLine("Enter a city:");
            string city = Console.ReadLine();

            // check if the city entered by the user is valid based on the data in the JSON file
            bool isValidCity = data.Cities.Any(c => c.Name == city && c.State == state);

            if (!isValidCity)
            {
                Console.WriteLine("Error: Invalid city.");
                return; // stop further execution of the program
            }

            Console.WriteLine("State: " + state);
            Console.WriteLine("City: " + city);
        }

        public class Data
        {
            public State[] States { get; set; }
            public City[] Cities { get; set; }
        }

        public class State
        {
            public string Name { get; set; }
        }

        public class City
        {
            public string Name { get; set; }
            public string State { get; set; }
        }
    }
}
