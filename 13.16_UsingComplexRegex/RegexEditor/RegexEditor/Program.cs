using System;
using System.Text;
using System.Text.RegularExpressions;


namespace RegexEditor
{
    class Program
    {
        static void ReplaceHyperlinks()
        {
            string input = "<p>Please visit <a href=\"http://softuni.org\">" +
            "our site</a> to choose a training course. Also visit " +
            "<a href=\"http://forum.softuni.org\">our forum</a> to discuss " +
            "the courses.</p>";
            string pattern = "<a href=\"(?<url>[^\"]*)\">(?<text>[^<]*)</a>";
            string replacement= "[URL=\"${url}\"]${text}[/URL]";
            string result = Regex.Replace(input, pattern, replacement);
            Console.WriteLine(result);

        }
        static void ExtractDates()
        {
            StringBuilder resultSB = new StringBuilder();

            string pattern = "(?<=(\\s|[^a-zA-Z]))((([1-2][0-9])|(3[0-1]))|([0-9]))\\." +
                "(((0[0-9])|(1[12]))|([0-9]))\\.\\d{4}";

            string input = "I was born at 14.06.1980. My sister was born at 3.7.1984. " +
                "In 5/1999 I graduated my high school. " +
                "The law says (see section 7.3.12) that we are allowed to do this";

            Regex regex = new Regex(pattern);
            Match match = regex.Match(input);
            resultSB.Append(match+"\n");

            while (match.Success)
            {
                match = match.NextMatch();
                resultSB.Append(match+"\n");
            }

            Console.WriteLine(resultSB);

        }

        static void Main(string[] args)
        {
            ExtractDates();
        }
    }
}
