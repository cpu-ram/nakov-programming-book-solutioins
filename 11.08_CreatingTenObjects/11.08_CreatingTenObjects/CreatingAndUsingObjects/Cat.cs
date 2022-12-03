using System;
namespace _11._08_CreatingTenObjects.CreatingAndUsingObjects
{
    public class Cat
    {
        private string name;
        private string color;
        public Cat()
        {
            this.name = "Unnamed";
            this.color = "grey";

        }
        public Cat(string name, string color)
        {
            this.name = name;
            this.color = color;

        }
        public void SayMiau()
        {
            Console.WriteLine("{0} cat {1} said :Miauuu", color, name);
        }

    }



}
