using System;

namespace Zoo
{
    public abstract class Animal
    {

        #region Getters-Setters
        public int Age { get; set; }

        public string Sex { get; set; }

        public string Name { get; set; }

        public int Weight { get; set; }
        
        #endregion

        #region Constructor's
        public Animal(int age, string sex, int weight)
        { 
            Age = age;
            Sex = sex;
            Weight = weight;
            Name = "Неизвестно";
        }
        
        public Animal(int age, string sex, string name, int weight)
        {
            Age = age;
            Sex = sex;
            Name = name;
            Weight = weight;
        }

        #endregion

        public abstract void GetInfo();

    }
}