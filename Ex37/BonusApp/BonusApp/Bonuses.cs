using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusApp
{
    public class Bonuses
    {
        public static double TenPercent(double v)
        {
            return v * .1;
        }

        public static double FlatTwoIfAmountMoreThanFive(double v)
        {
            return v > 5 ? 2 : 0;
        }
    }
}
