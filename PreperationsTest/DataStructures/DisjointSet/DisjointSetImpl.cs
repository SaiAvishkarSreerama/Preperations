/*
 * Either we can use Rank approach or Size approach.
 *      if Rank, merging sets will increment the rank
 *      if Size, merging will adds both sets sizes
 * Disjoint sets can be implemented using
 *      1. Arrays
 *      2. Trees
 * Time Complexity - O(α(n)), where α(n) is the inverse Ackermann function. This function grows very slowly, making the Find operation nearly constant time in practice. - nearly O(1)
 * Space Complexity - O(n), we use parent, rank/size arrays
 */

namespace PreperationsTest.DataStructures.DisjointSet
{
    [TestClass]
    public class DisjointSetImpl
    {
        public class DisjointSets
        {
            public int[] rank { get; set; }
            public int[] parent { get; set; }
            public int[] size { get; set; }

            // Constructor
            public DisjointSets(int n)
            {
                rank = new int[n];
                parent = new int[n];
                size = new int[n];

                for (int i = 0; i < n; i++)
                {
                    parent[i] = i;
                    rank[i] = 0;
                    size[i] = 1; //if using size, intialize with 1
                }
            }

            public int Find(int x)
            {
                if (parent[x] != x)
                {
                    parent[x] = Find(parent[x]); // path compression
                }
                return parent[x];
            }

            /// <summary>
            /// Using Rank
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            public void Union(int x, int y)
            {
                int xRoot = Find(x);
                int yRoot = Find(y);

                // if both ele has same root means they are in same set
                if (xRoot == yRoot)
                {
                    return;
                }

                if (rank[xRoot] < rank[yRoot])
                {
                    parent[xRoot] = yRoot;
                }
                else if (rank[xRoot] > rank[yRoot])
                {
                    parent[yRoot] = xRoot;
                }
                else
                {
                    parent[xRoot] = yRoot;
                    rank[yRoot]++;
                }
            }

            /// <summary>
            /// Using Size
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            public void Union_Size(int x, int y)
            {
                int xRoot = Find(x);
                int yRoot = Find(y);

                // if both ele has same root means they are in same set
                if (xRoot == yRoot)
                {
                    return;
                }

                if (rank[xRoot] <= rank[yRoot])
                {
                    parent[xRoot] = yRoot;
                    size[yRoot] += size[xRoot]; // Since y becoming root, add x size to y, coz now y->y+x
                }
                else
                {
                    parent[yRoot] = xRoot;
                    size[xRoot] += size[yRoot]; // Since x becoming root, add y size to x, coz now x->x+y
                }
            }
        }


        [TestMethod]
        public void DisjointSet_Implementation()
        {
            // Let there be 5 persons with ids as
            // 0, 1, 2, 3 and 4
            int n = 5;

            DisjointSets ds = new DisjointSets(n);

            // 1 is friend of 2
            ds.Union(1, 2);

            // using size
            ds.Union_Size(0, 4);

            // 4 is friend of 3
            ds.Union(4, 3);

            // Find the relationship of 4 and 2
            if (ds.Find(4) == ds.Find(2))
            {
                Console.WriteLine("both are freinds, as they both have same root");
            }
            else
            {
                Console.WriteLine("4 and 2 belongs to two differnet sets");
            }
        }
    }
}
