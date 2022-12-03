using System;

namespace _02._03._00_ComparingRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
             * 
             The task: 
             Write a program, which compares correctly two real numbers with
             accuracy at least 0.000001.

             Guideline: 
             Two floating-point variables are considered equal if their difference is less
             than some predefined precision (e.g. 0.000001):
             bool equal = Math.Abs(a - b) < 0.000001;
             ____________________
            Comment: 
            their guideline looks weird to me. I'll try to compare them the regular way.

            What I learned: 
            make sure to double the equasion sign in the conditions.

            My questions:
            1) Why does the Console display the small Float Type numbers so weirdly, like "3.3E-05" etc. ?
            */

            float firstNumber = 0.000033F;
            float secondNumber = 0.000040F;
            bool firstBool = (firstNumber == secondNumber);

            
            
            if (firstBool)
            {
                Console.WriteLine(firstNumber + " = " + secondNumber);
            }
            else
            {
                Console.WriteLine(firstNumber + " != " + secondNumber);
            }


        }
    }
}
