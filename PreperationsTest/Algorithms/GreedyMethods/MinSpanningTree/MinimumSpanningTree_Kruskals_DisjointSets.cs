/*
 * Explanation:
 *      1. Sort the edges in no-descending order according to their weights.
 *      2. create a disjoint set and initialize the parent[] with no of vertices, and rank[] with 0s
 *      3. Iterate each edge, starts with lowest weight
 *      4. Check if the Root of both vertices are same, means forming loop, discard it.
 *      5. If not, union them and add the weight and increment the count variable, as we check if count should not exceeds (V-1) edges
 *      
 *  Time Complexity - O(E logE) or O(E logV)
 *      Sorting of Edges takes E logE
 *      ITerating through vetrices for union-find takes atmost O(logV)
 *  Space Complexity - O(E+V)    
 */

namespace PreperationsTest.Algorithms.GreedyMethods.MinSpanningTree
{
    [TestClass]
    public class MinimumSpanningTree_Kruskals_DisjointSets
    {
        [TestMethod]
        public void Run()
        {
            int[][] graph = { new int[] { 0, 1, 10 }, new int[] { 1, 3, 15 }, new int[] { 2, 3, 4 }, new int[] { 2, 0, 6 }, new int[] { 0, 3, 5 } };
            int mstCost = Kruskals_MinSpanningTree(graph, 4);
        }

        public int Kruskals_MinSpanningTree(int[][] graph, int vertices)
        {
            int cost = 0;
            int count = 0;
            DSU disjointSet = new DSU(vertices);

            // Step1: Sort all edges according their weight
            Array.Sort(graph, (a, b) => a[2].CompareTo(b[2]));

            foreach (var g in graph)
            {
                int v1 = g[0];
                int v2 = g[1];
                int w = g[2];

                // check if v1 vertex and v2 parents are not same, same means they form a loop
                if (disjointSet.Find(v1) != disjointSet.Find(v2))
                {
                    disjointSet.Union(v1, v2);
                    cost += w;
                    count++;
                }

                if (count == vertices - 1)
                    break;
            }

            return cost;
        }

        /// Mimic the DisjointSet
        public class DSU
        {
            private int[] Parent { get; set; }
            private int[] Rank { get; set; }
            public DSU(int n)
            {
                Parent = new int[n];
                Rank = new int[n];
                for (int i=0; i<n; i++)
                {
                    Parent[i] = i;
                    Rank[i] = 0;
                }
            }

            public int Find(int i)
            {
                if (Parent[i] != i)
                {
                    Parent[i] = Find(Parent[i]);
                }

                return Parent[i];
            }

            public void Union(int x, int y)
            {
                int xRoot = Find(x);
                int yRoot = Find(y);

                if (xRoot == yRoot)
                    return;

                if (Rank[xRoot] >= Rank[yRoot])
                {
                    Parent[yRoot] = xRoot;
                    if(Rank[xRoot] == Rank[yRoot])
                    {
                        Rank[xRoot]++;
                    }
                }
                else
                {
                    Parent[xRoot] = yRoot;
                }
            }
        }
    }
}
