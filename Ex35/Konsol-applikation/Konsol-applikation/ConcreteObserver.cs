using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konsol_applikation
{
    public class ConcreteObserver : Observer
    {
        private ConcreteSubject Subject;
        public int State = 0;

        public ConcreteObserver(ConcreteSubject subject)
        {
            Subject = subject;
        }

        public override void Update()
        {
            State = Subject.State;
        }
    }
}
