using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Geometry
{
    public class Plane
    {
        private HashSet<Point> points;

        public Plane()
        {
            this.Points = new HashSet<Point>();
        }

        public HashSet<Point> Points { get => points; set => points = value; }

        public void AddPoint(params Point[] points)
        {
            foreach(Point point in points)
            {
                if (!this.Contains(point))
                {
                    this.Points.Add(point);
                }
            }
        }
        public void RemovePoint(params Point[] points)
        {
            foreach(Point point in points)
            {
                if (this.Points.Contains(point))
                {
                    this.Points.Remove(point);
                }
            }
        }
        public bool Contains(Point point)
        {
            if (this.Points.Contains(point))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Tuple<int?,int?> FindMedianAxes()
        {
            int totalCount = Points.Count;
            bool countIsOdd = (totalCount % 2 == 1);

            int? xMedianAxis = null;
            int? yMedianAxis = null;

            int centerPointer;

            var sortedByX =
                from point in Points
                orderby point.X
                select point.X;
            var sortedByY =
                from point in Points
                orderby point.Y
                select point.Y;
            
            int[] xSortedArray = new int[totalCount];
            int[] ySortedArray = new int[totalCount];

            int xPointer = 0;
            foreach(var point in sortedByX)
            {
                xSortedArray[xPointer] = (int)point;
                xPointer++;
            }
            int yPointer = 0;
            foreach (var point in sortedByY)
            {
                ySortedArray[yPointer] = (int)point;
                yPointer++;
            }

            if (countIsOdd)
            {
                centerPointer = (totalCount / 2);
                Tuple<int, int> xCenterItemBoundaries = FindSiblingBoundaries
                    (xSortedArray, centerPointer);
                Tuple<int, int> yCenterItemBoundaries = FindSiblingBoundaries
                    (ySortedArray, centerPointer);

                bool xMedianExists = IsMedianItem(xCenterItemBoundaries, totalCount);
                bool yMedianExists = IsMedianItem(yCenterItemBoundaries, totalCount);
                if (xMedianExists) xMedianAxis = centerPointer;
                if (yMedianExists) yMedianAxis = centerPointer;
            }
            else
            {
                bool xMedianExists = true;
                bool yMedianExists = true;
                Tuple<int, int> xCenterItemBoundaries;
                Tuple<int, int> yCenterItemBoundaries;

                int centerLeftPosition = (totalCount / 2)-1;
                int centerRightPosition = centerLeftPosition + 1;

                if (xSortedArray[centerLeftPosition]
                    != xSortedArray[centerRightPosition])
                {
                     xMedianExists= false;
                     xMedianAxis = null;
                }
                else
                {
                    xMedianExists = true;
                }
                if (ySortedArray[centerLeftPosition]
                    != ySortedArray[centerRightPosition])
                {
                    yMedianExists = false;
                    yMedianAxis = null;
                }
                else
                {
                    yMedianExists = true;
                }

                if (xMedianExists)
                {
                    xCenterItemBoundaries = FindSiblingBoundaries
                        (xSortedArray, centerLeftPosition);
                    if (IsMedianItem(xCenterItemBoundaries, totalCount))
                    {
                        xMedianAxis = xSortedArray[centerLeftPosition];
                    }
                    
                }
                if (yMedianExists)
                {
                    yCenterItemBoundaries = FindSiblingBoundaries
                        (ySortedArray, centerLeftPosition);
                    if (IsMedianItem(yCenterItemBoundaries, totalCount))
                    {
                        yMedianAxis = centerLeftPosition;
                    }

                }
            }
            Tuple<int?, int?> resultTuple =
                    new Tuple<int?, int?>(xMedianAxis, yMedianAxis);
            return resultTuple;


            Tuple<int,int> FindSiblingBoundaries(int[] sequence, int id)
            {
                int referenceValue = sequence[id];

                int lowerBoundary = id;
                int upperBoundary = id;

                if(id<0 || id >= sequence.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }
                for(int i=id; i>=0; i--)
                {
                    if (sequence[id] == referenceValue)
                    {
                        lowerBoundary = id;
                    }
                    if (sequence[id] != referenceValue)
                    {
                        break;
                    }
                }
                for(int i=0; i<sequence.Length; i++)
                {
                    if (sequence[id] == referenceValue)
                    {
                        upperBoundary = id;
                    }
                    else
                    {
                        break;
                    }
                }

                Tuple<int, int> resultTuple =
                    new Tuple<int, int>(lowerBoundary, upperBoundary);
                return resultTuple;
            }
            bool IsMedianItem (Tuple<int,int> itemBoundaries, int totalCount)
            {
                int lowerBoundary = itemBoundaries.Item1;
                int higherBoundary = itemBoundaries.Item2;

                int countBelowLowerBoundary = lowerBoundary;
                int countAboveHigherBoundary = (totalCount - 1) - higherBoundary;

                if (countBelowLowerBoundary == countAboveHigherBoundary)
                {
                    return true;
                }
                else return false;
            }
        }
        
    }
}
