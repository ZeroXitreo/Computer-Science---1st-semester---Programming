using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oevelse_3
{
    public abstract class Subject
    {
        protected NotifyHandler observers;

        public void Attach(IObserver observer)
        {
            observers += observer.Update;
            observer.Update(this);
        }

        public void Detach(IObserver observer) => observers -= observer.Update;

        public void Notify() => observers?.Invoke(this);
    }
}
