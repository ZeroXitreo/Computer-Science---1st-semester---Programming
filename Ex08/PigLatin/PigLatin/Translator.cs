using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigLatin
{
    public class Translator
    {
        public static readonly char[] ENGLISH = { 'a', 'e', 'i', 'o' };
        public static readonly char[] DANISH = { 'a', 'e', 'i', 'o', 'u', 'y', 'æ', 'ø', 'å' };

        public string Translate(string sentence, char[] languageVocals = null)
        {
            languageVocals = languageVocals ?? ENGLISH;
            string[] split = sentence.Split(' ');

            for (int i = 0; i < split.Length; i++)
            {
                split[i] = TranslateWord(split[i], languageVocals);
            }

            return string.Join(" ", split);
        }

        private string TranslateWord(string word, char[] languageVocals)
        {
            bool isUpper = char.IsUpper(word[0]) ? true : false;
            word = word.ToLower();

            for (int i = 0; i < word.Length; i++)
            {
                if (languageVocals.Contains(word[0]))
                {
                    break;
                }
                word = word.Substring(1) + word[0];
            }
            return (isUpper ? CapitalizeFirstLetter(word) : word) + "ay";
        }

        private string CapitalizeFirstLetter(string word)
        {
            return char.ToUpper(word[0]) + word.Substring(1);
        }
    }
}
