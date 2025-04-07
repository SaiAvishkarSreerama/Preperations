/*
 * Points to Remember:
 *      Single source shortest path:
 *          1. Dijkstras Algorithm
 *              i. Drawback: 50-50 success when a negative weight exists
 *          2. Bellman-Ford Algorithm
 *              i. Drawback: When a cycle with negative total weight exists, bellman form theory fails to find the shortest path, as it takes more than n-1 relxations to complete the solution, 
 *                 it keeps reduces the paths for more relaxations too
 *              ii. Helps to detect any negative weight cycle exitst or not - After n-1 relxations, doing one more relaxation changes any value, means negative weight cycle exits
 * Approach: Relaxing the edges (n-1) times, where n is the no of vertices/nodes.
 * Explanations: 
 *      1. Need an array int[v], for storing the shortest distances of the nodes
 *      2. Iterate the relxations for given n times(5 => 0-4), where n-1(4 => i= 0-3) is for the edge relxation and nth(i=4) iteration is for checking the nedative weighted cycle
 *      3. for each relaxation of i, iterate all edges of the given graph
 *      4. When the dist[u] + wt < dist[v], update dist[v]
 *      5. If i = n-1, means the negative cycle, return -1 array; 
 * 
 * TC - O(E*V) if V=n, E=V-1=n-1 => O(n^2)
 * SC - O(V)
 * Geeks - https://www.geeksforgeeks.org/bellman-ford-algorithm-dp-23/?ref=header_outind
 * */

namespace PreperationsTest.Algorithms.DynamicProgramming
{
    [TestClass]
    public class SingleSourceShortestPath_BellmanFord
    {
        [TestMethod]
        public void Run()
        {
            int source = 0; // source node
            int v = 5;
            List<List<int>> edges = new List<List<int>>() {
                new List<int> { 1, 3, 2 },
                new List<int> { 4, 3, -1 },
                new List<int> { 2, 4, 1 },                                          //        (0)---5-->(1)--2-->(3)
                new List<int> { 1, 2, 1 },                                          //                   |        ^               -5    
                new List<int> { 0, 1, 5 },                                          //                  1|        |-1   +    (3)------->(2) new edge
                new List<int> { 3, 2, -5 } //This edge forms a negative cycle       //                   v        |             
             };                                                                     //                  (2)---1-->(4)                      

            int[] dist = BellmaFordAlgo(v, edges, source);

            if(dist.Length == 1)
            {
                Console.WriteLine("Negative weighted cycle exits");
            }

            for (int i = 0; i < dist.Length; i++)
            {
                Console.WriteLine(dist[i]);
            }
        }

        /// <summary>
        /// Shortest distances using V-1 relaxations
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public int[] BellmaFordAlgo(int n, List<List<int>> edges, int source)
        {
            int[] dist = new int[n];
            for (int i = 0; i < n; i++)
            {
                dist[i] = int.MaxValue;
            }
            dist[source] = 0;

            // n-1 times relxations
            // Do one more relxation to check if there is any negative weight cycle
            for (int i = 0; i <= n - 1; i++)
            {
                foreach (var edge in edges)
                {
                    int u = edge[0];
                    int v = edge[1];
                    int wt = edge[2];

                    if (dist[u] != int.MaxValue && dist[u] + wt < dist[v])
                    {
                        // Additional relaxation
                        if (i == n - 1)
                        {
                            return new int[] { -1 };
                        }
                        dist[v] = dist[u] + wt;
                    }
                }
            }

            return dist;
        }
    }
}
