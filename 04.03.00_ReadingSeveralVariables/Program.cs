using System;

namespace _04._03._00_ReadingSeveralVariables
{
    class Program
    {
        static void Main(string[] args)
        {

            // gonna do this with cycles
            string[] vars = { "name", "address", "phone", "fax", "website", "manager", "mName", "mSurname", "mPhone"};

            Console.WriteLine("Enter the name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the address:");
            string address = Console.ReadLine();

            Console.WriteLine("Enter the phone:");
            string phone = Console.ReadLine();

            Console.WriteLine("Enter the fax:");
            string fax = Console.ReadLine();

            Console.WriteLine("Enter the website:");
            string website = Console.ReadLine();

            Console.WriteLine("Enter the manager:");
            string manager = Console.ReadLine();

            Console.WriteLine("Enter the mName:");
            string mName = Console.ReadLine();

            Console.WriteLine("Enter the mSurname:");
            string mSurname = Console.ReadLine();

            Console.WriteLine("Enter the mPhone:");
            string mPhone = Console.ReadLine();

            Console.WriteLine("name={0}, address={1}, phone={2}, fax={3}, website={4}, manager={5}, mName={6}, mSurname={7}, mPhone={8}", name,
                address, phone, fax, website, manager, mName, mSurname, mPhone);



        }
    }
}
