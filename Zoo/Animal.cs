using System;

namespace Zoo
{
    public class Animal
    {
        public int Age;
        public string Sex;
        public string Name;
        public int Weight;
        
        public Animal(int age, string sex, int weight)
        {
            Age = age;
            Sex = sex;
            Weight = weight;
            Name = "Неизвестно";
        }
        
        public Animal(int age, string sex, string name, int weight)
        {
            Age = age;
            Sex = sex;
            Name = name;
            Weight = weight;
        }

        public void GetInfo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Age: {Age}, Sex: {Sex}, Name: {Name}, Weight: {Weight}.");
            Console.ResetColor();
        }
    }
}