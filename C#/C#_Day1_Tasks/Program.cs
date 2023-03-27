using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day1_Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {

         taskinitial:
         
            Console.Write("Enter the Task Number: ");
            int taskNumber = Convert.ToInt16(Console.ReadLine());

            switch(taskNumber)
            { 
                case 1:
                    Console.WriteLine(" ----> Task-1 Number is Positive, Negative or Zero <---- ");
                    Console.Write("Enter a Number: ");
                    double inputNumber = Convert.ToDouble(Console.ReadLine());
                    if (inputNumber > 0)
                    {
                        Console.WriteLine(inputNumber + " is Positive ");
                    }
                    else if (inputNumber == 0)
                    {
                        Console.WriteLine("Number is Zero");
                    }
                    else
                    {
                        Console.WriteLine(inputNumber + " is Negative ");
                    }
                    goto taskinitial;

                case 2:
                    Console.WriteLine(" ----> Task-2 Week Days <---- ");
                    Console.Write("Enter the week Number: ");
                    int weekNumber= Convert.ToInt16(Console.ReadLine());
                    switch(weekNumber)
                    {
                        case 1:
                            Console.WriteLine("Sunday");
                            break; 
                        case 2:
                            Console.WriteLine("Monday");
                            break;
                        case 3:
                            Console.WriteLine("Tuesday");
                            break;
                        case 4:
                            Console.WriteLine("Wednesday");
                            break;
                        case 5:
                            Console.WriteLine("Thursday");
                            break;
                        case 6:
                            Console.WriteLine("Friday");
                            break;
                        case 7:
                            Console.WriteLine("Saturday");
                            break;
                        default:
                            Console.WriteLine("Please Enter Number between 1 to 7");
                            break;
                    }
                    goto taskinitial;

                case 3:
                    Console.WriteLine(" ----> Task-3 Maximum and Minimum of Two Number <---- ");
                    Console.Write("Enter the First Number : ");
                    double firstNumber= Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter the Second Number : ");
                    double secondNumber= Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("To Find Maximum Write (1) and for Minimum Write (2)");
                    Console.Write("Enter the Number : ");
                    int maxMinInput= Convert.ToInt16(Console.ReadLine());
                    if (firstNumber!=secondNumber)
                    {
                        if (maxMinInput == 1)
                        {
                            Console.WriteLine("Maximum Number is " + Math.Max(firstNumber, secondNumber));
                        }
                        else if (maxMinInput == 2)
                        {
                            Console.WriteLine("Minimum Number is " + Math.Min(firstNumber, secondNumber));
                        }
                        else
                        {
                            Console.WriteLine("Please Enter Valid Number, as per above message");
                        }
                        goto taskinitial;
                    }
                    else
                    {
                        Console.WriteLine("Both the Number are Equal");
                        goto taskinitial;
                    }

                case 4:
                    Console.WriteLine(" ----> Task-4 Temperature Reader <---- ");
                    Console.Write("Enter the Temperature : ");
                     double temperature= Convert.ToDouble(Console.ReadLine());
                    if (temperature<0)
                    {
                        Console.WriteLine(" Freezing Weather ");
                    }
                    else if (0 <= temperature && temperature<=9  )
                    {
                        Console.WriteLine(" Very Cold Weather ");
                    }
                    else if (10 <= temperature && temperature <= 19)
                    {
                        Console.WriteLine(" Cold Weather ");
                    }
                    else if (20 <= temperature && temperature <= 29)
                    {
                        Console.WriteLine("Normal in Temp");
                    }
                    else if (30 <= temperature && temperature <= 39)
                    {
                        Console.WriteLine(" Hot Weather");
                    }
                    else
                    {
                        Console.WriteLine("Very Hot Weather");
                    }
                    goto taskinitial;

                case 5:
                    Console.WriteLine(" ----> Task-5 Calculator For two Number <---- ");
                    Console.Write("Enter the First Number : ");
                    double firstNumberforCalculation = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter the Second Number : ");
                    double secondNumberforCalculation = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Available Operator ('+','-','*','%','/')");
                    Console.Write("Proived any One Operator from above :  ");
                    String inputOperators = Convert.ToString( Console.ReadLine());

                    switch (inputOperators)
                    {
                        case "+" :
                            Console.WriteLine("Addition Of " +firstNumberforCalculation+" and " +secondNumberforCalculation+" is " + (firstNumberforCalculation + secondNumberforCalculation) );
                            break;
                        case "-":
                            Console.WriteLine("Subtraction  Of " + firstNumberforCalculation + " and " + secondNumberforCalculation + " is " + (firstNumberforCalculation - secondNumberforCalculation));
                            break;
                        case "*":
                            Console.WriteLine("Multiplication  Of " + firstNumberforCalculation + " and " + secondNumberforCalculation + " is " + (firstNumberforCalculation * secondNumberforCalculation));
                            break;
                        case "%":
                            Console.WriteLine("Remainder  Of " + firstNumberforCalculation + " and " + secondNumberforCalculation + " is " + (firstNumberforCalculation % secondNumberforCalculation));
                            break;
                        case "/":
                            if (secondNumberforCalculation!=0)
                            {
                                Console.WriteLine("Division  Of " + firstNumberforCalculation + " and " + secondNumberforCalculation + " is " + (firstNumberforCalculation / secondNumberforCalculation));
                            }
                            else
                            {
                                Console.WriteLine("Infinite");
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid Operator");
                            break;
                    }
                    goto taskinitial;
                default:
                    Console.WriteLine("Enter Number From 1 to 5 to View Tasks");
                    goto taskinitial;
                   
            }











        }
    }
    
}
