using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morgengry
{
    public class ValuableRepository : IPersistable
    {
        private List<IValuable> Valuables = new List<IValuable>();
        private string DefaultFilename = "ValuableRepository.txt";

        public void AddValuable(IValuable valuable)
        {
            Valuables.Add(valuable);
        }

        public IValuable GetValuable(string itemId)
        {
            foreach (IValuable valuable in Valuables)
            {
                switch (valuable)
                {
                    case Merchandise merchandise:
                        if (merchandise.ItemId == itemId)
                        {
                            return merchandise;
                        }
                        break;
                    case Course course:
                        if (course.Name == itemId)
                        {
                            return course;
                        }
                        break;
                    default:
                        break;
                }
            }
            return null;
        }

        public double GetTotalValue()
        {
            double total = 0;
            foreach (IValuable valuable in Valuables)
            {
                total += valuable.GetValue();
            }
            return total;
        }

        public int Count()
        {
            return Valuables.Count;
        }

        public void Save()
        {
            Save(DefaultFilename);
        }

        public void Save(string filename)
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (IValuable valuable in Valuables)
                {
                    switch (valuable)
                    {
                        case Book book:
                            outputFile.WriteLine(string.Format("BOG; {0}; {1}; {2}", book.ItemId, book.Title, book.Price));
                            break;
                        case Amulet amulet:
                            outputFile.WriteLine(string.Format("AMULET; {0}; {1}; {2}", amulet.ItemId, (int)amulet.Quality, amulet.Design));
                            break;
                        case Course course:
                            outputFile.WriteLine(string.Format("COURSE; {0}; {1}", course.Name, course.DurationInMinutes));
                            break;
                    }
                }
            }
        }

        public void Load()
        {
            Load(DefaultFilename);
        }

        public void Load(string filename)
        {
            Valuables = new List<IValuable>();
            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] split = line.Split(';');

                        for (int i = 0; i < split.Length; i++)
                        {
                            split[i] = split[i].Trim();
                        }

                        switch (split[0])
                        {
                            case "BOG":
                                Valuables.Add(new Book(split[1], split[2], double.Parse(split[3])));
                                break;
                            case "AMULET":
                                Valuables.Add(new Amulet(split[1], (Level)int.Parse(split[2]), split[3]));
                                break;
                            case "COURSE":
                                Valuables.Add(new Course(split[1], int.Parse(split[2])));
                                break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
