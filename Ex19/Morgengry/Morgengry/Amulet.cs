using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morgengry
{
    public class Amulet : Merchandise
    {
        public string Design;
        public Level Quality;
        public double LowQualityValue { get; set; } = 12.5;
        public double MediumQualityValue { get; set; } = 20;
        public double HighQualityValue { get; set; } = 27.5;

        public Amulet(string itemId, Level quality = Level.medium, string design = "")
        {
            ItemId = itemId;
            Quality = quality;
            Design = design;
        }

        public override double GetValue()
        {
            double price;

            switch (Quality)
            {
                case Level.low:
                    price = LowQualityValue;
                    break;
                default:
                case Level.medium:
                    price = MediumQualityValue;
                    break;
                case Level.high:
                    price = HighQualityValue;
                    break;
            }

            return price;
        }

        new 
        public string ToString()
        {
            return "ItemId: " + ItemId + ", Quality: " + Quality + ", Design: " + Design;
        }
    }
}
