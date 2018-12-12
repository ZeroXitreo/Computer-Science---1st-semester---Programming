using System;
using System.Collections.Generic;

namespace AcademyApp
{
    internal class Academy : Organization, IAcademy
    {
        private string message;
        private List<IStudent> Students = new List<IStudent>();

        public Academy(string name, string address) : base(name, address)
        {
        }

        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
                Notify();
            }
        }

        public void Attach(IStudent s)
        {
            Students.Add(s);
        }

        public void Detach(IStudent s)
        {
            Students.Remove(s);
        }

        public void Notify()
        {
            Students.ForEach(s => s.Update());
        }
    }
}