using System;
using System.Collections.Generic;
using System.Text;

namespace Arknight_Roll_Count_Code
{
    public class CurrentRolls : IRolls
    {
        /* amt of each */
        public float CurTotalRolls { get; set; }
        public float AmtOf6Stars { get; set; }
        public float AmtOf5Stars { get; set; }
        public float AmtOf4Stars { get; set; }
        public float AmtOf3Stars { get; set; }

        /* percent of each */
        public float percent5star { get; private set; }
        public float percent6star { get; private set; }
        public float percent4star { get; private set; }
        public float percent3star { get; private set; }

        public void ClearCurRolls()
        {
            CurTotalRolls = 0;
            AmtOf3Stars = 0;
            AmtOf4Stars = 0;
            AmtOf5Stars = 0;
            AmtOf6Stars = 0;
        }

        public void DisplayAllCurPercents()
        {
            CurTotalRolls = AmtOf3Stars + AmtOf4Stars + AmtOf5Stars + AmtOf6Stars;
            percent6star = divide(AmtOf6Stars , CurTotalRolls) * 100;
            percent5star = divide(AmtOf5Stars, CurTotalRolls) * 100;
            percent4star = divide(AmtOf4Stars, CurTotalRolls) * 100;
            percent3star = divide(AmtOf3Stars, CurTotalRolls) * 100;

            Console.WriteLine($"Current amount of rolls is {CurTotalRolls}");
            Console.WriteLine($"6 Star Precentage is {AmtOf6Stars} / {CurTotalRolls} = {percent6star}%");
            Console.WriteLine($"5 Star Precentage is {AmtOf5Stars} / {CurTotalRolls} = {percent5star}%");
            Console.WriteLine($"4 Star Precentage is {AmtOf4Stars} / {CurTotalRolls} = {percent4star}%");
            Console.WriteLine($"3 Star Precentage is {AmtOf3Stars} / {CurTotalRolls} = {percent3star}%");

        }
        public float divide(float n1, float n2)
        {
            /* n1 divided by n2 */            
            if(n2 == 0)
            {
                return (n1 / 1);
            }
            return (n1/n2);
        }
    }
}
