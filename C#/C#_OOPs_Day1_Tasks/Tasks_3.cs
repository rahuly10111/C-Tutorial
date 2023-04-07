using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__OOPs_Day1_Tasks
{
    public class Tasks_3
    {
        public static void RoiCalculator() {
            Console.Write(" Enter the Amount Invested : ");
            int AmountInvested=Convert.ToInt32(Console.ReadLine());
            Console.Write(" Enter the Amount Returned : ");
            int AmountReturned =Convert.ToInt32(Console.ReadLine());
            DateTime start = new DateTime(2023, 4, 3);
            DateTime end = new DateTime(2027, 12, 31);
            TimeSpan difference = end - start; //create TimeSpan object
            double InvestmentTime = Convert.ToDouble ((difference.Days) / 365.2425);
            InvestmentTime = (double)System.Math.Round(InvestmentTime, 2);
            Console.WriteLine(" -->  Investment Length : " + InvestmentTime);
            // Console.WriteLine("Difference in days: " + yeardiff);
            double InvestmentGain = (AmountReturned - AmountInvested);
            Console.WriteLine(" -->  Investment Gain :  " + InvestmentGain);
            double Userroi = (InvestmentGain / AmountInvested) * 100;
            Userroi = (double)System.Math.Round(Userroi, 2);
            Console.WriteLine(  " --> ROI :  "+Userroi+"% ");

        }

    }
}
