using System;
namespace _11._07_ProjectHierarchyPractice.CreatingAndUsingObjects
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
