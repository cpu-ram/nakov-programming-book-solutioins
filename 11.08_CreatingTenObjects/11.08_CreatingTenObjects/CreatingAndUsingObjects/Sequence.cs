using System;
namespace _11._08_CreatingTenObjects.CreatingAndUsingObjects
{
    public class Sequence
    {

        private static int currenValue = 0;
        public Sequence()
        {
        }
        public int NextValue
        {
            get
            {
                currenValue++;
                return currenValue;
            }

        }

    }

}
