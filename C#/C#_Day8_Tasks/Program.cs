using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace C__Day8_Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            employeeRecord employeeRecordDetail = new employeeRecord();
            string fileDetail = "employeeRecordDetail.json";
            List<employeeRecord> employeeDetailList = new List<employeeRecord>();

            if(File.Exists(fileDetail))
            {
                var jsonString = File.ReadAllText("employeeRecordDetail.json");
                employeeDetailList = JsonConvert.DeserializeObject<List<employeeRecord>>(jsonString);
            }
            var isout = false;
            do
            {
                Console.WriteLine(" Kindly,\n Type 1 to Add New Detail : , \n Type 2 to View Detail :");
                Console.Write("Type the Number as per Above Message : ");
                int collegefeature = Convert.ToInt16(Console.ReadLine());

                switch (collegefeature)

                {
                    case 1:
                        addemployeeDetails(fileDetail,employeeDetailList);
                        break;
                    case 2:
                        fileDataRead();
                        break;
                    
                    default:
                        Console.WriteLine(" Only Type the Number as per Above Message ");
                        break;
                }
                Console.WriteLine("\n TO Continue Watching Features -- Press (y) \n");
                var input = Console.ReadLine();
                if (input.ToLower() == "y")
                {
                    isout = true;
                }
                else
                {
                    isout = false;

                }

            } while (isout);

           
           
            
        }

        public class employeeRecord
        {
            public string employeeFirstName;
            public string employeeLastName;
            public string employeeGender;
            public string employeeEmailId;
            public int employeePhoneNumber;
            public int employeeDesignation;
            public string employeeSalary;
        }

        public enum employeeDesignation
        {
            Developer=1,
            QA=2,
            PM=3,
            BA=4
        }

        public static void addemployeeDetails(string fileDetail, List<employeeRecord> employeeDetailList)
        {
            Console.WriteLine(" ---->  Enter Your Details Here  <---- ");
            employeeRecord employeeRecordDetail = new employeeRecord();
            do
            {
                Console.Write(" Enter Your First Name : ");
                employeeRecordDetail.employeeFirstName = Convert.ToString(Console.ReadLine());
            } while (!NameValidation(employeeRecordDetail.employeeFirstName));
           
            do
            {
                Console.Write(" Enter Your Last Name : ");
                employeeRecordDetail.employeeLastName = Convert.ToString(Console.ReadLine());
            }while(!NameValidation(employeeRecordDetail.employeeLastName));

            do
            {
                Console.Write(" Enter Your Gender : ");
                employeeRecordDetail.employeeGender = Convert.ToString(Console.ReadLine());
            } while(!GenderValidation(employeeRecordDetail.employeeGender));
           


            Console.Write(" Enter Your Email Id : ");
            employeeRecordDetail.employeeEmailId = Convert.ToString(Console.ReadLine());
            EmailValidation(employeeRecordDetail.employeeEmailId);




            Console.Write(" Enter Your Phone Number : ");
            employeeRecordDetail.employeePhoneNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" \n Enter 1 for De \n Enter 2 for QA  \n Enter 3 for PM \n Enter 4 for BA");
            Console.Write(" Enter the Number Above Message : ");
            var userinput=Convert.ToInt16(Console.ReadLine());
            switch (userinput)
            {
                case 1:
                    employeeRecordDetail.employeeDesignation = (int)employeeDesignation.Developer;
                    break;
                case 2:
                    employeeRecordDetail.employeeDesignation = (int)employeeDesignation.QA;
                    break;
                case 3:
                    employeeRecordDetail.employeeDesignation = (int)employeeDesignation.PM;
                    break;
                case 4:
                    employeeRecordDetail.employeeDesignation = (int)employeeDesignation.BA;
                    break;
            }

            do
            {
                Console.Write(" Enter Your Salary : ");
                employeeRecordDetail.employeeSalary = Convert.ToString(Console.ReadLine());
            } while(!SalaryValidation(employeeRecordDetail.employeeSalary));

            
            
                employeeDetailList.Add( employeeRecordDetail);
            
          

            
            string JsonConvertFile = JsonConvert.SerializeObject(employeeDetailList);
            using (StreamWriter writer = new StreamWriter(fileDetail))
            {
                writer.WriteLine(JsonConvertFile);
            }
            //File.AppendAllText(fileDetail, JsonConvertFile);
        }

        public static bool NameValidation(string namevalidation)
        {

            if (string.IsNullOrEmpty(namevalidation))
                return false;

            Regex regex = new Regex(@"^[A-Z][a-zA-Z]*$",
                  RegexOptions.CultureInvariant | RegexOptions.Singleline);
            return regex.IsMatch(namevalidation);

        }

        public static bool GenderValidation(string gendervalidation)
        {

            if (string.IsNullOrEmpty(gendervalidation))
                return false;

            Regex regex = new Regex(@"^Male?$|^Female?$|^male?$|^female?$",
                  RegexOptions.CultureInvariant | RegexOptions.Singleline);
            return regex.IsMatch(gendervalidation);

        }

        public static bool SalaryValidation(string salaryvalidation)
        {

            if (string.IsNullOrEmpty(salaryvalidation))
                return false;

            Regex regex = new Regex(@"(1000[0-9]|100[1-9][0-9]|10[1-9][0-9]{2}|1[1-9][0-9]{3}|[2-4][0-9]{4}|5000)",
                  RegexOptions.CultureInvariant | RegexOptions.Singleline);
            return regex.IsMatch(salaryvalidation);

        }

        public static bool EmailValidation(string emailvalidation)
        {

            if (string.IsNullOrEmpty(emailvalidation))
                return false;

            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                  RegexOptions.CultureInvariant | RegexOptions.Singleline);
            return regex.IsMatch(emailvalidation);

        }

        public static string fileDataRead()
        {
            if (File.Exists("employeeRecordDetail.json"))
            {
                var jsonString = File.ReadAllText("employeeRecordDetail.json");
                var employees = JsonConvert.DeserializeObject<List<employeeRecord>>(jsonString);
                foreach (var employee in employees) {
                    
                    return $" --> Your Name is {employee.employeeFirstName} , You are {employee.employeeLastName} Year Old and You Live in {employee.employeeGender} Which has Population Of {employee.employeeEmailId} .";
                }
                return "";
            }
            else
            {
                return $" File Don't Exists ";
            }
        }


    }
}

