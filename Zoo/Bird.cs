using System;
using System.Drawing;
using System.Dynamic;

namespace Zoo
{
    public class Bird : Animal
    {
        public int WingLenght { get; set; }

        public int TimeFlight { get; set; }

        public Bird(int age, string sex, int weight, int wingLenght, int timeFlight) : base(age, sex, weight)
        {
            WingLenght = wingLenght;
            TimeFlight = timeFlight;
        }

        public Bird(int age, string sex, string name, int weight, int wingLenght, int timeFlight) : base(age, sex, name, weight)
        {
            WingLenght = wingLenght;
            TimeFlight = timeFlight;
        }

        public override void GetInfo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Age: {Age}, Sex: {Sex}, Name: {Name}, Weight: {Weight}, TimeFlight: {TimeFlight}, WingLenght: {WingLenght}.");
            Console.ResetColor();
        }
    }
}