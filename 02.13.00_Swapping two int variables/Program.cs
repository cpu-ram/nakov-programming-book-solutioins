using System;

namespace _02._13._00_Swapping_two_int_variables
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5; 
            int b = 10; //declaring initial values

            int x = a;
            int a = b;
            int b = x; // swapping the values using an intermediary value for the transfer
        }
    }
}
