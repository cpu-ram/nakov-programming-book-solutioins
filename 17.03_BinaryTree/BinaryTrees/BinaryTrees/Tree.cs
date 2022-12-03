using System;
using System.Text;
using System.Collections.Generic;
namespace BinaryTrees
{
    public class BinaryTree<T> where T : IComparable
    {
        private TreeNode rootNode;

        public BinaryTree()
        {
            this.Root = null;
        }

        internal TreeNode Root { get => rootNode; set => rootNode = value; }

        public void Add(T entry) 
        {
            TreeNode entryNode;
            if (this.Root == null)
            {
                entryNode = new TreeNode(entry);
                this.Root = entryNode;
                return;
            }
            else
            {
                bool entryInserted = false;
                TreeNode currentElement = this.Root;
                while (entryInserted == false)
                {
                    T currentElementValue = currentElement.Value;
                    if (currentElementValue.Equals(entry))
                    {
                        entryInserted = true;
                        return;
                    }
                    else
                    {
                        if (entry.CompareTo(currentElementValue) > 0)
                        {
                            if (currentElement.RightChild == null)
                            {
                                TreeNode resultNode = new TreeNode(entry, currentElement);
                                currentElement.RightChild = resultNode;
                            }
                            else
                            {
                                currentElement = currentElement.RightChild;
                                continue;
                            }
                        }
                        if (entry.CompareTo(currentElementValue) < 0)
                        {
                            if (currentElement.LeftChild == null)
                            {
                                TreeNode resultNode = new TreeNode(entry, currentElement);
                                currentElement.LeftChild = resultNode;
                            }
                            else
                            {
                                currentElement = currentElement.LeftChild;
                                continue;
                            }
                        }
                    }

                }
            }
        }
        public List<List<T>> FindValuesByLevel()
        {
            List<List<T>> resultList = new List<List<T>>();

            TreeNode startLocation = this.Root;
            Queue <Tuple<TreeNode, int>> searchQueue= new Queue<Tuple<TreeNode, int>>();
            Tuple<TreeNode, int> entryTuple = new Tuple<TreeNode, int>(startLocation, 0);
            searchQueue.Enqueue(entryTuple);

            while (searchQueue.Count > 0)
            {
                Tuple<TreeNode, int> currentTuple = searchQueue.Dequeue();
                TreeNode currentNode = currentTuple.Item1;
                int currentDepth = currentTuple.Item2;
                T currentNodeValue = currentNode.Value;

                if (resultList.Count == currentDepth)
                {
                    List<T> currentLevel = new List<T>();
                    resultList.Add(currentLevel);
                }
                resultList[currentDepth].Add(currentNodeValue);

                TreeNode leftChild = currentNode.LeftChild;
                TreeNode rightChild = currentNode.RightChild;
                if (leftChild != null)
                {
                    Tuple<TreeNode, int> leftChildNode = new Tuple<TreeNode, int>
                        (leftChild, currentDepth + 1);
                    searchQueue.Enqueue(leftChildNode);
                }
                if (rightChild != null)
                {
                    Tuple<TreeNode, int> rightChildNode = new Tuple<TreeNode, int>
                        (rightChild, currentDepth + 1);
                    searchQueue.Enqueue(rightChildNode);
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int i=0; i<resultList.Count; i++)
            {
                for(int j=0; j<resultList[i].Count; j++)
                {
                    sb.Append(resultList[i][j]+" ");
                }
                sb.Append("\n");
            }
            Console.WriteLine(sb);
            return resultList;
        }
        public void FindParentsOfLeaves()
        {
            List<TreeNode> leaves = new List<TreeNode>();
            HashSet<TreeNode> resultSet = new HashSet<TreeNode>();
            List<int> resultList = new List<int>();

            TreeNode entryNode = this.Root;
            Queue<TreeNode> searchQueue = new Queue<TreeNode>();
            searchQueue.Enqueue(entryNode);

            while (searchQueue.Count > 0)
            {
                TreeNode currentNode = searchQueue.Dequeue();
                TreeNode leftChild = currentNode.LeftChild;
                TreeNode rightChild = currentNode.RightChild;
                if (leftChild != null)
                {
                    searchQueue.Enqueue(leftChild);
                }
                if (rightChild != null)
                {
                    searchQueue.Enqueue(rightChild);
                }
                if(leftChild==null && rightChild == null)
                {
                    leaves.Add(currentNode);
                }
            }
            for(int i=0; i<leaves.Count; i++)
            {
                TreeNode currentNode = leaves[i];
                TreeNode parentOfCurrentNode = currentNode.Parent;
                if (!resultSet.Contains(parentOfCurrentNode))
                {
                    resultSet.Add(parentOfCurrentNode);
                }
            }
            IEnumerator<TreeNode> enumerator = resultSet.GetEnumerator();
            StringBuilder sb = new StringBuilder();
            while (enumerator.MoveNext())
            {
                string currentValueAsString = Convert.ToString(enumerator.Current.Value);
                sb.Append(currentValueAsString);
            }
            Console.WriteLine(sb);
        }
        public bool IsPerfectlyBalanced()
        {
            TreeNode rootNode = this.Root;
            if (rootNode == null)
            {
                throw new ArgumentNullException();
            }
            bool resultBool = CheckIfPerfectlyBalanced(rootNode);

            static bool CheckIfPerfectlyBalanced(TreeNode entryNode)
            {
                bool leftChildIsBalanced = false;
                bool rightChildIsBalanced=false;

                TreeNode leftChild = entryNode.LeftChild;
                TreeNode rightChild = entryNode.RightChild;
                if(entryNode.LeftChild!=null && entryNode.RightChild != null)
                {
                    leftChildIsBalanced = CheckIfPerfectlyBalanced(leftChild);
                    rightChildIsBalanced = CheckIfPerfectlyBalanced(rightChild);
                }
                if(leftChild==null && rightChild == null)
                {
                    return true;
                }
                if(leftChild==null ^ rightChild == null)
                {
                    if (leftChild == null)
                    {
                        if (rightChild.LeftChild != null || rightChild.RightChild != null)
                        {
                            return false;
                        }
                        else return true;
                    }
                    if (rightChild == null)
                    {
                        if (leftChild.LeftChild != null || leftChild.RightChild != null)
                        {
                            return false;
                        }
                        else return true;
                    }
                }

                if(leftChildIsBalanced && rightChildIsBalanced)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            return resultBool;
        }
        public void Print()
        {
            if (this.rootNode == null) throw new Exception();

            Stack<Tuple<TreeNode, int>> searchStack = new Stack<Tuple<TreeNode, int>>();
            TreeNode entryNode = this.rootNode;
            Tuple<TreeNode,int> entryTuple=new Tuple<TreeNode, int>(entryNode,0);
            searchStack.Push(entryTuple);

            StringBuilder sb = new StringBuilder();

            while (searchStack.Count > 0)
            {
                Tuple<TreeNode, int> currentTuple = searchStack.Pop();
                TreeNode currentNode = currentTuple.Item1;
                int currentDepth = currentTuple.Item2;
                if (currentNode.RightChild != null)
                {
                    Tuple<TreeNode, int> newTuple = new Tuple<TreeNode, int>(currentNode.RightChild, currentDepth + 1);
                    searchStack.Push(newTuple);
                }
                if (currentNode.LeftChild != null)
                {
                    Tuple<TreeNode, int> newTuple = new Tuple<TreeNode, int>(currentNode.LeftChild, currentDepth + 1);
                    searchStack.Push(newTuple);
                }
                

                for(int i=0; i<currentDepth; i++)
                {
                    sb.Append("-");
                }
                sb.Append("[" + currentNode.Value + "]");
                sb.Append("\n");
            }
            Console.WriteLine(sb);
        }

        public class TreeNode
        {
            private TreeNode parentNode;

            internal T value;
            private TreeNode leftChild;
            private TreeNode rightChild;

            public TreeNode(T entry, TreeNode parentNode = null)
            {
                this.value = entry;
                this.Parent = parentNode;
                this.LeftChild = null;
                this.RightChild = null;
            }

            public T Value { get => value; set => this.value = value; }
            public TreeNode LeftChild { get => leftChild; set => leftChild = value; }
            public TreeNode RightChild { get => rightChild; set => rightChild = value; }
            internal TreeNode Parent { get => parentNode; set => parentNode = value; }
        }
    }
}
