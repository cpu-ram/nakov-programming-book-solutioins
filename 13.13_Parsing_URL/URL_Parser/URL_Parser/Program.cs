using System;
using StringEditor;

namespace URL_Parser
{
    public class URL
    {
        private string protocol;
        private string server;
        private string resource;

        public string Protocol { get => protocol; set => protocol = value; }
        public string Server { get => server; set => server = value; }
        public string Resource { get => resource; set => resource = value; }

        public void CheckCorrectURL(string entryString)
        {

        }

        public void ParseURL(string entryString)
        {
            string firstSeparator = "://";
            string secondSeparator = "/";

            int firstSeparatorPosition = entryString.IndexOf(firstSeparator);
            int secondSeparatorPosition = entryString.IndexOf(secondSeparator, firstSeparatorPosition+3);

            int serverStartPosition = firstSeparatorPosition+3;
            int serverLength = secondSeparatorPosition - serverStartPosition;
            int resourceLength = entryString.Length - secondSeparatorPosition;

            string protocol = entryString.Substring(0, firstSeparatorPosition);
            string server = entryString.Substring(serverStartPosition, serverLength);
            string resource = entryString.Substring(secondSeparatorPosition, resourceLength);
            this.Protocol = protocol;
            this.Server = server;
            this.Resource = resource;
        }

        public URL(string entryString)
        {
            ParseURL(entryString);
        }
        public void Display()
        {
            Console.WriteLine("[protocol]='{0}'", this.Protocol);
            Console.WriteLine("[server]='{0}'", this.Server);
            Console.WriteLine("[resource]='{0}'", this.Resource);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string url = StringEditor.ConsoleEntry.EnterString("URL");
            URL urlOne = new URL(url);
            urlOne.Display();
        }
    }
}
