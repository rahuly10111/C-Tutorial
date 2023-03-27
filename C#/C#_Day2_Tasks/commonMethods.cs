using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day2_Tasks
{
    public class commonMethods
    {
        public static void printName()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" ----> Task-1 Print Name <---- ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("Enter Your Name : ");
            string userName = Convert.ToString(Console.ReadLine());
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(userName);
            }
        }

        public static void printNumbers() {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" ----> Task-2 Print Even Numbers <---- ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Task 2");
            Console.WriteLine("Even Number Between 0 and 50 - As per the Condition");
            Console.Write(" (");
            for (int i = 1; i < 50; i++) 
            {
                if (i%2==0)
                {
                    if (i%10==2 )
                    {
                        continue;
                    }
                    Console.Write(" " +i);
                }
            }
            Console.Write(" )");
        }

        public static void negativenumber() {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" ----> Task-3 Negative Number <---- ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("Enter the Length of Array : ");
            int arrayLenght = Convert.ToInt16(Console.ReadLine());

            int[] userarray = new int[arrayLenght];
            for(int i = 0; i<arrayLenght; i++)
            {
                Console.Write("Element - {0} : ", i);
                userarray[i] = Convert.ToInt32(Console.ReadLine()); 
            }
            Console.Write(" Array : { ");
            for (int i = 0; i < arrayLenght; i++)
            {
                Console.Write("{0} " , userarray[i] );
            }
            Console.Write("} \n");
            int totalNegitiveElement= userarray.Count(n => n < 0);
            Console.WriteLine( "Total Number of Negative Element in Array are " +totalNegitiveElement);

        }

        public static void maxMinNumber() {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" ----> Task-4 max Min Number <---- ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("Enter the Length of Array : ");
            int arrayLenght = Convert.ToInt16(Console.ReadLine());
            int[] userarray = new int[arrayLenght];
            for (int i = 0; i < arrayLenght; i++)
            {
                Console.Write("Element - {0} : ", i);
                userarray[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.Write(" Array : { ");
            for (int i = 0; i < arrayLenght; i++)
            {
                Console.Write("{0} ", userarray[i]);
            }
            Console.Write("} \n");
            int maximumElement = userarray.Max();
            int  minimumElement = userarray.Min();
            Console.WriteLine( "Maximum Value almong all the element is " +maximumElement);
            Console.WriteLine("Minimum Value almong all the element is " + minimumElement);
        }

        public static void oddEvenNumber(){
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" ----> Task-5 Odd Even Number <---- ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("Enter the Length of Array : ");
            int arrayLenght = Convert.ToInt16(Console.ReadLine());
            int[] userarray = new int[arrayLenght];
            for (int i = 0; i < arrayLenght; i++)
            {
                Console.Write("Element - {0} : ", i);
                userarray[i] = Convert.ToInt32(Console.ReadLine());
            }
            int odd = 0;
            int even = 0;
            Console.Write(" Array : { ");
            for (int i = 0; i < arrayLenght; i++)
            {
                Console.Write("{0} ", userarray[i]);
                if (userarray[i] % 2 == 0)
                {
                    even++;
                }
                else
                {
                    odd++;
                }
            }
            Console.Write("} \n");
            Console.WriteLine("Total Number of Even Element in Array are " + even);
            Console.WriteLine("Total Number of Odd Element in Array are " + odd);
        }

        public static void intstringoverloading() {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" ----> Task-6 Int string Overloading <---- ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter Your Name : ");
            string userName=Convert.ToString( Console.ReadLine());
            Console.Write("Enter your Age : ");
            int userAge=Convert.ToInt16( Console.ReadLine());
            Print(userName);
            Print(userAge);
            Print(userName, userAge);
        }
        public static void Print(string userName)
        {
            Console.WriteLine("--> Your Name is " + userName);
        }
        public static void Print(string userName, int userAge)
        {
            Console.WriteLine("--> Your Name is " + userName +" and You are " + userAge+ " Year Old");

        }
        public static void Print(int userAge)
        {
            Console.WriteLine("--> Your age is " + userAge);
        }

        public static void sumOfInteger()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" ----> Task-7 Sum Of Integer <---- ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("Enter the First Integer : ");
            int first =Convert.ToInt16( Console.ReadLine());
            Console.Write("Enter the Second Integer : ");
            int second= Convert.ToInt16( Console.ReadLine());
            Console.Write("Enter the Third Integer : ");
            int third = Convert.ToInt16( Console.ReadLine());
            Add(first, second);
            Add(first, second,third);
            Console.Write("Enter the First Integer : ");
            double doublefirst = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the Second Integer : ");
            double doublesecond = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the Third Integer : ");
            double doublethird = Convert.ToDouble(Console.ReadLine());
            Add(doublefirst, doublesecond, doublethird);

        }
        public static void  Add(int first, int second)
        {
            Console.WriteLine( "--> "+first + " + " + second +" = "+  (first+second));
        }
        public static void Add(int first, int second,int third)
        {
            Console.WriteLine("--> " + first + " + " + second + " + "+ third + " = " + (first + second+third));
        }
        public static void Add(double doublefirst, double doublesecond, double doublethird)
        {
            Console.WriteLine("--> " + doublefirst + " + " + doublesecond + " + " + doublethird + " = " + (doublefirst + doublesecond + doublethird));
        }





    }
}
