using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace Graphs
{
    public class Graph
    {
        private IdStorage<int> ids;
        internal Dictionary<int, SortedDictionary<int, double>> outgoingEdges;
        internal Dictionary<int, SortedDictionary<int, double>> incomingEdges;

        internal IdStorage<int> IDs { get => ids; set => ids = value; }

        public Graph()
        {
            this.IDs = new IdStorage<int>();
            this.outgoingEdges = new Dictionary<int, SortedDictionary<int, double>>();
            this.incomingEdges = new Dictionary<int, SortedDictionary<int, double>>();
        }

        public int[] getVerticeIDs()
        {
            return this.IDs.GetIDs();
        }
        private bool ContainsVertice(int id)
        {
            if (IDs.Contains(id)) return true;
            else return false;
        }
        internal bool DirectedEdgeExists(int startingPoint, int endPoint)
        {
            if (outgoingEdges.ContainsKey(startingPoint))
            {
                if (outgoingEdges[startingPoint].ContainsKey(endPoint))
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }
        public int AddVertice()
        {
            int elementID = IDs.Add();
            return elementID;
        }
        public void AddEdge(int startingPoint, int endPoint, double weight)
        {
            if (outgoingEdges.ContainsKey(startingPoint))
            {
                outgoingEdges[startingPoint][endPoint] = weight;
            }
            else
            {
                SortedDictionary<int, double> tempDictionary = new SortedDictionary<int, double>();
                tempDictionary[endPoint] = weight;
                outgoingEdges[startingPoint] = tempDictionary;
            }

            if (incomingEdges.ContainsKey(endPoint))
            {
                incomingEdges[endPoint][startingPoint] = weight;
            }
            else
            {
                SortedDictionary<int, double> tempDictionary = new SortedDictionary<int, double>();
                tempDictionary[startingPoint] = weight;
                incomingEdges.Add(endPoint, tempDictionary);
            }

        }
        public void RemoveVertice(int id)
        {
            if (!this.ContainsVertice(id))
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                if (this.incomingEdges.ContainsKey(id))
                {
                    incomingEdges.Remove(id);
                }
                if (this.outgoingEdges.ContainsKey(id))
                {
                    outgoingEdges.Remove(id);
                }
                this.IDs.Remove(id);
            }
        }
        public void RemoveEdge(int startingPoint, int endPoint)
        {
            if (!this.ContainsVertice(startingPoint) ||
                    !this.ContainsVertice(endPoint))
            {
                throw new ArgumentOutOfRangeException();
            }
            if(!DirectedEdgeExists(startingPoint, endPoint))
            {
                throw new ArgumentOutOfRangeException();
            }

            incomingEdges[endPoint].Remove(startingPoint);
            outgoingEdges[startingPoint].Remove(endPoint);
            if (incomingEdges[endPoint].Count == 0)
            {
                incomingEdges.Remove(endPoint);
            }
            if(outgoingEdges[startingPoint].Count == 0)
            {
                outgoingEdges.Remove(startingPoint);
            }
        }
        public int[] GetDescendants(int id)
        {
            if (IDs.Contains(id))
            {
                if (outgoingEdges.ContainsKey(id))
                {
                    List<int> resultList = new List<int>();
                    IDictionaryEnumerator enumerator = outgoingEdges[id].GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        resultList.Add(Convert.ToInt32(enumerator.Key));
                    }
                    int[] resultArr = new int[resultList.Count];
                    for (int i = 0; i < resultList.Count; i++)
                    {
                        resultArr[i] = resultList[i];
                    }
                    return resultArr;
                }
                else
                {
                    int[] resultArr = new int[0];
                    return resultArr;
                }
            }
            else throw new ArgumentOutOfRangeException();
        }
        public double GetEdgeWeight(int idOne, int idTwo)
        {
            if(!this.DirectedEdgeExists(idOne, idTwo))
            {
                throw new ArgumentOutOfRangeException();
            }
            double resultWeight = outgoingEdges[idOne][idTwo];
            return resultWeight;
        }
        public int VerticeCount
        {
            get
            {
                int count = this.ids.Capacity;
                return count;
            }

        }
        public bool EdgeExistsInEitherDirection(int idOne, int idTwo)
        {
            int[] descendantsArrOne = GetDescendants(idOne);
            for (int i = 0; i < descendantsArrOne.Length; i++)
            {
                if (descendantsArrOne[i] == idTwo) return true;
            }

            int[] descendantsArrTwo = GetDescendants(idTwo);
            for (int i = 0; i < descendantsArrTwo.Length; i++)
            {
                if (descendantsArrTwo[i] == idOne) return true;
            }
            return false;
        }

        public Path FindPathWithLeastSteps(int idOne, int idTwo)
        {
            Path resultPath = new Path();
            HashSet<int> visitedLocations = new HashSet<int>();

            if (!this.ContainsVertice(idOne) || !this.ContainsVertice(idTwo))
            {
                throw new ArgumentOutOfRangeException();
            }
            Queue<Path.PathPoint> positions = new Queue<Path.PathPoint>();
            Path.PathPoint startPosition = new Path.PathPoint(idOne);
            positions.Enqueue(startPosition);

            while (positions.Count > 0)
            {
                Path.PathPoint currentPosition = positions.Dequeue();
                int currentPositionID = currentPosition.GetID();
                if (currentPositionID == idTwo)
                {
                    resultPath = currentPosition.RestorePath();
                    return resultPath;
                }
                int[] tempChildrenIDs = GetDescendants(currentPositionID);
                for (int i = 0; i < tempChildrenIDs.Length; i++)
                {
                    int tempChildID = tempChildrenIDs[i];

                    if (!visitedLocations.Contains(tempChildID))
                    {
                        Path.PathPoint newPosition = new Path.PathPoint(tempChildID, currentPosition);
                        positions.Enqueue(newPosition);
                        visitedLocations.Add(tempChildID);

                    }
                }
            }
            return null;

        }


        // test requirements: test with identic start/end points
        public void FindShortestDistancePath(int idOne, int idTwo)
        {
            if (!this.ContainsVertice(idOne) || !this.ContainsVertice(idTwo))
            {
                throw new ArgumentOutOfRangeException();
            }

            Dictionary<int, double> verticeToDistanceDictionary = new Dictionary<int, double>();
            Dictionary<int, Path> verticeToPathDictionary = new Dictionary<int, Path>();
            verticeToDistanceDictionary[idOne] = 0d;
            Path.PathPoint entryPoint = new Path.PathPoint(idOne);


            Queue<Path.PathPoint> searchQueue = new Queue<Path.PathPoint>();
            searchQueue.Enqueue(entryPoint);
            Path.PathPoint currentParent;
            double currentDistance;
            while (searchQueue.Count > 0)
            {
                currentParent = searchQueue.Dequeue();
                int currentParentID = currentParent.GetID();

                Path.PathPoint previousPosition = currentParent.PreviousPosition;
                
                double previousPositionWeight;

                double lastEdgeWeight;

                if (previousPosition == null)
                {
                    int[] children = GetDescendants(currentParentID);
                    for(int i=0; i<children.Length; i++)
                    {
                        int currentChildID = children[i];
                        Path.PathPoint newChild = new Path.PathPoint(currentChildID, currentParent);
                        searchQueue.Enqueue(newChild);
                    }
                }
                else
                {
                    int previousPositionID = previousPosition.GetID();
                    previousPositionWeight = verticeToDistanceDictionary[previousPositionID];
                    lastEdgeWeight = this.GetEdgeWeight(previousPositionID, currentParentID);
                    currentDistance = previousPositionWeight + lastEdgeWeight;


                    bool continuationConditions =
                        !verticeToDistanceDictionary.ContainsKey(currentParentID)
                            || verticeToDistanceDictionary[currentParentID] > currentDistance;
                    // if we found a new vertice or the shortest-so-far path to a visited one
                    if (continuationConditions)
                    {
                        verticeToDistanceDictionary[currentParentID] = currentDistance;
                        Path newPath = currentParent.RestorePath();
                        verticeToPathDictionary[currentParentID] = newPath;

                        int[] currentChildren = this.GetDescendants(currentParentID);
                        for (int i = 0; i < currentChildren.Length; i++)
                        {
                            int currentChildID = currentChildren[i];
                            Path.PathPoint newChild = new Path.PathPoint(currentChildID, currentParent);
                            searchQueue.Enqueue(newChild);
                        }
                    }
                    else continue;
                }

                
            }

            if (verticeToDistanceDictionary.ContainsKey(idTwo))
            {
                double resultDistance = verticeToDistanceDictionary[idTwo];
                Console.WriteLine("Shortest distance:" + resultDistance);

                Path shortestPath = verticeToPathDictionary[idTwo];
                Console.WriteLine("Shortest path:");
                shortestPath.Print();
            }
            else
            {
                Console.WriteLine("Error: No path was found between teh vertices.");
            }
            

        }

        public void FindAllLoops()
        {
            List<Path> loopsFound = new List<Path>();

            int[] fullSetArray = this.IDs.GetIDs();
            HashSet<int> allVerticesSet = new HashSet<int>(fullSetArray);
            HashSet<int> visitedVerticesSet = new HashSet<int>();
            HashSet<int> unvisitedVerticesSet = new HashSet<int>();

            List<HashSet<int>> exhaustedComponents = new List<HashSet<int>>();
            ComponentStorage componentStorage = new ComponentStorage();
            HashSet<int> verticesWithExhaustedOugoingPaths = new HashSet<int>();
            HashSet<int> currentComponent;
            int currentComponentID = 0;

            HashSet<int> currentStreakSet = new HashSet<int>();

            Stack<Path.PathPoint> searchStack;
            int entryPointID = 0;
            Path.PathPoint entryPoint;


            unvisitedVerticesSet = new HashSet<int>(allVerticesSet);
            unvisitedVerticesSet.ExceptWith(visitedVerticesSet);

            while (unvisitedVerticesSet.Count > 0)
            {
                // Setting a starting point for traversal

                searchStack = new Stack<Path.PathPoint>();
                if (visitedVerticesSet.Count == 0)
                {
                    entryPointID = fullSetArray[0];
                    entryPoint = new Path.PathPoint(entryPointID);

                    searchStack.Push(entryPoint);
                }
                else
                {
                    IEnumerator enumerator = unvisitedVerticesSet.GetEnumerator();
                    enumerator.MoveNext();
                    entryPointID = Convert.ToInt32(enumerator.Current);
                    entryPoint = new Path.PathPoint(entryPointID);
                    searchStack.Push(entryPoint);
                    currentComponentID++;

                    searchStack.Push(entryPoint);
                }
                currentComponent = new HashSet<int>();
                // starting to crawl a component
                while (searchStack.Count > 0)
                {
                    Path.PathPoint currentParent = searchStack.Pop();
                    int currentParentID = currentParent.Location;
                    int currentParentDepth = currentParent.GetDepth();

                    if (!visitedVerticesSet.Contains(currentParentID))
                    {
                        visitedVerticesSet.Add(currentParentID);
                    }
                    if (verticesWithExhaustedOugoingPaths.Contains(currentParentID))
                    {
                        continue;
                    }
                    else if (!currentComponent.Contains(currentParentID))
                    {
                        currentComponent.Add(currentParentID);
                    }


                    if (currentParent.Ancestors.Contains(currentParentID))
                    {
                        Path newLoop = currentParent.RestorePath().TrimLoop();
                        //Next line is questionable
                        if (!loopsFound.Contains(newLoop))
                        {
                            loopsFound.Add(newLoop);
                        }
                        continue;
                    }
                    else
                    {
                        int[] children = GetDescendants(currentParentID);
                        if (children.Length > 0)
                        {
                            currentStreakSet.Add(currentParentID);
                            foreach (int childID in children)
                            {
                                Path.PathPoint childPoint = new Path.PathPoint(childID, currentParent);
                                searchStack.Push(childPoint);
                            }
                        }
                    }


                }
                //end of the component

                //merging components if necessary, updating the visited-unvisited-exhausted sets
                componentStorage.AddComponent(currentComponent);
                verticesWithExhaustedOugoingPaths.UnionWith(currentComponent);
                unvisitedVerticesSet = new HashSet<int>(allVerticesSet);
                unvisitedVerticesSet.ExceptWith(visitedVerticesSet);
            }

            //printing the loops found
            componentStorage.Print();
        }
        public void FindAllComponents()
        {
            int[] fullSetArray = this.IDs.GetIDs();

            HashSet<int> fullVerticeSet = new HashSet<int>(fullSetArray);
            HashSet<int> visitedVertices = new HashSet<int>();
            ComponentStorage components = new ComponentStorage();
            ComponentStorage componentStorage = new ComponentStorage();

            while (fullVerticeSet.Count > visitedVertices.Count)
            {
                HashSet<int> unVisitedVertices = new HashSet<int>(fullVerticeSet);
                unVisitedVertices.ExceptWith(visitedVertices);
                IEnumerator <int> enumerator= unVisitedVertices.GetEnumerator();
                enumerator.MoveNext();

                HashSet<int> currentComponentSet = new HashSet<int>();

                int entryVerticeID = Convert.ToInt32(enumerator.Current);
                Path.PathPoint entryPoint = new Path.PathPoint(entryVerticeID);
                Queue <Path.PathPoint> searchQueue = new Queue<Path.PathPoint>();
                searchQueue.Enqueue(entryPoint);

                currentComponentSet = new HashSet<int>();

                while (searchQueue.Count>0)
                {
                    

                    Path.PathPoint currentParent = searchQueue.Dequeue();
                    int currentParentID = currentParent.GetID();
                    int[] tempChildrenIDs = GetDescendants(currentParentID);
                    int tempChildrenCount = tempChildrenIDs.Length;

                    if (!visitedVertices.Contains(currentParentID))
                    {
                        visitedVertices.Add(currentParentID);
                        currentComponentSet.Add(currentParentID);
                    }
                    else
                    {
                        currentComponentSet.Add(currentParentID);
                        continue;
                    }

                    List<Path.PathPoint> currentParentChildren = new List<Path.PathPoint>();
                    for(int i=0; i<tempChildrenCount; i++)
                    {
                        Path.PathPoint newChild = new Path.PathPoint(tempChildrenIDs[i], currentParent);
                        searchQueue.Enqueue(newChild);
                    }
                }
                componentStorage.AddComponent(currentComponentSet);
            }
            componentStorage.Print();

        }

        public void ArrangeOrderedTaskPairs()
        {
            bool sequenceFound = false;
            List<int> executionSequence = new List<int>();

            while (this.VerticeCount > 0)
            {
                int[] fullVerticeSet = this.IDs.GetIDs();
                List<int> tempExecutableTaskIDs = new List<int>();
                for(int i=0; i<fullVerticeSet.Length; i++)
                {
                    int currentID = fullVerticeSet[i];
                    if (!incomingEdges.ContainsKey(currentID))
                    {
                        tempExecutableTaskIDs.Add(currentID);
                        executionSequence.Add(currentID);
                    }
                }
                if (tempExecutableTaskIDs.Count == 0)
                {
                    StringBuilder sb = new StringBuilder();
                    for(int i=0; i<executionSequence.Count; i++)
                    {
                        sb.Append(executionSequence[i]);
                        if (i < executionSequence.Count - 1)
                        {
                            sb.Append(", ");
                        }
                    }
                    sequenceFound = true;
                    Console.WriteLine(sb);
                    break;

                } 
                for (int i = 0; i < tempExecutableTaskIDs.Count; i++)
                {
                    int currentAncestorID = tempExecutableTaskIDs[i];
                    int[] currentDescendantsArray = GetDescendants(currentAncestorID);
                    for(int j=0; j<currentDescendantsArray.Length; j++)
                    {
                        int currentDescendantID = currentDescendantsArray[j];
                        RemoveEdge(currentAncestorID, currentDescendantID);
                    }
                    RemoveVertice(currentAncestorID);
                }
            }
            if (!sequenceFound)
            {
                Console.WriteLine("Error: No executable path has been found.");
            }
                
        }


        public class Path : IEquatable<Path>
        {
            private List<int> sequence;
            internal double totalWeight;
            internal HashSet<int> visitedPositions;

            public List<int> Sequence { get => sequence; set => sequence = value; }

            public Path()
            {
                this.Sequence = new List<int>();
                this.totalWeight = 0d;
                this.visitedPositions = new HashSet<int>();
            }
            public void Add(int entry)
            {
                this.Sequence.Add(entry);
            }

            //<RequiresTesting>
            public Path TrimLoop()
            {
                Path resultPath = new Path();
                
                List<int> sequenceElements = new List<int>();
                int finalElementID = Sequence.Count - 1;
                int finalElement = Sequence[finalElementID];

                SortedSet<int> sequenceElementsSet = new SortedSet<int>();
                Dictionary<int, int> valuesToIDs = new Dictionary<int, int>();

                int currentElement;
                int startElementID;
                bool startElementIdFound = false;

                //finding the starting element of the loop and compiling the elementsList
                for(int i=finalElementID-1; i>=0; i--)
                {
                    currentElement = Sequence[i];
                    sequenceElements.Add(currentElement);
                    if (currentElement == finalElement)
                    {
                        startElementID = i;
                        startElementIdFound = true;
                        break;
                    }
                    if(i==0 && startElementIdFound == false)
                    {
                        throw new Exception("Error: no loop was found.");
                    }
                }
                sequenceElements.Reverse();

                /* finding the position of the smallest element of the loop, 
                 * to set it as the starting point */

                int minValue = sequenceElements[0];
                int minValueID = 0;
                int tempElement;
                for(int i=0; i<sequenceElements.Count; i++)
                {
                    tempElement = sequenceElements[i];
                    if (tempElement < minValue)
                    {
                        minValue = tempElement;
                        minValueID = i;
                    }
                }

                //building the final loop
                sequenceElements.Add(finalElement);
                for(int i=minValueID; i<sequenceElements.Count; i++)
                {
                    resultPath.Add(sequenceElements[i]);
                }
                for(int i=0; i < minValueID; i++)
                {
                    resultPath.Add(sequenceElements[i]);
                }

                return resultPath;

            }
            public bool Equals(Path otherPath)
            {
                List<int> otherPathSequence = otherPath.Sequence;
                if (this.Sequence.Count != otherPathSequence.Count) return false;
                for(int i=0; i<this.Sequence.Count; i++)
                {
                    if (this.Sequence[i] != otherPath.Sequence[i]) return false;
                }
                return true;
            }
            public void Print()
            {
                StringBuilder sb = new StringBuilder();
                for(int i=0; i<this.Sequence.Count; i++)
                {
                    sb.Append(Sequence[i]);
                    sb.Append(" ");
                }
                Console.WriteLine(sb);
            }

            public class PathPoint
            {
                private int location;
                private PathPoint previousPosition;
                private HashSet<int> ancestors;
                private int depth;
                private double distanceFromStartingPoint;
                public PathPoint(int location, PathPoint previousPosition = null)
                {
                    if (previousPosition == null) this.Depth = 0;
                    else this.Depth = previousPosition.GetDepth() + 1;
                    this.Location = location;
                    this.PreviousPosition = previousPosition;

                    if (previousPosition != null)
                    {
                        this.Ancestors = new HashSet<int>(previousPosition.Ancestors);
                        this.Ancestors.Add(previousPosition.GetID());
                    }
                    else
                    {
                        this.Ancestors = new HashSet<int>();
                    }
                }

                public HashSet<int> Ancestors { get => ancestors; set => ancestors = value; }
                public double DistanceFromStartingPoint { get => distanceFromStartingPoint; set => distanceFromStartingPoint = value; }
                internal int Depth { get => depth; set => depth = value; }
                internal PathPoint PreviousPosition { get => previousPosition; set => previousPosition = value; }
                internal int Location { get => location; set => location = value; }

                public int GetDepth()
                {
                    return this.Depth;
                }
                public int GetID()
                {
                    return this.Location;
                }
                public Path RestorePath()
                {
                    Path resultPath = new Path();
                    List<int> path = new List<int>();
                    PathPoint currentPathPoint = this;
                    while (currentPathPoint != null)
                    {
                        int currentID = currentPathPoint.GetID();
                        path.Add(currentID);
                        currentPathPoint = currentPathPoint.PreviousPosition;
                    }
                    for(int i=path.Count-1; i>=0; i--)
                    {
                        resultPath.Add(path[i]);
                    }
                    //resultPath.Add(this.GetID());
                    return resultPath;
                }
            }
        }
        public class ComponentStorage
        {
            List<HashSet<int>> components = new List<HashSet<int>>();
            public bool ContainsVertice(int verticeID)
            {
                bool resultBool = false;
                for (int i = 0; i < components.Count; i++)
                {
                    if (components[i].Contains(verticeID))
                    {
                        resultBool = true;
                    }
                }
                return resultBool;
            }
            public void AddComponent(HashSet<int> entryComponent)
            {
                if (components.Count > 0)
                {
                    // Find the components of the ComponentStorage that will be merged 
                    SortedSet<int> componentsToMergeWithSet = new SortedSet<int>();

                    IEnumerable<int> componentsToMergeWithReverseSet = componentsToMergeWithSet.Reverse();

                    IEnumerator entryComponentEnumerator = entryComponent.GetEnumerator();
                    while (entryComponentEnumerator.MoveNext())
                    {
                        int currentElement = Convert.ToInt32(entryComponentEnumerator.Current);

                        for (int i = 0; i < components.Count; i++)
                        {
                            if (components[i].Contains(currentElement))
                            {
                                componentsToMergeWithSet.Add(i);
                            }
                        }
                    }
                    IEnumerator<int> componentsToMergeWithSetEnumerator = componentsToMergeWithSet.GetEnumerator();
                    IEnumerator<int> componentsToMergeWithReverseSetEnumerator =
                        componentsToMergeWithReverseSet.GetEnumerator();



                    if (componentsToMergeWithSet.Count > 0)
                    {
                        // Merging components
                        componentsToMergeWithSetEnumerator.MoveNext();
                        int resultMergedComponentID = Convert.ToInt32(componentsToMergeWithSetEnumerator.Current);
                        int componentsToMergeWithReverseSetCount = componentsToMergeWithSet.Count;

                        components[resultMergedComponentID].UnionWith(entryComponent);
                        for (int i = 0; i < componentsToMergeWithReverseSetCount - 1; i++)
                        {
                            componentsToMergeWithReverseSetEnumerator.MoveNext();
                            int currentComponentID = componentsToMergeWithReverseSetEnumerator.Current;
                            HashSet<int> currentComponentToMerge = components[currentComponentID];
                            components[resultMergedComponentID].UnionWith(currentComponentToMerge);

                            // can not be applied to the first(last) element
                            components.RemoveAt(currentComponentID);
                        }
                    }
                    else
                    {
                        components.Add(entryComponent);
                    }
                }
                else
                {
                    components.Add(entryComponent);
                }
            }
            public void Print()
            {
                StringBuilder tempSB = new StringBuilder();
                for (int i=0; i<components.Count; i++)
                {
                    IEnumerator<int> enumerator= components[i].GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        tempSB.Append(enumerator.Current+ " ");
                    }
                    if (i < components.Count - 1)
                    {
                        tempSB.Append("\n");
                    }
                }
                Console.WriteLine(tempSB);
            }
        }

    }
}
