using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using AutoMapper;
using System.ComponentModel;

namespace C__Day9_Tasks
{
    public class Program
    {
        private static string mobileNumber;

        static void Main(string[] args)
        {

            // employeeRecord employeeRecordDetail = new employeeRecord();
            // string fileDetail = "employeeRecordDetail.json";
            List<StudentEntity> StudentDetailList = new List<StudentEntity>();

            // if (File.Exists(fileDetail))
            //  {
            //    var jsonString = File.ReadAllText("StudentDetail.xml");
            //      using (StreamReader streamReader = new StreamReader(filename))
           // {
            //    students = (List<StudentEntity>)xmlserializer.Deserialize(streamReader);
          //  }
            // }
            var isout = false;
            do
            {
                Console.WriteLine(" Kindly,\n Type 1 to Add New Detail : , \n Type 2 to View Detail :");
                Console.Write("Type the Number as per Above Message : ");
                int collegefeature = Convert.ToInt16(Console.ReadLine());

                switch (collegefeature)

                {
                    case 1:
                        AddStudent(StudentDetailList);
                        break;
                    case 2:
                        ShowData();
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



        public class StudentEntity
        {
            public string studentFirstName;
            public string studentLastName;
            public string studentGender;
            public string studentEmailId;
            public string studentPhoneNo;
            public string studentAddress;

        }
        public enum studentGenderSelect
        {
            [Description("Male")]
            Male,
            [Description("Female")]
            Female,
        }

        public static void AddStudent(List<StudentEntity> StudentDetailList)
        {

            Console.WriteLine(" ---->  Enter Your Details Here  <---- ");
            StudentEntity studentRecordDetail = new StudentEntity();
            do
            {
                Console.Write(" Enter Your First Name : ");
                studentRecordDetail.studentFirstName = Convert.ToString(Console.ReadLine());
            } while (!NameValidation(studentRecordDetail.studentFirstName));

            do
            {
                Console.Write(" Enter Your Last Name : ");
                studentRecordDetail.studentLastName = Convert.ToString(Console.ReadLine());
            } while (!NameValidation(studentRecordDetail.studentLastName));

            Console.WriteLine(" \n Enter 1 for Male \n Enter 2 for Female ");
            Console.Write(" Enter the Number Above Message : ");
            var userinput = Convert.ToInt16(Console.ReadLine());
            switch (userinput)
            {
                case 1:
                    studentRecordDetail.studentGender = Convert.ToString(studentGenderSelect.Male);
                    break;
                case 2:
                    studentRecordDetail.studentGender = Convert.ToString(studentGenderSelect.Female); ;
                    break;
                default:
                    Console.WriteLine("Please Enter Number As Per Above Message");
                    break;

            }

            do
            {
                Console.Write(" Enter Your Email Id : ");
                studentRecordDetail.studentEmailId = Convert.ToString(Console.ReadLine());
            } while (!EmailValidation(studentRecordDetail.studentEmailId));

            do
            {
                Console.Write(" Enter Your Phone Number : ");
                mobileNumber = Convert.ToString(Console.ReadLine());
            }
            while (!phonenoValidation(mobileNumber));
            studentRecordDetail.studentPhoneNo = EnryptString(mobileNumber);
            //Console.WriteLine(studentRecordDetail.studentPhoneNo);

            Console.Write(" Enter Your Address : ");
            studentRecordDetail.studentAddress = Convert.ToString(Console.ReadLine());

            StudentDetailList.Add(studentRecordDetail);
            var xmlserializer = new XmlSerializer(typeof(List<StudentEntity>));
            var stringWriter = new StringWriter();
            using (var writer = XmlWriter.Create("StudentDetail.xml"))
            { xmlserializer.Serialize(writer, StudentDetailList); }

        }

        //var config = new MapperConfiguration(cfg => {
        //    cfg.CreateMap<StudentEntity, StudentViewModel>();
        //});
        //IMapper iMapper = config.CreateMapper();

        public class StudentViewModel
        {
            public string studentFirstName;
            public string studentLastName;
            public string studentGender;
            public string studentEmailId;
            public string studentPhoneNo;
            public string studentAddress;
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

        public static bool phonenoValidation(string emailvalidation)
        {

            if (string.IsNullOrEmpty(emailvalidation))
                return false;

            Regex regex = new Regex(@"^[6789]\d{9}$",
                  RegexOptions.CultureInvariant | RegexOptions.Singleline);
            return regex.IsMatch(emailvalidation);

        }

        public static string DecryptString(string encrString)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(encrString);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException)
            {
                decrypted = "";
            }
            return decrypted;
        }

        public static string EnryptString(string strEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }

        public static void ShowData()
        {
            XmlDocument xmlDoc = new XmlDocument();

            string filename = "StudentDetail.xml";

            xmlDoc.Load(filename);

            xmlDoc.Save(Console.Out);

        }

    }
}
