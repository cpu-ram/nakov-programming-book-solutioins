using System;
using System.Collections.Generic;

namespace Matrices
{
    class Matrix
    {
        public int width = 0;
        public int height = 0;
        public Location entryPoint;
        public Location exitPoint;

        public enum Direction
        {
            Up, Right, Down, Left, None
        }
        public Location EntryPoint
        {
            get
            {
                return entryPoint;
            }
            set
            {
                char entryChar = Convert.ToChar("n");
                SetCell(value, entryChar);
            }
        }
        public Location ExitPoint
        {
            get
            {
                return exitPoint;
            }
            set
            {
                char exitChar = Convert.ToChar("x");
                SetCell(value, exitChar);
            }
        }
        public List<Location> ImpassableCells
        {
            get
            {
                return impassableCells;
            }
            set
            {
                this.impassableCells = new List<Location>();
                List<Location> tempList = CopyTupleList(value);
                foreach (Tuple<int, int> element in tempList)
                {
                    if (element.Item1 >= height || element.Item2 >= width)
                    {
                        throw new IndexOutOfRangeException();
                    }
                }
                for (int i = 0; i < tempList.Count; i++)
                {
                    impassableCells.Add(tempList[i]);
                }


                foreach (Tuple<int, int> element in impassableCells)
                {
                    if (element.Equals(entryPoint) || element.Equals(exitPoint))
                    {
                        Exception locationConflict = new Exception
                            ("A position to be filled is already occupied.");
                    }
                    this.elements[element.Item1, element.Item2] = Convert.ToChar("*");
                }

            }
        }
        public List<Location> impassableCells = new List<Location>();
        char[,] elements;
        List<int[]> matrixCellPositions = new List<int[]>();
        List<List<Tuple<int, int>>> adjacentCellSets;
        List<int[]> unsortedCells = new List<int[]>();
        char whitespace = Convert.ToChar(" ");
        public Matrix(int width, int height, Location entryPoint = null, Location exitPoint = null)
        {
            this.width = width;
            this.height = height;
            elements = new char[this.height, this.width];
            for (int i = 0; i < this.width; i++)
            {
                for (int j = 0; j < this.height; j++)
                {
                    int[] tempIntArr = new int[2];
                    tempIntArr[0] = i;
                    tempIntArr[1] = j;
                    matrixCellPositions.Add(tempIntArr);
                    elements[i, j] = Convert.ToChar(" ");
                }
            }
            if (entryPoint != null)
            {
                if (IsWithinRange(entryPoint))
                {
                    this.EntryPoint = entryPoint;
                }
                else throw new IndexOutOfRangeException();
            }
            if (exitPoint != null)
            {
                if (IsWithinRange(exitPoint))
                {
                    this.ExitPoint = exitPoint;
                }
                else throw new IndexOutOfRangeException();
            }
        }
        public class Location
        {
            Tuple<int, int> coordinates;
            public Location(int y, int x)
            {
                Coordinates = new Tuple<int, int>(y, x);
            }
            public int X
            {
                get
                {
                    return this.Coordinates.Item1;
                }
                
            }
            public int Y
            {
                get
                {
                    return this.Coordinates.Item2;
                }
            }

            public Tuple<int, int> Coordinates { get => coordinates; set => coordinates = value; }
            public bool Equals(Location location)
            {
                if (this.X == location.X && this.Y == location.Y)
                {
                    return true;
                }
                else return false;
            }
        }
        public void SetCell(Location location, char value)
        {
            int y = location.Coordinates.Item1;
            int x = location.Coordinates.Item2;
            elements[y, x] = value;
        }
        public char GetCell(Location location)
        {
            int y = location.Coordinates.Item1;
            int x = location.Coordinates.Item2;
            char result = elements[y, x];
            return result;
        }
        public Location Step(Location startPosition, Direction direction)
        {
            int elementOne = startPosition.Coordinates.Item1;
            int elementTwo = startPosition.Coordinates.Item2;
            int newElementOne;
            int newElementTwo;
            Location resultLocation;

            switch (direction)
            {
                case Direction.Up:
                    newElementOne = elementOne - 1;
                    resultLocation = new Location(newElementOne, elementTwo);
                    break;
                case Direction.Right:
                    newElementTwo = elementTwo + 1;
                    resultLocation = new Location(elementOne, newElementTwo);
                    break;
                case Direction.Down:
                    newElementOne = elementOne + 1;
                    resultLocation = new Location(newElementOne, elementTwo);
                    break;
                case Direction.Left:
                    newElementTwo = elementTwo - 1;
                    resultLocation = new Location(elementOne, newElementTwo);
                    break;
                case Direction.None:
                    resultLocation = new Location(elementOne, elementTwo);
                    break;
                default:
                    resultLocation = new Location(elementOne, elementTwo);
                    break;
            }
            return resultLocation;
        }


        public List<Tuple<int, int>> SubstractSet(List<Tuple<int, int>> minuend, List<Tuple<int, int>> substrahend)
        {
            List<Tuple<int,int>> tempMinuend = CopyTupleList(minuend);
            List<Tuple<int, int>> tempSubstrahend = CopyTupleList(substrahend);
            bool[] elementsToKeep = new bool[tempMinuend.Count];
            for (int i = 0; i < elementsToKeep.Length; i++)
            {
                elementsToKeep[i] = true;
            }
            List<Tuple<int, int>> difference = new List<Tuple<int, int>>();

            for (int i = 0; i < tempMinuend.Count; i++)
            {
                for (int j = 0; j < tempSubstrahend.Count; j++)
                {
                    if (tempMinuend[i].Equals(tempMinuend[j]))
                    {
                        elementsToKeep[i] = false;
                        break;
                    }
                }
            }

            for (int i = 0; i < tempMinuend.Count; i++)
            {
                if (elementsToKeep[i] == true)
                {
                    difference.Add(tempMinuend[i]);
                }
            }


            return difference;
        }
        public List<Location> CopyTupleList(List<Tuple<int,int>> entryList)
        {
            if (entryList == null)
            {
                List<Tuple<int,int>> newList = new List<Location>();
                return newList;
            }
            List<Tuple<int,int>> tempTupleList = new List<Tuple<int,int>>();

            for (int i = 0; i < entryList.Count; i++)
            {
                int elementOne = entryList[i].Item1;
                int elementTwo = entryList[i].Item2;
                Tuple<int, int> tempTuple = new Tuple<int, int>(elementOne, elementTwo);
                tempTupleList.Add(tempTuple);
            }
            return tempTupleList;
        }
        public int[] CopyIntArr(int[] entryIntArr)
        {
            int[] tempIntArr = new int[entryIntArr.Length];
            for (int i = 0; i < tempIntArr.Length; i++)
            {
                tempIntArr[i] = entryIntArr[i];
            }
            return tempIntArr;
        }
        public List<Tuple<int, int>> AddIntArrToList(List<Tuple<int, int>> entryList,
            Tuple<int, int> entryIntArr)
        {
            List<Tuple<int, int>> tempList = CopyTupleList(entryList);
            tempList.Add(entryIntArr);
            return tempList;
        }
        public List<Tuple<int, int>> MergeLists(List<Tuple<int, int>> entryListOne,
            List<Tuple<int, int>> entryListTwo)
        {
            List<Tuple<int, int>> tempListOne = CopyTupleList(entryListOne);
            List<Tuple<int, int>> tempListTwo = CopyTupleList(entryListTwo);

            for (int i = 0; i < tempListTwo.Count; i++)
            {
                if (!DoesContain(tempListOne, tempListTwo[i]))
                {
                    tempListOne.Add(tempListTwo[i]);
                }
            }
            return tempListOne;
        }
        static int[] CreateIntCouple(int intOne, int intTwo)
        {
            int[] tempIntArr = new int[2];
            tempIntArr[0] = intOne;
            tempIntArr[1] = intTwo;
            return tempIntArr;
        }
        static Tuple<int,int> CreateTuple(int intOne, int intTwo)
        {
            Tuple<int, int> resultTuple = new Tuple<int, int>(intOne, intTwo);
            return resultTuple;
        }
        public static bool TuplesAreEqual(Tuple<int, int> tupleOne, Tuple<int, int> tupleTwo)
        {
            if (tupleOne.Item1 == tupleTwo.Item1 && tupleOne.Item2 == tupleTwo.Item2)
            {
                return true;
            }
            return false;
        }
        public static bool DoesContain(List<Tuple<int, int>> entryList, Tuple<int, int> entryTuple)
        {
            bool resultBool = false;
            for (int i = 0; i < entryList.Count; i++)
            {
                if (entryList[i].Item1 == entryTuple.Item1 && entryList[i].Item2 == entryTuple.Item2)
                {
                    resultBool = true;
                    return true;
                }
            }
            return false;
        }
        public static void PrintLocationList(List<Location> entryList)
        {
            Console.WriteLine();
            for (int i = 0; i < entryList.Count; i++)
            {
                Console.Write("[");
                Console.Write(entryList[i].Item1 + "," + entryList[i].Item2);
                Console.Write("] ");
            }
        }
        static List<int[]> removeDuplicates(List<int[]> entryList)
        {
            List<int> removalPositions = new List<int>();
            List<int[]> resultList = entryList;
            int counter = 0;
            while (counter < entryList.Count - 1)
            {
                removalPositions.Clear();
                for (int i = counter + 1; i < entryList.Count; i++)
                {
                    if (entryList[i] == entryList[counter])
                    {
                        removalPositions.Add(i);
                    }
                }
                if (removalPositions.Count > 0)
                {
                    foreach (int position in removalPositions)
                    {
                        resultList.RemoveAt(position);
                    }
                }
            }

            return resultList;
        }

        public void AddImpassableCells(List<Tuple<int,int>> entryList)
        {
            if (entryList.Count > 0)
            {
                List<Tuple<int, int>> tempList = CopyTupleList(ImpassableCells);
                tempList = MergeLists(tempList, entryList);
                this.ImpassableCells = tempList;
            }
            else
            {
                return;
            }
        }


        public bool IsWithinRange(Tuple<int,int> positionTuple)
        {
            if (positionTuple.Item1 >= elements.GetLength(0)
                || positionTuple.Item1 < 0)
            {
                return false;
            }
            if (positionTuple.Item2 >= elements.GetLength(1)
                || positionTuple.Item2 < 0)
            {
                return false;
            }
            return true;
        }
        public bool IsWithinRange(Location location)
        {
            Tuple<int, int> position = location.Coordinates;
            bool resultBool = IsWithinRange(position);
            return resultBool;
        }
        static bool IsWithinRange(int[] entryIntArr, char[,] entryMatrix)
        {
            if (entryIntArr[0] >= entryMatrix.GetLength(0)
                || entryIntArr[0] < 0)
            {
                return false;
            }
            if (entryIntArr[1] >= entryMatrix.GetLength(1)
                || entryIntArr[1] < 0)
            {
                return false;
            }
            return true;
        }
        public bool PositionIsOpen(Tuple<int,int> currentPosition, Direction direction=Direction.None)
        {
            Location tempLocation = new Location(currentPosition.Item1, currentPosition.Item2);
            bool result = PositionIsOpen(tempLocation, direction);
            return result;
        }
        public bool PositionIsOpen(Location location, Direction direction = Direction.None)
        {
            Location resultLocation;
            int elementOne = location.Coordinates.Item1;
            int elementTwo = location.Coordinates.Item2;
            int newElementOne;
            int newElementTwo;
            if (!IsWithinRange(location)) return false;

            resultLocation = Step(location, direction);

            if (!IsWithinRange(resultLocation)) return false;
            if (!elements[resultLocation.Coordinates.Item1, resultLocation.Coordinates.Item2].Equals(' '))
            {
                return false;
            }
            return true;
        }
        public void Print()
        {
            for (int i = 0; i < height; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < width; j++)
                {

                    if (elements[i, j] == whitespace)
                    {
                        Console.Write("{0,2}", Convert.ToString("-"));
                    }
                    else
                    {

                        Console.Write("{0,2}", Convert.ToString(elements[i, j]));
                    }

                }
            }
        }
        public void FindAllPaths(Location entryPosition=null, List<Location> pathRecord = null, bool pathFound = false)
        {
            if (EntryPoint == null || ExitPoint == null) throw new NullReferenceException();
            if (entryPosition == null) entryPosition = EntryPoint;
            Location tempEntryPosition;

            if (entryPosition.Equals(ExitPoint))
            {
                pathRecord.Add(ExitPoint);
                PrintLocationList(pathRecord);
                pathRecord.RemoveAt(pathRecord.Count - 1);
                pathFound = true;
                return;
            }
            if (!IsWithinRange(entryPosition))
            {
                return;
            }
            
            if (pathRecord == null)
            {
                pathRecord = new List<Location>();
                pathRecord.Add(entryPosition);
            }
            else
            {
                if(entryPosition.Equals(EntryPoint))
                {
                    return;
                }
                if(impassableCells.Contains(entryPosition))
                {
                    return;
                }

                if (pathRecord.Contains(entryPosition))
                {
                    return;
                }
                pathRecord.Add(entryPosition);
            }


            int y = entryPosition.Y;
            int x = entryPosition.X;

            

            tempEntryPosition = new Location(y+1, x);
            FindAllPaths(tempEntryPosition, pathRecord, pathFound);

            tempEntryPosition = new Location(y, x+1);
            FindAllPaths(tempEntryPosition, pathRecord, pathFound);

            tempEntryPosition = new Location(y-1, x);
            FindAllPaths(tempEntryPosition, pathRecord, pathFound);

            tempEntryPosition = new Location(y, x-1);
            FindAllPaths(tempEntryPosition, pathRecord, pathFound);

            pathRecord.RemoveAt(pathRecord.Count - 1);
            return;
        }
        public void FindTheGreatestAreaOfNeighboringCells()
        {
            
        }
        public static void FindDistances(Location startPosition, int matrixSize)
        {
            Matrix matrix = new Matrix(matrixSize, matrixSize);
            matrix.SetCell(startPosition, '0');
            Queue<Location> queue = new Queue<Location>();
            queue.Enqueue(startPosition);
            while (queue.Count > 0)
            {
                Location tempPosition = queue.Peek();
                char tempChar = matrix.GetCell(tempPosition);
                int tempInt = Convert.ToInt32(tempChar);
                char nextChar = Convert.ToChar(tempInt + 1);
                for (int i=0; i<4; i++)
                {
                    Location newLocation = matrix.Step(tempPosition, (Direction)i);
                    if (matrix.PositionIsOpen(newLocation))
                    {
                        matrix.SetCell(newLocation, nextChar);
                        queue.Enqueue(newLocation);
                    }
                }
                queue.Dequeue();
            }
            matrix.Print();
        }

        public static void TestLabyrinth()
        {
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
        }
    }
}
