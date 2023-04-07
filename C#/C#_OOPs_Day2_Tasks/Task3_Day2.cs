using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__OOPs_Day2_Tasks
{
    internal class Task3_Day2
    {
        public static void Task3()
        {

        }

        public class AllMovies
        {
            public virtual void ViewMovies(){}
            public virtual void DownloadMovie(){}
        }

        public class HindiMovies : AllMovies {
            public override void ViewMovies(){ }
            public override void DownloadMovie() { }
        }

        public class EnglishMovies: AllMovies
        {
            public override void ViewMovies(){ }
            public override void DownloadMovie() { }
        }

        public class ActivePlanDeatil
        {
            public string StaringDate;
            public string EndDate;
           
        }

        public class UserDetail
        {
            public string UserName;
            public string UserEmailId;
            public string UserPhoneNo;
            public string UserAge;
        }

        

    }
}
