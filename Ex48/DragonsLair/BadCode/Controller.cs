using System;
using System.Collections.Generic;

namespace BadCode
{
    public class Controller
    {
        private TournamentRepo tournamentRepository = null;

        public Controller()
        {
            tournamentRepository = new TournamentRepo();
            Init();
        }

        public void Init()
        {
            Console.WriteLine("Initialiserer \"BADCODE\"...");
            TeamRepo teamRepository = new TeamRepo();
            PlayerRepo playerRepository = new PlayerRepo();
            string tournamentName = "X";

            Console.WriteLine("Registrerer spillere...");
            playerRepository.Insert(new Player("Laust Ulriksen"));
            playerRepository.Insert(new Player("Matthias Therkelsen", null, "matthias@therkelsen.dk", "+45 47002155"));
            playerRepository.Insert(new Player("Martin Bertelsen", "Nyborgvej 10, Odense", null, "+45 22521112"));
            playerRepository.Insert(new Player("Line Madsen", "Kochsgade 21, Odense", "linem@msn.dk", "+45 00142563"));
            playerRepository.Insert(new Player("Jette Detlevsen"));

            Console.WriteLine("Registrerer teams...");
            // initialize with a default set of teams
            teamRepository.Insert(new Team("A"));
            teamRepository.Insert(new Team("B"));
            teamRepository.Insert(new Team("C"));
            teamRepository.Insert(new Team("D"));
            teamRepository.Insert(new Team("E"));
            Console.WriteLine("Tilføjer spillere til teams...");
            // Add players to teams
            Team FCK = teamRepository.GetByName("A");
            FCK.AddPlayer(playerRepository.GetByName("Laust Ulriksen"));
            FCK.AddPlayer(playerRepository.GetByName("Matthias Therkelsen"));
            Team OB = teamRepository.GetByName("B");
            Team BiF = teamRepository.GetByName("C");
            BiF.AddPlayer(playerRepository.GetByName("Martin Bertelsen"));
            Team Hobro = teamRepository.GetByName("D");
            Hobro.AddPlayer(playerRepository.GetByName("Line Madsen"));
            Team AGF = teamRepository.GetByName("E");
            AGF.AddPlayer(playerRepository.GetByName("Jette Detlevsen"));

            Console.WriteLine("Registrerer Liga...");
            // initialize with a default tournament
            tournamentRepository.Insert(new Tournament(tournamentName));
            Tournament tournament = tournamentRepository.GetByName(tournamentName);

            Console.WriteLine("Tilføjer teams til Liga...");
            // Add teams to tournament
            tournament = tournamentRepository.GetByName(tournamentName);
            tournament.AddTeam(FCK);
            tournament.AddTeam(OB);
            tournament.AddTeam(BiF);
            tournament.AddTeam(Hobro);
            tournament.AddTeam(AGF);

            Console.WriteLine("Planlægger 1. runde...");
            // Initialize first round (this also initializes matches)
            ScheduleNewRound(tournamentName);
        }

        private string PadSpaceToName(string n, int l)
        {
            for (int i = n.Length; i < l; i++)
            {
                n = n + " ";
            }
            return n;
        }

        private int GetHighestScore(Dictionary<string, int> teamNameToScore)
        {
            int highestScore = 0;
            foreach (KeyValuePair<string, int> element in teamNameToScore)
            {
                if (highestScore < element.Value)
                {
                    highestScore = element.Value;
                }
            }
            return highestScore;
        }

        public void ShowScore(string tournamentName)
        {
            Dictionary<string, int> teamNameToScore = new Dictionary<string, int>();

            Tournament selectedTournament = tournamentRepository.GetByName(tournamentName);
            int numberOfRounds = selectedTournament.GetNumberOfRounds();
            if (numberOfRounds > 0)
            {
                int numberOfMatches = 0;
                for (int i = 1; i <= numberOfRounds; i++)
                {
                    Round currentRound = selectedTournament.GetRound(i);
                    numberOfMatches = numberOfMatches + currentRound.GetNumberOfMatches();
                    foreach (Team winningTeam in currentRound.WinningTeams)
                    {
                        if (!teamNameToScore.ContainsKey(winningTeam.Name))
                        {
                            teamNameToScore.Add(winningTeam.Name, 0);
                        }
                        teamNameToScore[winningTeam.Name] = teamNameToScore[winningTeam.Name] + 1;
                    }
                }

                //output in sorted order starting with highest score - find highest score
                int highestScore = GetHighestScore(teamNameToScore);

                Console.WriteLine("  #####");
                Console.WriteLine(" #     # ##### # #      #      # #    #  ####  ");
                Console.WriteLine(" #         #   # #      #      # ##   # #    # ");
                Console.WriteLine("  #####    #   # #      #      # # #  # #      ");
                Console.WriteLine("       #   #   # #      #      # #  # # #  ### ");
                Console.WriteLine(" #     #   #   # #      #      # #   ## #    # ");
                Console.WriteLine("  #####    #   # ###### ###### # #    #  #### ");
                Console.WriteLine("0--------------------------------------------------0");
                Console.WriteLine($"|      Liga : {tournamentName}                     |");
                Console.WriteLine($"|      Spillede runder : {numberOfRounds}                         |");
                Console.WriteLine($"|      Spillede kampe : {numberOfMatches}                         |");
                Console.WriteLine("-----------------------------------| Vundne kampe  |");

                for (int i = highestScore; i >= 0; i--)
                {
                    foreach (KeyValuePair<string, int> element in teamNameToScore)
                    {
                        if (element.Value == i)
                        {
                            int score = highestScore - i + 1;
                            string name = PadSpaceToName(element.Key, 18);
                            Console.WriteLine($"|         {score}. {name}    |      {element.Value}        |");
                        }
                    }
                }
                Console.WriteLine("0--------------------------------------------------0\n");
            }
        }

        public void ScheduleNewRound(string tournamentName)
        {
            Tournament selectedTournament = tournamentRepository.GetByName(tournamentName);
            List<Team> teams = null;
            Round thisRound = null;

            //Get teams for new round
            int numberOfRounds = selectedTournament.GetNumberOfRounds();
            //Get teams for new round
            if (numberOfRounds == 0) //SPECIAL CASE: Initialize first round. Handled by adding all teams from tournament 
            {
                teams = selectedTournament.Teams();
            }
            else // We are scheduling round > 0, get winners from this round if it is finished
            {
                thisRound = selectedTournament.GetRound(numberOfRounds);
                if (thisRound.IsRoundFinished())
                {
                    teams = thisRound.WinningTeams;
                    if (thisRound.FreeRider != null)
                    {
                        teams.Add(thisRound.FreeRider);
                    }
                }
                else
                {
                    throw new Exception("Round is not finished");
                }
            }

            if (teams.Count < 2)
            {
                selectedTournament.Status = Tournament.State.FINISHED;
            }
            else
            {
                Round newRound = new Round();
                
                //Manage freeRiders
                if ((teams.Count % 2) != 0) //Select a freeRider
                {
                    //If prior round exists and it had a freeRider and if was first team the select second team
                    if ((numberOfRounds > 0) && (thisRound.FreeRider != null) && (thisRound.FreeRider.Equals(teams[0])))
                    {
                        newRound.FreeRider = teams[1];
                        teams.Remove(teams[1]);
                    }
                    else //select first team
                    {
                        newRound.FreeRider = teams[0];
                        teams.Remove(teams[0]);
                    }
                }

                Random r = new Random();
                List<int> randomIndices = new List<int>();
                for (int i = 0; i < teams.Count; i++)
                {
                    randomIndices.Add(i);
                }
                for (int i = 0; i < 100; i++)
                {
                    int idx1 = r.Next(teams.Count);
                    int idx2 = r.Next(teams.Count);
                    int temp = randomIndices[idx1];
                    randomIndices[idx1] = randomIndices[idx2];
                    randomIndices[idx2] = temp;
                }

                int noOfMatches = teams.Count / 2;
                for (int i = 0; i < noOfMatches; i++)
                {
                    Match newMatch = new Match
                    {
                        FirstOpponent = teams[randomIndices[2 * i]],
                        SecondOpponent = teams[randomIndices[2 * i + 1]]
                    };
                    newRound.AddMatch(newMatch);
                }
                selectedTournament.AddRound(newRound);
                int matchNo = 1;
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("        Liga: " + tournamentName);
                Console.WriteLine("          Runde " + numberOfRounds);
                Console.WriteLine("-----------------------------------------");
                foreach (Match m in newRound.matches)
                {
                    string first = PadSpaceToName(m.FirstOpponent.Name, 10);
                    string second = m.SecondOpponent.Name;
                    Console.WriteLine($"    {matchNo}. {first}  -  {second}");
                    matchNo++;
                }

                if (newRound.FreeRider != null)
                {
                    Console.WriteLine("        FreeRider: " + newRound.FreeRider.Name);
                }
                Console.WriteLine("-----------------------------------------");

                Console.Write("Tryk på en vilkårlig tast...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void SaveMatch(string tournamentName, int roundNumber, string team1, string team2, string winningTeam)
        {
            Tournament tournament = tournamentRepository.GetByName(tournamentName);
            Round selectedRound = tournament.GetRound(roundNumber);
            Team winner = tournament.GetTeam(winningTeam);
            Match m = selectedRound.GetMatch(tournament.GetTeam(team1), tournament.GetTeam(team2));
            m.Winner = tournament.GetTeam(winningTeam);
        }

        public Tournament GetTournament(string name)
        {
            return tournamentRepository.GetByName(name);
        }
    }
}
