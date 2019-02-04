using System.Collections.Generic;

namespace BadCode
{
    public class Team
    {
        public string Name { get; set; }
        private List<Player> players = new List<Player>();

        public Team(string teamName)
        {
            Name = teamName;
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public override string ToString() => Name;
    }
}
