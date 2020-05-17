﻿using System;

namespace Zoo
{
    public class Fish : Animal
    {
        public string SeaOrRiver { get; set; }

        public Fish(int age, string sex, int weight, string seaOrRiver) : base(age, sex, weight)
        {
            SeaOrRiver = seaOrRiver;
        }

        public Fish(int age, string sex, string name, int weight, string seaOrRiver) : base(age, sex, name, weight)
        {
            SeaOrRiver = seaOrRiver;
        }

        public override void GetInfo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Age: {Age}, Sex: {Sex}, Name: {Name}, Weight: {Weight}, SeaOrRiver: {SeaOrRiver}.");
            Console.ResetColor();
        }
    }
}