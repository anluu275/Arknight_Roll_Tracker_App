using System;
using System.Collections.Generic;
using System.Text;

namespace Arknight_Roll_Count_Code
{
    public class GrandRolls : IRolls
    {
        public List<CurrentRolls> RollStreakSummary = new List<CurrentRolls>();
        public float GrandTotalRolls { get; private set; }
        public float AmtOf3Stars { get; private set; }
        public float AmtOf4Stars { get; private set; }
        public float AmtOf5Stars { get; private set; }
        public float AmtOf6Stars { get; private set; }
    }
}
