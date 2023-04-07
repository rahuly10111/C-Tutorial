using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace C__Exam
{
    internal class Program
    {


        static void Main(string[] args)
        {
            employeeData employeeRecordDetail = new employeeData();
            string fileDetail = "EmployeeData_TodayDate.json";
            SortedList mySortedList = new SortedList();

            if (File.Exists(fileDetail))
            {
                var jsonString = File.ReadAllText("EmployeeData_TodayDate.json");
                // employeeDetailList = JsonConvert.DeserializeObject<List<employeeData>>(jsonString);

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
                        addEmployeeDetail(fileDetail, mySortedList);
                        break;
                    case 2:

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


        public class employeeData
        {
            public string employeeId;
            public string employeeName;
            public DateTime employeeDOB;
            public string employeeGender;
            public string employeeDesignation;
            public string employeeState;
            public string employeeCity;
            public string employeePostCode;
            public string employeePhoneNo;
            public string employeeEmail;
            public DateTime employeeDateOfJoining;
            public double employeeTotalExperience;
            public string employeeRemark;
            public string employeeDepartMent;
            public int employeeMonthlySalary;
        }

        public enum employeeDepartMentenum
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


        public static void addEmployeeDetail(string fileDetail, SortedList mylist)
        {
            employeeData employeeRecordDetail = new employeeData();

            Console.WriteLine(" ---->  Enter Your Details  <---- ");

            do
            {
                Console.Write(" Enter Employee Id :  ");
                employeeRecordDetail.employeeId = Convert.ToString(Console.ReadLine());
            } while (!IdValidation(employeeRecordDetail.employeeId));


            do
            {
                Console.Write(" Enter Employee Name : ");
                employeeRecordDetail.employeeName = Convert.ToString(Console.ReadLine());
            } while (!NameValidation(employeeRecordDetail.employeeName));


            Console.Write(" Enter Employee Date Of Birth :  ");
            employeeRecordDetail.employeeDOB = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine(" Please Type M for Male and F for Female ");
            //do
            //{
            //    Console.Write(" Enter Employee Gender : ");
            //    employeeRecordDetail.employeeGender = Convert.ToString(Console.ReadLine());
            //} while (!GenderValidation(employeeRecordDetail.employeeGender));

            //do
            //{
            //    Console.Write(" Enter Employee Designation : ");
            //    employeeRecordDetail.employeeDesignation = Convert.ToString(Console.ReadLine());
            //} while (!DesignationValidation(employeeRecordDetail.employeeDesignation));

            //do
            //{
            //    Console.Write(" Enter Employee State : ");
            //    employeeRecordDetail.employeeState = Convert.ToString(Console.ReadLine());
            //} while (!StringValidation(employeeRecordDetail.employeeState));

            //do
            //{
            //    Console.Write(" Enter Employee City : ");
            //    employeeRecordDetail.employeeCity = Convert.ToString(Console.ReadLine());
            //} while (!StringValidation(employeeRecordDetail.employeeCity));

            //do
            //{
            //    Console.Write(" Enter Employee PostCode : ");
            //    employeeRecordDetail.employeePostCode = Convert.ToString(Console.ReadLine());
            //} while (!PostCodeValidation(employeeRecordDetail.employeePostCode));


            //do
            //{
            //    Console.Write(" Enter Employee Phone Number : ");
            //    employeeRecordDetail.employeePhoneNo = Convert.ToString(Console.ReadLine());
            //} while (!phonenoValidation(employeeRecordDetail.employeePhoneNo));


            //do
            //{
            //    Console.Write(" Enter Employee Email ID : ");
            //    employeeRecordDetail.employeeEmail = Convert.ToString(Console.ReadLine());
            //} while (!EmailValidation(employeeRecordDetail.employeeEmail));


            //Console.Write(" Enter Employee Date Of Joining : ");
            //employeeRecordDetail.employeeDateOfJoining = Convert.ToDateTime(Console.ReadLine());
            //DateTime now = DateTime.Now;

            //var datedifference = Convert.ToInt32((now - employeeRecordDetail.employeeDateOfJoining).TotalDays);
            //var yeardifference = Convert.ToDecimal(datedifference / 365.2425);
            //employeeRecordDetail.employeeTotalExperience = (double)System.Math.Round(yeardifference, 1);
            //Console.WriteLine("  "+ employeeRecordDetail.employeeName + " has " + employeeRecordDetail.employeeTotalExperience + " Years of Experiance ");

            //do
            //{
            //    Console.Write(" Enter Employee Remark : ");
            //    employeeRecordDetail.employeeRemark = Convert.ToString(Console.ReadLine());
            //} while (!StringValidation(employeeRecordDetail.employeeRemark));


            //Console.WriteLine("   Enter Employee Department   ");
            //Console.WriteLine(" \n Enter 1 for Development \n Enter 2 for Sales  \n Enter 3 for QA \n Enter 4 for Marketing \n Enter 5 for HR \n Enter 6 for SEO ");
            //Console.Write(" Enter the Number Above Message : ");
            //var userinput = Convert.ToInt16(Console.ReadLine());
            //switch (userinput)
            //{
            //    case 1:
            //        employeeRecordDetail.employeeDepartMent = Convert.ToString(employeeDepartMentenum.Development);
            //        break;
            //    case 2:
            //        employeeRecordDetail.employeeDepartMent = Convert.ToString(employeeDepartMentenum.Sales);
            //        break;
            //    case 3:
            //        employeeRecordDetail.employeeDepartMent = Convert.ToString(employeeDepartMentenum.QA);
            //        break;
            //    case 4:
            //        employeeRecordDetail.employeeDepartMent = Convert.ToString(employeeDepartMentenum.Marketing);
            //        break;
            //    case 5:
            //        employeeRecordDetail.employeeDepartMent = Convert.ToString(employeeDepartMentenum.HR);
            //        break;
            //    case 6:
            //        employeeRecordDetail.employeeDepartMent = Convert.ToString(employeeDepartMentenum.SEO);
            //        break;
            //    default:
            //        Console.WriteLine(" Enter Number As Per Above Message ");
            //        break;
            //}

          //  do
           // {
                Console.Write(" Enter Employee Monthly Salary : ");
                employeeRecordDetail.employeeMonthlySalary = Convert.ToInt16(Console.ReadLine());
           // } while (!SalaryValidation(employeeRecordDetail.employeeMonthlySalary));

            mylist.Add(employeeRecordDetail.employeeMonthlySalary, (employeeRecordDetail.employeeName, employeeRecordDetail.employeeDOB));

            string JsonConvertFile = JsonConvert.SerializeObject(mylist);
            using (StreamWriter writer = new StreamWriter(fileDetail))
            {
                writer.WriteLine(JsonConvertFile);
            }



        }

        public static bool IdValidation(string namevalidation)
        {
            if (string.IsNullOrEmpty(namevalidation))
                return false;

            Regex regex = new Regex(@"^[\d]*$",
                  RegexOptions.CultureInvariant | RegexOptions.Singleline);
            return regex.IsMatch(namevalidation);

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

            Regex regex = new Regex(@"^M?$|^F?$|^m?$|^f?$",
                  RegexOptions.CultureInvariant | RegexOptions.Singleline);
            return regex.IsMatch(gendervalidation);

        }

        public static bool EmailValidation(string emailvalidation)
        {
            if (string.IsNullOrEmpty(emailvalidation))
                return false;

            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                  RegexOptions.CultureInvariant | RegexOptions.Singleline);
            return regex.IsMatch(emailvalidation);

        }

        public static bool phonenoValidation(string phoneValidation)
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

        public static bool SalaryValidation(string salaryvalidation)
        {
            if (string.IsNullOrEmpty(salaryvalidation))
                return false;

            Regex regex = new Regex(@"(1000[0-9]|100[1-9][0-9]|10[1-9][0-9]{2}|1[1-9][0-9]{3}|[2-4][0-9]{4}|50000)",
                  RegexOptions.CultureInvariant | RegexOptions.Singleline);
            return regex.IsMatch(salaryvalidation);

        }





    }




}
