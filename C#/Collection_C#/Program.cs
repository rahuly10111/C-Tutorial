using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack stk = new Stack();
            stk.Push("cs.net");
            stk.Push("vb.net");
            stk.Push("asp.net");
            stk.Push("sqlserver");

            foreach (object o in stk)
            {
                Console.Write(o + "\n");
            }
            Console.ReadLine();
        }
    }
}
