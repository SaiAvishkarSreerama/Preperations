/*
 * Problem: Given a n number of files, to find the minimum computations done to reach the Optimal Merge Pattern
 * Ex: 4,5,3,6,2 are the five files with sizes
 *      1. Merging 4 and 5 => 9, now we have 9, 3, 6, 2, merging 9+3=> 12, becomes 12,6,2, again 12+6=18, 18+2=20
 *      2. So total work sone here is 9+12+18+20 = 59
 *      3. Sort the list first, 2 3 4 5 6, no do same
 *      4. 2+3=5, sort again 4 5 5 6, 4+5=9, sort again 5+6+9, 5+6=11, 9+11 = 20, total = 5+9+11+20 = 45
 *      5. so, we can observe the optimal merge file count can get by merging the smallest files
 *      
 * Time Complexity - O (n logn) - for sorting in list or Enqueue/Dequeuein PQ
 * Space Complexity - O (n), for both lists and priority queues
 */
namespace PreperationsTest.Algorithms.GreedyMethods
{
    [TestClass]
    public class OptimalFileMergePatterns
    {
        [TestMethod]
        public void Run()
        {
            int[] files = new int[] { 3, 4, 6, 5, 2, 7 };
            int optimalcount = OptimalMerge_UsingLists(files);

            optimalcount = OptimalMerge_UsingPriorityQueue(files);
        }

        /// <summary>
        /// Time Complexity - O(n Logn) -for sorting
        /// Space Complexity - O(n) for new list 
        /// </summary>
        /// <returns></returns>
        public int OptimalMerge_UsingLists(int[] files)
        {
            // new list with given files, as we keep adding the resultant files count to it
            List<int> fileList = new(files);
            int optimalCount = 0;

            while (fileList.Count > 1)
            {
                // sort the list for every iteration as we keep getting new files count
                fileList.Sort();

                int file1 = fileList[0];
                int file2 = fileList[1];

                // count for two files merge, add this to the fileList at last
                int combinedFilesCount = file1 + file2;

                // our optimal result
                optimalCount += combinedFilesCount;

                //remove the first and second elements
                fileList.RemoveAt(0);
                fileList.RemoveAt(0);

                fileList.Add(combinedFilesCount);
            }

            return optimalCount;
        }

        /// <summary>
        /// Time Complexity - O(n logn) 
        ///     Enqueue operation of pq takes nlogn
        ///     Dequeue operation takes (n-1)logn
        /// Space Complexity - O(n) for pq
        /// </summary>
        /// <returns></returns>
        public int OptimalMerge_UsingPriorityQueue(int[] files)
        {
            // minHeap priority queue
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
            int optimalResult = 0;
            for (int i = 0; i < files.Length; i++)
            {
                pq.Enqueue(files[i], files[i]);
            }

            while (pq.Count > 1)
            {
                int file1 = pq.Dequeue();
                int file2 = pq.Dequeue();

                int combinedFilesCount = file1 + file2;
                optimalResult += combinedFilesCount;

                pq.Enqueue(combinedFilesCount, combinedFilesCount);
            }

            return optimalResult;
        }
    }
}
