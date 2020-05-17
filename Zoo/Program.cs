using System;

namespace Zoo
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Beast beast1 = new Beast(13, "Male", "Alpha", 12, "White", "Wolf");
            
            beast1.GetInfo();
            
            Bird bird1 = new Bird(2, "Female", 1, 6, 110);
            bird1.GetInfo();
            
            Carp carp1 = new Carp(10, "Male", 4, "Sea", 7);
            carp1.GetInfo();
            carp1.GetFishInfo();
            
            Shark shark1 = new Shark(10, "Male", 4, "Sea");
            shark1.GetFishInfo();
        }
    }
}