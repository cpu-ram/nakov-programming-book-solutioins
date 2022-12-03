using System;
using StringEditor;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DateParser
{
    class Program
    {
        static void DaysCountBetweenTwoDays()
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            string format = "d.M.yyyy";

            string firstUserInput = Console.ReadLine();
            string secondUserInput = Console.ReadLine();
            DateTime firstDate = DateTime.ParseExact(firstUserInput, format, provider);
            DateTime secondDate = DateTime.ParseExact(secondUserInput, format, provider);
            DateTime startDate = firstDate;
            DateTime endDate = secondDate;
            if (firstDate > secondDate)
            {
                startDate = secondDate;
                endDate = firstDate;
            }

            int daysCount = (endDate - startDate).Days;
            Console.WriteLine(daysCount);
        }
        static void AddTime()
        {
            CultureInfo culture = CultureInfo.InvariantCulture;
            string format = "d.M.yyyy hh:mm:ss";
            string input = StringEditor.ConsoleEntry.EnterString();
            TimeSpan timeSpan = new TimeSpan(0,6,30,0,0);

            DateTime originalDateTime = DateTime.ParseExact(input, format, culture);
            DateTime modifiedDateTime = originalDateTime.Add(timeSpan);

            Console.WriteLine("yo");
            Console.WriteLine(modifiedDateTime);
           
        }
        static void ExtractDates()
        {
            CultureInfo canadianCulture = new CultureInfo("en-CA");

            string pattern = "(?<date>((([1-2][0-9])|(3[0-1]))|([0-9]))\\." +
                "(((0[0-9])|(1[12]))|([0-9]))\\.\\d{4})";
            string input = "I was born at 14.06.1980. My sister was born at 3.7.1984. " +
                "In 5/1999 I graduated my high school. " +
                "The law says (see section 7.3.12) that we are allowed to do this";

            string replacement = "\n${date}\n";
            string resultString = Regex.Replace(input, pattern, replacement);

            MatchCollection matches = Regex.Matches(input, pattern);
            for(int i=0; i<matches.Count; i++)
            {
                Console.WriteLine(Convert.ToString(matches[i]));
            }


        }

        static void Main()
        {
            ExtractDates();
        }
    }

    

}
