using System;
using System.Collections.Generic;
namespace PriorityQueues
{
    public class PriorityQueue<T> where T : IComparable
    {
        T[] values;
        internal int count;
        int capacity;
        int openPositionID;

        Dictionary<int, bool> occupiedPositions;
        
        
        int? lastOccupiedPosition;
        const int INITIAL_CAPACITY = 16;
        SortOrder sortOrder;

        public int Count { get => count; set => count = value; }

        public enum SortOrder
        {
            Standard, Reverse
        }
        public PriorityQueue(SortOrder sortOrder)
        {
            this.occupiedPositions = new Dictionary<int, bool>();

            this.capacity = INITIAL_CAPACITY;
            this.Count = 0;
            this.openPositionID = 0;
            values = new T[capacity];
            this.sortOrder = sortOrder;

            for(int i=0; i<capacity; i++)
            {
                this.occupiedPositions[i] = false;
            }
        }

        public void Add(T entry)
        {
            if (!this.IsBalanced())
            {
                throw new Exception("Internal error: queue is not balanced");
            }
            if (this.Count == this.capacity)
            {
                this.Resize();
            }
            InsertOnPathTo(entry, openPositionID);
        }
        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new NullReferenceException();
            }
            if (this.Count < 0)
            {
                throw new Exception();
            }

            if (!this.IsBalanced())
            {
                throw new Exception();
            }
            if (openPositionID == 0)
            {
                throw new ArgumentOutOfRangeException("Error: can " +
                    "not dequeue because the queue is empty.");
            }

            T result = ExtractAtPosition(0);
            if (this.Count > 0)
            {
                PullUp(0);
            }
            
            return result;
        }
        public bool IsBalanced()
        {
            for (int i = 0; i < openPositionID; i++)
            {
                if (!PositionIsOccupied(i))
                {
                    return false;
                }
            }
            if (this.openPositionID != this.Count)
            {
                return false;
            }
            return true;
        }
        internal T GetValue(int id)
        {
            if (!PositionIsWithinRange(id) || !PositionIsOccupied(id))
            {
                throw new ArgumentOutOfRangeException();
            }
            T result = this.values[id];
            return result;
        }

        internal void Resize()
        {
            if (!this.IsBalanced())
            {
                throw new Exception();
            }
            int oldCount = this.Count;
            int doubleCount = this.Count * 2;
            T[] newElementsArray = new T[doubleCount];
            for(int i=0; i<this.openPositionID; i++)
            {
                newElementsArray[i] = this.GetValue(i);
            }
            this.values = newElementsArray;
            this.Count = doubleCount;
            for(int i=oldCount; i<this.Count; i++)
            {
                this.occupiedPositions[i] = true;
            }

        }
        internal bool TryFindPathBetween(int idOne, int idTwo, out int[] resultPath)
        {
            int entryPointID;
            int endPointID;
            resultPath = new int[0];

            if(PositionIsWithinRange(idOne, idTwo))
            {
                int idsComparison = idOne.CompareTo(idTwo);
                switch (idsComparison)
                {
                    case -1:
                        entryPointID = idOne;
                        endPointID = idTwo;
                        break;
                    case 0:
                        resultPath =new int[1]{idOne};
                        return true;
                    case 1:
                        entryPointID = idTwo;
                        endPointID = idOne;
                        break;
                    default:
                        throw new Exception();
                }

                List<int> sequence = new List<int>();
                Queue<int> path = new Queue<int>();
                path.Enqueue(endPointID);
                while (path.Count > 0)
                {
                    int currentID = path.Dequeue();
                    if (currentID < entryPointID)
                    {
                        resultPath = new int[0];
                        return false;
                    }
                    if (currentID == entryPointID)
                    {
                        sequence.Add(currentID);
                        sequence.Reverse();
                        resultPath = sequence.ToArray();
                        return true;
                    }


                    int parentID = GetParentID(currentID);
                    sequence.Add(currentID);
                    path.Enqueue(parentID);
                }
                return false;
            }
            else
            {
                throw new ArgumentException();
            }
        }
        public void InsertOnPathTo(T entry, int endPoint)
        {
            int entryPoint = 0;
            if (TryFindPathBetween(entryPoint, endPoint, out int[] path))
            {
                if (PathIsValidForInsertion(path))
                {
                    int finalPosition = path[path.Length-1];

                    if (path.Length == 1)
                    {
                        int onlyPosition = path[0];
                        if (!PositionIsOccupied(onlyPosition))
                        {
                            SetPositionToValue(onlyPosition, entry);
                            return;
                        }
                        else
                        {
                            throw new ArgumentException();
                        }
                    }
                    if (path.Length > 1)
                    {
                        Queue<int> pathTraversalQueue = new Queue<int>();
                        int currentPathStep = 0;
                        int currentPosition = path[currentPathStep];
                        int pathLength = path.Length;
                        T valueToInsert = entry;
                        pathTraversalQueue.Enqueue(currentPosition);

                        T oldValue = default(T);
                        while(pathTraversalQueue.Count>0)
                        {
                            currentPosition = pathTraversalQueue.Dequeue();
                            if (currentPosition < finalPosition)
                            {
                                T existingValueOfCurrentPosition = GetValue(currentPosition);
                                if(IsOfHigherOrder(valueToInsert, existingValueOfCurrentPosition))
                                {
                                    oldValue = existingValueOfCurrentPosition;
                                    SetPositionToValue(currentPosition, valueToInsert);
                                    valueToInsert = oldValue;
                                    currentPathStep += 1;
                                    int nextPosition = path[currentPathStep];
                                    pathTraversalQueue.Enqueue(nextPosition);
                                    continue;

                                }
                                else
                                {
                                    currentPathStep += 1;
                                    int nextPosition = path[currentPathStep];
                                    pathTraversalQueue.Enqueue(nextPosition);
                                }
                            }
                            if (currentPosition == finalPosition)
                            {
                                SetPositionToValue(currentPosition, valueToInsert);
                                return;
                            }
                        }
                    }
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            else
            {
                throw new Exception();
            }
            bool PathIsValidForInsertion(int[] path)
            {
                if (PositionIsOccupied(path[path.Length - 1]))
                {
                    return false;
                }
                if (path.Length > 1)
                {
                    for (int i = 0; i < path.Length; i++)
                    {
                        int currentPosition = path[i];
                        if (i < path.Length - 1)
                        {
                            if (!PositionIsOccupied(currentPosition))
                            {
                                return false;
                            }
                        }
                        if (i == path.Length - 1)
                        {
                            if (PositionIsOccupied(currentPosition))
                            {
                                return false;
                            }
                            else return true;
                        }
                    }
                    return false;
                }
                if (path.Length == 1)
                {
                    if (PositionIsOccupied(path[0]))
                    {
                        return false;
                    }
                    else return true;
                }
                if (path.Length == 0)
                {
                    return false;
                }
                return false;
            }
        }

        public void PullUp(int currentPosition)
        {
            if (currentPosition < 0 || currentPosition >= openPositionID
                    || PositionIsOccupied(currentPosition))
            {
                throw new ArgumentException();
            }

            int[] childrenIDs = GetChildrenIDs(currentPosition);
            int nextPosition;
            T replacementValue;
            if (childrenIDs.Length > 2) throw new Exception();

            switch (childrenIDs.Length)
            {
                case 2:
                    nextPosition = PickPositionContainingValueOfHigherOrder(
                    childrenIDs[0], childrenIDs[1]);
                    break;
                case 1:
                    nextPosition = childrenIDs[0];
                    break;
                case 0:
                    replacementValue = ExtractAtPosition(openPositionID - 1);
                    InsertOnPathTo(replacementValue, currentPosition);
                    return;
                default:
                    throw new Exception();
            }

            if (nextPosition < openPositionID - 1)
            {
                replacementValue = ExtractAtPosition(nextPosition);
                SetPositionToValue(currentPosition, replacementValue);
                PullUp(nextPosition);
                return;
            }
            if (nextPosition == openPositionID - 1)
            {
                replacementValue = ExtractAtPosition(nextPosition);
                SetPositionToValue(currentPosition, replacementValue);
                return;
            }
        }

        internal bool IsOfHigherOrder(T elementOne, T elementTwo)
        {
            if (elementOne.CompareTo(elementTwo) == 1 ||
                    elementOne.CompareTo(elementTwo) == 0)
            {
                if (this.sortOrder == SortOrder.Standard)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (this.sortOrder == SortOrder.Standard)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        internal int PickPositionContainingValueOfHigherOrder
            (int positionOne, int positionTwo)
        {
            int result;
            if (!PositionIsWithinRange(positionOne, positionTwo))
            {
                throw new ArgumentOutOfRangeException();
            }
            if (IsOfHigherOrder(values[positionOne], values[positionTwo]))
            {
                result = positionOne;
                return result;
            }
            else
            {
                result = positionTwo;
                return result;
            }
        }
        internal int[] GetChildrenIDs(int parentID)
        {
            List<int> tempChildrenList = new List<int>();

            if (!PositionIsWithinRange(parentID))
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                int shiftedParentID = parentID + 1;
                int childOneID = (shiftedParentID * 2)-1;
                int childTwoID = (shiftedParentID * 2);
                if (PositionIsWithinRange(childOneID) && childOneID<openPositionID)
                {
                    tempChildrenList.Add(childOneID);
                }
                if (PositionIsWithinRange(childTwoID) && childTwoID<openPositionID)
                {
                    tempChildrenList.Add(childTwoID);
                }
                int[] resultArray = tempChildrenList.ToArray();
                return resultArray;
            }
        }
        internal int GetParentID(int childID)
        {
            if (!PositionIsWithinRange(childID))
            {
                throw new ArgumentOutOfRangeException();
            }
            if (childID == 0)
            {
                throw new ArgumentException();
            }
            else
            {
                int parentID = ((childID + 1)/2)-1;
                return parentID;
            }
        }
        internal bool PositionIsOccupied(int entryID)
        {
            if (occupiedPositions[entryID] == true)
            {
                return true;
            }
            else return false;
        }
        internal T ExtractAtPosition(int positionID)
        {
            if (!PositionIsOccupied(positionID) || !PositionIsWithinRange(positionID)
                    || positionID==openPositionID)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                T resultValue = this.GetValue(positionID);
                ClearPosition(positionID);
                return resultValue;
            }
        }
        internal void ClearPosition(int positionID)
        {
            if (!PositionIsOccupied(positionID) || !PositionIsWithinRange(positionID)
                    || positionID == openPositionID)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.occupiedPositions[positionID] = false;
            if (positionID == openPositionID - 1)
            {
                openPositionID--;
            }
            Count--;
        }
        internal void SetPositionToValue(int id, T value)
        {
            if (!PositionIsWithinRange(id))
            {
                throw new ArgumentOutOfRangeException();
            }

            this.values[id] = value;
            if (this.openPositionID == id)
            {
                openPositionID++;
            }
            if (this.occupiedPositions[id] == false)
            {
                this.occupiedPositions[id] = true;
                this.Count++;
            }
        }
        internal bool PositionIsWithinRange(params int[] positionsArray)
        {
            foreach (int position in positionsArray)
            {
                if (position < 0 || position > openPositionID)
                {
                    return false;
                }
            }
            return true;
        }

        public void FillOpenPosition(T entry)
        {
            this.values[openPositionID] = entry;
            openPositionID++;
            lastOccupiedPosition = openPositionID - 1;
        }
    }
}
