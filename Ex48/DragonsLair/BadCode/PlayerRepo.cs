using System.Collections.Generic;

namespace BadCode
{
    class PlayerRepo : IRepository<Player>
    {
        private List<Player> players = new List<Player>();

        public void Insert(Player player)
        {
            players.Add(player);
        }

        public Player GetByName(string name)
        {
            foreach (Player player in players)
            {
                if (player.Name == name)
                {
                    return player;
                }
            }
            return null;
        }
    }
}
