using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day4_Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            try
            {
                var isout = false;
                do {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("Enter the Tasks Number : ");
                    int taskNumber=Convert.ToInt32(Console.ReadLine()); 
                    switch (taskNumber) {
                        case 1:
                            CommonMethod.Calculater();
                            break;
                        case 2:
                            CommonMethod.ClassOfStudent();
                            break;
                        default: Console.WriteLine("Please Enter 1 or 2 to view the Tasks");
                            break;
                    
                    }
                    Console.WriteLine("\n TO Continue Watching Tasks -- Press (Y) \n");
                    var input= Console.ReadLine();
                    if (input.ToLower()=="y")
                    {
                        isout = true;
                    }
                    else
                    {
                        isout = false;
                    }

                } while (isout);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
