using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace AlgorithmRutishauser
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //MyStruct[] y = {};
            int[] y = new[] {1, 2, 3};
            StructurList<int> x = new StructurList<int>(y);
            
            AlgorithmRutishauser t = new AlgorithmRutishauser();
            
            x.Add(4, 1);
            x.Remove(2);
            
            string res = t.Rutishauser("((7*(43+99))+(35+24))");
            
            Console.WriteLine(x);
        }
        
        
    }
}