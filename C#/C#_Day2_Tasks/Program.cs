using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day2_Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            try
            {
                var IsOut = false;
                do
                {
                    
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Enter Task number : ");
                    int userInput = Convert.ToInt16( Console.ReadLine());
                    switch (userInput)
                    {
                        case 1:
                            commonMethods.printName();
                            break;

                        case 2:
                            commonMethods.printNumbers();
                            break;

                        case 3:
                            commonMethods.negativenumber();
                            break;

                        case 4:
                            commonMethods.maxMinNumber(); 
                            break;

                        case 5:
                            commonMethods.oddEvenNumber();
                            break;

                        case 6:
                            commonMethods.intstringoverloading();
                            break;
                        case 7:
                            commonMethods.sumOfInteger();
                            break;
                        default:
                            Console.WriteLine("Enter Number From 1 to 7 to View Tasks");
                            break;
                    }
                    Console.WriteLine(" \n TO Continue Watching Tasks -- Press (Y) \n");
                    var Input = Console.ReadLine();
                    if (Input.ToLower() == "y")
                        IsOut = true;
                    else
                        IsOut = false;

                } while (IsOut);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

        }
    }
}
