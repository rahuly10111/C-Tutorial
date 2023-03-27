using day3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day3_Tasks
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
                    int userInput = Convert.ToInt16(Console.ReadLine());
                    switch (userInput)
                    {
                       
                        case 2:
                            CommonMethods.readfile();
                            break;

                        case 3:
                           CommonMethods.arrayofstringinfile();
                            break;

                        case 4:
                            CommonMethods.appendtext();
                            break;

                        case 5:
                          CommonMethods.firstline();
                            break;

                        case 6:
                           CommonMethods.countline();  
                            break;
                        case 7:
                          CommonMethods.exceptionHandle();
                            break;
                        case 8:
                            CommonMethods.dividebyzero();
                            break;
                        case 9:
                            dataMethodExtensionMethod extensionMethodObj = new dataMethodExtensionMethod();
                            extensionMethodObj.DateMethodExtensionMethod();

                            //taMethodExtensionMethod.DateMethodExtensionMethod();
                            //ommonMethods.Dateformate();
                            break;
                        case 10:
                            CommonMethods.argumentnullexp();
                            break;
                        case 11:
                            CommonMethods.emailencryption();
                            break;
                        case 12:
                            CommonMethods.retrievepassword();
                            break;

                        default:
                            Console.WriteLine("Enter Number From 2 to 12 to View Tasks");
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
