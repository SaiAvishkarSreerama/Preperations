/* Problem: Maximum number of activities that won't overlap
 * Time Cmomplexity = O(n logn)
 *      Sorting the list takes O(n logn)
 *      looping the list takes O(n)
 * Space Complexity = O(n)
 *      Extra space used for result activities list O(n)
*/
namespace PreperationsTest.Algorithms.GreedyMethods
{
    [TestClass]
    public class MaxNumOfActivitiesThatWontOverlap
    {
        [TestMethod]
        public void Run()
        {
            // Example activities (start, end)
            List<(int, int)> activities = new List<(int, int)>
            {
                (1, 3),
                (4, 6),
                (2, 5),
                (8, 9),
                (5, 7)
            };

            List<(int, int)> selectedActivities = SelectActivities(activities);
        }

        /// <summary>
        /// 1. Sort the activities list according to the end time
        /// 2. for each activity check the start time is >= last activity end time, if so update the end time with current end time and add the activity to result.
        /// </summary>
        /// <param name="activities"></param>
        /// <returns></returns>
        public List<(int, int)> SelectActivities(List<(int, int)> activities)
        {
            List<(int, int)> maxListOfActivities = new List<(int, int)>();
            int lastEndTime = 0;

            // sort the list
            /* CompareTo is a method that compares two values and returns:
                1. A negative number if a.Item2 is less than b.Item2.
                2. Zero if a.Item2 is equal to b.Item2.
                3. A positive number if a.Item2 is greater than b.Item2.*/
            activities.Sort((a, b) => a.Item2.CompareTo(b.Item2));

            foreach ((int, int) activity in activities) {
                if(activity.Item1 >= lastEndTime)
                {
                    maxListOfActivities.Add(activity);
                    lastEndTime = activity.Item2;
                };
            };

            return maxListOfActivities;
        }
    }
}
