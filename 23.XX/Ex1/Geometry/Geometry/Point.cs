using System;
namespace Geometry
{
    public class Point
    {
        private int x;
        private int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public bool Equals(Point anotherPoint)
        {
            if(X==anotherPoint.X && Y == anotherPoint.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            int hashCode = ((X.GetHashCode()) + Y).GetHashCode();
            return hashCode;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
    }
}
