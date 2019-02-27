using System;
using System.Collections.Generic;

namespace AcademyApp
{
    internal class Academy : Organization, IAcademy
    {
        private NotifyHandler students;
        private string message;

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
            students += s.Update;
        }

        public void Detach(IStudent s)
        {
            students -= s.Update;
        }

        public void Notify()
        {
            students();
        }
    }
}