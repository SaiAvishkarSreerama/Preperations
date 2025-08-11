/*
 * You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part. For example, the string "ababcc" can be partitioned into ["abab", "cc"], but partitions such as ["aba", "bcc"] or ["ab", "ab", "cc"] are invalid.
 * Note that the partition is done so that after concatenating all the parts in order, the resultant string should be s.
 * Return a list of integers representing the size of these parts.

 * Example 1:
 * Input: s = "ababcbacadefegdehijhklij"
 * Output: [9,7,8]
 * Explanation:
 * The partition is "ababcbaca", "defegde", "hijhklij".
 * This is a partition so that each letter appears in at most one part.
 * A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.
 
 * Example 2:
 * Input: s = "eccbbbbdec"
 * Output: [10]
 * 
 * Constraints:
 * 1 <= s.length <= 500
 * s consists of lowercase English letters.
 */

namespace PreperationsTest.LeetCode.Medium.Strings
{
    [TestClass]
    public class _763_PartitionLabels
    {
        [TestMethod]
        public void Run()
        {
            string s = "ababcbacadefegdehijhklij";
            IList<int> partitionLabelsLengths = PartitionLabels(s);
        }

        /// <summary>
        /// TC - O(N)
        /// SC - O(1), as int[26] is constant space
        ///     for Dictionary O(k), k will be up to 26
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<int> PartitionLabels(string s)
        {
            List<int> result = new List<int>();

            // hold the last appeared index of each char
            // Dictionary<char, int> last = new Dictionary<char, int>();
            // for(int i = 0; i < s.Length; i++){
            //     last[s[i]] = i; 
            // }.

            // Using int[26] provides a constant Space, as we know if uses for sure 26 positions
            // in time, there will be no hasing required to store any key/values pairs like dictionary, even though TC - O(N) same
            int[] last = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                last[s[i] - 'a'] = i;
            }

            // iterating the string
            int start = 0;
            int end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                // for each char we see between start to end, check if the last seen of that char is with in the end
                // otherwise the new end will be updated
                end = Math.Max(end, last[s[i] - 'a']);

                // when our curr index is end, means we have a substring
                // add it to the result and update the start to end+1
                if (i == end)
                {
                    result.Add(end - start + 1);
                    start = end + 1;
                }
            }

            return result;
        }
    }
}
