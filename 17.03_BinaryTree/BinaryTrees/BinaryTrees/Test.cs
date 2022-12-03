using System;
namespace BinaryTrees
{
    public static class Test
    {
        public static void Run()
        {
            TestBinaryTree();
        }

        public static void TestBinaryTree()
        {
            int[] numbers = { 5, 2, 7, 4, 1, 3, 6, 0, -1, -2, -3};
            BinaryTree<int> testTree = new BinaryTree<int>();
            for(int i=0; i<numbers.Length; i++)
            {
                int currentValue = numbers[i];
                testTree.Add(currentValue);
            }
            testTree.Print();
            testTree.FindValuesByLevel();
        }
    }
}
