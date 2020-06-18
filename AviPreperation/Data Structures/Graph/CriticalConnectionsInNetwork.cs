using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Graph
{
    public class CriticalConnectionsInNetworkSolution
    {
        int time = 0;
        List<IList<int>> result;
        Dictionary<int, List<int>> dict;

        public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
        {
            result = new List<IList<int>>();
            dict = new Dictionary<int, List<int>>();
            for (int i = 0; i < connections.Count; i++)
            {
                //Add connection 0 -> 1, since undirected graph, so consider from both nodes
                if (!dict.ContainsKey(connections[i][0]))
                    dict.Add(connections[i][0], new List<int>());
                dict[connections[i][0]].Add(connections[i][1]);
                //Add connection 1 -> 0
                if (!dict.ContainsKey(connections[i][1]))
                    dict.Add(connections[i][1], new List<int>());
                dict[connections[i][1]].Add(connections[i][0]);
            }

            int[] low = new int[n];
            int[] visited = new int[n];
            System.Array.Fill(visited, -1);

            for (int i = 0; i < n; i++)
            {
                if (visited[i] == -1)
                    DFS(i, low, visited, i);
            }
            return result;
        }

        public void DFS(int currentNode, int[] low, int[] visited, int parentNode)
        {
            visited[currentNode] = low[currentNode] = ++time;
            for (int j = 0; j < dict[currentNode].Count; j++)
            {
                int childNode = dict[currentNode][j];
                if (childNode == parentNode)
                {
                    continue;
                }
                if (visited[childNode] == -1)
                {
                    DFS(childNode, low, visited, currentNode);
                    low[currentNode] = Math.Min(low[currentNode], low[childNode]);
                    if (low[childNode] > visited[currentNode])
                        result.Add(new List<int> { currentNode, childNode });
                }
                else
                {
                    low[currentNode] = Math.Min(low[currentNode], visited[childNode]);
                }
            }
        }

        //public static void Main()
        //{
        //    //[[0,1],[1,2],[2,0],[1,3]]
        //    List<IList<int>> input = new List<IList<int>>();
        //    input.Add(new List<int> { 0, 1 });
        //    input.Add(new List<int> { 1, 2 });
        //    input.Add(new List<int> { 2, 0 });
        //    input.Add(new List<int> { 1, 3 });
        //    CriticalConnectionsInNetworkSolution ccClass = new CriticalConnectionsInNetworkSolution();
        //    var res = ccClass.CriticalConnections(4, input);
        //}
    }
}
