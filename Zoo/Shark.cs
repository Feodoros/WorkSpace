using System;

namespace Zoo
{
    public class Shark : Fish
    {
        private string seaOrRiver;

        public override string SeaOrRiver
        {
            get { return seaOrRiver; }
            set
            {
                if (seaOrRiver != "Sea")
                {
                    Console.WriteLine("Вообще-то акулы морские...");
                }
                
                seaOrRiver = value;
            }
        }

        public Shark(int age, string sex, int weight, string seaOrRiver) : base(age, sex, weight, seaOrRiver)
        {
        }

        public Shark(int age, string sex, string name, int weight, string seaOrRiver) : base(age, sex, name, weight, seaOrRiver)
        {
        }
        
    }
}