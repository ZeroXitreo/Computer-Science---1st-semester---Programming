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
            string[] splitResult = new string[split.Length];

            for (int i = 0; i < split.Length; i++)
            {
                string pushback = "";

                // Updownlow
                bool isUpper = false;
                if(char.IsUpper(split[i][0]))
                {
                    isUpper = true;
                }
                split[i] = split[i].ToLower();
                // That's how we go


                for (int j = 0; j < split[i].Length; j++)
                {
                    if (!language.Contains(split[i][j]))
                    {
                        pushback += split[i][j];
                    }
                    else
                    {
                        break;
                    }
                }
                splitResult[i] = split[i].Substring(pushback.Length) + pushback + "ay";
                splitResult[i] = isUpper ? (char.ToUpper(splitResult[i][0]) + splitResult[i].Substring(1)) : splitResult[i];
            }

            return string.Join(" ", splitResult);
        }
    }
}
