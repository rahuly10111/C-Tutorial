using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using System.Security.Cryptography;

namespace C__Day3_Tasks
{
    internal class CommonMethods
    {
        public static void createfile()
        {
            String fileText = "hello C# \n";
            File.WriteAllText("textfile.txt", fileText);

        }

        public static void readfile()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" ----> Task-2 Read File <---- ");
            Console.ForegroundColor = ConsoleColor.Black;
            createfile();
            string readfileText = File.ReadAllText("textfile.txt");
            Console.WriteLine(readfileText);
        }

        public static void arrayofstringinfile()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" ----> Task-3 Array of String in File <---- ");
            Console.ForegroundColor = ConsoleColor.Black;
            createfile();
            Console.Write("Enter the Length of Array : ");
            int arrayLenght = Convert.ToInt16(Console.ReadLine());
            int[] userarray = new int[arrayLenght];
            using (StreamWriter sr = new StreamWriter("textfile.txt" , append:true))
            {
                for (int i = 0; i < arrayLenght; i++)
                {
                    Console.Write("Element - {0} : ", i);
                    userarray[i] = Convert.ToInt32(Console.ReadLine());
                    sr.Write( "  " + userarray[i]);
                }
            }
            using (StreamReader sr = new StreamReader("textfile.txt")) 
            {
                string res = sr.ReadToEnd();
                Console.WriteLine(res);
            }


        }

        public static void appendtext()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" ----> Task-4 Append Text <---- ");
            Console.ForegroundColor = ConsoleColor.Black;
            createfile();
            using (StreamWriter sr = new StreamWriter("textfile.txt", append: true))
            {
                string apeendtext = "Lorem ipsum dolor sit amet consectetur adipisicing elit. \n Facilis velit harum consequuntur sapiente,\n ad accusantium assumenda quaerat, autem deleniti dolorem fugiat,\n dolores nam incidunt hic ea laboriosam aliquid rerum dolor?";
                sr.WriteLine(apeendtext);
            }
            using (StreamReader sr = new StreamReader("textfile.txt"))
            {
                string res = sr.ReadToEnd();
                Console.Write(res);
            }
        }

        public static void firstline()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" ----> Task-5 file First Line <---- ");
            Console.ForegroundColor = ConsoleColor.Black;
            appendtext();
            string line1 = File.ReadLines("textfile.txt").First();
            Console.WriteLine(line1);
        }
        
        public static void countline()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" ----> Task-6 Count Line <---- ");
            Console.ForegroundColor = ConsoleColor.Black;
            appendtext();
            int count = File.ReadAllLines("textfile.txt").Length;
            Console.WriteLine(count);
        }

        public static void exceptionHandle()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" ----> Task-7 Exception Handle <---- ");
            Console.ForegroundColor = ConsoleColor.Black;
            try
            {
                Console.Write("Enter Your Age : ");
                int userage = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine( "Ohh You are "+userage+ " years Old ");
            }
            catch (Exception )
            {
                Console.WriteLine("Kindly add  Only Number Not ALphabet .");
            }
        }

        public static void dividebyzero()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" ----> Task-8 Divide by zero <---- ");
            Console.ForegroundColor = ConsoleColor.Black;
            try
            {
                Console.Write("First Number : ");
                int firstnumber = Convert.ToInt16(Console.ReadLine());
                Console.Write("Second Number : ");
                int secondnumber= Convert.ToInt16(Console.ReadLine());
                int divisonofnumber = (firstnumber/secondnumber);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void Dateformate()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" ----> Task-9 Date formate <---- ");
            Console.ForegroundColor = ConsoleColor.Black;
            try
            {
                DateTime currentDate = DateTime.Now;
                Console.WriteLine("For [mm/dd/yyyy] Formate Enter (1) \n For [dd/mm/yyyy] Formate Enter (2) \n For [WeekDay, dd/mm/yyyy] Formate Enter (3) \n For [Year Month ] Formate Enter (4) \n For [Month date] Formate Enter (5) ");
                Console.Write("Enter Number 1 to 5 As per Above Message : ");
                int dateSr = Convert.ToInt16(Console.ReadLine());
                    switch (dateSr)
                    {
                        case 1:
                            Console.WriteLine(currentDate.ToString("MM/dd/yyyy"));
                            break;
                        case 2:
                            Console.WriteLine(currentDate.ToString("dd/MM/yyyy"));
                            break;
                        case 3:
                            Console.WriteLine(currentDate.ToString(" dddd , dd/MM/yyyy"));
                            break;
                        case 4:
                            Console.WriteLine(currentDate.ToString("yyyy MMMM"));
                            break;
                        case 5:
                            Console.WriteLine(currentDate.ToString("MMMM dd"));
                            break;
                        default:
                            Console.WriteLine("Enter Number From 1 to 5 as per above Message");
                            break;
                    }
            } catch(Exception ex) {

                Console.WriteLine(ex.Message);
            }
        }

        public static void argumentnullexp()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" ----> Task-10 Argument null exp <---- ");
            Console.ForegroundColor = ConsoleColor.Black;

string val = null;
            try
            {
                int res = int.Parse(val);
            }
            catch (ArgumentNullException e)
            {
                Console.Write(e.Message);
                Console.ReadLine();
            }
        }

        public static void emailencryption()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" ----> Task-11 Email encryption <---- ");
            Console.ForegroundColor = ConsoleColor.Black;
            createfile();
            Console.Write("Enter yous email ID : ");
            string strEncrypted = Console.ReadLine();
            string encryptemail = EnryptString(strEncrypted);
            string encryptEmailFile = "\n Encrypt Form of  " + strEncrypted + " is  " + (encryptemail);
            File.AppendAllText("textfile.txt", encryptEmailFile);
            string dencryptemail = DecryptString(encryptemail);
            string dencryptEmailFile = "\n Decrypt Form of  " + encryptemail + "  is  " + dencryptemail;
            File.AppendAllText("textfile.txt", dencryptEmailFile);
            string readfileText = File.ReadAllText("textfile.txt");
            Console.WriteLine(readfileText);
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
            catch (FormatException )
            {
                decrypted = "";
            }
            return decrypted;
        }

        public static  string EnryptString(string strEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }

        public static void retrievepassword()
        {
            createfile();
            string userpassword = ConfigurationManager.AppSettings["dev@333"];
            string encryptpassword = EnryptString(userpassword);
            string encryptpasswordFile = "\n Encrypt Form of  Password  is  " + encryptpassword;
            File.AppendAllText("textfile.txt", encryptpasswordFile);


        }

    }
}
