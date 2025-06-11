/*
 * Given two sparse vectors, compute their dot product.
 * Implement class SparseVector:
 * SparseVector(nums) Initializes the object with the vector nums
 * dotProduct(vec) Compute the dot product between the instance of SparseVector and vec
 * A sparse vector is a vector that has mostly zero values, you should store the sparse vector efficiently and compute the dot product between two SparseVector.
 * Follow up: What if only one of the vectors is sparse?
 * 
 * Example 1:
 * Input: nums1 = [1,0,0,2,3], nums2 = [0,3,0,4,0]
 * Output: 8
 * Explanation: v1 = SparseVector(nums1) , v2 = SparseVector(nums2)
 * v1.dotProduct(v2) = 1*0 + 0*3 + 0*0 + 2*4 + 3*0 = 8
 * 
 * Example 2:
 * Input: nums1 = [0,1,0,0,0], nums2 = [0,0,0,0,2]
 * Output: 0
 * Explanation: v1 = SparseVector(nums1) , v2 = SparseVector(nums2)
 * v1.dotProduct(v2) = 0*0 + 1*0 + 0*0 + 0*0 + 0*2 = 0
 * 
 * Example 3:
 * Input: nums1 = [0,1,0,0,2,0,0], nums2 = [1,0,0,0,3,0,4]
 * Output: 6
 * 
 * ******************************
 * 
 * Your SparseVector object will be instantiated and called as such:
 * SparseVector v1 = new SparseVector(nums1);
 * SparseVector v2 = new SparseVector(nums2);
 * int ans = v1.DotProduct(v2);
 * 
 * public SparseVector(int[] nums)
 * {
 * }
 * 
 * // Return the dotProduct of two sparse vectors
 * public int DotProduct(SparseVector vec)
 * {
 * }
 */

//Companies: @Meta
namespace PreperationsTest.LeetCode.Medium.Arrays
{
    [TestClass]
    public class _1570_SparseVector
    {
        [TestMethod]
        public void Run()
        {

        }

        #region Approach-1: using Arrays
        // Using Array to store the sparse vectors
        // TC - O(N), traversing the vector elements of length n at single pass 
        // SC - O(1), returning result directly
        public class SparseVector_Array
        {
            private int[] array { get; set; }
            public SparseVector_Array(int[] nums)
            {
                array = nums;
            }

            // Return the dotProduct of two sparse vectors
            public int DotProduct(SparseVector_Array vec)
            {
                int result = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    result += array[i] * vec.array[i];
                }

                return result;
            }
        }
        #endregion

        #region Approach-2: Using Dictionary to store only non-zeroes ( For Random access)
        // Using Array to store the sparse vectors
        // TC - O(N), traversing the vector elements of length n at single pass 
        // SC - O(L), for saving the non-zeroes in dict
        public class SparseVector_dict
        {
            // dict saves index as key, and non-zero vector val as value
            private Dictionary<int, int> dict { get; set; }
            public SparseVector_dict(int[] nums)
            {
                // Storing only non-zero values of a sparse vector
                dict = new Dictionary<int, int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] != 0)
                    {
                        dict[i] = nums[i];
                    }
                }
            }

            // Return the dotProduct of two sparse vectors
            public int DotProduct(SparseVector_dict vec)
            {
                int result = 0;
                foreach (var d in dict)
                {
                    // Check if the current key exists in 2nd Vector-dictionary
                    // Since we are saving only non-zeroes, both vectors have diff indices now
                    if (vec.dict.ContainsKey(d.Key))
                    {
                        result += d.Value * vec.dict[d.Key];
                    }
                }

                return result;
            }
        }
        #endregion

        #region Approach-3: Using Two-Pointer (Both sparse vectors and treated as a sorted lists, by storing in a list of List<(index, value)>)
        public class SparseVector_TwoPointer
        {
            // TC - O(m+n), traverse both vectore once
            // SC - O(1)
            private List<(int index, int value)> element { get; set; }
            public SparseVector_TwoPointer(int[] nums)
            {
                // Storing only non-zero values of a sparse vector
                element = new List<(int index, int value)>();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] != 0)
                    {
                        element.Add((i, nums[i]));
                    }
                }
            }

            // Return the dotProduct of two sparse vectors
            public int DotProduct(SparseVector_TwoPointer vec)
            {
                int result = 0;
                int i = 0;
                int j = 0;
                var a = element;
                var b = vec.element;
                // two-pointer: both elements are now have diff indexex(non-zeros), so check the indexes and then multiply them
                while (i < a.Count && j < b.Count)
                {
                    if (a[i].index == b[j].index)
                    {
                        result += a[i].value * b[j].value;
                        i++; j++;
                    }
                    else if (a[i].index < b[j].index)
                    {
                        i++;
                    }
                    else
                    {
                        j++;
                    }
                }
                return result;
            }
        }
        #endregion

        #region Approach-4, Binary Search (if one of the vector is dense(less zeros), other is sparce(more zeroes))
        // Using Array to store the sparse vectors
        // TC - O(N), traversing the vector elements of length n at single pass to fill the elements vector
        //         O(m logk), m- no of ele in smaller vectore, k-no of ele in larger vector, Binary search takes logk times to find the ele for m elements
        // SC - O(s), for saving the non-zeroes in dict
        public class SparseVector_Binary
        {
            private List<(int index, int value)> element { get; set; }
            public SparseVector_Binary(int[] nums)
            {
                // Storing only non-zero values of a sparse vector
                element = new List<(int index, int value)>();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] != 0)
                    {
                        element.Add((i, nums[i]));
                    }
                }
            }

            // Return the dotProduct of two sparse vectors
            // Using Binary search
            public int DotProduct(SparseVector_Binary vec)
            {
                int result = 0;

                // get the smaller and larger list, binary search can be perfromed on smaller list
                // based on the size of vectors form two more lists
                List<(int index, int value)> smaller = element.Count <= vec.element.Count ? element : vec.element;
                List<(int index, int value)> larger = element.Count > vec.element.Count ? element : vec.element;

                foreach (var list in smaller)
                {
                    // get the larger list value using the current index
                    int largerValue = BinarySearch(larger, list.index);
                    result += largerValue * list.value;
                }

                return result;
            }

            public int BinarySearch(List<(int index, int value)> larger, int targetIndex)
            {
                int l = 0;
                int h = larger.Count - 1;
                while (l <= h)
                {
                    int mid = l + (h - l) / 2;
                    if (larger[mid].index == targetIndex)
                    {
                        return larger[mid].value;
                    }
                    else if (larger[mid].index < targetIndex)
                    {
                        l = mid + 1;
                    }
                    else
                    {
                        h = mid - 1;
                    }
                }

                return 0;
            }
        }
        #endregion
    }
}
