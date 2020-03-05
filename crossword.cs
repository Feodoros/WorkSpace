using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace crsswrd
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string[] BaseOfWords = { "булка", "поток", "плющ", "бум", "смех" };
            string HorizontalWord = "лопух";

            List<char[]> Cross = Crossword(BaseOfWords, HorizontalWord);
            Print(Cross, HorizontalWord);
        }

        public static List<char[]> Crossword(string[] BaseOfWords, string HorizontalWord)
        {
            int[] indexes = new int[HorizontalWord.Length];

            List<char[]> FinalWords = new List<char[]>();

            for (int i = 0; i < HorizontalWord.Length; i++)
            {
                int index = BaseOfWords[i].IndexOf(HorizontalWord[i]);

                if (index == -1 || HorizontalWord.Length != BaseOfWords.Length)
                    ImpossibleMakingCross();

                indexes[i] = index;
            }

            int max = indexes.Max();

            for (int i = 0; i < BaseOfWords.Length; i++)
            {
                int NumOfSpaces = max - indexes[i];
                char[] spaces = new char[NumOfSpaces];
                for (int j = 0; j < NumOfSpaces; j++)
                {
                    spaces[j] = ' ';
                }
                char[] FinalWord = new char[spaces.Length + BaseOfWords[i].Length];
                spaces.CopyTo(FinalWord, 0);
                BaseOfWords[i].ToCharArray().CopyTo(FinalWord, spaces.Length);

                FinalWords.Add(FinalWord);
            }
            return FinalWords;
        }

        public static void ImpossibleMakingCross()
        {
            Console.WriteLine("не возможно сделать кроссворд!");
            Environment.Exit(-1);
        }

        public static void Print(List<char[]> BaseOfWords, string HorizontalWord)
        {
            for (int i = 0; i < HorizontalWord.Length; i++)
            {
                bool isFirst = true;
                for (int j = 0; j < BaseOfWords[i].Length; j++)
                {
                    if (isFirst && BaseOfWords[i][j] == HorizontalWord[i])
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        isFirst = false;
                    }
                    else
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(BaseOfWords[i][j] + " ");
                }
                Console.WriteLine();

            }
        }
    }
}