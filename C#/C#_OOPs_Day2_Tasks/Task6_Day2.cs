using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__OOPs_Day2_Tasks
{
    internal class Task6_Day2
    {
        public static void Task6()
        {
            Student student = new Student();
            student.FirstName = "A";
            student.LastName = "B";
            student.MiddleName = "C";
        }



        public class Student
        {
            private string _firstName;

            public string FirstName
            {
                get { return _firstName; }
                set { _firstName = value; }
            }

            private string _middleName;

            public string MiddleName
            {
                get { return _middleName; }
                set { _middleName = value; }
            }


            private string _lastName;

            public string LastName
            {
                get { return _lastName; }
                set { _lastName = value; }
            }


           

       
        }


    }
}
