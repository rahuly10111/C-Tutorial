using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__OOPs_Day1_Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Players players = new Players();
            Console.WriteLine(players.TeamName);
            Console.WriteLine( players.TournamentName) ;
            Console.WriteLine(players.TotalScore);
           Tasks_3.RoiCalculator();
            Console.ReadLine();
        }

        public  class CricketTournament
        {
            public string TournamentName = " Abc Tournament";
            public string TournamentCountryOrigin;
            public string TournamentFoundedBy;

        }

        public class Team : CricketTournament
        {
            public string TeamName ="Team 1";
            public string TeamOwnerName;
            public int TeamValution;
            public int TeamFanBaseCount;
           // public string PlayersNames;

        }

        public class PlayerStatistics : Team
        {
            public int TotalScore = 12000;
            public int TotalWicket;
            public int InternationalRank;
            public int NumberOfMatches;
            public int NumberofFours;
            public int NumberofSixes;

        }

        public  class Players : PlayerStatistics
        {
            public  string PlayerName= "rrrr";
            public int PlayerAge;
            public string PlayerGender;
            public string PlayerCountry;
            public int PlayerPurchasePrice;
             

        }

       

        private class TournamentSupportStaff
        {
            public string UmpireNames;
            public string CommenterNames;
        }
    }
}
