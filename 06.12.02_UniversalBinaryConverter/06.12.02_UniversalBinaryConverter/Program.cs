using System;

namespace _06._12._02_UniversalBinaryConverter
{
    class Program
    {
        static string Print(int[] binaryMask) 

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

            ConvertFromDecimalToBinary();




        }

        static string ConvertFromDecimalToBinary(double entryDouble=9999)
        {
            string resultString = "";




            double[] powersString = new double[30]; // Array consisting of the powers of the base to which a conversion is done;
            int[] binaryMask = new int[32]; /* Declaration of an array that is meant to store the digits of the converted number
                                               (to be displayed later) */

            double entryDoubleZero = 10000;
            double origN = entryDoubleZero;
            double opN = entryDoubleZero; // all service variables;
            double nsp = 0; // "Nearest smaller power", initialization

            double val;
            int i = 0; // service variables for building a base-powers array
            while (true)   // assigning array elements
            {
                val = Math.Pow(2, i);
                powersString[i] = val;
                //Console.WriteLine(val);
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
                        opN -= nsp;
                        */

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

            
            Console.WriteLine("The binary result: " + Print(binaryMask) + "\n\n");
           




            return resultString;
        }
    }
}
