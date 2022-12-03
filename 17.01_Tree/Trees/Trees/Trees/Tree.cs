using System;
using System.Collections.Generic;
using System.Text;

namespace Trees
{
    public class Tree<T>
    {
        internal TreeNode root;
        public Tree(TreeNode root, List<TreeNode> children)
        {
            this.root = root;
            if (children == null)
            {
                this.root.Children = new List<TreeNode>();
            }
            else
            {
                this.root.Children = children;
            }
            this.root.HasParent = false;
        }
        public class NodeAndDepth
        {
            internal Tuple<TreeNode, int> value;
            internal Tuple<TreeNode, int> Value { get => value; set => this.value = value; }
            public NodeAndDepth(TreeNode entryNode, int entryInt)
            {
                Tuple<TreeNode, int> newTuple = new Tuple<TreeNode, int>(entryNode, entryInt);
                this.Value = newTuple;
            }
            public TreeNode Node
            {
                get
                {
                    return this.Value.Item1;
                }
            }
            public int Depth
            {
                get
                {
                    return this.Value.Item2;
                }
            }
            public void Print()
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i <= this.Depth; i++)
                {
                    sb.Append('-');
                }
                sb.Append(this.Node.ToString());
                Console.WriteLine(sb);
            }
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder("\n");
                for (int i = 0; i <= this.Depth; i++)
                {
                    sb.Append('-');
                }
                sb.Append(this.Node.ToString());
                string resultString = Convert.ToString(sb);
                return resultString;
            }
        }
        public class TreeNode
        {
            internal T value;
            private List<TreeNode> children = new List<TreeNode>();
            private bool hasParent;
            public TreeNode(T value, List<TreeNode> children = null)
            {
                this.value = value;
                if (children == null)
                {
                    this.Children = new List<TreeNode>();
                }
                else
                {
                    this.Children = children;
                }

            }
            public T Value { get => value; set => this.value = value; }
            public int ChildrenCount
            {
                get
                {
                    return this.Children.Count;
                }
            }
            public TreeNode GetChild(int i)
            {
                return this.Children[i];
            }
            public bool HasParent { get => hasParent; set => hasParent = value; }
            internal List<TreeNode> Children { get => children; set => children = value; }
            public void Print()
            {
                Console.WriteLine(Convert.ToString(this.value));
            }
            public void AddChildren(TreeNode childNode)
            {
                childNode.HasParent = true;
                this.Children.Add(childNode);
            }
            public void AddChildren(List<TreeNode> childNodes)
            {
                for (int i = 0; i < childNodes.Count; i++)
                {
                    this.AddChildren(childNodes[i]);
                }
            }
            public override string ToString()
            {
                return this.Value.ToString();
            }
        }

        public TreeNode GetRoot
        {
            get
            {
                return this.root;
            }
        }

        public void TraverseBFS()
        {
            Queue<Tuple<TreeNode, int>> nodeQueue = new Queue<Tuple<TreeNode, int>>();
            TreeNode firstNode = this.GetRoot;
            nodeQueue.Enqueue(new Tuple<TreeNode, int>(firstNode, 0));
            while (nodeQueue.Count < 100 && nodeQueue.Count > 0)
            {
                Tuple<TreeNode, int> tempTuple = nodeQueue.Dequeue();
                TreeNode tempBaseNode = tempTuple.Item1;
                int tempBaseNodeDepth = tempTuple.Item2;
                int tempChildCount = tempBaseNode.ChildrenCount;
                for (int i = 0; i < tempChildCount; i++)
                {
                    nodeQueue.Enqueue(new Tuple<TreeNode, int>(tempBaseNode.GetChild(i),
                        tempBaseNodeDepth + 1));
                }

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i <= tempBaseNodeDepth; i++)
                {
                    sb.Append('-');
                }
                sb.Append(tempBaseNode.ToString());
                Console.WriteLine(sb);
            }
        }
        public void TraverseDFS()
        {
            StringBuilder resultSB = new StringBuilder();
            TreeNode tempBaseNode = this.GetRoot;
            NodeAndDepth tempBaseNodeAndDepth = new NodeAndDepth(tempBaseNode, 0);
            Stack<NodeAndDepth> nodeAndDepthStack = new Stack<NodeAndDepth>();
            nodeAndDepthStack.Push(tempBaseNodeAndDepth);

            while (nodeAndDepthStack.Count > 0 && nodeAndDepthStack.Count < 100)
            {
                NodeAndDepth tempNodeAndDepth = nodeAndDepthStack.Pop();
                tempBaseNode = tempNodeAndDepth.Node;
                resultSB.Append(tempNodeAndDepth.ToString());
                int tempBaseDepth = tempNodeAndDepth.Depth;
                List<TreeNode> tempChildrenList = new List<TreeNode>();
                for (int i = tempBaseNode.ChildrenCount - 1; i >= 0; i--)
                {
                    TreeNode tempNode = tempBaseNode.GetChild(i);
                    NodeAndDepth childNodeAndDepth = new NodeAndDepth(tempNode, tempBaseDepth + 1);
                    nodeAndDepthStack.Push(childNodeAndDepth);
                }
            }
            Console.WriteLine(resultSB);
        }
        public int FindNumberOfInstances(T query)
        {
            TreeNode tempBaseNode = this.GetRoot;
            Stack<TreeNode> nodeStack = new Stack<TreeNode>();
            nodeStack.Push(tempBaseNode);
            int instancesFound = 0;

            while (nodeStack.Count > 0 && nodeStack.Count < 100)
            {
                tempBaseNode = nodeStack.Pop();
                int tempChildrenCount = tempBaseNode.ChildrenCount;
                List<TreeNode> tempChildrenList = new List<TreeNode>();
                for (int i = tempChildrenCount-1; i >= 0; i--)
                {
                    TreeNode tempNode = tempBaseNode.GetChild(i);
                    T tempValue = tempNode.Value;
                    if (query.Equals(tempValue))
                    {
                        instancesFound++;
                    }
                    nodeStack.Push(tempNode);
                }
            }
            Console.WriteLine("Instances found: " + instancesFound);
            return instancesFound;
        }
        public void FindNumberOfLeavesAndInternalVertices()
        {
            TreeNode tempBaseNode = this.GetRoot;
            Stack<TreeNode> nodeStack = new Stack<TreeNode>();
            nodeStack.Push(tempBaseNode);
            int leavesFound = 0;
            int internalVerticesFound = 0;

            while (nodeStack.Count > 0 && nodeStack.Count < 100)
            {
                tempBaseNode = nodeStack.Pop();

                int tempChildrenCount = tempBaseNode.ChildrenCount;
                if (tempChildrenCount == 0)
                {
                    leavesFound++;
                }
                else
                {
                    if (!ReferenceEquals(tempBaseNode, this.GetRoot))
                    {
                        internalVerticesFound++;
                    }
                }

                for (int i = tempChildrenCount - 1; i >= 0; i--)
                {
                    TreeNode tempNode = tempBaseNode.GetChild(i);
                    T tempValue = tempNode.Value;
                    nodeStack.Push(tempNode);
                }
            }
            Console.WriteLine("Leaves found:{0},\nInternal vertices found:{1}",
                leavesFound, internalVerticesFound);
        }
        public void FindDepthLevelTotalSums()
        {
            Type currentNodeValueType;
            string invalidArgumentMessage = "Can not calculate the sum of the tree level" +
                "because the value of one of the cells is in an incorrect format.";
            Exception invalidArgumentException = new ArgumentException(invalidArgumentMessage);

            Dictionary<int, double> levelsAndElementCounts = new Dictionary<int, double>();

            Queue<NodeAndDepth> nodeQueue = new Queue<NodeAndDepth>();
            TreeNode firstNode = this.GetRoot;
            nodeQueue.Enqueue(new NodeAndDepth(firstNode, 0));
            while (nodeQueue.Count < 100 && nodeQueue.Count > 0)
            {
                NodeAndDepth tempNodeAndDepth = nodeQueue.Dequeue();
                T currentNodeValue = tempNodeAndDepth.Node.Value;

                currentNodeValueType = currentNodeValue.GetType();
                //checking if the value of the cell being processed is of numeric type

                double currentValueAsDouble = Convert.ToDouble(currentNodeValue);

                TreeNode tempBaseNode = tempNodeAndDepth.Node;
                int tempBaseNodeDepth = tempNodeAndDepth.Depth;

                //int shiftedDepth = tempBaseNodeDepth + 1;
                if (levelsAndElementCounts.ContainsKey(tempBaseNodeDepth))
                {
                    levelsAndElementCounts[tempBaseNodeDepth] += currentValueAsDouble;
                }
                else
                {
                    levelsAndElementCounts.Add(tempBaseNodeDepth, currentValueAsDouble);
                }

                int tempChildCount = tempBaseNode.ChildrenCount;
                for (int i = 0; i < tempChildCount; i++)
                {
                    nodeQueue.Enqueue(new NodeAndDepth(tempBaseNode.GetChild(i),
                        tempBaseNodeDepth + 1));
                }
            }

            StringBuilder linesAndNumbersText = new StringBuilder();
            for (int i = 0; i < levelsAndElementCounts.Count; i++)
            {
                linesAndNumbersText.Append($"Line {i}: ");
                linesAndNumbersText.Append(levelsAndElementCounts[i]);
                linesAndNumbersText.Append('\n');
            }
            Console.WriteLine(linesAndNumbersText);
        }
        public void FindAllTheSecondFromLastLevelNodes()
        {
            Console.WriteLine();
            List<string> nodesFound = new List<string>();

            StringBuilder resultSB = new StringBuilder();
            TreeNode tempParentNode = this.GetRoot;
            NodeAndDepth tempBaseNodeAndDepth = new NodeAndDepth(tempParentNode, 0);
            Stack<NodeAndDepth> nodeAndDepthStack = new Stack<NodeAndDepth>();
            nodeAndDepthStack.Push(tempBaseNodeAndDepth);
            
            while (nodeAndDepthStack.Count > 0)
            {
                NodeAndDepth tempNodeAndDepth = nodeAndDepthStack.Pop();
                tempParentNode = tempNodeAndDepth.Node;
                //resultSB.Append(tempNodeAndDepth.ToString());
                int tempParentDepth = tempNodeAndDepth.Depth;
                List<TreeNode> tempChildrenList = new List<TreeNode>();
                int tempChildrenCount = tempParentNode.ChildrenCount;

                bool currentParentNodeHasOnlyLeavesForKids;
                if (tempChildrenCount > 0)
                {
                    currentParentNodeHasOnlyLeavesForKids = true;
                }
                else currentParentNodeHasOnlyLeavesForKids = false;

                for (int i = tempChildrenCount - 1; i >= 0; i--)
                {
                    TreeNode currentChildNode = tempParentNode.GetChild(i);
                    int childrenCountOfCurrentChild = currentChildNode.ChildrenCount;
                    if (childrenCountOfCurrentChild > 0) currentParentNodeHasOnlyLeavesForKids=false;
                    NodeAndDepth childNodeAndDepth = new NodeAndDepth(currentChildNode, tempParentDepth + 1);
                    nodeAndDepthStack.Push(childNodeAndDepth);
                }
                if (currentParentNodeHasOnlyLeavesForKids)
                {
                    string tempParentNodeStringValue = tempParentNode.ToString();
                    nodesFound.Add(tempParentNodeStringValue);
                }
            }

            for(int i=0; i<nodesFound.Count; i++)
            {
                Console.WriteLine(nodesFound[i]);
            }
        }

    }
}