﻿using System;

namespace _04._05._00_BasicSwitchUse
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter a digit:");
            int a = Int32.Parse(Console.ReadLine());

            string num="";

            switch (a)
            {
                case 0:
                    num = "zero";
                    break;
                case 1:
                    num = "one";
                    break;
                case 2:
                    num = "two";
                    break;
                case 3:
                    num = "three";
                    break;
                case 4:
                    num = "four";
                    break;
                case 5:
                    num = "five";
                    break;
                case 6:
                    num = "six";
                    break;
                case 7:
                    num = "seven";
                    break;
                case 8:
                    num = "eight";
                    break;
                case 9:
                    num = "nine";
                    break;

                default:
                    Console.WriteLine("Enter a digit, please.");
                    break;

            }

            Console.WriteLine("You entered '{0}' number.", num);





        }
    }
}
