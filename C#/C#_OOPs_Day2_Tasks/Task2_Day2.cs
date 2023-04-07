using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__OOPs_Day2_Tasks
{
    internal class Task2_Day2
    {
        public static void Task2()
        {
            UserMale userMale = new UserMale();
            userMale.UserName = "Abc";
            UserFemale userFemale = new UserFemale();
            userFemale.UserName = "abc";
            if (userMale.Userid==userFemale.Userid) {
                userMale.MatchAlert();
            }
            
        }

        public class UserDetail
        {
            public int Userid;
            public string UserName ;
            public string UseraAge;
            public string UserEmail;
            public string UserPhone;
            public string UserLocation;
            public void MatchAlert()
            {
                Console.WriteLine("You find a Match ");
            }

        }

        public class UserMale : UserDetail
        {
           
        }

        public class UserFemale : UserDetail
        {
           
        }
    }
}
