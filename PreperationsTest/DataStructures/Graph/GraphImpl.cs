/*
 * Graph is represented as a 2D array/matrix, where rows and columns denotes the vertices and each entry represents the weight of the edges between the vertices
 * Adjacency Matrix: In this example I used the 2D array, which is an adjacency matrix.
 *      TC - O(V2) for iterating O(1) for Add, remove, check an edge, V - no of vertices
 *      SC - O(V2)
 * Adjacency Lists: use _Graph = new List<int>[] instead of int[v, v]. for add/remove, _Graph[v1].Add(v2)/.Remove(v2)
 *      TC - O(V+E) for iterating O(1) for Add-O(1), Remove-O(E), check edge exists O(V), V - no of vertices, E - no of edges
 *      SC - O(V+E)
 * Edge List: use List<Edge>(); where Edge is a class that has source, destination, weight props. _graph = new List<Edge>() 
 *      _Graph.Add(new Edge(source, destination, weight);
 *      TC - O(E) for all except Add-O(1)
 *      SC - O(E)
 */

namespace PreperationsTest.DataStructures.Graph
{
    [TestClass]
    public class GraphImpl
    {
        public int[,] Graph { get; set; }

        public GraphImpl() { }

        public GraphImpl(int v)
        {
            // v - no of vertices
            Graph = new int[v, v];
        }

        // Default weight is 1 otherwise
        public void AddEdge(int v1, int v2, int weight = 1)
        {
            Graph[v1, v2] = weight;
            Graph[v2, v1] = weight;
        }

        public void RemoveEdge(int v1, int v2)
        {
            Graph[v1, v2] = 0;
            Graph[v2, v1] = 0;
        }

        public void PrintGraph()
        {
            int v = Graph.GetLength(0);
            for (int i = 0; i < v; i++)
            {
                for (int j = 0; j < v; j++)
                {
                    Console.WriteLine(Graph[i, j] + " ");
                }
            }
        }

        [TestMethod]
        public void Run()
        {
            GraphImpl graph = new GraphImpl(5);
            // unweighted-undirected graph
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 4);
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(1, 4);

            // weighted graph
            graph.AddEdge(2, 3, 10);
            graph.AddEdge(3, 4, 20);

            RemoveEdge(0, 4);

            // Print graph
            graph.PrintGraph();
        }
    }
}
