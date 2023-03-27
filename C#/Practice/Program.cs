using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //Writeline-method
            Console.WriteLine("Hello World!");
            Console.WriteLine("I am Learning C#");
            Console.WriteLine(2+2);
            //Write-Method  
            Console.Write("I am Learning C# ");
            Console.Write("in VCode");
            Console.Write('\n');
            //input from user
            Console.Write("what is your name :");
            string username = Console.ReadLine();
            Console.WriteLine("My Name is " + username);
            int letter = 22 + 12;
            Console.WriteLine("Before Convert" + letter);
            Console.WriteLine(Convert.ToString(letter));
        }
    }
}