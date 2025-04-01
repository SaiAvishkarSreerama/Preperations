/*
 * GeeksForGeeks - https://www.geeksforgeeks.org/prims-minimum-spanning-tree-mst-greedy-algo-5/
 * Time Complexity: O((E+V)*log(V)) where V is the number of vertex and E is the number of edges
 *      => Algo processes V vertices and priority queue enqueu and dequeue takes Log V 
 *      => Each edge is processed once and enqueue the pq takes O(log V)
 *      => combining both (E + V) logV
 * Space Complexity: O(E+V) where V is the number of vertex and E is the number of edges
 *      Vertices (V): The space needed to store the vertices.
 *      Edges (E): The space needed to store the edges.
 *      Overall: The total auxiliary space required is O(E+V).
 *      
 * Explanation:
 *      1. Declare Adjacency list and given graph's List[vertex] = {vertex, weight};
 *      2. Declare a pq, and enqueu with root node (0,0) - (weight, vertex)
 *      3. Dequeu (0,0) and visit the each connected node by getting the values of 0 node from adjList
 *          i. If not visited the node already, push it to pq and dq it inside the loop
 *          ii. for each iteration of dq, add the values to the result
 *          iii. While enqueueing the (weight, vertex), heapify will put the min one at front
 */

namespace PreperationsTest.Algorithms.GreedyMethods.Prims_MinSpanningTree
{
    [TestClass]
    public class MinimumSpanningTree_AdjLists
    {
        [TestMethod]
        public void Run()
        {
            // { vertex, vertex, weight}
            int[,] graph = { { 0, 1, 5 }, { 1, 2, 3 }, { 0, 2, 1 } };

            MinSpanningTree_AdjLists(graph, 3, 3);
        }

        public int MinSpanningTree_AdjLists(int[,] graph, int v, int e)
        {
            // Declare and initialize Adjacency lists
            List<List<int[]>> adjList = new List<List<int[]>>();

            for (int i = 0; i < v; i++)
            {
                adjList.Add(new List<int[]>());
            }

            for (int i = 0; i < e; i++)
            {
                int vertex1 = graph[i, 0];
                int vertex2 = graph[i, 1];
                int weight = graph[i, 2];

                //add the vertex and weight to the adj list
                adjList[vertex1].Add(new int[] { vertex2, weight });
                adjList[vertex2].Add(new int[] { vertex1, weight });
            }

            // Initalize a  priority queue
            PriorityQueue<(int, int)> pq = new PriorityQueue<(int, int)>();
            pq.Enqueue((0, 0)); // start with 0 vertex

            bool[] visited = new bool[v];
            int result = 0;

            while (pq.Count > 0)
            {
                (int, int) p = pq.Dequeue();
                int weight = p.Item1;  // Weight to the edge 
                int vertex = p.Item2;  // Vertex connected of the edge

                if (visited[vertex])
                    continue;

                result += weight;
                visited[vertex] = true;

                // visit all connected vertices
                foreach(var vx in adjList[vertex])
                {
                    if (!visited[vx[0]])
                    {
                        pq.Enqueue((vx[1], vx[0])); // Weight should be first item, as the compareTo compare with the first ele
                    }
                }
            }

            return result;
        }

        public class PriorityQueue<T> where T : IComparable<T>
        {
            public List<T> heap = new List<T>();

            public int Count => heap.Count;

            public void Enqueue(T item)
            {
                heap.Add(item);
                int currentIndex = heap.Count - 1;

                while (currentIndex > 0)
                {
                    int parentIndex = (currentIndex - 1) / 2;
                    if (heap[parentIndex].CompareTo(heap[currentIndex]) <= 0){
                        break;
                    }

                    Swap(parentIndex, currentIndex);
                    currentIndex = parentIndex;
                }
            }

            public T Dequeue()
            {
                // get the leaf node
                int lastIndex = heap.Count - 1;

                // get the first heap value to return which is our min value
                T returnValue = heap[0];

                // replace the min value with node value and reduce the size, now do heapify 
                heap[0] = heap[lastIndex];
                heap.RemoveAt(lastIndex);

                --lastIndex;
                int parentIndex = 0;

                // get left, right and parent=0
                // compare left & right, take the min (let use leftIndex only for storing as newLeft)
                // compare newLeft and parent, if parent is small then do nothing, else swap and now parent is our newLeft
                while (true) {
                    int leftChildIndex = 2 * parentIndex + 1;
                    if (leftChildIndex > lastIndex)
                        break;

                    int rightChildIndex = leftChildIndex + 1;
                    if (rightChildIndex <= lastIndex && heap[leftChildIndex].CompareTo(heap[rightChildIndex]) > 0) // left > right
                    {
                        leftChildIndex = rightChildIndex;
                    }

                    if (heap[parentIndex].CompareTo(heap[leftChildIndex]) <= 0)
                        break;

                    Swap(leftChildIndex, parentIndex);
                    parentIndex = leftChildIndex;
                }

                //return the min value
                return returnValue;
            }

            public void Swap(int p, int c)
            {
                T temp = heap[p];
                heap[p] = heap[c];
                heap[c] = temp;
            }
        }
    }
}
