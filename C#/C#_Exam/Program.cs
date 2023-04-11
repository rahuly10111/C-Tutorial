using FluentAssertions.Common;
using FluentAssertions.Equivalency;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
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
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" Kindly,\n Type 1 to Add New Detail : , \n Type 2 to Delete Data :");
                Console.Write("Type the Number as per Above Message : ");
                int collegefeature = Convert.ToInt16(Console.ReadLine());

                switch (collegefeature)

                {
                    case 1:
                        AddEmployeeDetail(employeeDetailList);
                        break;
                    case 2:
                        FileDataRead();
                        RemoveEmployee(employeeDetailList);
                        break;
                    default:
                        Console.WriteLine(" Only Type the Number as per Above Message ");
                        break;
                }
                Console.WriteLine("\n TO Continue Watching Tasks -- Press (3) \n");
                var input = Console.ReadLine().Trim();
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
            public double employeeMonthlySalary;
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

        public static void AddEmployeeDetail(List<EmployeeData> employeeDetailList)
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

            bool isValidName = false;
            while (!isValidName)
            {
                Console.Write(" Enter Employee Name : ");
                employeeRecordDetail.employeeName = Convert.ToString(Console.ReadLine());

                if (!NameValidation(employeeRecordDetail.employeeName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" -> Invalid name. Please enter a valid name.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    isValidName = true;
                }
            }



            bool birthDate = true;
            while (birthDate)
            {
                Console.Write(" Enter Employee Date Of Birth :  ");
                string dateofbirth = Convert.ToString(Console.ReadLine());

                try
                {
                    DateTime getBirthDate = Convert.ToDateTime(dateofbirth);
                    employeeRecordDetail.employeeDOB = DateExtensions.DateFormate(getBirthDate);

                    birthDate = false;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" -> Invalid Date Format.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
            }

             bool isgendervalid=false;
            while (!isgendervalid)
            {
                Console.WriteLine(" Please Type M for Male and F for Female ");
                Console.Write(" Enter Employee Gender : ");
                string gender = Convert.ToString(Console.ReadLine().ToLower().Trim());
                switch (gender)
                {
                    case "m":
                        employeeRecordDetail.employeeGender = "Male";
                        isgendervalid = true;
                        break;
                    case "f":
                        employeeRecordDetail.employeeGender = " Female ";
                        isgendervalid = true;
                        break;
                    default:
                        Console.WriteLine(" -> Ivalid Input  ");
                        break;
                }
            }
            


            bool isValidDesignation = false;
            while (!isValidDesignation)
            {
                Console.Write(" Enter Employee Designation : ");
                employeeRecordDetail.employeeDesignation = Convert.ToString(Console.ReadLine());

                if (!DesignationValidation(employeeRecordDetail.employeeDesignation))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" -> Invalid Designation. Please enter a valid Designation.");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else
                {
                    isValidDesignation = true;
                }
            }

            bool isStateValid = false;
            while (!isStateValid)
            {
                Console.Write(" Enter Employee State : ");
                employeeRecordDetail.employeeState = Convert.ToString(Console.ReadLine());
                if (!StringValidation(employeeRecordDetail.employeeState))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" -> Invalid State Name. Please enter a valid State Name.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    isStateValid = true;
                }
            }


            bool isCityValid = false;
            while (!isCityValid)
            {
                Console.Write(" Enter Employee City : ");
                employeeRecordDetail.employeeCity = Convert.ToString(Console.ReadLine());
                if (!StringValidation(employeeRecordDetail.employeeCity))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" -> Invalid City Name. Please enter a valid City Name .");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    isCityValid = true;
                }
            }

            bool ispostcodeValid = false;
            while (!ispostcodeValid)
            {
                Console.Write(" Enter Employee PostCode : ");
                employeeRecordDetail.employeePostCode = Convert.ToString(Console.ReadLine());
                if (!PostCodeValidation(employeeRecordDetail.employeePostCode))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" -> Invalid PostCode. Please enter a valid PostCode.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    ispostcodeValid = true;
                }
            }


            bool isPhonenoValid = false;
            while (!isPhonenoValid)
            {
                Console.Write(" Enter Employee Phone Number : ");
                employeeRecordDetail.employeePhoneNo = Convert.ToString(Console.ReadLine());
                if (!PhonenoValidation(employeeRecordDetail.employeePhoneNo))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" -> Invalid Phone Number. Please enter a valid Phone Number.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    isPhonenoValid = true;
                }
            }

            bool isEmailIdValid = false;
            while (!isEmailIdValid)
            {
                Console.Write(" Enter Employee Email ID : ");
                employeeRecordDetail.employeeEmail = Convert.ToString(Console.ReadLine());
                if (!EmailValidation(employeeRecordDetail.employeeEmail))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" -> Invalid Email ID. Please enter a valid Email ID.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    isEmailIdValid = true;
                }
            }


            bool joinDate = true;
            while (joinDate)
            {
                Console.Write(" Enter Date Of Joining : ");
                string dateOfJoin = Console.ReadLine();
                try
                {
                    DateTime getJoinDate = Convert.ToDateTime(dateOfJoin);
                    employeeRecordDetail.employeeDateOfJoining = DateExtensions.DateFormate(getJoinDate);
                    DateTime joiningdatestring = Convert.ToDateTime(employeeRecordDetail.employeeDateOfJoining);
                    DateTime birthdatestring = Convert.ToDateTime(employeeRecordDetail.employeeDOB);

                    int result = DateTime.Compare(birthdatestring, joiningdatestring);
                    if (result >= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" -> Invalid date! Date of Joining cannot be greater than or equal to Date of Birth.");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                    DateTime now = DateTime.Now;
                    var datedifference = Convert.ToInt32((now - joiningdatestring).TotalDays);
                    var yeardifference = Convert.ToDecimal(datedifference / 365.2425);
                    employeeRecordDetail.employeeTotalExperience = (double)System.Math.Round(yeardifference, 1);

                    joinDate = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    continue;
                }
            }

            bool isRemarkValid = false;
            while (!isRemarkValid)
            {
                Console.Write(" Enter Employee Remark : ");
                employeeRecordDetail.employeeRemark = Convert.ToString(Console.ReadLine());
                if (!StringValidation(employeeRecordDetail.employeeRemark))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" -> Invalid Remark. Please enter a valid Remark.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    isRemarkValid = true;
                }
            }

            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("   Enter Employee Department   ");
                Console.WriteLine(" \n Enter 1 for Development \n Enter 2 for Sales  \n Enter 3 for QA \n Enter 4 for Marketing \n Enter 5 for HR \n Enter 6 for SEO ");
                Console.Write(" Enter the Number Above Message : ");
                var userinput = Convert.ToInt16(Console.ReadLine());
                switch (userinput)
                {
                    case 1:
                        employeeRecordDetail.employeeDepartMent = Convert.ToString(EmployeeDepartMentenum.Development);
                        validInput = true;
                        break;
                    case 2:
                        employeeRecordDetail.employeeDepartMent = Convert.ToString(EmployeeDepartMentenum.Sales);
                        validInput = true;
                        break;
                    case 3:
                        employeeRecordDetail.employeeDepartMent = Convert.ToString(EmployeeDepartMentenum.QA);
                        validInput = true;
                        break;
                    case 4:
                        employeeRecordDetail.employeeDepartMent = Convert.ToString(EmployeeDepartMentenum.Marketing);
                        validInput = true;
                        break;
                    case 5:
                        employeeRecordDetail.employeeDepartMent = Convert.ToString(EmployeeDepartMentenum.HR);
                        validInput = true;
                        break;
                    case 6:
                        employeeRecordDetail.employeeDepartMent = Convert.ToString(EmployeeDepartMentenum.SEO);
                        validInput = true;
                        break;
                    default:
                        Console.WriteLine(" -> Enter Number As Per Above Message ");
                        break;
                }
            }



            try
            {
                Console.Write(" Enter Employee Monthly Salary : ");
                employeeRecordDetail.employeeMonthlySalary = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            employeeDetailList.Add(employeeRecordDetail);
            employeeDetailList = employeeDetailList.OrderByDescending(e => e.employeeMonthlySalary).ToList();
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
