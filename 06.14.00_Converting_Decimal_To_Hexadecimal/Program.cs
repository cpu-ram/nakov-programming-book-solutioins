using System;

namespace _06._14._00_Converting_Decimal_To_Hexadecimal
{
    class Program
    {



        static string ArrayToString(double[] convertedMask)
        {
            /* This Method takes an array that stores the values of every digit of the
             * 'operational' binary mask and returns a 32-character string fit to be displayed. 
             */

            string val = "";
            for (int i = 31; i >= 0; i--)
            {
                val += " " + convertedMask[i] + " ";
            }
            return val;
        }
        static double[] ConvertAndReturnArray(double inputNum)
        {





            double[] powersArray = new double[30]; // Array consisting of the powers of the base to which a conversion is done;
            double[] convertedMask = new double[32]; /* Declaration of an array that is meant to store the digits of the converted number
                                               (to be displayed later) */

            double n = inputNum;
            double origN = n;
            double opN = n; // all service variables;
            double nsn = 0; // "Nearest smaller power", initialization

            double val;
            int i = 0; // service variables for building a base-powers array


            int baseVal = 16; // value of the base to which conversion is made


            while (true)   // assigning array elements
            {
                val = Math.Pow(baseVal, i);
                powersArray[i] = val;
                if (val > 100000) break;
                i++;
            }






            int f = 0;
            double g = 0;
            double h = 0;

            double convertedSum = 0;  // all service variables for the calculation cycle;


            while (opN > 0) // we'll calculate the hexadecimal representation of the decimal number digit by digit, 
                            // constatnly substracting the current hexadecimal sum from the operational N, until opN=0;
            {
                while (true) // first iteration of the cycle
                {
                    if (powersArray[f] > opN) // if we are at an element of the array that follows the NSP directly 
                                               // , meaning we are at the position of the NGP...
                    {
                        f -= 1;                 // go back one iteration [and start iterating the (16-1) values of that bit]


                        for (g = 1; g < 16; g++)
                        {
                            h = powersArray[f] * g;

                            if (h > opN)
                            {
                                g--;
                                nsn = powersArray[f] * g;
                                convertedMask[f] = g;
                                

                                convertedSum += nsn;
                                opN -= nsn;
                                break;

                            }

                            
                        }




                        
                        f = 0;
                        break;
                    }

                    else
                    {
                        convertedMask[f] = 0;
                    }

                    f++;
                }
            }




            return convertedMask;

        }

        static int ConvertToDecimal(double[] nonDecimalMask, double baseVal)
        {
            int decimalVal = 0; //initial declarations
            double sum = 0;
            double element = 0;

            for (int i = 0; i < 32; i++) //converting back to decimal
            {
                int counterDouble = Convert.ToInt32(i);
                element = nonDecimalMask[i]*Math.Pow(baseVal,(i));
                sum += element;

            }
            decimalVal = Convert.ToInt32(sum);

                return decimalVal;

        }

        static void Main()
        {
            Console.WriteLine("Enter your natural number no bigger than 10000:"); // entering an N number to be converted back and forth;

            double inputNum = Double.Parse(Console.ReadLine());

            double[] numArray = ConvertAndReturnArray(inputNum);
            string convertedVal = ArrayToString(numArray); // N converted to binary N2, as a string;

            Console.WriteLine($"You enter6ed {inputNum}, and the converted representation of it in the numeral system with a base of 16 is {convertedVal}." + // displaying the N2;
                $"\nReverse-calculating the decimal value...");

            Console.WriteLine(ConvertToDecimal(numArray,16));
            


        }
    }   
    }
