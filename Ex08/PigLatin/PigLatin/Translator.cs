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

        public string Translate(string v, char[] language = null)
        {
            language = language == null ? ENGLISH : language;
            string[] split = v.Split(' ');

            for (int i = 0; i < split.Length; i++)
            {
                string pushback = "";
                
                bool isUpper = char.IsUpper(split[i][0]) ? true : false;
                split[i] = split[i].ToLower();

                for (int j = 0; j < split[i].Length; j++)
                {
                    if (language.Contains(split[i][j]))
                    {
                        break;
                    }
                    pushback += split[i][j];
                }
                split[i] = split[i].Substring(pushback.Length) + pushback + "ay";
                split[i] = isUpper ? (char.ToUpper(split[i][0]) + split[i].Substring(1)) : split[i];
            }

            return string.Join(" ", split);
        }
    }
}
