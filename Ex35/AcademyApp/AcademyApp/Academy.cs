using System;

namespace AcademyApp
{
    internal class Academy : Subject
    {
        public string Name { get; }
        private string message;
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

        public Academy(string name)
        {
            Name = name;
        }
    }
}