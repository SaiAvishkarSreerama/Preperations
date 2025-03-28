/*
 * Problem: Given three arrays id[], deadline[], profit[], where each job i is associated with id[i], deadline[i], and profit[i].
 * Each job takes 1 unit of time to complete, and only one job can be scheduled at a time. You will earn the profit associated with a job only if it is completed by its deadline.
 * 
 * Approach:Greedy method
 *      1. Form a tuple or a list combining jobId, profit and deadlines
 *      2. Sort the tuple by profits
 *      3. Find the maximum deadline so that we know total hours available for to accommodate the jobs
 *      4. Iterate from last, check if the job can finish before the deadline. Let say 40profit jobId-4 can be done in deadline-1hr.
 *      5. When any job with deadline-1 comes, we skip it as it is already occupied.
 *      6. run through all jobs and result will be calculated as the max profits of the assigned jobs
 * 
 * Approach 1: Naive Greedy, uses 2 for loops
 * Approach 2: Priority Queue, single for loop
 * Approach 3: Using Disjoint sets
 */

namespace PreperationsTest.Algorithms.GreedyMethods
{
    [TestClass]
    public class JobSequenceProblem
    {
        [TestMethod]
        public void Run()
        {
            //// Example 1
            //int[] jobId = { 1, 2, 3, 4 };
            //int[] deadline = { 4, 1, 1, 1 };
            //int[] profit = { 20, 10, 40, 30 };
            //// Otuput - 40 + 20 = 60

            // Example 2
            int[] jobId = { 1, 2, 3, 4, 5 };
            int[] deadline = { 2, 1, 2, 1, 1 };
            int[] profit = { 100, 19, 27, 25, 15 };
            // Otuput - 100 + 27 = 127

            JobSequence_NaiveGreedy(jobId, profit, deadline);
            JobSequence_PriorityQueue(jobId, profit, deadline);
            JobSequence_DisjointSets(jobId, profit, deadline);
        }

        /// <summary>
        /// Approach 1
        /// Time Complexity: O(N^2)
        ///      Sorting the list takes 'n logn' time
        ///      Iterating the list i takes n time, j takes n-1 items - n^2
        /// space Complexity: O(N)
        ///      creating a new list/tuple by combining all inputs - O(N)
        ///      created an array to maintian the scehduled jobs - O(d), where d is the max deadline
        ///      created few constants - O(1)
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="profit"></param>
        /// <param name="deadline"></param>
        /// <returns></returns>
        public int JobSequence_NaiveGreedy(int[] jobId, int[] profit, int[] deadline)
        {
            int maxDeadline = 0;
            int maxProfit = 0;
            int n = jobId.Length;

            // form a tuple with all info
            List<(int, int, int)> jobInfo = new List<(int, int, int)>();
            for (int i = 0; i < n; i++)
            {
                jobInfo.Add(new(jobId[i], profit[i], deadline[i]));
                if (deadline[i] > maxDeadline)
                {
                    maxDeadline = deadline[i];
                }
            }

            // Sort the job info list based on profits, descending b->a
            jobInfo.Sort((a, b) => b.Item2.CompareTo(a.Item2));

            // Initialize an array to note the assigned jobs
            bool[] acceptedJobs = new bool[maxDeadline];
            for (int i = 0; i < n; i++)
            {
                // math.min ensures that j starts from the latest possible slot before the job's deadline
                // In example 2, first high profit job takes the index-1, next high profit job also looks for index-1, but since it is occupied we need to check for next available slot
                // If the deadline spot is taken, looking for lower index slots can be assigned for the similar deadline job
                // -1 : gives the array index for length - 4, 0 - 3 indexes
                for (int j = Math.Min(maxDeadline, jobInfo[i].Item3) - 1; j >= 0; j--)
                {
                    // check if the acceptedjob bool array has false means that hour is empty and we can assign a job
                    if (!acceptedJobs[j])
                    {
                        maxProfit += jobInfo[i].Item2;
                        acceptedJobs[j] = true;
                        break;
                    }
                }
            }
            return maxProfit;
        }

        /// <summary>
        /// Approach 2: Using Priority Queue:  https://www.geeksforgeeks.org/job-sequencing-problem/#naive-approach-using-greedy-approach-on-2-time-and-on-space
        /// Time Complexity: O(N LogN)
        ///      Sorting the list takes 'n logn' time
        ///      Iterating the list takes N time
        /// space Complexity: O(N)
        ///      creating a new list/tuple by combining all inputs - O(N)
        ///      created an priority queueu - O(N)
        ///      created few constants - O(1)
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="profit"></param>
        /// <param name="deadline"></param>
        /// <returns></returns>
        public int JobSequence_PriorityQueue(int[] jobId, int[] profit, int[] deadline)
        {
            int maxProfit = 0;
            int n = jobId.Length;

            // form a tuple with all info
            List<(int, int, int)> jobInfo = new List<(int, int, int)>();
            for (int i = 0; i < n; i++)
            {
                jobInfo.Add(new(jobId[i], profit[i], deadline[i]));
            }

            // Sort the job info list based on **deadlines**
            jobInfo.Sort((a, b) => a.Item3.CompareTo(b.Item3));

            // Initialize an array to note the assigned jobs
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
            foreach (var job in jobInfo)
            {
                // Since we are iterating deadlines in ascending order 1,1,1,2,2
                // first we get deadline-1, since pq is empty, enqueue: pq has 1 item, (profit: 19)
                // second item, we check deadline-1 and pq.count-1, so go to else and peek-19 < currentProfit-25, dequeu the previous one and enqueue(25)
                // next time when we get deadline-2 and pq.count-1, enqueu it (100), now pq-count becomes 2
                // next we get deadline-2 again, goes to else and peek(25, as it FIFO), dequeue and enqueue(27)
                if (job.Item3 > pq.Count)
                {
                    pq.Enqueue(job.Item2, job.Item2);
                }
                else if (pq.Count > 0 && pq.Peek() < job.Item2)
                {
                    pq.Dequeue();
                    pq.Enqueue(job.Item2, job.Item2);
                }
            }

            //Iterate through the pq and Deququq one by one and add it to maxProfit
            while (pq.Count > 0)
            {
                maxProfit += pq.Dequeue();
            }

            return maxProfit;
        }


        /// <summary>
        /// Using Disjoint Sets
        /// https://www.geeksforgeeks.org/job-sequencing-problem-using-disjoint-set/
        /// Time Complexity: O(N Log(d))
        ///      Sorting the list takes 'n logn' time
        ///      Iterating the list takes N time
        /// space Complexity: O(d)
        /// </summary>
        /// <param name="job"></param>
        /// <param name="profit"></param>
        /// <param name="deadline"></param>
        /// <returns></returns>
        public int JobSequence_DisjointSets(int[] jobId, int[] profit, int[] deadline)
        {
            int maxDeadline = int.MinValue;
            int maxProfit = 0;
            int n = jobId.Length;

            // form a tuple with all info
            List<(int, int, int)> jobInfo = new List<(int, int, int)>();
            for (int i = 0; i < n; i++)
            {
                jobInfo.Add(new(jobId[i], profit[i], deadline[i]));
                if (deadline[i] > maxDeadline)
                {
                    maxDeadline = Math.Max(maxDeadline, deadline[i]);
                }
            }

            // Sort the job info list based on profits, descending b->a
            jobInfo.Sort((a, b) => b.Item2.CompareTo(a.Item2));

            DisJointSet ds = new DisJointSet(maxDeadline);
            for (int i = 0; i < jobId.Length; i++)
            {
                // get the slot of the current job deadline
                int slots = ds.Find(jobInfo[i].Item3);

                if (slots > 0)
                {
                    ds.Union(ds.Find(slots - 1), slots); // Here we set each slot's parent as its previous dlot (slot -1)
                                                         // That means when 2 comes, 2 slots are availble, we use one slot and set parent[2] = 1.
                                                         // When another 2 comes, we get parent[2] = 1, means 1 slot availble, and agian set parent[1] = 0
                                                         // when another job comes, we traverse to the parent and get 0, means 0 available slots
                    maxProfit += jobInfo[i].Item2;
                }
            }
            return maxProfit;
        }

        public class DisJointSet
        {
            public int[] parent { get; set; }

            public DisJointSet(int d) // d is the maxdeadline
            {
                parent = new int[d + 1];

                for (int i = 0; i <= d; i++)
                {
                    parent[i] = i;
                }
            }

            public int Find(int i)
            {
                if (parent[i] != i)
                {
                    parent[i] = Find(parent[i]);
                }
                return parent[i];
            }

            public void Union(int x, int y)
            {
                parent[y] = x;
            }
        }
    }
}
