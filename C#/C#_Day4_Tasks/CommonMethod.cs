using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace C__Day4_Tasks
{
    internal class CommonMethod
    {
        public static void Calculater()
        {
            try
            {
                Console.Write("Enter the First Number : ");
                double firstNumberforCalculation = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter the Second Number : ");
                double secondNumberforCalculation = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Available Operator ('+','-','*','%','/')");
                Console.Write("Proived any One Operator from above :  ");
                String inputOperators = Convert.ToString(Console.ReadLine());
                switch (inputOperators)
                {
                    case "+":
                        Addition(firstNumberforCalculation, secondNumberforCalculation);
                        break;
                    case "-":
                        Subtraction(firstNumberforCalculation, secondNumberforCalculation);
                        break;
                    case "*":
                        Multiply(firstNumberforCalculation, secondNumberforCalculation);
                        break;
                    case "/":
                        if (secondNumberforCalculation != 0)
                        {
                            Division(firstNumberforCalculation, secondNumberforCalculation);
                        }
                        else
                        {
                            Console.WriteLine("Denominator Can't be Zero");
                        }
                        break;
                    default:
                        Console.WriteLine("Please Enter any one Operator as per above Message");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        public static void Addition(double firstnumber, double secondnumber)
        {
            Console.WriteLine(" ----> " + firstnumber + " + " + secondnumber + " = " + (firstnumber + secondnumber));
        }
        public static void Subtraction(double firstnumber, double secondnumber)
        {
            Console.WriteLine(" ----> " + firstnumber + " - " + secondnumber + " = " + (firstnumber - secondnumber));
        }
        public static void Multiply(double firstnumber, double secondnumber)
        {
            Console.WriteLine(" ----> " + firstnumber + " * " + secondnumber + " = " + (firstnumber * secondnumber));
        }

        public static void Division(double firstnumber, double secondnumber)
        {
            Console.WriteLine(" ----> " + firstnumber + " / " + secondnumber + " = " + (firstnumber / secondnumber));
        }


        public class Student
        {
            private int StudentId
            { get; set; }
            public string StudentName
            {
                get; set;
            }
            private string StudentDateOfBrith
            {
                get; set;
            }
            private int studentRollno
            {
                get; set;
            }
            private string StudentEmail
            {
                get; set;
            }

            private double[] StudentGPA
            {
                get; set;
            }

            public double StudentCGPA
            {
                get; set;
            }

            public enum Gpa
            {
                gpa1 = 1,
                gpa2 = 2,
                gpa3 = 3,
                gpa4 = 4
            }

            public Student()
            {
                Console.WriteLine("----> Add Student Detail <---- ");
                Console.Write(" Enter the Student Id : ");
                StudentId = Convert.ToInt16(Console.ReadLine());
                Console.Write(" Enter the Name : ");
                StudentName = Convert.ToString(Console.ReadLine());
                Console.Write(" Enter the Date of Birth : ");
                StudentDateOfBrith = Convert.ToString(Console.ReadLine());
                Console.Write(" Enter the RollNo : ");
                studentRollno = Convert.ToInt16(Console.ReadLine());
                do
                {
                    Console.Write(" Enter the Email Id : ");
                    StudentEmail = Convert.ToString(Console.ReadLine());
                }
                while (!EmailValidation(StudentEmail));


                StudentGPA = new double[5];
                Console.WriteLine(" \n Enter 1 for 1 GPA \n Enter 2 for 2 GPA  \n Enter 3 for 3 GPA \n Enter 4 for 4 GPA");
                for (int i = 0; i < 5; i++)
                {
                    Console.Write(" GPA For " + (i + 1) + " Semester : ", i);

                    var input = Convert.ToDecimal(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            StudentGPA[i] = (double)Gpa.gpa1;
                            break;
                        case 2:
                            StudentGPA[i] = (double)Gpa.gpa2;
                            break;
                        case 3:
                            StudentGPA[i] = (double)Gpa.gpa3;
                            break;
                        case 4:
                            StudentGPA[i] = (double)Gpa.gpa4;
                            break;
                        default:
                            StudentGPA[i] = (double)Gpa.gpa3;
                            break;

                    }
                }
                StudentCGPA = FindCGPA(StudentGPA);
                Console.ReadLine();
            }

            public Student(Student objectStudent1, Student objectStudent2, Student objectStudent3)
            {
                string nameOFStudents = objectStudent1.StudentName + objectStudent2.StudentName + objectStudent3.StudentName;
                Console.WriteLine(nameOFStudents);
            }


        }

        public static void ClassOfStudent()
        {
            Student objectStudent1 = new Student();
            Student objectStudent2 = new Student();
            Student objectStudent3 = new Student();
            Student objectStudent4 = new Student(objectStudent1, objectStudent2, objectStudent3);
            double studentCGPA1 = (objectStudent1.StudentCGPA);
            double studentCGPA2 = (objectStudent2.StudentCGPA);
            double studentCGPA3 = (objectStudent3.StudentCGPA);
            Findcr(studentCGPA1, studentCGPA2, studentCGPA3, objectStudent1, objectStudent2, objectStudent3);

        }

        public static double FindCGPA(double[] studentGPA)
        {
            double studentCGPA = studentGPA.Sum() / 5;
            Console.WriteLine(" CGPA Of the Student is  " + studentCGPA);
            return studentCGPA;
        }

        public static bool EmailValidation(string emailvalidation)
        {

            if (string.IsNullOrEmpty(emailvalidation))
                return false;

            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                  RegexOptions.CultureInvariant | RegexOptions.Singleline);
            return regex.IsMatch(emailvalidation);

        }

        //public static string operator +(Student objStudent1, Student objStudent2)
        //{
        //    var result = objStudent1.StudentName + " " + objStudent2.StudentName;
        //    return result;
        //}

        public static void Findcr(double cgpa1, double cgpa2, double cgpa3, Student objectStudent1, Student objectStudent2, Student objectStudent3)
        {
            string crstudent = "";
            if (cgpa1 == cgpa2 && cgpa1 > cgpa3)
            {
                crstudent = " --> " + (objectStudent1.StudentName) + " and " + (objectStudent2.StudentName) + " are CR ";
            }
            else if (cgpa1 == cgpa3 && cgpa1 > cgpa2)
            {
                crstudent = " --> " + (objectStudent1.StudentName) + " and " + (objectStudent3.StudentName) + " are CR ";
            }
            else if (cgpa2 == cgpa3 && cgpa2 > cgpa1)
            {
                crstudent = " --> " + (objectStudent2.StudentName) + " and " + (objectStudent3.StudentName) + " are CR ";
            }
            else if (cgpa1 == cgpa2 && cgpa1 == cgpa3)
            {
                crstudent = " --> " + (objectStudent1.StudentName) + " , " + (objectStudent2.StudentName) + " and " + (objectStudent3.StudentName) + " all  three  are CR ";
            }
            else
            {
                crstudent = (cgpa1 > cgpa2 && cgpa1 > cgpa3) ? (" --> " + (objectStudent1.StudentName) + " is CR ") : (cgpa2 > cgpa1 && cgpa2 > cgpa3) ? (" --> " + (objectStudent2.StudentName) + " is CR ") : (" --> " + (objectStudent3.StudentName) + " is CR ");
            }
            Console.WriteLine(crstudent);
        }





    }
}
