using System;

namespace Zoo
{
    public class Beast : Animal
    {
        public string Color { get; set; }
        public string Type { get; set; }

        private bool isAlpha = false;
        
        public Beast(int age, string sex, int weight, string color, string type, bool isAlpha) : base(age, sex, weight)
        {
            this.isAlpha = isAlpha;
            Type = type;
            Color = color;
        }
        
        public Beast(int age, string sex, string name, int weight, string color, string type) : base(age, sex, name, weight)
        {
            Type = type;
            Color = color;
        }


        public override void GetInfo() 
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Age: {Age}, Sex: {Sex}, Name: {Name}, Weight: {Weight}, Color: {Color}, Type: {Type}, IsAlpha: {isAlpha}.");
            Console.ResetColor();
        }
        
    }
}