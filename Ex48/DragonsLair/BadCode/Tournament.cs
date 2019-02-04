using System.Collections.Generic;

namespace BadCode
{
    public class Tournament
    {
        public enum State { STANDBY, ACTIVE, FINISHED };

        public string Name { get; set; }
        public State Status { get; set; }
      
        private TeamRepo teams = new TeamRepo();
        private List<Round> rounds = new List<Round>();

        public Tournament(string tournamentName)
        {
            Name = tournamentName;
            Status = State.STANDBY;
        }

        public Tournament(string tournamentName, State status)
        {
            Name = tournamentName;
            Status = status;
        }

        public void AddTeam(Team t)
        {
            teams.RegisterTeam(t);
        }

        public Team GetTeam(string name)
        {
            return teams.GetTeam(name);
        }

        public List<Team> Teams()
        {
            return teams.Teams();
        }

        public int GetNumberOfRounds()
        {
            return rounds.Count;
        }
        
        public Round GetRound(int idx)
        {
            return rounds[idx - 1]; //Første runde er No. 1, men index 0
        }

        public void AddRound(Round r)
        {
            rounds.Add(r);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
