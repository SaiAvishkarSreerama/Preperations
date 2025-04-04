/*
 * The Floyd Warshall Algorithm is an all-pair shortest path algorithm that uses Dynamic Programming to find the shortest distances between every pair of vertices in a graph,
 * unlike Dijkstra and Bellman-Ford which are single source shortest path algorithms. 
 * This algorithm works for both the directed and undirected weighted graphs and can handle graphs with both positive and negative weight edges.
 * 
 * Explanation:
 * Initialize the solution matrix same as the input graph matrix as a first step.
 * Then update the solution matrix by considering all vertices as an intermediate vertex. 
 * The idea is to pick all vertices one by one and updates all shortest paths which include the picked vertex as an intermediate vertex in the shortest path. 
 * When we pick vertex number k as an intermediate vertex, we already have considered vertices {0, 1, 2, .. k-1} as intermediate vertices. 
 * For every pair (i, j) of the source and destination vertices respectively, there are two possible cases. 
 *      k is not an intermediate vertex in shortest path from i to j. We keep the value of dist[i][j] as it is. 
 *      k is an intermediate vertex in shortest path from i to j. We update the value of dist[i][j] as dist[i][k] + dist[k][j], if dist[i][j] > dist[i][k] + dist[k][j]
 *      
 * TC - O(N^3)
 * SC - O(N^2) - to create 2D matrix to store the shortest distance of each pairs
 */

namespace PreperationsTest.Algorithms.DynamicProgramming
{
    [TestClass]
    public class Floyd_Marshall_ShortestPathToAllVertices
    {
        [TestMethod]
        public void Run()
        {
            int[,] graph =  {
                { 0, 4, -1, 5, -1},
                { -1, 0, 1, -1, 6},
                { 2, -1, 0, 3, -1},
                { -1, -1, 1, 0, 2},
                { 1, -1, -1, 4, 0}
            };

            FloydWashallAlgo(graph);
        }

        public void FloydWashallAlgo(int[,] graph)
        {
            int v = graph.GetLength(0);

            for (int k = 0; k < v; k++)
            {
                for (int i = 0; i < v; i++)
                {
                    for (int j = 0; j < v; j++)
                    {
                        // -1 + any non-inf num(10) becomes +ve > -1, but since is infinity to us, we should avoid any -1 comes here for [i,k] or [k,j]
                        // Since we are using -1 instead of INFINITY, the sum should be less than infinity, but here the sum comes as greater than -1
                        // So when [i,j] == -1, we should allow updating the graph otherwise we fail for a case -1 > 6(sum), So using '||' to avoid this case
                        if (graph[i, k] != -1 && graph[k, j] != -1 &&
                                (graph[i, j] == -1 || graph[i, j] > graph[i, k] + graph[k, j]))
                        {
                            graph[i, j] = graph[i, k] + graph[k, j];
                        }
                    }
                }
            }

        }
    }
}
