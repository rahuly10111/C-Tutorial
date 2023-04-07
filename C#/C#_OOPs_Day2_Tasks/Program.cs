using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__OOPs_Day2_Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeDetail employeeDetail = new EmployeeDetail();
            employeeDetail.AddTasks();
        }

        public class Office
        {
            public string OfficeName;
            public string OfficeDescription;
            public int OfficePhoneNumber;
            public string OfficeType;
            public string OfficeAddress;
        }

        public class EmployeeTasks
        {
            public string TaskName;
            public string TaskDescription;
            public int TaskId;
            public string TaskStatus;
            public  void AddTasks() { }
            public  void UpdateTasks() { }
            public void RemoveTasks() { }

        }

        public class EmployeeDetail : EmployeeTasks
        {
            public String EmployeeName;
            public int EmployeeId;
            public string EmployeeDesignation ;
            public string EmployeeEmailId;
            List<EmployeeTasks> EmployeeTasksDetail= new List<EmployeeTasks>();
        }
    }
}
