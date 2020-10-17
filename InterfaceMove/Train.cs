using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMove
{
    class Train : IMove
    {
        public int Velocity { get; set ; }
        public string MoveSound { get; set; }
        public string VelocityEngine { get ; set; }

        public Train(int velocity, string moveSound, string velocityEngine)
        {
            Velocity = velocity;
            MoveSound = moveSound;
            VelocityEngine = velocityEngine;
        }

        public string MakeSound()
        {
            return "Поезд делает " + MoveSound;
        }

        public void SomeMethod()
        {

        }
    }
}
