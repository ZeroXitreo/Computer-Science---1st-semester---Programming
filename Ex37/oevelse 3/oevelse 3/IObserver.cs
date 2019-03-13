using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oevelse_3
{
    public interface IObserver
    {
        void Update(Subject subject);
    }
}
