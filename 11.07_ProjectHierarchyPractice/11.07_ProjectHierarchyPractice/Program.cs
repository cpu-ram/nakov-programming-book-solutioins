using System;
using _11._07_ProjectHierarchyPractice.CreatingAndUsingObjects;

namespace _11._07_ProjectHierarchyPractice
{
    class Example
    {
        static void Main(string[] args)
        {
            Cat kitty = new Cat("Kitty", "black");
            kitty.SayMiau();
            Sequence seq = new Sequence();
            Console.WriteLine(seq.NextValue);
        }
    }

}
