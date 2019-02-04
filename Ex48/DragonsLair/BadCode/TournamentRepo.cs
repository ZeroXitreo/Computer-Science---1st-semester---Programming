using System.Collections.Generic;

namespace BadCode
{
    class TournamentRepo
    {
        private List<Tournament> t = new List<Tournament>();

        public void RegisterTournament(string name)
        {
            Tournament newTournament = new Tournament(name);
            RegisterTournament(newTournament);
        }

        public void RegisterTournament(Tournament tournament)
        {
            t.Add(tournament);
        }

        public Tournament GetTournament(string x)
        {
            Tournament y = null;
            int idx = 0;
            while((y == null) && (idx < t.Count))
            {
                if (t[idx].Name.Equals(x))
                {
                    y = t[idx];
                }
                idx++;
            }
            return y;
        }
    }
}
