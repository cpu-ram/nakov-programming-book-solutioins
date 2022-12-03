using System;
using System.Collections;
using System.Collections.Generic;
using Maps;

namespace Graphs
{
    public class Test
    {
        public static void Run()
        {
            GraphTest graphTest = new GraphTest();
            graphTest.FindShortestDistancePath();

        }

        public class MapTest
        {
            public static void Run()
            {
                Map testMap = new Map();
                string[] cities = {"washington","detroit","new york","toronto", "pittsburgh", "columbus",
                 "baltimore", "boston"};
                foreach (string city in cities)
                {
                    testMap.AddCity(city);
                }
                testMap.AddRoad("washington", "new york", 208);
                testMap.AddRoad("detroit", "new york", 481);
                testMap.AddRoad("new york", "toronto", 338);
                testMap.AddRoad("toronto", "pittsburgh", 221);
                testMap.AddRoad("pittsburgh", "columbus", 156);
                testMap.AddRoad("columbus", "detroit", 156);
                testMap.AddRoad("pittsburgh", "baltimore", 195);
                testMap.AddRoad("baltimore", "washington", 52);
                testMap.AddRoad("toronto", "boston", 416);

                testMap.FindShortestPath("toronto", "baltimore");
            }
        }
        public class GraphTest
        {
            Graph graph;
            public GraphTest()
            {
                CreateGraph();
            }

            public void FindAllLoops()
            {
                CreateGraph();
                graph.FindAllLoops();
            }
            public void FindAllComponents()
            {
                CreateGraph();
                graph.FindAllComponents();
            }
            public void FindShortestDistancePath()
            {
                int startID = 0;
                int endID = 6;

                this.graph.FindShortestDistancePath(startID, endID);
            }
            public void TestExecutableSequenceFinder()
            {
                Graph thisGraph = new Graph();
                for(int i=0; i<5; i++)
                {
                    thisGraph.AddVertice();
                }
                thisGraph.AddEdge(0, 2, 1);
                thisGraph.AddEdge(0, 3, 1);
                thisGraph.AddEdge(1, 0, 1);

                thisGraph.ArrangeOrderedTaskPairs();
            }

            internal void CreateGraph()
            {
                this.graph = new Graph();
                for (int i = 0; i < 14; i++)
                {
                    graph.AddVertice();
                }
                graph.AddEdge(0, 1, 1d);
                graph.AddEdge(0, 5, 3d);
                graph.AddEdge(1, 2, 40d);
                graph.AddEdge(2, 6, 40d);
                graph.AddEdge(6, 1, 1d);
                graph.AddEdge(2, 3, 1d);
                graph.AddEdge(2, 4, 1d);
                graph.AddEdge(2, 5, 1d);
                graph.AddEdge(3, 4, 1d);
                graph.AddEdge(4, 2, 1d);
                graph.AddEdge(4, 8, 3d);
                graph.AddEdge(5, 4, 1d);
                graph.AddEdge(5, 3, 1d);
                graph.AddEdge(7, 8, 1d);
                graph.AddEdge(7, 6, 3d);
                graph.AddEdge(8, 9, 1d);
                graph.AddEdge(9, 7, 1d);
                graph.AddEdge(10, 11, 1d);
                graph.AddEdge(11, 7, 1d);
                graph.AddEdge(12, 13, 1d);
                graph.AddEdge(13, 12, 1d);
                graph.AddEdge(6, 12, 1d);
            }

        }
        
        public class ComponentStorageTest
        {
            public void Run()
            {
                Graph.ComponentStorage componentStorage = new Graph.ComponentStorage();
                HashSet<int>[] setArray = new HashSet<int>[5];

                int[] arrayOne = { 0, 1, 2 };
                int[] arrayTwo = { 3, 4 };
                int[] arrayThree = { 5, 6 };
                int[] arrayFour = { 0, 7 };
                int[] arrayFive = { 8, 2 };

                setArray[0] = new HashSet<int>(arrayOne);
                setArray[1] = new HashSet<int>(arrayTwo);
                setArray[2] = new HashSet<int>(arrayThree);
                setArray[3] = new HashSet<int>(arrayFour);
                setArray[4] = new HashSet<int>(arrayFive);

                for(int i=0; i<setArray.Length; i++)
                {
                    componentStorage.AddComponent(setArray[i]);
                }
                componentStorage.Print();
            }
        }
        public static class SortedSetTest
        {
            public static void Run()
            {
                SortedSet <int> sortedSet= new SortedSet<int>();
                for(int i=0; i<5; i++)
                {
                    sortedSet.Add(i);
                }
                IEnumerator<int> enumerator = sortedSet.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    Console.WriteLine(enumerator.Current);
                }
            }
        }
        

        
    }
}
