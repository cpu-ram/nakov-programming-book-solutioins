using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Graphs;

namespace Maps
{
    public class Map
    {
        internal Graph contents;
        internal HashSet<string> citiesSet;
        internal Dictionary<string, int> cityIDs;
        internal Dictionary<int, string> idNames;

        public Map()
        {
            this.contents = new Graph();
            this.citiesSet = new HashSet<string>();
            this.cityIDs = new Dictionary<string, int>();
            this.idNames = new Dictionary<int, string>();
        }

        public void AddCity(string entryName)
        {
            string name = entryName.ToLower();
            if (citiesSet.Contains(name))
            {
                throw new ArgumentException();
            }
            else
            {
                int newCityID = contents.AddVertice();
                cityIDs[name] = newCityID;
                idNames[newCityID] = name;
                citiesSet.Add(name);
            }
        }
        public void AddRoad(string cityOne, string cityTwo, int length)
        {
            if (!citiesSet.Contains(cityOne) || !citiesSet.Contains(cityTwo))
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                double rationalLength = Convert.ToDouble(length);
                int idOne = cityIDs[cityOne];
                int idTwo = cityIDs[cityTwo];
                contents.AddEdge(idOne, idTwo, rationalLength);
                contents.AddEdge(idTwo, idOne, rationalLength);
            }
        }
        public void FindShortestPath(string cityOne, string cityTwo)
        {
            if (!citiesSet.Contains(cityOne) || !citiesSet.Contains(cityTwo))
            {
                throw new ArgumentOutOfRangeException();
            }
            StringBuilder sb = new StringBuilder();
            Graph.Path graphPath = contents.FindPathWithLeastSteps(cityIDs[cityOne], cityIDs[cityTwo]);
            if (graphPath == null)
            {
                Console.WriteLine($"No path was found between {cityOne} and {cityTwo}.");
            }

            else
            {
                List<int> graphPathSequence = graphPath.Sequence;
                for (int i = 0; i < graphPathSequence.Count; i++)
                {
                    int currentCityID = graphPathSequence[i];
                    string currentCityName=idNames[currentCityID];
                    if (i > 0) sb.Append(", ");
                    sb.Append(currentCityName);
                }
                Console.WriteLine(sb);
            }
        }

        public class City
        {
            private string name;
            public City(string name)
            {
                this.Name = name;
            }
            public override int GetHashCode()
            {
                return this.Name.GetHashCode();
            }

            internal string Name { get => name; set => name = value; }
        }
        public class Path
        {
            private Graph.Path contents;

            public Path(Graph.Path graphPath)
            {
                this.contents = graphPath;
            }
        }
    }
}
