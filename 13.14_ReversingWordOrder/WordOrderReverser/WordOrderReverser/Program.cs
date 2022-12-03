using System;
using System.Text;


namespace WordOrderReverser
{
    class Program
    {
        static string ReverseWordOrder(string entryString)
        {
            string[] stringArr = entryString.Split(" ");
            StringBuilder sb = new StringBuilder();
            for(int i=0;i<stringArr.Length; i++)
            {
                if (i > 0) sb.Append(" ");
                sb.Append(stringArr[i]);
            }
            string resultString = Convert.ToString(sb);
            return resultString;
        }

        static void Main(string[] args)
        {
            string sampleString = "C# is not C++ and PHP is not Delphi";
            string processedString = ReverseWordOrder(sampleString);
            Console.WriteLine($"'{processedString}'");
        }
    }
}
