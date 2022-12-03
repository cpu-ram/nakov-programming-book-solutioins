using System;
namespace Geometry
{
    public static class Test
    {
        public static void Run()
        {
            TestMedianLineFinder();
        }
        public static void TestMedianLineFinder()
        {
            Plane plane = new Plane();
            for(int i=0; i<7; i++)
            {
                Point newPoint = new Point(i, i);
                plane.AddPoint(newPoint);
            }
            Tuple<int?, int?> medianAxes = plane.FindMedianAxes();
            Console.WriteLine(medianAxes);
        }
    }
}
