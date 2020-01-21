using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures
{
    public class CourseScheduleIISolution
    {
        //Indegree
        //TC - O(N)
        //SC - O(N)
        public int[] FindOrder(int numCourses, int[][] pre)
        {
            if (numCourses == 0)
                return null;

            //copy no of courses have no of prerequisites
            int[] course = new int[numCourses];
            for (int i = 0; i < pre.Length; i++)
                course[pre[i][0]]++;

            //we need a queue to do the bfs of the course
            Queue<int> q = new Queue<int>();
            int index = 0;
            int[] order = new int[numCourses];

            for (int i = 0; i < numCourses; i++)
            {
                if (course[i] == 0)
                { //that course has zero prerequisites
                    q.Enqueue(i);
                    order[index] = i; //add the course which has 0 prerequisites to teh output list
                    index++;
                }
            }

            while (q.Count > 0)
            {
                int prereq = q.Dequeue();
                for (int i = 0; i < pre.Length; i++)
                {
                    if (pre[i][1] == prereq)
                    {
                        course[pre[i][0]]--;
                        if (course[pre[i][0]] == 0)
                        {
                            q.Enqueue(pre[i][0]);
                            order[index] = pre[i][0];
                            index++;
                        }
                    }
                }
            }
            return numCourses == index ? order : new int[0];
        }
    }
}
