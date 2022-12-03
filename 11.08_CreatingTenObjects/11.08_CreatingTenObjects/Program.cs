using System;
using _11._08_CreatingTenObjects.CreatingAndUsingObjects;

namespace _11._08_CreatingTenObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat[] catArray = new Cat[10];


            for(int i=0; i<10; i++)
            {
                string tempString = "#" + i;
                Cat tempCat=new Cat(tempString, "black");
                catArray[i] = tempCat;
                catArray[i].SayMiau();


            }
        }
    }
}
