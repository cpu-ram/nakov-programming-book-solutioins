using System;

namespace _006._13._00_Converting_From_Decimal_To_Hexadecimal
{
    class Program
    {
                     
        static string[] ConvertToHexadecimalArray(double inputNum)
        {
                                          
            double[] powersString = new double[32]; // 'powerString' Array consisting of the powers of the base to which a conversion is done;
            string[] binaryMask = new string[32]; /* The returned array's declaration */

            double n = inputNum; // N
            double origN = n; // 'original 'N'
            double opN = n; // 'operational N';
            double nsp = 0; // "Nearest smaller power", initialization

            double val;
            int i = 0; 
            while (true)   // calculating the powerString array
            {
                val = Math.Pow(16, i);   
                powersString[i] = val;
                if (val > 100000) break;
                i++;
            }






            int f = 0; // power number / digit number
            int g = 0;
            double binarySum = 0;  // all service variables for the calculation cycle;


            while (opN > 0)
            {
                while (true) // first iteration of the cycle
                {
                    if (powersString[f] > opN) // Finding a power of 16 that is bigger than the inputted number;
                    {
                        f -= 1;
                        binaryMask[f] = "1"; /* here it has to iterate (int g) from 0 to F, and IF  
                                              *  ((g*(16^f))>orNum) { g--; hexMask[f]="g"; hexSum+=(g*(16^f));opN-=(g*(16^f));}
                                              * At the end, return hexMask.
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
                        binaryMask[f] = "0";
                    }

                    f++;
                }
            }




            return binaryMask;

        }
        static string ArrayToString(string[] binaryArray)
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
            Console.WriteLine("This program is going to convert a number from decimal to hexadecimal.\n\n");

            Console.WriteLine("Enter your natural number no bigger than 100000:"); // entering an N number to be converted back and forth;

            int inputNum = Int32.Parse(Console.ReadLine());

            string[] numArray = ConvertToHexadecimalArray(inputNum);
            string binaryVal = ArrayToString(numArray); // N converted to binary N2, as a string;

            Console.WriteLine($"You entered {inputNum}, and the binary representation of it is {binaryVal}."); // displaying the N2;
                


        }
    }
}
