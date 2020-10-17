using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMove
{
    class Program
    {
        delegate string MakeNoize();
        static void Main(string[] args)
        {
            MakeNoize makeNoize;

            Opel opel = new Opel(60, "Бип-Бип", "Двигатель", "ModelX");

            string model = opel.Model;


            Mitshubishi mitshubishi = new Mitshubishi(60, "Беп-Беп", "Двигатель");

            Plane plane = new Plane(900, "Супер-Двигатель");

            Train train = new Train(90, "Туу-Туу", "Двигатель поезда");

            List<IMove> list = new List<IMove>() { opel, mitshubishi, train, plane };

            list.ForEach(l => Console.WriteLine(l.MakeSound()));

            List<Car> cars = new List<Car>() { opel, mitshubishi };

            cars[0].SomeCarMethod();


            List<IMove> ImoveCars = (List<IMove>)(IMove)cars;

            makeNoize = null;

            foreach (var l in list)
            {
                if (l.MoveSound.Equals("Беп-Беп"))
                {
                    //Console.WriteLine(l.MakeSound());
                    makeNoize = l.MakeSound;
                }
            }

            if (DateTime.Now == new DateTime(2020, 10, 18))
            {
                string newS = makeNoize() + " something else";
            }




            /*foreach(var l in list)
            {
                Console.WriteLine(l.MakeSound());
            }
            */

            Console.ReadLine();
        }
    }
}
