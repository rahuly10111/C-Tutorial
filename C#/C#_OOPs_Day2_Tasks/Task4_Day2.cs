using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__OOPs_Day2_Tasks
{
    internal class Task4_Day2
    {
        public static void Task4()
        {
            PcParts pcParts = new PcParts();
            pcParts.ThisIsMouse();
            pcParts.ThisIsKeyBoard();
        }
        interface IMouse
        {
            void ThisIsMouse();
        }

        interface IKeyBoard
        {
            void ThisIsKeyBoard();
        }

        class PcParts : IMouse, IKeyBoard
        {
            public void ThisIsMouse()
            {
                Console.WriteLine("This Is Mouse");
            }

            public void ThisIsKeyBoard()
            {
                Console.WriteLine("This Is Keyboard");
            }
        }
    }
}
