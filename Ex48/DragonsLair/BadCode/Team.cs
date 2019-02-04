using System.Collections.Generic;

namespace BadCode
{
    public class Team : IEntity
    {
        public string Name { get; set; }
        private List<Player> players = new List<Player>();

        public Team(string name)
        {
            Name = name;
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public override string ToString() => Name;
    }
}
