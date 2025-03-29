/*
 * Huffman Codes: Are used to encode the message with least no of bits
 * Time Complexity: O(N logN)
 *      Sorting the min heap - O(N logN)
 *      Traversing the heap branches - O(logN)
 *      ExtractMin takes O(logN), as it calls Heapify()
 *  Space Complexity - O(N)
 *      Memory usage for storing minHeap
 */

using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Extensions;
using System.Collections;

namespace PreperationsTest.Algorithms.GreedyMethods
{
    [TestClass]
    public class HuffmanCoding
    {
        [TestMethod]
        public void Run()
        {
            char[] arr = { 'a', 'b', 'c', 'd', 'e', 'f' };
            uint[] freq = { 5, 9, 12, 13, 16, 45 };

            int size = arr.Length;
            HuffmanCodes(arr, freq, size);
        }

        public string ReturnString { get; set; }

        public class MinHeapNode
        {
            public MinHeapNode Left { get; set; }
            public MinHeapNode Right { get; set; }
            public char Data { get; set; }
            public int Freq { get; set; }
            public MinHeapNode(char d, int f)
            {
                Data = d;
                Freq = f;
                Left = null;
                Right = null;
            }
        }
        public class compareMinHeapNode : IComparer<MinHeapNode>
        {
            public int Compare(MinHeapNode x, MinHeapNode y)
            {
                return x.Freq.CompareTo(y.Freq);
            }
        }

        /// <summary>
        /// Huffman Coding steps
        /// 1. Initialize a SortedSet - MinHeap with comparer, left right and top nodes
        /// 2: Add values to the sorted set minheap
        /// 3: Iterate minheap
        ///     1: get top 2 min values as left and right
        ///     2: Add left and right as top to minheap, and let the internal node distiguish as data=$ instead of data characters
        /// 4: Print the minheap with a recursive call that recursively traverse the tree and print the characters and codes
        ///     For this assign 0 to left recursion and 1 to right recursion branches
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="freq"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public void HuffmanCodes(char[] data, uint[] freq, int size)
        {
            // Step1: Initialize a SortedSet - MinHeap with comparer, left right and top nodes
            SortedSet<MinHeapNode> minHeap = new SortedSet<MinHeapNode>(new compareMinHeapNode());
            MinHeapNode left;
            MinHeapNode right;
            MinHeapNode top;

            // Step2: Add values to the sorted set minheap
            for (int i = 0; i < size; i++)
            {
                minHeap.Add(new MinHeapNode(data[i], (int)freq[i]));
            }

            // Step3: Iterate minheap
            while (minHeap.Count > 1)
            {
                // Step 3.1: get top 2 min values as left and right
                left = minHeap.Min;
                minHeap.Remove(left);

                right = minHeap.Min;
                minHeap.Remove(right);

                // Step 3.2: Add left and right as top to minheap, and let the internal node distiguish as data=$ instead of data characters
                top = new MinHeapNode('$', left.Freq + right.Freq);
                top.Left = left;
                top.Right = right;

                minHeap.Add(top);
            }

            // Step4: Print the minheap with a recursive call that recursively traverse the tree and print the characters and codes
            // For this assign 0 to left recursion and 1 to right recursion branches
            PrintMinHeapRecusion(minHeap.Min /*root*/, "");
        }


        public void PrintMinHeapRecusion(MinHeapNode root, string str)
        {
            // return if root is null
            if (root == null)
            {
                return;
            }

            // when reaching the leaf node, which has data[i] char assigned to node
            // returning the data: string
            if (root.Data != '$')
            {
                ReturnString += root.Data + ": " + str +";  ";
            }

            // Traverse left node: assigning 0 for left nodes
            PrintMinHeapRecusion(root.Left, str + "0");
            
            // Traverse right node: assigning 1 for right nodes
            PrintMinHeapRecusion(root.Right, str + "1");
        }
    }
}
