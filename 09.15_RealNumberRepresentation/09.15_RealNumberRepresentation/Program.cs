using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _09._15_RealNumberRepresentation
{
    public class ConvertNumber
    {
        public static List<int> ReverseIntListOrder(List<int> list)
        {
            int pointerOne = 0;
            int pointerTwo = list.Count - 1;
            int tempInt;

            while (pointerTwo > pointerOne)
            {
                tempInt = pointerTwo;
                pointerOne = pointerTwo;
                pointerTwo = tempInt;
                pointerOne++;
                pointerTwo--;
            }
            return list;
        }
        public static List<char> ReverseCharListOrder(List<char> list)
        {
            int pointerOne = 0;
            int pointerTwo = list.Count - 1;
            char tempChar;


            while (pointerTwo > pointerOne)
            {
                tempChar = list[pointerOne];
                list[pointerOne] = list[pointerTwo];
                list[pointerTwo] = tempChar;
                pointerOne++;
                pointerTwo--;


            }
            return list;
        }
        public static string[] ConvertCharArrToStringArr(char[] entryCharArr)
        {
            string[] stringArr = new string[entryCharArr.Length];
            for (int i = 0; i < entryCharArr.Length; i++)
            {
                stringArr[i] = Convert.ToString(entryCharArr[i]);
            }

            return stringArr;
        }


        public static char TranslateToHexadecimalDigit(int digit)
        {
            string digitString;

            Exception wrongNumber = new Exception("Error translating to Hexadecimal: a number outside of bounds was passed.");
            if (digit > 15)
            {
                throw wrongNumber;
            }

            char resultChar = Convert.ToChar("O");

            if (digit >= 0 & digit < 10)
            {
                digitString = Convert.ToString(digit);
                return Convert.ToChar(digitString);
            }




            if (digit >= 10 & digit < 16)
            {
                switch (digit)
                {
                    case 10:
                        resultChar = Convert.ToChar('a');
                        break;
                    case 11:
                        resultChar = Convert.ToChar('b');
                        break;
                    case 12:
                        resultChar = Convert.ToChar('c');
                        break;
                    case 13:
                        resultChar = Convert.ToChar('d');
                        break;
                    case 14:
                        resultChar = Convert.ToChar('e');
                        break;
                    case 15:
                        resultChar = Convert.ToChar('f');
                        break;
                }

            }

            return resultChar;



        }
        public static int TranslateFromHexadecimalDigit(char hex)
        {
            int result = 0;

            Regex regex = new Regex("[0-9a-zA-Z]");
            Exception wrongEntry = new Exception("Enter a proper hexidecimal digit");
            if (!regex.IsMatch(Convert.ToString(hex))) throw wrongEntry;



            for (int i = 0; i < 10; i++)
            {
                if (hex == Convert.ToChar(i))
                {
                    result = i;
                    return result;
                }
            }

            if (hex == Convert.ToChar("a"))
            {
                result = 10;
                return result;
            }
            if (hex == Convert.ToChar("b"))
            {
                result = 11;
                return result;
            }
            if (hex == Convert.ToChar("c"))
            {
                result = 12;
                return result;
            }
            if (hex == Convert.ToChar("d"))
            {
                result = 13;
                return result;
            }
            if (hex == Convert.ToChar("e"))
            {
                result = 14;
                return result;
            }
            if (hex == Convert.ToChar("f"))
            {
                result = 15;
                return result;
            }

            return result;
        }
        public static int TranslateFromHexadecimalDigit(string hex)
        {
            char hexChar = Convert.ToChar(hex);
            int result = TranslateFromHexadecimalDigit(hexChar);
            return result;

        }


        static double SeparateFraction(double entry = 0d)
        {
            entry = entry % 1;
            return entry;
        }
        static double SeparateWholePart(double entry = 0d)
        {
            entry = entry - SeparateFraction(entry);
            return entry;
        }
        public static string DecimalToBinary(int decimalNum)
            {

            if (decimalNum == 0) return "0";

            List<int> binaryList = new List<int>();
            bool keepCounting = true;
            int tempResult;
            int tempRemainder;

            while (keepCounting)
            {
                tempRemainder = decimalNum % 2;
                decimalNum = decimalNum / 2;

                if (decimalNum == 0 & tempRemainder == 0)
                {
                    keepCounting = false;
                    break;
                }




                binaryList.Add(tempRemainder);
            }
            binaryList = ReverseIntListOrder(binaryList);

            string result = "";


            for (int i = 0; i < binaryList.Count; i++)
            {
                result += Convert.ToString(binaryList[i]);
            }

            return result;

        }
        public static string DecimalToBinary(double doubleNum)
        {
            string resultStr = "";

            string wholePartStr;
            string fractionalPartStr;

            double fractionalPartDouble = SeparateFraction(doubleNum);


            int wholePartInt = Convert.ToInt32(doubleNum - fractionalPartDouble);
            wholePartStr = DecimalToBinary(wholePartInt);
            fractionalPartStr = ConvertFraction(fractionalPartDouble);
            
            static string ConvertFraction(double entryDouble)
            {

                Exception wrongEntryFormat = new Exception("Incorrect entry! Enter a 'double'-type number between 0 and 1.");
                if (entryDouble >= 1) throw wrongEntryFormat;
                if (entryDouble == 0) return null; 

                double tempDouble = entryDouble;
                double tempDoubleTwo;

                

                string resultString = "";

                while (SeparateFraction(tempDouble) != 0)
                {
                    tempDouble *= 2;
                    tempDoubleTwo = SeparateWholePart(tempDouble);
                    resultString += tempDoubleTwo;
                    tempDouble = SeparateFraction(tempDouble);
                }

                return resultString;


            }

            if (fractionalPartDouble != 0)
            {
                resultStr = wholePartStr + "." + fractionalPartStr;
            }

            if(fractionalPartDouble == 0)
            {
                resultStr = wholePartStr;
            }

            return resultStr;
        }




        public static string DecimalToHexadecimal(int decimalNum)
        {

            List<char> hexList = new List<char>();
            bool keepCounting = true;
            int tempResult;
            int tempRemainder;
            char tempChar;

            while (keepCounting)
            {

                tempRemainder = decimalNum % 16;
                decimalNum = decimalNum / 16;






                if (decimalNum == 0 & tempRemainder == 0)
                {
                    keepCounting = false;
                    break;
                }

                tempChar = TranslateToHexadecimalDigit(tempRemainder);
                hexList.Add(tempChar);
            }
            hexList = ReverseCharListOrder(hexList);

            string result = "";


            for (int i = 0; i < hexList.Count; i++)
            {
                result += Convert.ToString(hexList[i]);
            }

            return result;

        }

        public static string DecimalToAny(int sourceInt, int targetBase)
        {

            List<char> hexList = new List<char>();
            bool keepCounting = true;
            int tempResult;
            int tempRemainder;
            char tempChar = Convert.ToChar("Z");

            while (keepCounting)
            {

                tempRemainder = sourceInt % targetBase;
                sourceInt = sourceInt / targetBase;






                if (sourceInt == 0 & tempRemainder == 0)
                {
                    keepCounting = false;
                    break;
                }

                tempChar = TranslateToHexadecimalDigit(tempRemainder);

                hexList.Add(tempChar);
            }
            hexList = ReverseCharListOrder(hexList);



            string result = "";


            for (int i = 0; i < hexList.Count; i++)
            {
                result += Convert.ToString(hexList[i]);
            }

            return result;

        }
        public static int ConvertAnyToDecimal(string source, int baseVal)
        {
            Exception baseTooHigh = new Exception("Output numeral base is too high for conversion. Choose a base up to 16.");
            Exception wrongDigitException = new Exception("Couldn't process the digit, something went wrong.");

            if (baseVal > 16) throw baseTooHigh;


            char[] charArr = source.ToCharArray();

            string[] stringArr = ConvertCharArrToStringArr(charArr);


            int tempInt = 0;
            int tempIntResult = 0;
            int result = 0;

            Regex regex = new Regex("[abcdef]");
            Regex numRegex = new Regex("[0123456789]");

            for (int i = stringArr.Length - 1; i >= 0; i--)
            {
                if (regex.IsMatch(stringArr[i]))
                {
                    tempInt = TranslateFromHexadecimalDigit(stringArr[i]);

                }
                else if (numRegex.IsMatch(stringArr[i]))
                {
                    tempInt = Convert.ToInt32(stringArr[i]);
                }
                else
                {
                    throw wrongDigitException;
                }



                tempInt = Convert.ToInt32(tempInt * Math.Pow(Convert.ToDouble(baseVal), Convert.ToDouble(stringArr.Length - i - 1)));

                tempIntResult += tempInt;

            }

            return tempIntResult;

        }

    }
    public class RealNumber
    {

        string fullResultStr = "";


        char sign;
        float[] exponentAndMantissa;

        string exponentString;
        string mantissaString;
        string standardFloatStr;

        static public float[] FindExponentAndMantissa(float entryFloat)
        {
            float tempFloat;
            float tempMantissa;
            float power = 0;
            float baseFloat = 2f;

            entryFloat = Math.Abs(entryFloat);

            float[] exponentAndMantissa = new float[2];

            while (true)
            {
                tempMantissa = (entryFloat) / (float)(Math.Pow(baseFloat,power));
                if(tempMantissa>1 && tempMantissa < 2)
                {
                    exponentAndMantissa[0]=power;
                    exponentAndMantissa[1] = tempMantissa;
                    return exponentAndMantissa;
                }
                power += 1;
                
            }
            return null;
        }
        public RealNumber(float entryFloat)
        {
            if (entryFloat < 0)
            {
                sign = Convert.ToChar(Convert.ToString(1));

            } // setting the sign
            else
            {
                sign = Convert.ToChar(Convert.ToString(0));
            }

            exponentAndMantissa = FindExponentAndMantissa(entryFloat);



            float exponent = exponentAndMantissa[0];
            float mantissa = exponentAndMantissa[1];


            exponentString = ConvertNumber.DecimalToBinary(exponent + 127);
            mantissaString = ConvertNumber.DecimalToBinary(mantissa - 1d);

            string[] mantissaStringTempArr = mantissaString.Split(".");
            mantissaString = mantissaStringTempArr[1];
            string[] mantissaStringTempArrTwo = new string[mantissaString.Length];
            for(int i=0; i<mantissaStringTempArrTwo.Length; i++)
            {
                mantissaStringTempArrTwo[i] = Convert.ToString(mantissaString[i]);
            }

           


            Console.WriteLine($"original decimal number: {entryFloat}");
            Console.WriteLine($"sign={sign}, exponent={exponent}, mantissa={mantissa}.");
            standardFloatStr = sign + " "
                + exponentString + " "
                + mantissaString;


            Console.WriteLine(standardFloatStr);

        }
    }


    class Program
    {

        static void Main()
        {

        RealNumber realNumberOne = new RealNumber(-325443f);

        }

    }
}
