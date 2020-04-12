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
            
            MyStruct[] y = {};
            StructurList<MyStruct> x = new StructurList<MyStruct>(y);
            
            AlgorithmRutishauser t = new AlgorithmRutishauser();
            
            string res = t.Rutishauser("(2+(1+1))");
            
            Console.WriteLine(x);
        }
        
        
    }
}