using System;

namespace Zoo
{
    public sealed class Carp : Fish
    {
        public int JumpLenght { get; set; }

        public Carp(int age, string sex, int weight, string seaOrRiver, int jumpLenght) : base(age, sex, weight, seaOrRiver)
        {
            JumpLenght = jumpLenght;
        }

        public Carp(int age, string sex, string name, int weight, string seaOrRiver,  int jumpLenght) : base(age, sex, name, weight, seaOrRiver)
        {
            JumpLenght = jumpLenght;
        }

        public override void GetFishInfo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"SeaOrRiver: {SeaOrRiver}, JumpLenght: {JumpLenght}.");
            Console.ResetColor();
        }
    }
}