using System;
using FileTools;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Trees
{
    class Program
    {
        static List<Tree<int>> forest = new List<Tree<int>>();
        public List<Tree<int>> Forest { get => forest; set => forest = value; }

        public static Tree<int> CreateTree()
        {
            Tree<int>.TreeNode[] treeNodes = new Tree<int>.TreeNode[10];
            for (int i = 0; i < 10; i++)
            {
                treeNodes[i] = new Tree<int>.TreeNode(i + 1);
            }
            const int rootInt = 0;
            Tree<int>.TreeNode firstNode = new Tree<int>.TreeNode(rootInt);
            Tree<int> newTree = new Tree<int>(firstNode, null);
            for (int i = 0; i < 10; i++)
            {
                newTree.GetRoot.AddChildren(treeNodes[i]);
            }

            for (int i = 0; i < firstNode.ChildrenCount; i++)
            {
                Tree<int>.TreeNode currentNode = firstNode.GetChild(i);
                int tempValue = firstNode.GetChild(i).Value;
                for (int j = 0; j < 2; j++)
                {
                    double newDoubleValue = tempValue * 2 * (Math.Pow(2d, Convert.ToDouble(j)));
                    int newIntValue = Convert.ToInt32(newDoubleValue);
                    Tree<int>.TreeNode tempNode = new Tree<int>.TreeNode(newIntValue);
                    currentNode.AddChildren(tempNode);
                }
            }
            return newTree;

        }

        static void Test()
        {
            Tree<int> firstTree = CreateTree();
            forest.Add(firstTree);
            forest[0].TraverseDFS();

        }
        static void Main(string[] args)
        {
            Console.WriteLine("\n>>>");
            Test();
            Console.WriteLine("\n<<<.");
        } 
    }
}
