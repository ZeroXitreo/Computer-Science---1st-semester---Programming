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

        public Amulet(string itemId, Level quality = Level.medium, string design = "")
        {
            ItemId = itemId;
            Quality = quality;
            Design = design;
        }

        new 
        public string ToString()
        {
            return "ItemId: " + ItemId + ", Quality: " + Quality + ", Design: " + Design;
        }
    }
}
