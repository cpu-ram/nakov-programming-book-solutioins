using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _08._01_UniversalNumeralConverter
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
            for(int i=0; i<entryCharArr.Length; i++)
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

        public static string DecimalToBinary(int decimalNum)
        {

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
            string wholePartStr;
            string fractionalPartStr;

            double fraction = doubleNum - (doubleNum % 1);


            int wholePartInt = Convert.ToInt32(doubleNum-fraction);
            wholePartStr = DecimalToBinary(wholePartInt);
            fractionalPartStr = ConvertFraction(fraction);


            static string ConvertFraction(double entryDouble)
            {
                Exception wrongEntryFormat = new Exception("Incorrect entry! Enter a 'double'-type number between 0 and 1.");
                if (entryDouble >= 1) throw wrongEntryFormat;



                return null;


            }

            

            return null;
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
            char tempChar=Convert.ToChar("Z");

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

            for (int i = stringArr.Length-1; i >= 0; i--)
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



                tempInt = Convert.ToInt32(tempInt*Math.Pow(Convert.ToDouble(baseVal), Convert.ToDouble(stringArr.Length-i-1)));
                
                tempIntResult += tempInt;

            }
           
            return tempIntResult;

        }

    }

    public class Program
    {
        
        static void Test(string entryStr)
        {

            entryStr = "3";
            Console.WriteLine(entryStr);
            Regex regex = new Regex("[abcdef]");
            Regex numRegex = new Regex("[0123456789]");

            Console.WriteLine("entryStr: " + entryStr);
            Console.WriteLine("[a-f]: " + regex.IsMatch(entryStr));
            Console.WriteLine("[0-9]: " + numRegex.IsMatch(entryStr));


        }

        public static void TestConversions()
        {
            int originalDecimalInt = 1998;
            int nonDecimalBase = 2;


            string nonDecimalString = ConvertNumber.DecimalToAny(originalDecimalInt, nonDecimalBase);
            int finalDecimalInt = ConvertNumber.ConvertAnyToDecimal(nonDecimalString, nonDecimalBase);

            

            Console.Write($"Original decimal number: {originalDecimalInt}, \nbinary number: {nonDecimalString}, \nreversed decimal number: {finalDecimalInt}.");

        }


        public static void Main(string[] args)
        {
            TestConversions();


        }

        
    }
}
