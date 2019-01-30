namespace AcademyApp
{
    internal class Student : Person, IStudent
    {
        private IAcademy Academy;
        public string Message;

        public Student(IAcademy academy, string name) : base(name)
        {
            Academy = academy;
        }

        public void Update()
        {
            Academy academy = (Academy) Academy;
            Message = academy.Message;
            System.Console.WriteLine(string.Format("Studerende {0} modtog nyheden '{1}' fra {2}", Name, Message, academy.Name));
        }
    }
}