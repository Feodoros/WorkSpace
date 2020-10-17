using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMove
{
    class Human : IMove
    {
        public int Velocity { get; set; }
        public string MoveSound { get; set; } = "...";
        public string VelocityEngine { get; set; }

        public Human(int velocity, string velocityEngine)
        {
            Velocity = velocity;            
            VelocityEngine = velocityEngine;
        }

        public string MakeSound()
        {
            return "Человек делает " + MoveSound;
        }
    }
}
