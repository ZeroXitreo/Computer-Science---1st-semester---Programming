namespace AcademyApp
{
    interface IAcademy
    {
        void Attach(IStudent s);

        void Detach(IStudent s);

        void Notify();
    }
}
