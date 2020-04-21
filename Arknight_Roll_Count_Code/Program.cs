using System;
using System.Collections.Generic;

/* make a program that keep tracks of rolls I have down in arknights up till i hit a 6 star.
 * when 6 star is hit, add currentrolls class to allrolls class and reset currentrolls.
 * 
 */
namespace Arknight_Roll_Count_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            CurrentRolls RollStreak = new CurrentRolls();
            GrandRolls RollSummary = new GrandRolls();

            if (RollStreak.AmtOf6Stars == 1)
            {
                RollSummary.RollStreakSummary.Add(RollStreak);
                /* Empty out Roll Streak */
            }

            RollStreak.AmtOf3Stars = 13;
            RollStreak.AmtOf4Stars = 9;
            RollStreak.AmtOf5Stars = 3;

            RollStreak.DisplayAllCurPercents();

        }
    }
}
