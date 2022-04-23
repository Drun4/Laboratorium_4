using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Laboratorium_4
{
    public static class Extenion
    {
        public static string changeLetters(this string str)
        {
            int symbolNumber = 0;
            string result = "";
            foreach (var symbol in str)
            {
                if (symbol == Convert.ToChar(" "))
                {
                    result += " ";
                }
                else if (char.IsLetter(symbol))
                {
                    symbolNumber++;
                    if (symbolNumber % 2 == 1)
                    {
                        result += char.ToUpper(symbol);
                    }
                    else
                    {
                        result += char.ToLower(symbol);
                    }
                }
            }
            return result;
        }

        public static string removeVovels(this string str)
        {
            Regex rgx = new Regex("[aeiouAEIOU]");
            string result = "";
            foreach (var symbol in str)
            {
                if (!rgx.IsMatch(Convert.ToString(symbol)))
                {
                    result += symbol;
                }
            }
            return result;
        }

        public static int[] getWordsLength(this string str)
        {
            int spaceAmount = 0;
            foreach (var symbol in str)
            {
                if(Convert.ToString(symbol) == " ")
                {
                    spaceAmount++;
                }
            }

            int[] lengthTab = new int[spaceAmount + 1];
            int wordNumber = 0;
            foreach(var symbol in str)
            {
                if (Convert.ToString(symbol) == " ")
                {
                    wordNumber++;
                }
                else
                {
                    lengthTab[wordNumber]++;
                }
            }
            return lengthTab;
        }

        public static bool isSentence(this string str)
        {
            bool result;
            if (!char.IsLetter(str[0]))
            {
                return false;
            }
            if (str[0] == char.ToUpper(str[0]) && str[str.Length - 1] == Convert.ToChar("."))
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public static string mostCommonElement(this IEnumerable<char> str)
        {
            char element = ' ';
            int maxCount = int.MinValue;
            List<char> lista = str.ToList();
            foreach (var symbol in lista)
            {
                int count = 0;
                for (int i = 0; i < lista.Count; i++)
                {
                    if(lista[i] == symbol)
                    {
                        count++;
                        if (count > maxCount)
                        {
                            maxCount = count;
                            element = symbol;
                        }
                    }
                }
            }
            return Convert.ToString(element);
        }
    }
}
