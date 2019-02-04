using System;

namespace BadCode
{
    public class Menu
    {
        private Controller controller = null;

        public Menu()
        {
            controller = new Controller();
        }

        public void RunMenu()
        {
            string tournamentName = null;
            bool running = true;
            do
            {
                Console.WriteLine("Dragons Lair");
                Console.WriteLine();
                Console.WriteLine("1. Præsenter ligastilling");
                Console.WriteLine("2. Planlæg runde i liga");
                Console.WriteLine("3. Afvikl kamp");
                Console.WriteLine();
                Console.WriteLine("0. Exit");
                Console.WriteLine();
                Console.Write("Indtast dit valg: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "0":
                        running = false;
                        break;
                    case "1":
                        Console.Write("Angiv navn på liga: ");
                        tournamentName = Console.ReadLine();
                        controller.ShowScore(tournamentName);
                        break;
                    case "2":
                        Console.Write("Angiv navn på liga: ");
                        tournamentName = Console.ReadLine();
                        controller.ScheduleNewRound(tournamentName);
                        break;
                    case "3":
                        Console.Write("Angiv navn på liga: ");
                        tournamentName = Console.ReadLine();
                        Console.Write("Angiv runde: ");
                        string round = Console.ReadLine();
                        int roundnr = int.Parse(round);
                        Console.Write("Angiv første modstander: ");
                        string opponent1 = Console.ReadLine();
                        Console.Write("Angiv anden modstander: ");
                        string opponent2 = Console.ReadLine();
                        Console.Write("Angiv vinderhold: ");
                        string winner = Console.ReadLine();
                        Console.Clear();
                        controller.SaveMatch(tournamentName, roundnr, opponent1, opponent2, winner);
                        break;
                    default:
                        Console.WriteLine("Ugyldigt valg.");
                        Console.ReadLine();
                        break;
                }
            } while (running);
        }
    }
}