using System;

namespace AlgorithmRutishauser
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            string res = AlgorithmRutishauser.Rutishauser("(1 + (5 * (32 / 3)) )");
            
            Console.WriteLine(res);
        }

    }
}