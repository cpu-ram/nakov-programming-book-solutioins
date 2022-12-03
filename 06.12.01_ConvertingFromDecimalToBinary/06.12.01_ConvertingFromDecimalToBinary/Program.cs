using System;

namespace _06._12._01_ConvertingFromDecimalToBinary
{
    class Program
    {
        static string Print(int[] binaryMask) /* This Method takes an array that stores the values of every digit of the
                                               'operational' binary mask and returns a 32-character string fit to be displayed. 
                                               */

        {

            string val = "";
            for (int i = 31; i >= 0; i--)
            {
                val += binaryMask[i];
            }
            return val;
        }

        static void Main(string[] args)
        {
            /*
             
            Console.WriteLine("This is a test area. " +
                "\n\n\n");

            Console.WriteLine("Hello! This program will take a decimal number 10000 and convert it to its binary representation " +
               "through a sequence of operations.\n " +
               "\nThe original number N=10000;" +
               "\nThe original base = 10;" +
               "\nThe base to which the number is converted is 2;\n\n"); // program's introduction;

            Console.WriteLine("Calculating the powers of the Convert-To base... \n");
            */


            double[] powersString = new double[30]; // Array consisting of the powers of the base to which a conversion is done;
            int[] binaryMask = new int[32]; /* Declaration of an array that is meant to store the digits of the converted number
                                               (to be displayed later) */

            double n = 10000;
            double origN = n;

            Console.WriteLine($"Original decimal number: {origN}");
            double opN = n; // all service variables;
            double nsp = 0; // "Nearest smaller power", initialization

            double val;
            int i = 0; // service variables for building a base-powers array
            while (true)   // assigning array elements
            {
                val = Math.Pow(2, i);
                powersString[i] = val;
                if (val > 100000) break;
                i++;
            }


            /*
            Console.WriteLine($"\n________________________" +
                $"\n The powers array for the base of two is calculated, the results can be seen above." +
                $" \n The binary representation is being calculated. \n" +
                $"As the program goes through its iterations, the 'Operational value' numeral is constantly decreasing whereas the " +
                $"binary mask is ever-increasing." +
                              $"\n________________________\n\n");
            */

            int f = 0;
            int g = 0;
            double binarySum = 0;  // all service variables for the calculation cycle;


            while (opN > 0)
            {
                while (true) // first iteration of the cycle
                {
                    if (powersString[f] > opN) // if we are at an element of the array that follows the NSP directly...;
                    {
                        f -= 1;
                        binaryMask[f] = 1;
                        nsp = Math.Pow(2, f);
                        binarySum += nsp;
                        f++;
                        g++;


                        /*
                        Console.WriteLine($"\n\nSignificant bit #{g} found at position #{f}," +
                            $"\nOperational N = {opN}," +
                            $"\nNearest Smaller Number={nsp},\n " +
                            $"the current sum of the binary components = {binarySum},\n" +
                            $"the binary representation of that sum is " + Print(binaryMask) + "\n\n");
                        */

                        opN -= nsp;
                        f = 0;
                        break;
                    }

                    else
                    {
                        binaryMask[f] = 0;
                    }

                    f++;
                }
            }


            if (binarySum == origN)
            {
                Console.WriteLine("" +
                //$"\nOperational N = {opN}," +
                //$"the current sum of the binary components = {binarySum},\n" +
                $"the binary representation: " + Print(binaryMask) + "\n\n");


            }





        }
    }
}
