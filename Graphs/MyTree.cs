using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeGraph
{
    class MyTree
    {
        public static void Main()
        {
            Tree t = new Tree();

            //t.root = t.AddToTree(new int[] { 1, 2, 3, 4, 5, 6, 7, 8,9,10,11,12,13,14,15}, 0, 14);
            t.add(32);
            t.add(27);
            t.add(12);
            t.add(11);
            t.add(42);
            t.add(31);
            t.add(52);
            t.add(14);
            //t.Mirror(t.root);
            t.add(36);
            t.add(34);
            t.add(92);
            t.add(44);

            //t.Print();
            t.PrintDiagram(t.root);
            

            Console.WriteLine();
            //t.Print("preorder");
            //Console.WriteLine();
            //t.Print("postorder");
            //Console.WriteLine();
            //t.FindLevelLinkList(t.root);
            //DateTime d1 = DateTime.Now;
            //DateTime d2 = DateTime.Now;
            //TimeSpan ts = d2 - d1;
            //Console.WriteLine("time taken="+ts.Milliseconds+"    d1="+d1.ToString()+"   d2="+d2.ToString());
            //TNode node1 = t.GetNode(t.root, 11);
            //TNode node2 = t.GetNode(t.root, 31);
            //TNode result = t.FindLowestCommonAncestor2(t.root, node1, node2);
            //Console.Write("\nPrintByLevel: ");
            //t.printByLevel();
            Console.WriteLine();
            //t.printByDepth();
            //t.printByLevelZigzag();
            //Console.Write("\nPrinting nodes in max path: ");
            //t.printMaxPath_tree();
            //Console.Write("\nLCA = " + t.FindLowestCommonAncestor(12,52));
            //t.PrintNthLevel(1);
            //Console.WriteLine(t.find(132));
            //Console.WriteLine(t.FindElem(32));
            //Console.WriteLine("\nMax depth = "+t.MaxDepth());
            Console.ReadKey();
        }
  
    }
    
    class Tree
    {
        public TNode root;
        public Tree()
        {
            root = null;
        }
        public  void add(int value)
        {
            if (root == null)
            {
                root = new TNode(null,null,value);
                return;
            }
            TNode n = root;
            bool inserted = false;

            while (!inserted)
            {
                if (value.CompareTo(n.Element) < 0)
                {
                    //space found on the left
                    if (n.Left == null)
                    {
                        n.Left = new TNode( null, null,value);
                        inserted = true;
                    }
                    //keep looking for a place to insert (a null)
                    else
                    {
                        n = n.Left;
                    }
                }
                else if (value.CompareTo(n.Element) > 0)
                {
                    //space found on the right
                    if (n.Right == null)
                    {
                        n.Right = new TNode(null, null,value);
                        inserted = true;
                    }
                    //keep looking for a place to insert (a null)
                    else
                    {
                        n = n.Right;
                    }
                }
            }
        }
        public  bool find(int value)
        {
            return findNode(root,value);
        }
        private  bool findNode(TNode n, int value)
        {
            if (n == null) return false;
            if (n != null && n.Element.Equals(value))
                return true;
            return (value.CompareTo(n.Element) < 0) ? findNode(n.Left, value) : findNode(n.Right, value);
        }
        public TNode GetNode(TNode root, int value)
        {
            if (root == null) return null;
            if (root != null && root.Element.Equals(value))
                return root;
            return (value.CompareTo(root.Element) < 0) ? GetNode(root.Left, value) : GetNode(root.Right, value);
        }
        public bool FindElem(int value)
        {
            if (root == null)
            {
                return false;
            }
            TNode n = root;
            //bool inserted = false;

            while (n!=null)
            {
                if (n.Element == value)
                    return true;
                if (n.Element > value)
                {
                    n = n.Left;
                }
                else
                {
                    n = n.Right;
                }
            }
            return false;
        }
        public  void Print(string order = "inorder")
        {
            if (order == "preorder")
            {
                PrintPreOrder(root);
            }
            else if (order == "postorder")
            {
                PrintPostOrder(root);
            }
            else
            {
                print(root);
            }
        }
        private void print(TNode root)
        {
            if (root != null)
            {
                print(root.Left);
                Console.Write(root.Element + " ");
                print(root.Right);
            }
            
        }
        private void PrintPreOrder(TNode root)
        {
            if (root != null)
            {                
                Console.Write(root.Element + " ");
                PrintPreOrder(root.Left);
                PrintPreOrder(root.Right);
            }

        }

        private void PrintPostOrder(TNode root)
        {
            if (root != null)
            {
                PrintPostOrder(root.Left);
                PrintPostOrder(root.Right);
                Console.Write(root.Element + " ");
            }

        }

        public  void printByLevel()
        {
            if (root == null) return;
            Queue<TNode> q = new Queue<TNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                TNode b = q.Dequeue();
                Console.Write(b.Element + " ");
                if (b.Left != null)
                    q.Enqueue(b.Left);
                if (b.Right != null)
                    q.Enqueue(b.Right);
            }
        }

        public void printByLevelZigzag()
        {
            Stack<TNode> s1 = new Stack<TNode>();
            Stack<TNode> s2 = new Stack<TNode>();
            s1.Push(root);
            printByLevelZigzag(s1, s2, 0);
        }
        
        //first stack for printing from left to right. second stack for printing from right to left.

        private void printByLevelZigzag(Stack<TNode> s1, Stack<TNode> s2, int level)
        {
            while (s1.Count > 0)
            {
                TNode b = s1.Pop();
                Console.Write(b.Element + " ");
                if (level % 2 == 0)
                {
                    if(b.Left != null)
                        s2.Push(b.Left);
                    if (b.Right != null)
                        s2.Push(b.Right);
                }
                else
                {
                    if (b.Right != null)
                        s2.Push(b.Right);
                    if (b.Left != null)
                        s2.Push(b.Left);
                }
            }
            if (s2.Count > 0)
                printByLevelZigzag(s2, s1, level + 1);
        }

        public  void printByDepth()
        {
            if (root == null) return;
            Stack<TNode> stack = new Stack<TNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                TNode b = stack.Pop();
                Console.Write(b.Element+" ");
                if(b.Right!=null)
                    stack.Push(b.Right);
                if (b.Left != null)
                    stack.Push(b.Left);
            }
        }
        public  void PrintNthLevel(int level)
        {
            PrintNthLevel(root,level);
        }
        private void PrintNthLevel(TNode root, int level)
        {
            if (root == null || level < 0) return;
            if (level == 0)
                Console.Write(root.Element + " ");
            if (root.Left != null)
                PrintNthLevel(root.Left, level - 1);
            if (root.Right != null)
                PrintNthLevel(root.Right, level - 1);
        }
        public int FindLowestCommonAncestor(int val1, int val2)
        {
            return FindLowestCommonAncestor(root,val1,val2);
        }
        private int FindLowestCommonAncestor(TNode root, int val1, int val2)
        {
            if (root == null) return -1;
            if (val1 < root.Element && val2 < root.Element)
                return FindLowestCommonAncestor(root.Left, val1, val2);
            else if (val1 > root.Element && val2 > root.Element)
                return FindLowestCommonAncestor(root.Right, val1, val2);
            else
                return root.Element;
        }
        public TNode FindLowestCommonAncestor2(TNode root, TNode node1, TNode node2)
        {
            if (root == null) return null;
            if (node1.Element < root.Element && node2.Element < root.Element)
                return FindLowestCommonAncestor2(root.Left, node1, node2);
            else if (node1.Element > root.Element && node2.Element > root.Element)
                return FindLowestCommonAncestor2(root.Right, node1, node2);
            else
                return root;
        }
        public  int  MaxDepth()
        {
            return MaxDepth(root);
        }
        private int  MaxDepth(TNode root)
        {
            if (root == null)
                return -1;
            else
            {
                if (MaxDepth(root.Left) > MaxDepth(root.Right))
                    return MaxDepth(root.Left) + 1;
                else
                    return MaxDepth(root.Right) + 1;
            }
        }

        #region printMaximumPath
        private int[] MaxPath = new int[0];
        private int temp = 0;
        public void printMaxPath_tree()
        {
            int[] Arr = getMaxLenPath(root);
            for (int i = 0; i < Arr.Length; i++)
                Console.Write(Arr[i] + " ");
            Console.WriteLine();
        }
        public int[] getMaxLenPath(TNode root)
        {
            int[] path = new int[20];
            getAllPaths(root, path, 0);
            return MaxPath;
        }
        public void getAllPaths(TNode root, int[] path, int pathlen)
        {
            if (root == null) return;
            path[pathlen++] = root.Element;
            if (root.Left == null && root.Right == null)
            {
                if (temp < pathlen)
                {
                    MaxPath = new int[pathlen];
                    for (int i = 0; i < pathlen; i++)
                        MaxPath[i] = path[i];
                    temp = pathlen;
                }
            }
            else
            {
                getAllPaths(root.Left, path, pathlen);
                getAllPaths(root.Right, path, pathlen);
            }
        }
        #endregion

        public TNode AddToTree(int[] arr, int start, int end)
        {
            if (end < start)
            {
                return null;
            }
            int mid = (start + end) / 2;
            TNode n = new TNode(null, null, arr[mid]);
            n.Left = AddToTree(arr, start, mid - 1);
            n.Right = AddToTree(arr, mid + 1, end);
            return n;
        }

        public List<LinkedList<TNode>> FindLevelLinkList(TNode root)
        {
            int level = 0;
            List<LinkedList<TNode>> result = new List<LinkedList<TNode>>();
            LinkedList<TNode> list = new LinkedList<TNode>();
            list.AddFirst(root);
            result[level] = list;
            while (true)
            {
                list = new LinkedList<TNode>();
                for (int i = 0; i < result[level].Count(); i++)
                {
                    TNode n = (TNode)result[level].ElementAt(i);
                    if (n != null)
                    {
                        if (n.Left != null) list.AddLast(n.Left);
                        if (n.Right != null) list.AddLast(n.Right);
                    }
                }
                if (list.Count() > 0)
                {
                    result[level + 1] =  list;
                }
                else
                {
                    break;
                }
                level++;
            }
            return result;
        }

        public void Mirror(TNode n)
        {
            if (root == null)
            {
                return;
            }
            if(n.Left!=null)
                Mirror(n.Left);
            if(n.Right!=null)
                Mirror(n.Right);
            TNode temp = n.Left;
            n.Left = n.Right;
            n.Right = temp;
        }

        #region PrintTree diagram
        public void PrintDiagram(TNode root)
        {
            int maxLevel = MaxLevel(root);

            PrintNodeInternal(new List<TNode> { root }, 1, maxLevel);
        }        
        private static void PrintNodeInternal(List<TNode> nodes, int level, int maxLevel)
        {
            if (nodes.Count == 0 || AreAllElementsNull(nodes))
                return;

            int floor = maxLevel - level;
            int endgeLines = (int)Math.Pow(2, (Math.Max(floor - 1, 0)));
            int firstSpaces = (int)Math.Pow(2, (floor)) - 1;
            int betweenSpaces = (int)Math.Pow(2, (floor + 1)) - 1;

            PrintWhitespaces(firstSpaces);

            List<TNode> newNodes = new List<TNode>();
            foreach (TNode node in nodes)
            {
                if (node != null)
                {
                    Console.Write(node.Element);
                    newNodes.Add(node.Left);
                    newNodes.Add(node.Right);
                }
                else
                {
                    newNodes.Add(null);
                    newNodes.Add(null);
                    Console.Write(" ");
                }

                PrintWhitespaces(betweenSpaces);
            }
            Console.WriteLine("");

            for (int i = 1; i <= endgeLines; i++)
            {
                for (int j = 0; j < nodes.Count; j++)
                {
                    PrintWhitespaces(firstSpaces - i);
                    if (nodes.ElementAt(j) == null)
                    {
                        PrintWhitespaces(endgeLines + endgeLines + i + 1);
                        continue;
                    }

                    if (nodes.ElementAt(j).Left != null)
                        Console.Write("/");
                    else
                        PrintWhitespaces(1);

                    PrintWhitespaces(i + i - 1);

                    if (nodes.ElementAt(j).Right != null)
                        Console.Write("\\");
                    else
                        PrintWhitespaces(1);

                    PrintWhitespaces(endgeLines + endgeLines - i);
                }

                Console.WriteLine("");
            }

            PrintNodeInternal(newNodes, level + 1, maxLevel);
        }
        private static void PrintWhitespaces(int count)
        {
            for (int i = 0; i < count; i++)
                Console.Write(" ");
        }
        private static int MaxLevel(TNode node)
        {
            if (node == null)
                return 0;

            return Math.Max(MaxLevel(node.Left), MaxLevel(node.Right)) + 1;
        }
        private static bool AreAllElementsNull(List<TNode> list)
        {
            foreach (TNode item in list)
            {
                if (item != null)
                    return false;
            }

            return true;
        }
        #endregion
    }

    public class TNode
    {
        private TNode left;
        private TNode right;
        private int element;

        public TNode(TNode left, TNode right, int element)
        {
            this.left = left;
            this.right = right;
            this.element = element;
        }

        public TNode Left
        {
            get { return left; }
            set { left = value; }
        }
        public TNode Right
        {
            get { return right; }
            set { right = value; }
        }
        public int Element
        {
            get { return element; }
            set { element = value; }
        }
    }

}
