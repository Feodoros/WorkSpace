using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMove
{
    internal class Opel : Car
    {
        // Модель Опеля
        public string Model { get; set; }

        public Opel(int velocity, string moveSound, string velocityengine, string model) : base(velocity, moveSound, velocityengine)
        {
            Model = model;
        }

        public override string MakeSound()
        {
            return "Опель делает " + MoveSound;
        }
    }
}
