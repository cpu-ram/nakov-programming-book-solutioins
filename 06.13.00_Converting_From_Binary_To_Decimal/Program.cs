using System;

namespace _06._13._00_Converting_From_Binary_To_Decimal
{
    class Program
    {



        
        static int[] ConvertToBinaryArray(double inputNum)
        {





            double[] powersString = new double[30]; // Array consisting of the powers of the base to which a conversion is done;
            int[] binaryMask = new int[32]; /* Declaration of an array that is meant to store the digits of the converted number
                                               (to be displayed later) */

            double n = inputNum;
            double origN = n;
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




            return binaryMask;

        }
        static string ArrayToString(int[] binaryArray)
        {
            /* This Method takes an array that stores the values of every digit of the
             * 'operational' binary mask and returns a 32-character string fit to be displayed. 
             */

            string val = "";
            for (int i = 31; i >= 0; i--)
            {
                val += binaryArray[i];
            }
            return val;
        }

        static void Main()
        {
            Console.WriteLine("Enter your natural number no bigger than 10000:"); // entering an N number to be converted back and forth;

            int inputNum = Int32.Parse(Console.ReadLine());

            int[] numArray = ConvertToBinaryArray(inputNum);
            string binaryVal = ArrayToString(numArray); // N converted to binary N2, as a string;

            Console.WriteLine($"You entered {inputNum}, and the binary representation of it is {binaryVal}." + // displaying the N2;
                $"\nReverse-calculating the decimal value...");

            double sum = 0; // initializing the sum value which in the end be equal to the decimal representation of N2;
            double element = 0; // likewise, initializing the "element" integral which is to be updated at each iteration during the cycle;

            for (double i = 0; i < 32; i++)
            {
                int switchCondition = Convert.ToInt32(i);
                switch (numArray[switchCondition])
                {

                    case 1:
                        element = Math.Pow(Convert.ToDouble(2), (i));
                        break;

                    default:
                        element = 0;
                        break;
                }
                sum += element;
            }
            Console.WriteLine(sum);


        }
    }
}
