using FluentAssertions.Common;
using FluentAssertions.Equivalency;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static C__Exam.Program;

namespace C__Exam
{
    internal class Program
    {


        static void Main(string[] args)
        {
            string fileDetail = ConfigurationManager.AppSettings["file"]; ;
            List<EmployeeData> employeeDetailList = new List<EmployeeData>();

            if (File.Exists(fileDetail))
            {
                var jsonString = File.ReadAllText(fileDetail);
                employeeDetailList = JsonConvert.DeserializeObject<List<EmployeeData>>(jsonString);

            }
            var isout = false;
            do
            {
                Console.WriteLine(" Kindly,\n Type 1 to Add New Detail : , \n Type 2 to Delete Data :");
                Console.Write("Type the Number as per Above Message : ");
                int collegefeature = Convert.ToInt16(Console.ReadLine());

                switch (collegefeature)

                {
                    case 1:
                        AddEmployeeDetail(fileDetail, employeeDetailList);
                        break;
                    case 2:
                        FileDataRead();
                        RemoveEmployee(employeeDetailList);
                        //  removeEmployee(employeeDetailList);
                        break;



                    default:
                        Console.WriteLine(" Only Type the Number as per Above Message ");
                        break;
                }
                Console.WriteLine("\n TO Continue Watching Tasks -- Press (3) \n");
                var input = Console.ReadLine();
                if (input == "3")
                {
                    isout = true;
                }
                else
                {
                    isout = false;

                }

            } while (isout);
        }


        public class EmployeeData
        {
            public int employeeId;
            public string employeeName;
            public string employeeDOB;
            public string employeeGender;
            public string employeeDesignation;
            public string employeeState;
            public string employeeCity;
            public string employeePostCode;
            public string employeePhoneNo;
            public string employeeEmail;
            public string employeeDateOfJoining;
            public double employeeTotalExperience;
            public string employeeRemark;
            public string employeeDepartMent;
            public int employeeMonthlySalary;
        }

        public enum EmployeeDepartMentenum
        {
            [Description("Development")]
            Development,
            [Description("Sales")]
            Sales,
            [Description("Marketing")]
            Marketing,
            [Description("QA")]
            QA,
            [Description("HR")]
            HR,
            [Description("SEO")]
            SEO

        }


        public static void AddEmployeeDetail(string fileDetail, List<EmployeeData> employeeDetailList)
        {
            EmployeeData employeeRecordDetail = new EmployeeData();

            Console.WriteLine(" ---->  Enter Your Details  <---- ");

            bool checkStudentID = true;
            while (checkStudentID)
            {
                try
                {
                    Console.Write(" Enter Employee Id :  ");
                    employeeRecordDetail.employeeId = Convert.ToInt16(Console.ReadLine().Trim());
                    if (UserId(employeeRecordDetail.employeeId) == true)
                    {
                        checkStudentID = true;
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            do
            {
                Console.Write(" Enter Employee Name : ");
                employeeRecordDetail.employeeName = Convert.ToString(Console.ReadLine());
            } while (!NameValidation(employeeRecordDetail.employeeName));

            bool birthDate = true;
            while (birthDate)
            {
                Console.Write(" Enter Employee Date Of Birth :  ");
                string dateofbirth = Convert.ToString(Console.ReadLine());

                try
                {
                    DateTime getBirthDate = Convert.ToDateTime(dateofbirth);
                    employeeRecordDetail.employeeDOB = DateExtensions.DateFormate(getBirthDate);
                    //  Console.WriteLine("Your Date of Joining - " + employeeRecordDetail.employeeDOB);


                    birthDate = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Date Format.");
                    continue;
                }
            }


            Console.WriteLine(" Please Type M for Male and F for Female ");
            Console.Write(" Enter Employee Gender : ");
            string gender = Convert.ToString(Console.ReadLine().ToLower().Trim());
            switch (gender)
            {
                case "m":
                    employeeRecordDetail.employeeGender = "Male";
                    break;
                case "f":
                    employeeRecordDetail.employeeGender = " Female ";
                    break;
                default:
                    Console.WriteLine(" Kindly Type M for Male and F for Female ");
                    break;
            }


            do
            {
                Console.Write(" Enter Employee Designation : ");
                employeeRecordDetail.employeeDesignation = Convert.ToString(Console.ReadLine());
            } while (!DesignationValidation(employeeRecordDetail.employeeDesignation));

            do
            {
                Console.Write(" Enter Employee State : ");
                employeeRecordDetail.employeeState = Convert.ToString(Console.ReadLine());
            } while (!StringValidation(employeeRecordDetail.employeeState));

            do
            {
                Console.Write(" Enter Employee City : ");
                employeeRecordDetail.employeeCity = Convert.ToString(Console.ReadLine());
            } while (!StringValidation(employeeRecordDetail.employeeCity));

            do
            {
                Console.Write(" Enter Employee PostCode : ");
                employeeRecordDetail.employeePostCode = Convert.ToString(Console.ReadLine());
            } while (!PostCodeValidation(employeeRecordDetail.employeePostCode));


            do
            {
                Console.Write(" Enter Employee Phone Number : ");
                employeeRecordDetail.employeePhoneNo = Convert.ToString(Console.ReadLine());
            } while (!PhonenoValidation(employeeRecordDetail.employeePhoneNo));


            do
            {
                Console.Write(" Enter Employee Email ID : ");
                employeeRecordDetail.employeeEmail = Convert.ToString(Console.ReadLine());
            } while (!EmailValidation(employeeRecordDetail.employeeEmail));



            bool joinDate = true;
            while (joinDate)
            {
                Console.Write(" Enter Date Of Joining : ");
                string dateOfJoin = Console.ReadLine();
                try
                {
                    DateTime getJoinDate = Convert.ToDateTime(dateOfJoin);
                    employeeRecordDetail.employeeDateOfJoining = DateExtensions.DateFormate(getJoinDate);
                    // Console.WriteLine("Your Date of Joining - " + employeeRecordDetail.employeeDateOfJoining);
                    DateTime datestring = Convert.ToDateTime(employeeRecordDetail.employeeDateOfJoining);
                    DateTime now = DateTime.Now;
                    var datedifference = Convert.ToInt32((now - datestring).TotalDays);
                    var yeardifference = Convert.ToDecimal(datedifference / 365.2425);
                    employeeRecordDetail.employeeTotalExperience = (double)System.Math.Round(yeardifference, 1);

                    joinDate = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Date Format.");
                    continue;
                }
            }


            do
            {
                Console.Write(" Enter Employee Remark : ");
                employeeRecordDetail.employeeRemark = Convert.ToString(Console.ReadLine());
            } while (!StringValidation(employeeRecordDetail.employeeRemark));


            Console.WriteLine("   Enter Employee Department   ");
            Console.WriteLine(" \n Enter 1 for Development \n Enter 2 for Sales  \n Enter 3 for QA \n Enter 4 for Marketing \n Enter 5 for HR \n Enter 6 for SEO ");
            Console.Write(" Enter the Number Above Message : ");
            var userinput = Convert.ToInt16(Console.ReadLine());
            switch (userinput)
            {
                case 1:
                    employeeRecordDetail.employeeDepartMent = Convert.ToString(EmployeeDepartMentenum.Development);
                    break;
                case 2:
                    employeeRecordDetail.employeeDepartMent = Convert.ToString(EmployeeDepartMentenum.Sales);
                    break;
                case 3:
                    employeeRecordDetail.employeeDepartMent = Convert.ToString(EmployeeDepartMentenum.QA);
                    break;
                case 4:
                    employeeRecordDetail.employeeDepartMent = Convert.ToString(EmployeeDepartMentenum.Marketing);
                    break;
                case 5:
                    employeeRecordDetail.employeeDepartMent = Convert.ToString(EmployeeDepartMentenum.HR);
                    break;
                case 6:
                    employeeRecordDetail.employeeDepartMent = Convert.ToString(EmployeeDepartMentenum.SEO);
                    break;
                default:
                    Console.WriteLine(" Enter Number As Per Above Message ");
                    break;
            }

            try
            {
                Console.Write(" Enter Employee Monthly Salary : ");
                employeeRecordDetail.employeeMonthlySalary = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



            employeeDetailList.Add(employeeRecordDetail);
            employeeDetailList.Sort((x, y) => x.employeeMonthlySalary.CompareTo(y.employeeMonthlySalary));
            string filePath = ConfigurationManager.AppSettings["file"];
            string JsonConvertFile = JsonConvert.SerializeObject(employeeDetailList);
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(JsonConvertFile);
            }



        }

        public static void RemoveEmployee(List<EmployeeData> employeeDetailList)
        {
            string filePath = ConfigurationManager.AppSettings["file"];

            string jsonFile = "";
            if (File.Exists(filePath))
            {
                jsonFile = File.ReadAllText(filePath);

                var employeeList = JsonConvert.DeserializeObject<List<EmployeeData>>(jsonFile);
                int userid = 0;
                bool checkID = true;
                while (checkID)
                {
                    try
                    {
                        Console.Write("Please Enter employee id : ");
                        userid = Convert.ToInt32(Console.ReadLine());
                        checkID = false;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                EmployeeData employeeRemove = employeeDetailList.FirstOrDefault(e => e.employeeId == userid);
                if (employeeRemove != null)
                {
                    employeeDetailList.Remove(employeeRemove);
                    Console.WriteLine($"Employee Record Of Id {userid} Deleted");
                }
                else
                {
                    Console.WriteLine($"Employee with ID {userid} not found.");
                }
                string JsonConvertFile = JsonConvert.SerializeObject(employeeDetailList);
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(JsonConvertFile);
                }

            }
        }
        public static bool NameValidation(string namevalidation)
        {
            if (string.IsNullOrEmpty(namevalidation))
                return false;

            Regex regex = new Regex(@"^[A-Z][a-zA-Z]*$",
                  RegexOptions.CultureInvariant | RegexOptions.Singleline);
            return regex.IsMatch(namevalidation);

        }


        public static bool EmailValidation(string emailvalidation)
        {
            if (string.IsNullOrEmpty(emailvalidation))
                return false;

            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                  RegexOptions.CultureInvariant | RegexOptions.Singleline);
            return regex.IsMatch(emailvalidation);

        }

        public static bool PhonenoValidation(string phoneValidation)
        {
            if (string.IsNullOrEmpty(phoneValidation))
                return false;

            Regex regex = new Regex(@"^[6789]\d{9}$",
                  RegexOptions.CultureInvariant | RegexOptions.Singleline);
            return regex.IsMatch(phoneValidation);

        }

        public static bool StringValidation(string stringvalidation)
        {
            if (string.IsNullOrEmpty(stringvalidation))
                return false;

            Regex regex = new Regex(@"^[a-zA-Z]+$",
                  RegexOptions.CultureInvariant | RegexOptions.Singleline);
            return regex.IsMatch(stringvalidation);

        }

        public static bool DesignationValidation(string designationvalidation)
        {
            if (string.IsNullOrEmpty(designationvalidation))
                return false;

            Regex regex = new Regex(@"^\s*[a-zA-Z.\s]+\s*$",
                  RegexOptions.CultureInvariant | RegexOptions.Singleline);
            return regex.IsMatch(designationvalidation);

        }

        public static bool PostCodeValidation(string postcodevalidation)
        {
            if (string.IsNullOrEmpty(postcodevalidation))
                return false;

            Regex regex = new Regex(@"^[0-9]{6}(?:-[0-9]{5})?$",
                  RegexOptions.CultureInvariant | RegexOptions.Singleline);
            return regex.IsMatch(postcodevalidation);

        }



        public static bool UserId(int userId)
        {
            string filePath = ConfigurationManager.AppSettings["file"];
            if (File.Exists(filePath))
            {
                var jsonString = File.ReadAllText(filePath);
                var employees = JsonConvert.DeserializeObject<List<EmployeeData>>(jsonString);
                bool idExists = employees.Any(p => p.employeeId == userId);

                if (idExists)
                {
                    Console.WriteLine($"Employee with ID {userId} already exists.");
                    return true;
                }
            }

            return false;
        }
        public static void FileDataRead()
        {
            string filePath = ConfigurationManager.AppSettings["file"];
            if (File.Exists(filePath))
            {
                var jsonString = File.ReadAllText(filePath);
                var employees = JsonConvert.DeserializeObject<List<EmployeeData>>(jsonString);
                foreach (var employee in employees)
                {

                    Console.WriteLine($"\n Employee Id : {employee.employeeId} , \n Employee  Name:  {employee.employeeName},\n Person Gender : {employee.employeeGender},\n Employee Designation : {employee.employeeDepartMent}, \n Employee Email : {employee.employeeEmail}, \n Employee DOB : {employee.employeeDOB} \n");
                }

            }
            else
            {
                Console.WriteLine($" File Don't Exists ");
            }
        }



    }

    public static class DateExtensions
    {
        public static string DateFormate(this DateTime date)
        {
            string format = "dd-MMM-yyyy";
            return date.ToString(format);
        }
    }



}
