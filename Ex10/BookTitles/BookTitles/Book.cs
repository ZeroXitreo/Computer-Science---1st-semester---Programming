using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTitles
{
    public class Book
    {
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                string[] words = value.Split(' ');
                string finalWord = "";
                string[] lowerCaseWords = new string[] { "the", "over", "and", "a", "an", "in", "of" };

                for (int i = 0; i < words.Length; i++)
                {
                    if (string.IsNullOrEmpty(words[i]))
                    {
                        continue;
                    }
                    if (lowerCaseWords.Contains(words[i].ToLower()) && i != 0)
                    {
                        finalWord += words[i] + " ";
                    }
                    else
                    {
                        finalWord += char.ToUpper(words[i][0]) + words[i].Substring(1) + " ";
                    }
                }
                title = finalWord.Remove(finalWord.Length - 1, 1);
            }
        }
        private string title;
    }
}
