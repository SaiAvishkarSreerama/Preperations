/*
 * Huffman Encoder: Assigns prefix codes for the characters based on their frequecies
 * Huffman Decoder: Extracts the message(characters) from the prefix code that are assigned during the encoder
 */

using System.Collections;
using static PreperationsTest.Algorithms.GreedyMethods.Huffman.HuffmanEnCoding;

namespace PreperationsTest.Algorithms.GreedyMethods.Huffman
{
    [TestClass]
    public class HuffmanDecoding
    {
        [TestMethod]
        public void Run()
        {
            // Encode a message 
            string message = "This preparation is for my better future...";

            // prepare the frequency array
            FrequencyArrayBuilder(message);

            // Huffman Encoder
            HuffmanEnCoding hmanEncode = new HuffmanEnCoding();
            hmanEncode.HuffmanCodes(FreqDict, message);

            // Huffman Decoder
            string decodedMessage = HuffmanDecoder(hmanEncode.minHeap.Min, hmanEncode.EncodedString, hmanEncode.HuffManCodesTable);
        }

        public Dictionary<char, int> FreqDict { get; set; }
        public void FrequencyArrayBuilder(string msg)
        {
            FreqDict = new Dictionary<char, int>();
            int n = msg.Length;

            for (int i = 0; i < n; i++)
            {
                if (!FreqDict.ContainsKey(msg[i]))
                {
                    FreqDict[msg[i]] = 0;
                }
                FreqDict[msg[i]]++;
            }
        }

        public string HuffmanDecoder(MinHeapNode root, string enodedMesage, Dictionary<char, string> codeTable)
        {
            string DecodedMessage = "";
            MinHeapNode current = root;
            foreach(char c in enodedMesage)
            {
                if( c == '0')
                {
                   current = current.Left;
                }
                else
                {
                    current = current.Right;
                }

                //if (current.Left == null && current.Right == null) 
                    // OR
                if(current.Data != '$')
                {
                    DecodedMessage += current.Data;
                    current = root;
                }
            }

            return DecodedMessage;
        }
    }
}
