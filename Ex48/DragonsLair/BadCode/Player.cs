namespace BadCode
{
    public class Player
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        
        public Player(string name, string address = null, string email = null, string telephone = null)
        {
            Name = name;
            Address = address;
            Email = email;
            Telephone = telephone;
        }
    }
}
