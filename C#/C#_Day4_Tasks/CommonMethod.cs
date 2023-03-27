using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace C__Day4_Tasks
{
    internal class CommonMethod
    {
        public static void calculater()
        {
            try {
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
                        addition(firstNumberforCalculation, secondNumberforCalculation);
                        break;
                    case "-":
                        subtraction(firstNumberforCalculation,secondNumberforCalculation);
                        break;
                    case "*":
                        Multiply(firstNumberforCalculation, secondNumberforCalculation);
                        break;
                    case "/":
                        if (secondNumberforCalculation!=0)
                        {
                            division(firstNumberforCalculation, secondNumberforCalculation);
                        }
                        else
                        {
                            Console.WriteLine("Denominator Can't be Zero");
                        }
                        break;
                     default: Console.WriteLine("Please Enter any one Operator as per above Message");
                        break;
                }
            } catch (Exception e) { 
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        public static void addition(double firstnumber, double secondnumber ) {
            Console.WriteLine( " ----> " + firstnumber + " + " + secondnumber + " = " +(firstnumber+secondnumber));
        }
        public static void subtraction(double firstnumber, double secondnumber )
        {
            Console.WriteLine(" ----> " + firstnumber + " - "+ secondnumber + " = " +(firstnumber-secondnumber));
        }
        public static void Multiply(double firstnumber, double secondnumber)
        {
            Console.WriteLine(" ----> " + firstnumber + " * " + secondnumber + " = " + (firstnumber * secondnumber));
        }

        public static void division(double firstnumber, double secondnumber)
        {
            Console.WriteLine(" ----> " + firstnumber + " / " + secondnumber + " = " + (firstnumber / secondnumber));
        }


        class Student
        {
            private int studentId 
            { get; set;}
            private string studentName
            {
                get;set;
            }
            private string studentDateOfBrith
            {
                get; set;
            }
            private int studentRollno
            {
                get; set;
            }
            private string studentEmail
            {
                get;set;
            }

            private double[] studentGPA { 
                get; set; 
            }

            public Student()
            { 
                //Console.Write(" Enter the Student Id : ");
                //studentId = Convert.ToInt16(Console.ReadLine());
                //Console.Write(" Enter the Name : ");
                //studentName = Convert.ToString(Console.ReadLine());
                //Console.Write(" Enter the Date of Birth : ");
                //studentDateOfBrith= Convert.ToString(Console.ReadLine());
                //Console.Write(" Enter the RollNo : ");
                //studentRollno=Convert.ToInt16(Console.ReadLine());
                //Console.Write(" Enter the EmailId : ");
                //studentEmail=Convert.ToString(Console.ReadLine());
                studentGPA = new double[5];
                for (int i = 0; i < 5; i++)
                {
                    Console.Write(" GPA For " +(i+1)+ " Semester : " , i);
                    studentGPA[i] = Convert.ToDouble(Console.ReadLine());
                }
                findCGPA(studentGPA);


            }

        }

        public static void ClassOfStudent()
        {
            Student objStudent1 = new Student();
            Student objStudent2 = new Student();
            Student objStudent3 = new Student();
        }

        public static void findCGPA( double[] studentGPA)
        {
            double cgpa = studentGPA.Sum() / 5;
            Console.WriteLine(" CGPA Of the Student is : "+ cgpa);
        }

        




    }
}
