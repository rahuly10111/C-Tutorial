using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace C__Day7_Tasks
{
    internal class CommonMethods
    {
        //private static string studentemail;

        public static void Task1NewList()
        {
            Console.WriteLine(" ----> Task-1 List of Integers <---- ");
            Console.Write("Enter the Lenght of List : ");
            int ListLenght = Convert.ToInt16(Console.ReadLine());
            List<int> Userlist = new List<int>();
            List<int>outputList = new List<int>();
            for (int i = 0; i < ListLenght; i++)
            {
                Console.Write("Index {0} : ", i);
                int memlist = Convert.ToInt32(Console.ReadLine());
                Userlist.Add(memlist);
            }
            Console.Write(" --> User List With Plus Two   [");
            for (int i = 0; i < ListLenght; i++)
            {
                Console.Write(" " + (Userlist[i] + 2));
                outputList.Add(Userlist[i] + 2);
            }
            Console.WriteLine(" ]");
            Console.Write(" --> Output List  [");
            for (int i = 0; i < ListLenght; i++)
            {
                Console.Write(" " + (outputList[i] * 5));
            }
            Console.Write(" ]");

        }

        public static void Task2NewList()
        {
            Console.WriteLine(" ----> Task-2 Adjacent Numbers List  <---- ");
            Console.Write("Enter the Lenght of List : ");
            int ListLenght = Convert.ToInt32(Console.ReadLine());
            List<int> Userlist = new List<int>();

            for (int i = 0; i < ListLenght; i++)
            {
                Console.Write("Index {0} : ", i);
                int memlist = Convert.ToInt32(Console.ReadLine());
                Userlist.Add(memlist);
            }

            Console.Write("  --> User List    [");
            for (int i = 0; i < ListLenght; i++)
            {
                Console.Write(" " + (Userlist[i]));

            }
            Console.WriteLine(" ]");
            Task3NewList(ListLenght, Userlist);
        }

        public static void Task3NewList(int n, List<int> templist)
        {
            List<string> temp = new List<string>();
            for (int i = 0; i < n; i++)
            {
                int listData = templist[i];
                while (i < n - 1 && templist[i + 1] == templist[i] + 1)
                {
                    i++;

                }
                temp.Add(FormatListData(listData, templist[i]));
            }
             
            Console.Write("   -->  User List Adjacent Numbers   [");
            for (int i = 0; i < temp.Count; i++)
            {
                Console.Write(" " + (temp[i]));

            }
            Console.WriteLine(" ]");

        }

        public static string FormatListData(int startData, int endData)
        {
            if (startData == endData)
            {
                return startData.ToString();
            }
            else
            {
                return String.Format("{0}-{1}", startData, endData);
            }


        }

        public static void Task3()
        {
            SortedList mySortedList = new SortedList();
            String bestStudent="";
            Studentdetail newstudent=new Studentdetail();
            Console.WriteLine(" ----> Task-3 Students Detail in college <---- ");
            var isout = false;
            do
            {
                Console.WriteLine(" Kindly  Type 1 to Add New student , \n Type 2 to Remove student,\n Type 3 to Select Best student and \n Type 4 To View the Best student");
                Console.Write("Type the Number as per Above Message : ");
                int collegefeature = Convert.ToInt16(Console.ReadLine());

                switch (collegefeature)
                {
                    case 1:
                        Addstudent(mySortedList, newstudent);
                        break;
                    case 2:
                        Removestudent(mySortedList);
                        break;
                    case 3:
                        Console.WriteLine(" Student list is here : ");
                        Console.WriteLine("\t-Name-\t -Details-");
                        for (int i = 0; i < mySortedList.Count; i++)
                        {
                            Console.WriteLine("\t{0} \t{1}", mySortedList.GetKey(i), mySortedList.GetByIndex(i));
                        }
                        Console.Write("Enter the Name of Student has the ability for Best student : ");
                        bestStudent = Convert.ToString(Console.ReadLine());
                        Console.WriteLine(bestStudent + " is Best Student");
                        break;
                     case 4:
                        Console.WriteLine(bestStudent + " is Best Student");
                        break;
                     default: Console.WriteLine(" Only Type the Number as per Above Message ");
                        break;
                }
                Console.WriteLine("\n TO Continue Watching Features -- Press (C) \n");
                var input = Console.ReadLine();
                if (input.ToLower() == "c")
                {
                    isout = true;
                }
                else
                {
                    isout = false;

                }

            } while (isout);

            
           
        }

        public class Studentdetail
        {
            public string studentemail;
        }



        public static void Addstudent(SortedList mylist , Studentdetail newstudent)
        {
            Console.Write("Enter name : ");
            string studentName = Convert.ToString(Console.ReadLine());
            Console.Write("Enter your age  : ");
            int studentage = Convert.ToInt16(Console.ReadLine());
            do
            {
                Console.Write("Enter your Email Id  : ");
                newstudent.studentemail = Convert.ToString(Console.ReadLine());

            } while (!EmailValidation(newstudent.studentemail));

            
            mylist.Add(studentName, (studentage, newstudent.studentemail));
            Console.WriteLine(" **** congratulations **** ");
            Console.WriteLine(" Student list is here : ");
            Console.WriteLine("\t-Name-\t-Details-");
            for (int i = 0; i < mylist.Count; i++)
            {
                Console.WriteLine("\t{0} \t{1}", mylist.GetKey(i), mylist.GetByIndex(i));
            }
        }

        public static void Removestudent(SortedList mylist)
        {
            Console.WriteLine("list is here");
            Console.WriteLine("\t-Name-\t-Details-");
            for (int i = 0; i < mylist.Count; i++)
            {
                Console.WriteLine(" \t{0} \t{1}", mylist.GetKey(i), mylist.GetByIndex(i));
            }
            Console.Write("Enter the Name of Student you Want to Remove : ");
            string removestudentName = Convert.ToString(Console.ReadLine());
            mylist.Remove(removestudentName);
            Console.WriteLine(" Student list is here : ");
            Console.WriteLine("\t-Name-\t-Details-");
            for (int i = 0; i < mylist.Count; i++)
            {
                Console.WriteLine("\t{0} \t{1}", mylist.GetKey(i), mylist.GetByIndex(i));
            }
        }

        public static bool EmailValidation(string emailvalidation)
        {

            if (string.IsNullOrEmpty(emailvalidation))
                return false;

            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                  RegexOptions.CultureInvariant | RegexOptions.Singleline);
            return regex.IsMatch(emailvalidation);

        }




    }
}
