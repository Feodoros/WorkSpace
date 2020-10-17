using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMove
{
    class Plane :IMove
    {
        public int Velocity { get; set; }
        public string MoveSound { get; set; } = "Тууууууу";
        public string VelocityEngine { get; set; }

        public Plane(int velocity, string velocityEngine)
        {
            Velocity = velocity;
            VelocityEngine = velocityEngine;
        }

        public string MakeSound()
        {
            return "Самолет делает " + MoveSound;
        }
    }
}
