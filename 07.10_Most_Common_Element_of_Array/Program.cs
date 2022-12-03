using System;

namespace _07._10_Most_Common_Element_of_Array
{
    class Program
    {

        static int MostCommonElement(int[] arr)
        {
            int[,] twoRowArray = new int[2, 6];
            int uniqueElements = 0;

            Console.WriteLine(arr.Length +"\n");

            for(int i = 0; i < arr.Length; i++)
            {
                if(i>0)Console.WriteLine($"___\ni+=1 = {i}\n");


                if (i==0) // adding the first element to the counted array
                {
                    twoRowArray[0, 0] = arr[0];
                    twoRowArray[1, 0] += 1;
                    uniqueElements += 1;
                    continue;
                }

                for(int j = 0; j < uniqueElements; j++) // looking for the current arr[i] element within the counted array
                {
                    if (twoRowArray[0, j] == arr[i])
                    {
                        twoRowArray[1, j] += 1;
                        Console.WriteLine($"Another element '{arr[i]}' found. Counter[{j}]+=1 = {twoRowArray[1,j]}\n");

                        break;
                    }

                    if (j == (uniqueElements - 1))
                    {
                        twoRowArray[0,uniqueElements] = arr[i];
                        twoRowArray[1, uniqueElements] += 1;
                        Console.WriteLine($"arr[i]={arr[i]}(#{i}) not found in index. Added to index at position {uniqueElements}\n");

                        uniqueElements += 1;
                        break;
                    }
                }
            }


            for (int m = 0; m < twoRowArray.GetLength(0); m++)
            {
                for (int n = 0; n < twoRowArray.GetLength(1); n++)
                {
                    Console.Write("{0,4} ",twoRowArray[m, n]);
                }
                Console.WriteLine();
            }


            return 0;
        }
        static void Main(string[] args)
        {
            int[] arr = { 4, 2, 77, 2, 3, 2 };
            string displayString = "";
            foreach(int i in arr)
            {
                displayString += $" {i}";
            }
            Console.WriteLine(displayString);

            MostCommonElement(arr);


        }
    }
}
