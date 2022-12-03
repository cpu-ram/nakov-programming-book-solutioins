using System;

namespace _05._07._00_GreatestOfFiveNumbers
{
    class Program
    {

        static void ReplVal(ref int a, ref int b)                           // functional method -- begins
        {
            int c = a;
            a = b;
            b = c;

        }


        static void Main(string[] args)
        {
            int[] list = new int[5];


            list[0] = 5;
            list[1] = 1;
            list[2] = 5;
            list[3] = 1;
            list[4] = 4;

            for(int i=0; i<=4; i++)
            {
                Console.WriteLine($"Element {i}=" + list[i]);        //display the initial values;
                
            }
            Console.WriteLine("_________________________________\n\n"); // separator


            int bigger=0;
            for(int i=0; i<4; i++)
            {
                Console.WriteLine($"We're at iteration {i}.\n Element #{i} = " + list[i] + $",\n Element #{i+1} = {list[i+1]}; ");

                if ((list[i]) >= (list[i + 1])) 
                {
                    if (list[i] > bigger)
                    {
                        bigger = list[i];
                    }
                }
                else
                {
                    if (list[i + 1] > bigger)
                    {
                        bigger = list[i + 1];
                    }
                }
                Console.WriteLine($"Biggest number is {bigger} \n\n ");
            }


            

        }
    }
}
