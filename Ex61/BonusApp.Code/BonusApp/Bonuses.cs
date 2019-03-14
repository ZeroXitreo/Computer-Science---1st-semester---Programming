using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusApp
{
    public delegate double BonusProvider(double amount);

    public class Bonuses
    {
        public static double TenPercent(double amount)
        {
            return amount / 10.0;
        }
        public static double FlatTwoIfAmountMoreThanFive(double amount)
        {
            return amount > 5.0 ? 2.0 : 0.0;
        }
    }
}
