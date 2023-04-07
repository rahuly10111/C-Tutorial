using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__OOPs_Day1_Tasks
{
    internal class Task_2
    {
        public class RentingSystemApplication
        {
            public string NameOfAppUsed;
        }
        public class Car
        {
            public int CarId;
            public string CarCompanyName;
            public string CarModel;
            public string CarNumber;
            public int CarSeatingCapacity;
            public string CarColor;
            public static void AddCar(){}
            public static void RemoveCar() { }
            public static void SaveCar() { }
            
        }

        public class Driver
        {
            public int driverId;
            public string driverName;
            public string driverGender;
            public string driverLicence;
            public string driverMobileNo;
            public static void AddDriver() { }
            public static void RemoveDriver() { }
            public static void SaveDriver() { }
            public static void UpdateDriver() { }

        }

        public class Passenger
        {
            public int PassengerId;
            public string PassengerName;
            public string PassengerGender;
            public string PassengerMobileNo;
            public string PassengerAddress;
            public static void AddPassenger() { }
            public static void RemovePassenger() { }
            public static void SavePassenger() { }
            public static void UpdatePassenger() { }
        }


    }
}
