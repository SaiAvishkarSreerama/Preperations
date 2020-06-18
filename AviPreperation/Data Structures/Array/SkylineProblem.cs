using System;
using System.Collections.Generic;
using System.Text;
/*A city's skyline is the outer contour of the silhouette formed by all the buildings in that city when viewed from a distance. 
* Now suppose you are given the locations and height of all the buildings as shown on a cityscape photo (Figure A),
* write a program to output the skyline formed by these buildings collectively (Figure B).
* 
* Buildings Skyline Contour
* The geometric information of each building is represented by a triplet of integers [Li, Ri, Hi], where Li and Ri are the x 
* coordinates of the left and right edge of the ith building, respectively, and Hi is its height. 
* It is guaranteed that 0 ≤ Li, Ri ≤ INT_MAX, 0 < Hi ≤ INT_MAX, and Ri - Li > 0. 
* You may assume all buildings are perfect rectangles grounded on an absolutely flat surface at height 0.
* 
* For instance, the dimensions of all buildings in Figure A are recorded as: 
* [ [2 9 10], [3 7 15], [5 12 12], [15 20 10], [19 24 8] ] .
* 
* The output is a list of "key points" (red dots in Figure B) in the format of [ [x1,y1], [x2, y2], [x3, y3], ... ]
* that uniquely defines a skyline. A key point is the left endpoint of a horizontal line segment. Note that the last key point, 
* where the rightmost building ends, is merely used to mark the termination of the skyline, and always has zero height.
* Also, the ground in between any two adjacent buildings should be considered part of the skyline contour.
* 
* For instance, the skyline in Figure B should be represented as:[ [2 10], [3 15], [7 12], [12 0], [15 10], [20 8], [24, 0] ].
* 
* Notes:
* The number of buildings in any input list is guaranteed to be in the range [0, 10000].
* The input list is already sorted in ascending order by the left x position Li.
* The output list must be sorted by the x position.
* There must be no consecutive horizontal lines of equal height in the output skyline. For instance,
* [...[2 3], [4 5], [7 5], [11 5], [12 7]...] is not acceptable; the three lines of height 5 should be merged into one in the final 
* output as such: [...[2 3], [4 5], [12 7], ...]
* */
namespace AviPreperation.Data_Structures.Array
{
    public class SkylineProblemSolution
    {
        //TC - O(N logN)
        //SC- O(N)
        public IList<IList<int>> GetSkyline(int[][] buildings)
        {

            //insert into height as [Li, -Hi] and [Ri, Hi]
            List<int[]> heights = new List<int[]>();
            foreach (int[] h in buildings)
            {
                heights.Add(new int[] { h[0], -h[2] });//if negative : will know them as left
                heights.Add(new int[] { h[1], h[2] }); // else right
            }

            heights.Sort((a, b) => {
                return a[0] != b[0] ? a[0].CompareTo(b[0]) : a[1].CompareTo(b[1]);
            });

            //sorted Dictionary --> Max HEAP
            SortedDictionary<int, int> heap = new SortedDictionary<int, int>(Comparer<int>.Create((a, b) => -a.CompareTo(b)));
            heap.Add(0, 0);
            int pre = 0;
            List<IList<int>> result = new List<IList<int>>();

            foreach (int[] h in heights)
            {
                //left
                if (h[1] < 0)
                {
                    if (!heap.ContainsKey(-h[1]))
                        heap.Add(-h[1], 0);
                    heap[-h[1]]++;
                }
                else
                {
                    //the height must be inserted by left side of building so, decrease it by 1
                    heap[h[1]]--;
                    if (heap[h[1]] <= 0)
                        heap.Remove(h[1]);
                }

                int cur = heap.First().Key;
                if (pre != cur)
                {
                    result.Add(new List<int>() { h[0], cur });
                    pre = cur;
                }
            }
            return result;
        }
    }
}


/*                  *****LEETCODE SOLUTION SAME AS ABOVE BUT WITH COMMENTS*****
 public class Solution {
    public IList<IList<int>> GetSkyline(int[][] buildings) 
    {
        var height = new List<IList<int>>();
        
        
        // collect all vertcal building edges
        for(int i=0; i<buildings.Length; i++)
        {
			// left building edge (make it NEGATIVE so we can identify it first)
            height.Add(new int[]{buildings[i][0], -buildings[i][2]});
            // right building edge
            height.Add(new int[]{buildings[i][1],  buildings[i][2]});
        }        
        height.Sort((a,b)=>{
			// sort by vertcal building edge order
            if(a[0] != b[0])
            {
                return a[0].CompareTo(b[0]);
            }
            // if 2 buiding share edge
            // let shorter buildings go first
            // let left buiding edge go first (because it is negative)
            return a[1].CompareTo(b[1]);
        });
        var result = new List<IList<int>>();
		// note that the dictionary is MAX heap so that the first is the fallest
        var sd = new SortedDictionary<int, int>(Comparer<int>.Create((a,b)=>-a.CompareTo(b)));
        
        sd.Add(0, 0);
        var pre = 0;
        // for each buiding edge in order left to right
        foreach(var h in height)
        {
			// if this is left edhe
            if(h[1]<0)
            {
				// store height in dictionary as positive (reverse negative)
                if(!sd.ContainsKey(-h[1]))
                {
                    sd[-h[1]] = 0;
                }
                // increment for that height
                sd[-h[1]]++;
            }
            else // if this is right edge
            {
				// the hight must already been registered so decrement it
                sd[h[1]]--;
                // remove it for already passed any with that height
                if(sd[h[1]] <= 0)
                {
                     sd.Remove(h[1]);
                }
            }
            
            // get the tallest so far
            int cur = sd.First().Key;
            if(pre != cur)
            {
				// record it
                result.Add(new int[]{h[0], cur});
                pre =cur;
            }
        }
        return result;
    }
}*/
