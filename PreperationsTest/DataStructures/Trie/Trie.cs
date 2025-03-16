namespace PreperationsTest.DataStructures.Trie
{
    public class Trie
    {
        public Trie[] childNode { get; set; }
        public int wordCount { get; set; }
        public Trie()
        {
            wordCount = 0;
            childNode = new Trie[26];

            //for (int i = 0; i < 26; i++)
            //{
            //    childNode[i] = null;
            //}
        }
    }
}
