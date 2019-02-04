using System.Collections.Generic;

namespace BadCode
{
    public class TeamRepo : IRepository<Team>
    {
        public readonly List<Team> Teams = new List<Team>();

        public void Insert(Team team)
        {
            Teams.Add(team);
        }

        public Team GetByName(string name)
        {
            foreach (Team team in Teams)
            {
                if (team.Name == name)
                {
                    return team;
                }
            }
            return null;
        }
    }
}
