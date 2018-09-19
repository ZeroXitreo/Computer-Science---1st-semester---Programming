using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex07_SimonSays
{
    public class Simon
    {
        public string Echo(string v)
        {
            return v.ToLower();
        }

        public string Shout(string v)
        {
            return v.ToUpper();
        }

        public string Repeat(string v, int repeat = 2)
        {
            string result = v;
            for (int i = 1; i < repeat; i++)
            {
                result += " " + v;
            }
            return result;
        }

        public string StartOfWord(string v1, int v2)
        {
            return v1.Substring(0, v2);
        }

        public string FirstWord(string v)
        {
            string fullword = "";
            foreach (char character in v)
            {
                if(character == ' ')
                {
                    break;
                }
                fullword += character;
            }
            return fullword;
        }

        public string Titleize(string v)
        {
            string[] words = v.Split(' ');
            string finalWord = "";
            string[] lowerCaseWords = new string[] { "the", "over", "and" };
            
            for (int i = 0; i < words.Length; i++)
            {
                if (lowerCaseWords.Contains(words[i].ToLower()) && i != 0)
                {
                    finalWord += words[i] + " ";
                }
                else
                {
                    finalWord += char.ToUpper(words[i][0]) + words[i].Substring(1) + " ";
                }
            }
            return finalWord.Remove(finalWord.Length-1, 1);
        }
    }
}
