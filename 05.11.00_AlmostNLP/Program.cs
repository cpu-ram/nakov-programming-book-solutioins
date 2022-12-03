using System;

namespace _05._11._00_AlmostNLP
{
    class Program
    {
        //here, I'm going to build a Method that checks the number of digits in the number.

        static int DigitNumber(ref int x)  // counting digits
        {
            if ((x > 0) && (x < 10))
            {
                return 1;
            }

            if ((x > 9) && (x < 99))
            {
                return 2;
            }
            if ((x > 99) && (x <= 999))
            {
                return 3;
            }
            else
            {
                return 404;
            }
        }
        static void NumBreak(ref int x, ref int a, ref int b, ref int c) // a Method that will break the number down into digits
        {
            if (DigitNumber(ref x) == 1)
            {
                c = x;
                b = 0;
                a = 0;
            }

            if (DigitNumber(ref x) == 2)
            {
                c = x % 10;
                b = (x - c) / 10;
            }

            if (DigitNumber(ref x) == 3)
            {
                c = x % 10;
                a = x / 100;
                b = (x - (a * 100) - c) / 10;
            }


        }

       


        static string CParse(ref int c)
        {
            string cStr="";
            switch (c)
            {
                case 1:
                    cStr = "one";
                    break;
                case 2:
                    cStr = "two";
                    break;
                case 3:
                    cStr = "three";
                    break;
                case 4:
                    cStr = "four";
                    break;
                case 5:
                    cStr = "five";
                    break;
                case 6:
                    cStr = "six";
                    break;
                case 7:
                    cStr = "seven";
                    break;
                case 8:
                    cStr = "eight";
                    break;
                case 9:
                    cStr = "nine";
                    break;
                default:
                    break;

            }
            return cStr;
        }       
        static string TeensParse(ref int x)
        {
            string output="";

            switch (x)
            {
                case 10:
                    output = "ten";
                    break;
                case 11:
                    output = "eleven";
                    break;
                case 12:
                    output = "twelve";
                    break;
                case 13:
                    output = "thirteen";
                    break;
                case 14:
                    output = "fourteen";
                    break;
                case 15:
                    output = "fifteen";
                    break;
                case 16:
                    output = "sixteen";
                    break;
                case 17:
                    output = "seventeen";
                    break;
                case 18:
                    output = "eighteen";
                    break;
                case 19:
                    output = "nineteen";
                    break;
                default:
                    break;
            }
            return output;
        }
        static string DozensParse(int b)
        {
            string bStr = "";
            switch (b)
            {
                case 2:
                    bStr = "twenty";
                    break;
                case 3:
                    bStr = "thirty";
                    break;
                case 4:
                    bStr = "fourty";
                    break;
                case 5:
                    bStr = "fifty";
                    break;
                case 6:
                    bStr = "sixty";
                    break;
                case 7:
                    bStr = "seventy";
                    break;
                case 8:
                    bStr = "eighty";
                    break;
                case 9:
                    bStr = "ninety";
                    break;

            }
            return bStr;
        }

        static string TwoDigitParse(int x, int b, int c)
        {
            string output = "";
            if ((x > 9) && (x < 19))
            {
                output = TeensParse(ref x);
            }

            else
            {
                output = DozensParse(b) + "-" + CParse(ref c);
            }
            return output;
        }


        static void Main(string[] args)     // main method;
        {
            while (true) 
            { 
            
            int y;
            int a = 0;
            int b = 0;
            int c = 0;
            string aStr;
            string bStr;
            string cStr = "";
            string output = "";             // variable declarations;

            Console.WriteLine("Enter a natural number x, such as that 0<x<100");  // number entry;
            int x = Int32.Parse(Console.ReadLine());

                // not doing a check, assuming the input is correct;


            NumBreak(ref x, ref a, ref b, ref c);  // NumBreak;


            Console.WriteLine($"The number you entered = {x}, and its digits are {a} {b} {c}, number of digits = {DigitNumber(ref x)}");

            switch (DigitNumber(ref x))
            {
                case 1:
                    switch (c)
                    {
                        default:
                            cStr = CParse(ref c);
                            break;
                    }


                    output = cStr;
                    break;

                case 2:
                        output=TwoDigitParse(x, b, c);
                        break;

                case 3:
                        if (b == 0)
                        {
                            output = CParse(ref a) + " hundred and " + CParse(ref c);
                        }
                        else
                        {
                            output = CParse(ref a) + " hundred " + TwoDigitParse((x - (a * 100)), b, c);
                        }

                        break;

                default:
                    break;
            }

            Console.WriteLine($"Put in words, it is '{output}'\n\n____________________");
        }
        }
    }
}
