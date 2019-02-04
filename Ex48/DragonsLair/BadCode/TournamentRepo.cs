using System.Collections.Generic;

namespace BadCode
{
    class TournamentRepo : IRepository<Tournament>
    {
        private List<Tournament> tournaments = new List<Tournament>();

        public void Insert(Tournament tournament)
        {
            tournaments.Add(tournament);
        }

        public Tournament GetByName(string name)
        {
            foreach (Tournament tournament in tournaments)
            {
                if (tournament.Name == name)
                {
                    return tournament;
                }
            }
            return null;
        }
    }
}
