using System.Collections.Generic;

namespace BadCode
{
    public class Tournament : IEntity
    {
        public enum State { STANDBY, ACTIVE, FINISHED };

        public string Name { get; }
        public State Status { get; set; }

        private TeamRepo teamRepo = new TeamRepo();
        private List<Round> rounds = new List<Round>();

        public Tournament(string name)
        {
            Name = name;
            Status = State.STANDBY;
        }

        public Tournament(string name, State status)
        {
            Name = name;
            Status = status;
        }

        public void AddTeam(Team team)
        {
            teamRepo.Insert(team);
        }

        public Team GetTeam(string name)
        {
            return teamRepo.GetByName(name);
        }

        public List<Team> Teams()
        {
            return teamRepo.Teams;
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

        public override string ToString() => Name;
    }
}
