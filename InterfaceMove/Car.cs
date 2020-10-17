using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMove
{
    abstract class Car : IMove
    {
        public int Velocity { get; set; }
        public string MoveSound { get; set; }
        public string VelocityEngine { get; set; }

        public Car(int velocity, string moveSound, string velocityEngine)
        {
            Velocity = velocity;
            MoveSound = moveSound;
            VelocityEngine = velocityEngine;
        } 

        public virtual void SomeCarMethod()
        {

        }

        public virtual string MakeSound()
        {
            return "Машина делает " + MoveSound;
        }
    }
}
