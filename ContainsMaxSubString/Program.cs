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
            string text = "afabcbbbcfvbcc";
            string pattern = "afa*b*cf*bc";
            
            
            bool check0 = RegexContainsSubString(pattern, text);

            bool check1 = ListContainsSubString(pattern, text);
            
            bool check2 = ContainsSubString(pattern, text);
            
            Console.WriteLine($"{check0}, {check1}, {check2}");

        }

        // Решение с помощью Regex 
        private static bool RegexContainsSubString(string pattern, string text)
        {
            string replace = pattern.Replace("*", "\\D*");
            Regex regex = new Regex(replace);
            MatchCollection matches = regex.Matches(text);
            return matches.Count != 0;
        }
        
        // Решение с помощью сплита строки
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

        // Решение алгоритмом в один проход (O(n))
        private static bool ContainsSubString(string pattern, string text)
        {
            string match = "";
            int count = 0;
            
            for (int i = 0; i < text.Length - 1; i++)
            {
                while (text[i] == pattern[i - count] && pattern[i - count].ToString() != "") 
                {
                    match += pattern[i - count];
                    i++;
                    if (i - count > pattern.Length - 1)
                        break;
                }
                
                if ((i - count <= pattern.Length - 1) && pattern[i - count] == '*')
                {
                    match += "*";
                    pattern = pattern.Replace(match, "");
                    count += match.Length - 1;
                    match = "";
                }

                if (i - count > pattern.Length - 1)
                {
                    pattern = pattern.Replace(match, "");
                }

                count++;
            }

            return pattern.Length == 0;
        }
    }
}