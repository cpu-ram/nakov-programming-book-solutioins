using System;
using System.Diagnostics.Tracing;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace _07._23_All_Combinations_Of_Elements_Of_An_Array
{
    class Program
    {

        static int[] LandingPage()
        {

            bool calcCombos = false;
            bool calcVars = false;

            



            bool userEntersArr = false;
            bool userEntersLim = false;
            string[] options2 = { "Enter a max-limit", "Enter the full array manually" };
            string ch2 = ChooseBetweenOptions(options2);
            if (ch2 == "1")
            {
                userEntersLim = true;

            }
            if (ch2 == "2")
            {
                userEntersArr = true;
            }

            // end of section ?>


            int[] srcArr = { 0, 0 };

            if (userEntersArr)
            {
                srcArr = EnterIntArray();

            }
            if (userEntersLim)
            {
                srcArr = EnterIntLimitsCalculateArr(1);
            }

            PrintSingleDimArray(srcArr, "srcArr");
            return srcArr;
        }
        static string ChooseBetweenOptions(string[] args)
        {
            string input;
            string chosenOption = "0";

            while (true)
            {

                Console.WriteLine("Would you rather");

                int counter = 1;
                foreach (string i in args)
                {
                    if (counter > 1)
                    {
                        Console.Write(" OR ");
                    }
                    Console.Write("{0}) {1}", counter, i);

                    if (counter == args.Length)
                    {
                        Console.Write("?\n");
                    }
                    counter++;
                }

                input = Console.ReadLine();

                if (input != "1" & input != "2")
                {
                    Console.WriteLine("Please enter either '1' or '2'.");
                }
                else
                {
                    break;
                }
            }

            if (input == "1")
            {
                chosenOption = input;
            }

            if (input == "2")
            {
                chosenOption = input;
            }


            return chosenOption;





        }
        static int[] ParseStringArrayToIntArray(string[] stringArr)
        {
            

            int[] intArr = new int[stringArr.Length];

            int counter = 0;



            if (stringArr.Length > 1 & stringArr[0] != "")
            {
                

                foreach (string i in stringArr)
                {
                    bool parseSuccess = Int32.TryParse(i, out int number);



                    if (!parseSuccess)
                    {
                        Console.Write("\nCould not parse 'i'");
                        break;
                    }
                    if (parseSuccess) 
                    {
                        intArr[counter] = number;
                    }
                    counter++;
                }


            }
            Console.WriteLine();

            return intArr;
        }
        static int[] ParseStringToIntArray(string srcString, string divider)
        {
            //Console.Write("\nParsing string into an array...");
            string[] elementsStr = srcString.Split(divider);
            int[] intArr = new int[elementsStr.Length];

            

            for (int i = 0; i < elementsStr.Length; i++)
            {
                if (elementsStr[i] == "")
                {
                    Console.Write($"\nERROR! String to be parsed is empty. This might cause miscalculations!\n");
                }

                bool parseAttempt = Int32.TryParse(elementsStr[i], out intArr[i]);
            }

            //Console.Write("\nString parsed to an array.");
            //PrintString(srcString, "srcString");
            //PrintSingleDimArray(intArr, "resultArr");

            return intArr;
        }


        static int[] SelectionSort(int[] arr, string arrName)
        {
            //Console.Write($"\nSorting {arrName}");

            int minVal = 0;
            bool minValIsSet = false;
            int minValIndex = 0;

            int[] sortedArr = new int[arr.Length];
            bool[] checkedElements = new bool[arr.Length]; // 'logs' for the numbers of the checked elements of the array


            int checkedElementsNum = 0;

            minVal = arr[0];
            //Console.WriteLine($"minVal={minVal}.");

            for (int h = 0; h < arr.Length; h++)
            {


                for (int i = 0; i < arr.Length; i++)
                {
                    //Console.WriteLine($"Arr[i]={arr[i]}.");


                    if (!(checkedElements[i] == true))
                    {
                        if (minValIsSet == false)
                        {
                            minVal = arr[i];
                            minValIsSet = true;

                            //Console.WriteLine($"Min Value is reset to {arr[i]}.");
                        }


                        if (arr[i] <= minVal)
                        {
                            minVal = arr[i];


                            minValIndex = i;
                        }


                    }



                    if (i == arr.Length - 1)
                    {
                        checkedElementsNum++;
                        checkedElements[minValIndex] = true;
                        sortedArr[checkedElementsNum - 1] = minVal;

                        //Console.WriteLine($"Element #{minValIndex} with a value of '{minVal}' is marked out and added to the sorted array.");
                        minValIsSet = false;
                    }


                }
            }

            //PrintSingleDimArray(sortedArr, $"sorted {arrName}");
            Console.WriteLine();
            return sortedArr;
        }

        static int[] EnterIntArray()
        {


            Console.WriteLine("Enter the source integer array, separated BY SPACES");
            string entry = Console.ReadLine();

            string[] entryArrString = entry.Split(' ');

            int[] intArr = new int[entryArrString.Length];

            int counter = 0;
            foreach (string i in entryArrString)
            {
                intArr[counter] = Int32.Parse(i);
                counter++;
            }
            Console.WriteLine();

            return intArr;

        }
        static int EnterInt(string intName)
        {
            Console.Write($"\n\nEnter your '{intName}' int\n");
            string str = Console.ReadLine();
            int resultInt;
            bool parseSuccess = Int32.TryParse(str, out resultInt);
            return resultInt;


        }
        static int[] EnterIntLimitsCalculateArr(int minLim)
        {
            Console.WriteLine("Enter the max limit positive integer:");
            int maxLimit = Convert.ToInt32 (Console.ReadLine());

            int[] arr = new int[maxLimit];


            for(int i=minLim; i<=maxLimit; i++)
            {
                arr[i-1] = i;
            }

            return arr;
        }
        static int[] PassRangeCalculateIntArray(int minLim, int maxLim)
        {
            int length = maxLim - minLim + 1;
            int[] resultArr = new int[length];


            int counter = 0;
            for(int i=minLim; i<=maxLim; i++)
            {
                resultArr[counter] = i;
                counter++;
            }

            return resultArr;
        }


        static int[,] CalculateAllVariations(int[] srcArr, int sequenceLengthInt)
        {

            


            // to separate the following calculations into a separate method,
            // I need to pass the following parameters: 
            // sourceArr, sequenceLengthInt, 

            double allCombosHeightDouble = Math.Pow(srcArr.Length, sequenceLengthInt);
            int allCombosHeight = Convert.ToInt32(allCombosHeightDouble);
            int[,] allCombos = new int[allCombosHeight, sequenceLengthInt];
            int[] tempArr = new int[allCombos.GetLength(1)];






            Console.Write("\nCalculating 'first-order' combinations...\n");
            for (int lineCounter = 0; lineCounter < allCombos.GetLength(0); lineCounter++)
            {

                if (lineCounter == allCombos.GetLength(0))
                {
                    Console.Write("\n End of allCombos array reached.");
                    PrintArray(allCombos, srcArr);
                    break;
                } //"exception handler"
                Console.Write($"\n Processing line #{lineCounter}...");
                if (lineCounter == 0)
                {
                    for (int counter2 = 0; counter2 < allCombos.GetLength(1); counter2++)
                    {
                        allCombos[lineCounter, counter2] = 0;
                    }
                    continue;

                } // assigning values to the first row of allCombos
                for (int tempArrCounter = 0; tempArrCounter < allCombos.GetLength(1); tempArrCounter++) // copying the previous line for calculations
                {                                                                         // of the new line's elements
                    tempArr[tempArrCounter] = allCombos[lineCounter - 1, tempArrCounter];
                } // creating a temporary array for calculation


                // processing the current line
                for (int counter2 = allCombos.GetLength(1) - 1; counter2 >= 0; counter2--) // counter2 will equal the value of 
                                                                                           // the element of the 'tempArr' currently being processed
                {


                    Console.Write($"| Processing element #{counter2}");

                    // if the currently processed element of the tempArr is less than the value of the 'largest digit' of our array 
                    // then increase the current element in tempArr and continue to changing the values of allCombos, and 
                    // then go to a new line
                    if (tempArr[counter2] < srcArr.Length - 1)
                    {

                        tempArr[counter2] += 1;
                       // Console.Write($"| tempArr[{counter2}]+=1 |");

                        if (counter2 < allCombos.GetLength(1) - 1)
                        {
                            //Console.Write("| current bit > 0 |");


                            int counter3 = counter2;
                            while (counter3 < allCombos.GetLength(1) - 1)
                            {
                                counter3++;
                                tempArr[counter3] = 0;
                            }
                        }

                        break;
                    }


                    //if the digit has a maximum value, go to the next iteration:
                    if (tempArr[counter2] == srcArr.Length - 1)
                    {
                        // if the currently processed element of the tempArr
                        // equals the value of the 'largest digit'of our array
                        // (decimal example: equals 9

                        continue;

                    }

                }

                // transfering values from tempArr to allCombos
                for (int tempArrCounter = 0; tempArrCounter < allCombos.GetLength(1); tempArrCounter++)
                {
                    allCombos[lineCounter, tempArrCounter] = tempArr[tempArrCounter];

                }
                Console.Write($"| allCombos:line#{lineCounter}=tempArr |");

            }
            return allCombos;
        }

        static string allCombinations(int[] objArr, int[] refArr, string namesStr)
        {
            string result = "";





            return result;

        }
        static int[,] IncreaseByOne(int[] objArr, int[] refArr, string namesStr)
        {
            bool elementFound = false;
            int maxVariationsLength = 1;


            int prevG = refArr.Length;
            for (int f = 0; f < objArr.Length; f++)
            {
                maxVariationsLength *= prevG;
                prevG -= 1;
            }


            Console.Write("\nmaxVariationsLength=" + maxVariationsLength);

            int[,] variationsArr = new int[maxVariationsLength, objArr.Length];


            int variationCounterInt = 0;
            while (true)
            {
                if (variationCounterInt > maxVariationsLength - 2)
                {
                    Console.Write("\n\nLimit of variations reached.");

                    PrintArray(variationsArr, refArr);

                    return variationsArr;
                }


                //Console.Write($"\n________________________________________\nVariation#{variationCounterInt}");





                int[] tempObjArr;
                for (int i = objArr.Length - 1; i >= 0; i--)
                {
                    //Console.Write($"\n____________________________\nProcessing element {i}");

                    tempObjArr = FilterArrElementsByIndex(objArr, i, "<=");
                    int[] currentArrDifference = FindUniqueElements(refArr, tempObjArr, "refArr > tempObjArr");
                    currentArrDifference = SelectionSort(currentArrDifference, "");

                    if (currentArrDifference[0] == 9999)
                    {
                        Console.Write("Can't increase the current bit, going to the next bit");
                        continue;
                    } // in case of an error



                    else  // if no error occurs (under normal conditions...)
                    {

                        if (i == objArr.Length - 1)
                        {
                            //Console.Write("Increasing the current element...");
                            int[] filteredCurrentArrDifference = FilterArrElements(currentArrDifference, objArr[i], ">");
                            //PrintSingleDimArray(filteredCurrentArrDifference, "filtered values of refArr");

                            if (filteredCurrentArrDifference[0] == 9999)
                            {
                                //Console.Write("\nCan't increase the current bit, going to the next bit");
                                continue;
                            }


                            objArr[i] = filteredCurrentArrDifference[0]; // changing the current element
                            tempObjArr[i] = filteredCurrentArrDifference[0];


                            //Console.Write("\n<------------>\n");
                            //PrintSingleDimArray(objArr, "objArr");

                            for (int k = 0; k < objArr.Length; k++)
                            {
                                variationsArr[variationCounterInt + 1, k] = objArr[k];
                            }

                            break;
                        }

                        if (i < objArr.Length - 1) // continue the previous operations this way if the element just changed is not the last element of objArr
                        {
                            Console.Write("Increasing the current element...");
                            int[] filteredCurrentArrDifference = FilterArrElements(currentArrDifference, objArr[i], ">");
                            //PrintSingleDimArray(filteredCurrentArrDifference, "filtered values of refArr");

                            if (filteredCurrentArrDifference[0] == 9999)
                            {
                                //Console.Write("\nCan't increase the current bit, going to the next bit");
                                continue;
                            }


                            objArr[i] = filteredCurrentArrDifference[0]; // changing the current element
                            tempObjArr[i] = filteredCurrentArrDifference[0];


                            //Console.Write("\n<------------>\n");
                            //PrintSingleDimArray(tempObjArr, "tempobjArr");

                            //Console.Write("\nReady to populate the following elements...");
                            currentArrDifference = FindUniqueElements(refArr, tempObjArr, "");
                            currentArrDifference = SelectionSort(currentArrDifference, "");
                            objArr = PopulateArray(objArr, i + 1, currentArrDifference);

                            //PrintSingleDimArray(objArr, "objArr");

                            for (int k = 0; k < objArr.Length; k++)
                            {
                                variationsArr[variationCounterInt + 1, k] = objArr[k];
                            }
                            break;

                        }





                    } // if a correct-form array was returned by FindUniqueElements method...




                }
                variationCounterInt++;


            }


        }
        static int[] PopulateArray(int[] objArr, int id, int[] srcArr)
        {
            //Console.WriteLine("\n\nStarting to populate array...");

            //PrintSingleDimArray(objArr,"objArr");
            //PrintSingleDimArray(srcArr, "srcArr");
            //Console.Write("\nfirstElementId: " + id);

            srcArr = SelectionSort(srcArr, "srcArr");





            //Console.WriteLine();




            int counter = 0;

            if (objArr.Length > id) // checking whether the first element of iteration exists to avoid errors
            {

                for (int i = id; i < objArr.Length; i++)
                {

                    objArr[i] = srcArr[counter];
                    counter++;
                }
            }



            return objArr;
        }





        static void PrintArray(int[,] arraySchema, int[] srcArr)
        {
            PrintSingleDimArray(srcArr, "sourceArr");

            Console.Write("\n\nallCombos[,]' 'mask' values:\n");
            for (int m = 0; m < arraySchema.GetLength(0); m++)
            {
                for (int n = 0; n < arraySchema.GetLength(1); n++)
                {
                    Console.Write($"[{m},{n}]=" + arraySchema[m, n] + " ");
                }

                Console.Write("\n");
            }
            Console.Write("_____\n");

            Console.Write("\nAll combinations/variations of the entered elements of sourceArr:\n");
            for (int m = 0; m < arraySchema.GetLength(0); m++)
            {
                for (int n = 0; n < arraySchema.GetLength(1); n++)
                {
                    Console.Write(srcArr[arraySchema[m, n]] + " ");
                }

                Console.Write("\n");
            }
            Console.Write("_____");

        }
        static void PrintString(string srcString, string stringName)
        {
            Console.Write($"\nString {stringName}:'{srcString}'");
        }
        static void PrintSingleDimArray(int[] srcArr, string arrName)
        {

            Console.Write("\n\nint[] " + arrName + ":\n-values:   {");
            int iValCounter = 0;
            foreach (int i in srcArr)
            {
                

                if (iValCounter < srcArr.Length - 1)
                {
                    Console.Write($"{i,3}, ");
                }

                if (iValCounter == srcArr.Length - 1)
                {
                    Console.Write($"{i,3}");

                }
                iValCounter++;

            }
            Console.Write("}\n");

            Console.Write("-element #  ");
            iValCounter = 0;
            foreach (int i in srcArr)
            {

                if (iValCounter < srcArr.Length - 1)
                {
                    Console.Write($"{iValCounter,3}, ");
                    iValCounter++;
                }
                if (iValCounter == srcArr.Length-1)
                {
                    Console.Write($"{iValCounter,3}");
                    iValCounter++;
                }
            }
        }
        static void PrintBool(bool srcBool, string boolName)
        {
            Console.Write($"\n\nbool {boolName}={srcBool}");
        }


        static int[] CalculatePrecedingElements(int[] srcArr, int id)
        {
            Console.WriteLine($"\n\nCalculating preceding elements (srcArr, {id})...");

            int newArrLength = id;
            int[] resultArr = new int[newArrLength];

            for(int i=0; i<id; i++)
            {
                resultArr[i] = srcArr[i];
            }

            PrintSingleDimArray(resultArr, arrName:$"CalculatePrecedingElements(srcArr,{id})");

            return resultArr;
        }
        static int[] CalculateFollowingElements(int[] srcArr, int id)
        {
            if (id > srcArr.Length - 1) 
            {
                Console.Write("\n\n!!! 'CalculateFollowingElements' Method: parameter 'id' was set too high.");
                return null;
            }

            Console.Write("\n_____\n");
            Console.WriteLine($"\n\nCalculating following elements (srcArr, {id})...");

            int newArrLength = srcArr.Length-id-1;
            int[] resultArr = new int[newArrLength];


            int counter = 0;
            for (int i = id+1; i < srcArr.Length; i++)
            {
                resultArr[counter] = srcArr[i];
                counter++;
            }

            PrintSingleDimArray(resultArr, arrName: $"CalculateFollowingElements(srcArr,{id})");

            return resultArr;
        }


        static int[] FindUniqueElements(int[] objArr,  int[] refArr,  string arrNames)
        {
            //Console.Write($"\n\nComparing arrays: '{arrNames}'");
            //PrintSingleDimArray(objArr, "objArr");
            //PrintSingleDimArray(refArr, "refArr");

            
            string valsString = ""; // creating a string to store the 'unique elements' before assigning them to an array

            

            for(int i=0; i < objArr.Length; i++)
            {
                for(int j=0; j<refArr.Length; j++)
                {
                    if (objArr[i] == refArr[j])
                    {
                        break;
                    }

                    if (j == refArr.Length - 1)
                    {
                        if (valsString == "")
                        {
                            valsString = Convert.ToString(objArr[i]);
                            break;
                        }

                        else
                        {
                            valsString =valsString +  " " + objArr[i];
                        }
                    }
                }
            }


            int[] resultIntArr = ParseStringToIntArray(valsString, " ");


            //Console.WriteLine($"\n{arrNames} compared:");
            //PrintSingleDimArray(resultIntArr, "arrDifference");

            return resultIntArr;
            
        }
        static int[] FilterArrElements(int[] objArr, int limVal, string sign)
        {

            //Console.Write($"\nFiltering elements of an array so all the remaining elements '{sign}{limVal}' ");
            string resultString = "";
            int[] intArr;


            for(int i = 0; i < objArr.Length; i++)
            {
                //Console.Write($"\nProcessing element #{i}, arr[i]={objArr[i]}. ");


                

                bool addCurrentElement = false;


                switch (sign)
                {


                    case "<":
                        if (objArr[i] < limVal)
                        {
                            addCurrentElement = true;
                        }
                        break;
                    case ">":
                        if (objArr[i] > limVal)
                        {
                            addCurrentElement = true;
                        }
                        break;
                    case "=":
                        if (objArr[i] == limVal)
                        {
                            addCurrentElement = true;
                        }
                        break;
                    case "<=":
                        if (objArr[i] <= limVal)
                        {
                            addCurrentElement = true;
                        }
                        break;
                    case ">=":
                        if (objArr[i] >= limVal)
                        {
                            addCurrentElement = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nNo operation was specified for the entered 'comparison symbol'.");
                        break;
                }

                if (addCurrentElement == true)
                {
                    if (resultString != "")
                    {
                        resultString += " ";
                        //Console.Write("\nSpace added.Element Added.");
                    }
                    if (resultString == "")
                    {
                        //Console.Write("\nFirst element added.");
                    }
                    resultString += objArr[i];
                    addCurrentElement = false;
                }
            }
            //Console.Write($"\nfilteredElementsString='{resultString}'");
            //Console.Write("\nTrying to parse 'filteredElementsString' to an int array.");

            if (resultString == "")
            {
                //Console.Write("\nError occured while filtering. Try debugging the program.");
                intArr = new int[1];
                intArr[0] = 9999; // if an error occurs, returns '9999'
                return intArr;
            }

            intArr= ParseStringToIntArray(resultString, " ");

            //PrintSingleDimArray(intArr, "filteredElements");

            return intArr;
        }
        static int[] FilterArrElementsByIndex(int[] objArr, int limVal, string sign)
        {
            //Console.Write($"\nFiltering elements of an array so indexes of all the remaining elements '{sign}{limVal}' ");
            string resultString = "";
            int[] intArr;


            for (int i = 0; i < objArr.Length; i++)
            {



                switch (sign)
                {
                    case "<":
                        if (i < limVal)
                        {
                            if (resultString != "")
                            {
                                resultString += ",";
                            }
                            resultString += objArr[i];
                        }
                        break;
                    case ">":
                        if (i > limVal)
                        {
                            if (resultString != "")
                            {
                                resultString += ",";
                            }
                            resultString += objArr[i];
                        }
                        break;
                    case "=":
                        if (i == limVal)
                        {
                            if (resultString != "")
                            {
                                resultString += ",";
                            }
                            resultString += objArr[i];
                        }
                        break;
                    case "<=":
                        if (i <= limVal)
                        {
                            if (resultString != "")
                            {
                                resultString += ",";
                            }
                            resultString += objArr[i];
                        }
                        break;
                    case ">=":
                        if (i >= limVal)
                        {
                            if (resultString != "")
                            {
                                resultString += ",";
                            }
                            resultString += objArr[i];
                        }
                        break;
                }
            }
            //Console.Write($"\nfilteredElementsString='{resultString}'");

            //
            //Console.Write("\nTrying to parse 'filteredElementsString' to 'int' format.");
            intArr = ParseStringArrayToIntArray(resultString.Split(','));


            //PrintSingleDimArray(objArr, "original array");
            //PrintSingleDimArray(intArr, "filteredElements");

            return intArr;

        }

        

        static int FindSmallestElementValueOfArray(int[] srcArr)
        {
            srcArr = SelectionSort(srcArr, "");
            return srcArr[0];
        }
        
        


        static int[,] TestMethod(int srcArrLength, int combsLength)
        {

            int[] modelFullArr = PassRangeCalculateIntArray(0, srcArrLength - 1);
            int[] modelCombsArr = PassRangeCalculateIntArray(0, combsLength - 1);

            //int[] modelFullArr = {0,1,2,3,4,5};
            //int[] modelCombsArr = {0,1,2};

            PrintSingleDimArray(modelFullArr, arrName:"modelFullArr");
            PrintSingleDimArray(modelCombsArr, arrName: "modelCombsArr");
            //IncreaseNearestIncreasableElement(modelCombsArr, modelFullArr, "modelCombsArr > modelFullArr");

            Console.WriteLine("\n____________________________");
            //modelCombsArr = IncreaseByOne(modelCombsArr, modelFullArr, "combsArr < fullArr");

            //modelCombsArr=PopulateArray(modelCombsArr, 1, modelFullArr);
            //PrintSingleDimArray(modelCombsArr,"modelCombsArr");

            int[,] result=IncreaseByOne(modelCombsArr, modelFullArr, "modelCombsArr < modelFullArr");
            return result;


        }

        static void Main(string[] args)
        {
            // <? asking for user's commands / choices

            int[] srcArr = LandingPage();
            int sequenceLengthInt = EnterInt("Combinations/variations length");

            int[,] mask = { };

            string[] options = { "Calculate all combinations", "Calculate all variations" };
            string ch = ChooseBetweenOptions(options);
            if (ch == "1")
            {
                mask = TestMethod(srcArr.Length, sequenceLengthInt );
            }
            if (ch == "2")
            {
                mask = CalculateAllVariations(srcArr, sequenceLengthInt);
            }







            PrintArray(mask, srcArr);

            ////

            //TestMethod();

            Console.Write("\n\n\n");
        }
    }
}
