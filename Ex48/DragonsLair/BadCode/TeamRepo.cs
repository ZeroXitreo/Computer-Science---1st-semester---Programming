using System.Collections.Generic;

namespace BadCode
{
    public class TeamRepo
    {
        private List<Team> teams = new List<Team>();
        
        public void RegisterTeam(Team team)
        {
            teams.Add(team);
        }

        public void RegisterTeam(string name)
        {
            Team newTeam = new Team(name);
            teams.Add(newTeam);
        }

        public Team GetTeam(string name)
        {
            Team team = null;
            int idx = 0;
            while ((team == null) && (idx < teams.Count))
            {
                if (teams[idx].Name.Equals(name))
                {
                    team = teams[idx];
                }
                idx++;
            }
            return team;
        }

        public List<Team> Teams()
        {
            return teams;
        }
    }
}
