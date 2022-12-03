using System;
using System.Collections.Generic;

namespace _08._11_RomanToArabicDigits
{
    class Program
    {
        static string[] ConvertCharArrayToStringArray(char[] charArr)
        {
            string[] result = new string[charArr.Length];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Convert.ToString(charArr[i]);
            }
            return result;
        }


        static int ConvertRomanNumerals(string entry)
        {
            string[] stringArr = ConvertCharArrayToStringArray(entry.ToCharArray());
            int[] elementsArr = new int[stringArr.Length];
            int result = 0;


            IDictionary<string, int> romanDict= new SortedDictionary<string, int>();
            romanDict["M"] = 1000;
            romanDict["D"] = 500;
            romanDict["C"] = 100;
            romanDict["L"] = 50;
            romanDict["X"] = 10;
            romanDict["V"] = 5;
            romanDict["I"] = 1;

            for(int i = 0; i < stringArr.Length; i++)
            {
                
                elementsArr[i] = romanDict[stringArr[i]];
                if (i > 0)
                {
                    if (elementsArr[i] > elementsArr[i-1])
                    {
                        elementsArr[i - 1] *= -1;

                    }
                }


            }


            foreach(int element in elementsArr)
            {
                Console.Write(element + " ");
                result += element;
            }

            return result;

        }


        static void Main()
        {
            string romanNumeral = "MCMXCVIII";
            int arabicNumeral=ConvertRomanNumerals(romanNumeral);

            Console.WriteLine($"romanNumeral={romanNumeral}, arabicNumeral={arabicNumeral}");
                
        }
    }
}
