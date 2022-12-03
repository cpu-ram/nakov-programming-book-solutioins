using System;
using System.Text.RegularExpressions;

namespace TagRemover
{
    class Program
    {
        static void RemoveTags(string entryString)
        {
            string pattern = "<[^\\>]+>";
            string resultString = Regex.Replace(entryString, pattern, "");
            Console.WriteLine(resultString);
        }


        static void Test()
        {
            string testString = @"<br /><br /><div class='cinter'>
Don't Miss The <a href='regex-style.html' ><span class='redtext em2'><b>Regex Style Guide</b></span></a><br /><br />
and <a href='regex-best-trick.html' ><span class='redtext em2'><b>The Best Regex Trick Ever!!!</b></span></a><br />
</div><a href='regex-uses.html' >
<img src='http://b.yu8.us/next_regex.png' class='left' width='125' height='40' alt='next' /><br />
<b>&nbsp;The 1001 ways to use Regex</b>";
            RemoveTags(testString);
        }
        static void Main(string[] args)
        {
            Test();
        }
    }
}
