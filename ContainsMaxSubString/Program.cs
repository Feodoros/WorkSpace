using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace ContainsMaxSubString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string text = "abcbbbcfvbcc";

            string pattern = "ab*cf*bc";

            bool check = RegexContainsSubString(pattern, text);

            bool check1 = ListContainsSubString(pattern, text);

        }

        // Решение с помощью Regex 
        private static bool RegexContainsSubString(string pattern, string text)
        {
            string replace = pattern.Replace("*", "\\D*");
            Regex regex = new Regex(replace);
            MatchCollection matches = regex.Matches(text);
            return matches.Count != 0;
        }
        
        
        private static bool ListContainsSubString(string pattern, string text)
        {
            List<string> listMatches = pattern.Split('*').ToList();
            
            int check = 1;
            
            foreach (var match in listMatches)
            {
                check *= Convert.ToInt32(text.Contains(match));
            }
            
            return Convert.ToBoolean(check);
        }
    }
}