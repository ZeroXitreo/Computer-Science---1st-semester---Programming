namespace AcademyApp
{
    internal class Student : Observer
    {
        private Academy Subject;
        public string Message;
        public string Name { get; }

        public Student(Academy subject, string name)
        {
            Subject = subject;
            Name = name;
        }

        public override void Update()
        {
            Message = Subject.Message;
            System.Console.WriteLine(string.Format("Studerende {0} modtog nyheden '{1}' fra {2}", Name, Message, Subject.Name));
        }
    }
}