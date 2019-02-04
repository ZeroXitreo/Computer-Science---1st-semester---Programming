namespace BadCode
{
    public class Player : IEntity
    {
        public string Name { get; }
        public string Address { get; }
        public string Email { get; }
        public string Telephone { get; }

        public Player(string name, string address = null, string email = null, string telephone = null)
        {
            Name = name;
            Address = address;
            Email = email;
            Telephone = telephone;
        }
    }
}
