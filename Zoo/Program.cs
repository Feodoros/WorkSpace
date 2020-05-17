using System;

namespace Zoo
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal newAnimal = new Animal(18, "Female", 12);

            Animal newAnimal2 = new Animal(7, "Male", "Kesha", 12);
            
            newAnimal.GetInfo();
            newAnimal2.GetInfo();
            
            int x = newAnimal.Age;
            newAnimal.Age = 12;
            Console.WriteLine(x);
            newAnimal.GetInfo();

        }
    }
}