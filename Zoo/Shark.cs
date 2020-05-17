namespace Zoo
{
    public class Shark : Fish
    {
        public Shark(int age, string sex, int weight, string seaOrRiver) : base(age, sex, weight, seaOrRiver)
        {
        }

        public Shark(int age, string sex, string name, int weight, string seaOrRiver) : base(age, sex, name, weight, seaOrRiver)
        {
        }
        
    }
}