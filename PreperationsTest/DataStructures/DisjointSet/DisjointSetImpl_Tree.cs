/*
 * Implementation using Tree data structure
 * Time Complexity
 *      Find Operation: O(α(n)) amortized time complexity.
 *      Union Operation: O(α(n)) time complexity.
 * Space Complexity: O(n) for both parent and rank arrays, and used a dictionary
 */

namespace PreperationsTest.DataStructures.DisjointSet
{
    [TestClass]
    public class DisjointSetImpl_Tree
    {
        public class Node
        {
            public int Data { get; set; }
            public Node Parent;
            public int Rank;

            public Node(int data)
            {
                Data = data;
                Parent = this;
                Rank = 0;
            }
        }

        public class DisjointSetTree
        {
            public Dictionary<int, Node> nodeDict = new Dictionary<int, Node>();

            /// <summary>
            /// Prepares the node tree and maintains the copy of number and its node in a dict
            /// </summary>
            /// <param name="n"></param>
            public void MakeSet(int n)
            {
                Node newNode = new Node(n);
                nodeDict[n] = newNode;
            }

            /// <summary>
            /// Finds the data
            /// </summary>
            /// <param name="n"></param>
            /// <returns></returns>
            public int Find(int n)
            {
                return Find(nodeDict[n]).Data; // return node.data
            }

            /// <summary>
            /// Recursive method to get the parent of itself
            /// </summary>
            /// <param name="node"></param>
            /// <returns></returns>
            private Node Find(Node node)
            {
                if (node.Parent != node)
                {
                    node.Parent = Find(node.Parent); // path compression
                }
                return node.Parent;
            }

            public void Union(int x, int y)
            {
                Node xNode_Parent = Find(nodeDict[x]);
                Node yNode_Parent = Find(nodeDict[y]);


                if (xNode_Parent == yNode_Parent)
                {
                    return;
                }

                // >= condition
                if (xNode_Parent.Rank >= yNode_Parent.Rank)
                {
                    yNode_Parent.Parent = xNode_Parent;

                    if (xNode_Parent.Rank == yNode_Parent.Rank)
                    {
                        yNode_Parent.Rank++;
                    }
                }
                else // < condition
                {
                    xNode_Parent.Parent = yNode_Parent;
                }
            }
        }

        [TestMethod]
        public void Run()
        {
            DisjointSetTree ds = new DisjointSetTree();

            //Let say we have 10 sets
            for (int i = 0; i < 10; i++)
            {
                ds.MakeSet(i);
            }
            ds.Union(0, 1);
            ds.Union(1, 2);
            ds.Union(3, 4);
            ds.Union(4, 5);
            ds.Union(6, 7);
            ds.Union(7, 8);
            ds.Union(8, 9);

            Console.WriteLine(ds.Find(0));  // Output: 0
            Console.WriteLine(ds.Find(1));  // Output: 0
            Console.WriteLine(ds.Find(2));  // Output: 0
            Console.WriteLine(ds.Find(3));  // Output: 3
            Console.WriteLine(ds.Find(4));  // Output: 3
            Console.WriteLine(ds.Find(5));  // Output: 3
            Console.WriteLine(ds.Find(6));  // Output: 6
            Console.WriteLine(ds.Find(7));  // Output: 6
            Console.WriteLine(ds.Find(8));  // Output: 6
            Console.WriteLine(ds.Find(9));  // Output: 6
        }
    }
}
