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
using System.Xml;

namespace PreperationsTest.Algorithms.GreedyMethods.Huffman
{
    [TestClass]
    public class HuffmanEnCoding
    {
        [TestMethod]
        public void Run()
        {
            //char[] arr = { 'a', 'b', 'c', 'd', 'e', 'f' };
            //uint[] freq = { 5, 9, 12, 13, 16, 45 };

            Dictionary<char, int> dict = new Dictionary<char, int>();
            dict.Add('a', 5);
            dict.Add('b', 9);
            dict.Add('c', 12);
            dict.Add('d', 13);
            dict.Add('e', 16);
            dict.Add('f', 45);

            HuffmanCodes(dict, "");
        }

        public string EncodedString { get; set; }

        private string originalMessage { get; set; }

        // To map each character its Huffman value
        public readonly Dictionary<char, string> HuffManCodesTable = new Dictionary<char, string>();

        public SortedSet<MinHeapNode> minHeap = new SortedSet<MinHeapNode>(new compareMinHeapNode());

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
        public void HuffmanCodes(Dictionary<char, int> freqDict, string message)
        {
            // Step1: Initialize a SortedSet - MinHeap with comparer, left right and top nodes
            MinHeapNode left;
            MinHeapNode right;
            MinHeapNode top;
            originalMessage = message;

            // Step2: Add values to the sorted set minheap
            foreach (var item in freqDict)
            {
                minHeap.Add(new MinHeapNode(item.Key, item.Value));
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
            PrintMinHeapRecusion(minHeap.Min, ""); /*root*/

            EncodeMessage(originalMessage);
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
                HuffManCodesTable[root.Data] = str;
            }

            // Traverse left node: assigning 0 for left nodes
            PrintMinHeapRecusion(root.Left, str + "0");

            // Traverse right node: assigning 1 for right nodes
            PrintMinHeapRecusion(root.Right, str + "1");
        }

        public void EncodeMessage(string oriMessage)
        {
            if (oriMessage == null)
            {
                return;
            }

            foreach (char c in oriMessage)
            {
                EncodedString += HuffManCodesTable[c];
            }
        }

        #region Comparer
        public class compareMinHeapNode : IComparer<MinHeapNode>
        {
            public int Compare(MinHeapNode x, MinHeapNode y)
            {
                int freqComparison = x.Freq.CompareTo(y.Freq);
                if (freqComparison == 0)
                {
                    int dataComparison = x.Data.CompareTo(y.Data); // Compare by key if frequencies are equal
                    if (dataComparison == 0)
                    {
                        int leftComparison = CompareNodes(x.Left, y.Left);
                        if (leftComparison == 0)
                        {
                            return CompareNodes(x.Right, y.Right);
                        }
                        return leftComparison;
                    }
                    return dataComparison;
                }
                return freqComparison;

            }

            /// <summary>
            /// W are into left and right nodes where both parents nodes are "$ and sameFrequency"
            /// Again compare its freq and data
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public int CompareNodes(MinHeapNode x, MinHeapNode y)
            {
                if (x == null && y == null) return 0;
                if (x == null) return -1;
                if (y == null) return 1;
                int freqComparison = x.Freq.CompareTo(y.Freq);
                if (freqComparison == 0)
                {
                    return x.Data.CompareTo(y.Data);
                }
                return freqComparison;
            }



            // Fails to add the row to minheap, when data and freq both are same for x and y, but left and right are still different
            //public int Compare(MinHeapNode x, MinHeapNode y)
            //{
            //    int freqComparison = x.Freq.CompareTo(y.Freq);
            //    if (freqComparison == 0)
            //    {
            //        return x.Data.CompareTo(y.Data); // Compare by key if frequencies are equal
            //    }
            //    return freqComparison;
            //}

            // Fails to add the row to minheap, when the 'Freq' is same but 'Data' is differnet
            //public int Compare(MinHeapNode x, MinHeapNode y)
            //{
            //    int freqComparison = x.Freq.CompareTo(y.Freq);
            //    return freqComparison;
            //}
        }
        #endregion
    }
}