using System;
using System.Collections.Generic;
using System.Linq;

namespace WordGen
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberElements = 2;
            int length = 3;
            
            // Заполняем массив буквами
            char[] letters = LetterArray(numberElements);
            
            WordGeneration(letters, length);
            
        }

        private static void WordGeneration (char[] letters, int length)
        {
            int numberElements = letters.Length;
            for(int i = 0; i < Math.Pow(numberElements, length); i++)
            {
                string s = "";
                int ii = i;
                for (int j = 0; j < length; j++)
                {
                    s += letters[ii % numberElements];
                    ii /= numberElements;
                }
                Console.WriteLine(s);
            }
            Console.ReadKey();
        }
        private static char[] LetterArray(int numberElements)
        {
            if (numberElements > 32)
                numberElements = 32;
            
            char[] letters = new char[numberElements];
            
            for (int i = 0; i < numberElements; i++)
            {
                letters[i] = (char) (i+1040);
            }

            return letters;
        }
    }
}