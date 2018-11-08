using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morgengry
{
    public abstract class Merchandise : IValuable
    {
        public string ItemId;

        public abstract double GetValue();
    }
}
