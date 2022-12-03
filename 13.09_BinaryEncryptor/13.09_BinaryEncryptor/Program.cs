using System;
using System.Text;
using System.Collections.Generic;

namespace _13._09_BinaryEncryptor
{
    class Program
    {
        static ushort[] Encrypt(string text, string key)
        {
            List<ushort> resultList=new List<ushort>();
            ushort[] resultArray;
            ushort currentTextSymbol;
            ushort currentKeySymbol;
            ushort currentResultSymbolUshort;
            StringBuilder code = new StringBuilder(text.Length);
            List<char> charList = new List<char>();

            for(int i=0; i<text.Length; i++)
            {
                currentTextSymbol = Convert.ToUInt16(text[i]);
                currentKeySymbol = Convert.ToUInt16(key[i%key.Length]);
                currentResultSymbolUshort = Convert.ToUInt16(currentTextSymbol ^ currentKeySymbol);
                resultList.Add(currentResultSymbolUshort);
            }
            resultArray = resultList.ToArray();
            return resultArray;
        }



        static void Main(string[] args)
        {
            string text = "Test";
            string key = "ab";
            ushort[] encryptedCharactersArray=Encrypt(text, key);
            for(int i=0; i< encryptedCharactersArray.Length; i++)
            {
                Console.WriteLine("{0:x4}", encryptedCharactersArray[i]);
            }
        }
    }
}
