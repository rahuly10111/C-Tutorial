using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__OOPs_Day2_Tasks
{
    internal class Task5_Day2
    {
        public class BookDeatil
        {
            public string BookName;
            public string BookAuthor;
            public int BookNumber;
            public string BookDescription;
            public string BookType;
        }

        public class UserDetail
        {
            public string UserName;
            public int UserId;
        }

        public class BookInLibrary : BookDeatil 
        {
            public int BookPrice;
        }

        public class BookIssued : BookDeatil {
        }

        public class UserStudent : UserDetail
        {

        }

        public class UserLibrarian : UserDetail
        {

        }

    }
}
