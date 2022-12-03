using System;

namespace _08._12_ConvertArabicNumberToRoman
{
    class Program
    {
        static string[] ConvertCharArrayToStringArray(char[] charArr)
        {
            string[] result = new string[charArr.Length];

            for(int i=0; i<result.Length; i++)
            {
                result[i] = Convert.ToString(charArr[i]);
            }
            return result;
        }

        static string ConvertArabicToRoman(int entry)
        {
            Exception numberTooBig = new Exception("Number to translate is too big. Please enter a number under 3999");
            if (entry > 3999)
            {
                throw numberTooBig;
            }




            string entryString = Convert.ToString(entry);
            char[] entryCharArr = entryString.ToCharArray();

            string[] entryArr = ConvertCharArrayToStringArray(entryCharArr);

            string tempstring;


            string result = "";

            string tempString = "";

            static string TranslateChar(string digit, int digitOrder)
            {


                string returnVal = "-";
                string tempString = "";

                string[,] dict = new string[4, 2];
                dict[0, 0] = "I";
                dict[0, 1] = "V";
                dict[1, 0] = "X";
                dict[1, 1] = "L";
                dict[2, 0] = "C";
                dict[2, 1] = "D";
                dict[3, 0] = "M";


                switch(digit)
                {
                    case "1":
                        returnVal = dict[digitOrder, 0];
                        break;
                    case "2":
                        returnVal = dict[digitOrder, 0] + dict[digitOrder, 0];
                        break;
                    case "3":
                        returnVal = dict[digitOrder, 0] + dict[digitOrder, 0] + dict[digitOrder, 0];
                        break;
                    case "4":
                        returnVal = dict[digitOrder, 0] + dict[digitOrder, 1];
                        break;
                    case "5":
                        returnVal = dict[digitOrder, 1];
                        break;
                    case "6":
                        returnVal = dict[digitOrder, 1] + dict[digitOrder, 1];
                        break;
                    case "7":
                        returnVal = dict[digitOrder, 1] + dict[digitOrder, 0] + dict[digitOrder, 0];
                        break;
                    case "8":
                        returnVal = dict[digitOrder, 1] + dict[digitOrder, 0] + dict[digitOrder, 0] + dict[digitOrder, 0];
                        break;
                    case "9":
                        returnVal = dict[digitOrder, 0] + dict[digitOrder + 1, 0];
                        break;
                    default:
                        returnVal = null;
                        break;

                }




                return returnVal;
            }

            


            for (int i=0; i<entryArr.Length; i++)
            {
                tempString = TranslateChar(entryArr[i], entryArr.Length-i-1);
                result += tempString;
            }
            

                


            return result;
        }

        static void Test(int entry)
        {
            string entryString = entry.ToString();
            char[] charArr = entryString.ToCharArray();

            foreach(char element in charArr)
            {
                Console.Write(element);
            }

        }



        static void Main(string[] args)
        {
            int decimalNum = 1998;
            string binaryNum=Convert



        }
    }
}
