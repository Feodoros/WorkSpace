using System;
using System.Text;
using System.Collections.Generic;

namespace h
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var res = Check("(((ыыыааа)0))");
            Console.Write(res ? "True" : "False");
        }

        static bool Check(string CheckString)
        {
            Stack<char> brackets = new Stack<char>();
            var bracket = new Dictionary<char, char>
            {
                {')','(' },
                {']','[' },
                {'}','{' }
            };

            char[] openBrackets = { '(', '{', '[' };
            char[] closeBrackets = { ')', '}', ']' };

            foreach (var symbol in CheckString)
            {
                if (Array.IndexOf(openBrackets, symbol) > -1)
                    brackets.Push(symbol);
                for (int i = 0; i < closeBrackets.Length; i++)
                {
                    if (symbol == closeBrackets[i])
                    {
                        if (brackets.Count == 0 || brackets.Pop() != bracket[symbol])
                            return false;
                    }
                }
            }
            return brackets.Count == 0;
        }
    }
}
