using System;
using System.Collections.Generic;
using System.Text;
/*
*  There are a total of n courses you have to take, labeled from 0 to n-1.
* 
* Some courses may have prerequisites, for example to take course 0 you have to first take course 1, which is expressed as a pair: [0,1]
* 
* Given the total number of courses and a list of prerequisite pairs, is it possible for you to finish all courses?
* 
* Example 1: 
* Input: 2, [[1,0]] 
* Output: true
* Explanation: There are a total of 2 courses to take. 
*              To take course 1 you should have finished course 0. So it is possible.
*              
* Example 2: 
* Input: 2, [[1,0],[0,1]]
* Output: false
* Explanation: There are a total of 2 courses to take. 
*              To take course 1 you should have finished course 0, and to take course 0 you should
*              also have finished course 1. So it is impossible.
*              
* Note: 
* The input prerequisites is a graph represented by a list of edges, not adjacency matrices. Read more about how a graph is represented.
* You may assume that there are no duplicate edges in the input prerequisites.
* */
namespace AviPreperation.Data_Structures.Array
{
    public class CourseScheduleSolution
    {
        public bool CanFinishBFS(int numCourses, int[][] prerequisites)
        {
            //create a graph which is an array of lists, or a list of lists whcih is a siz of numCourses length and no of prerequisites a values
            //graph: [[],[]]
            List<int>[] graph = new List<int>[numCourses];
            for (int i = 0; i < numCourses; i++)
                graph[i] = new List<int>();

            //degree to maintain a count of prerequisites 
            int[] degree = new int[numCourses];
            
            //updating the prerequisite course number into degree, and the course(key)-prerequisite(value) to graph
            for (int i = 0; i < prerequisites.Length; i++)
            {
                degree[prerequisites[i][1]]++;
                graph[prerequisites[i][0]].Add(prerequisites[i][1]);
            }

            //queue for BFS
            Queue<int> q = new Queue<int>();
            int count = 0;

            //iterate degree array and push to Queue if 0, means that course does not have any prerequisite course to do.
            for (int i = 0; i < degree.Length; i++)
            {
                if (degree[i] == 0)
                {
                    count++;
                    q.Enqueue(i);
                }
            }

            //do BFS
            while (q.Count > 0)
            {
                int course = q.Dequeue();
                //get the course's that are using this course as prerequisites
                for (int i = 0; i < graph[course].Count; i++)
                {
                    //get each prereq course and 
                    int pointer = graph[course][i];
                    degree[pointer]--;
                    if (degree[pointer] == 0)
                    {
                        q.Enqueue(pointer);
                        count++;
                    }
                }
            }

            return count == numCourses;
        }


        //DFS
        public bool CanFinishDFS(int numCourses, int[][] prerequisites)
        {
            List<int>[] graph = new List<int>[numCourses];
            for (int i = 0; i < numCourses; i++)
                graph[i] = new List<int>();

            for (int i = 0; i < prerequisites.Length; i++)
                graph[prerequisites[i][0]].Add(prerequisites[i][1]);

            bool[] visited = new bool[numCourses];
            for (int i = 0; i < numCourses; i++)
            {
                if (!Dfs(graph, visited, i))
                {
                    return false;
                }
            }

            return true;
        }

        //DFS is doing the depth finding
        //once it enter into course 1, making as visited and enters into its prerequisites and do dfs to their 
        //prerequisites, since we made 1 as true, so if any where is is prerequisites of its prerequisite, then 
        //returns false 
        public bool Dfs(List<int>[] graph, bool[] visited, int course)
        {
        if (visited[course])
            return false;

        visited[course] = true;

        for (int i = 0; i < graph[course].Count; i++)
        {
            if (!Dfs(graph, visited, graph[course][i]))
                return false;
        }

        visited[course] = false;
        return true;
        }
    }
}
