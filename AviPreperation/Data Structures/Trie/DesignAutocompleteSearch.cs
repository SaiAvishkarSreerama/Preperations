using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AviPreperation.Data_Structures.Trie
{
    //My Solution from the below one but failing to submit
    //public class AutocompleteSystem
    //{
    //    //Global variables
    //    public string prefix;
    //    public TrieNode root;
    //    public Dictionary<string, int> dict;
    //    public TrieNode node;

    //    //TrieNode class
    //    public class TrieNode
    //    {
    //        public Dictionary<char, TrieNode> children;
    //        public List<string> matches;

    //        public TrieNode()
    //        {
    //            children = new Dictionary<char, TrieNode>();
    //            matches = new List<string>();
    //        }

    //        public TrieNode(string match)
    //        {
    //            matches = new List<string> { match };
    //        }

    //        public TrieNode(List<string> match)
    //        {
    //            children = new Dictionary<char, TrieNode>();
    //            matches = match;
    //        }
    //    }


    //    public AutocompleteSystem(string[] sentences, int[] times)
    //    {
    //        dict = new Dictionary<string, int>();
    //        root = new TrieNode();
    //        prefix = "";
    //        node = root;

    //        for (int i = 0; i < sentences.Length; i++)
    //        {
    //            //Add the word-times into dictionary
    //            dict.Add(sentences[i], times[i]);

    //            //create a trienode
    //            InsertWord(sentences[i]);
    //            //InsertWord_recursion(node, sentences[i], sentences[i]);
    //        }
    //    }

    //    //Insert Word to the root - TrieNode
    //    public void InsertWord(string word)
    //    {
    //        TrieNode cur = root;
    //        foreach (char c in word)
    //        {
    //            if (!cur.children.ContainsKey(c))
    //            {
    //                cur.children.Add(c, new TrieNode());
    //            }
    //            //Adding the words to each node of the root as a list
    //            cur.matches.Add(word);
    //            cur = cur.children[c];
    //        }
    //    }

    //    //public void InsertWord_recursion(TrieNode cur, string word, string match)
    //    //{
    //    //    if (string.IsNullOrEmpty(word))
    //    //        return;

    //    //    if (!cur.children.TryGetValue(word[0], out var child))
    //    //    {
    //    //        child = new TrieNode(match);
    //    //        cur.children.Add(word[0],child);
    //    //    }
    //    //    else { 
    //    //        //Adding the words to each node of the root as a list
    //    //        child.matches.Add(match);
    //    //    }

    //    //    InsertWord_recursion(cur, word.Substring(1), match);
    //    //}

    //    public IList<string> Input(char c)
    //    {
    //        List<string> list = new List<string>();

    //        if (c == '#')
    //        {
    //            //# means the search keyword end, so we need to add the keyword to Trie and dict
    //            ResetKeyWord();
    //            return list;
    //        }

    //        //maintaining the search characters in prefix.
    //        prefix += c;

    //        if (!node.children.TryGetValue(c, out node))
    //            return list;

    //        return node.matches.OrderByDescending(m => dict[m]).ThenBy(match => match, StringComparer.Ordinal)
    //            .Take(3).ToList();
    //    }

    //    public void ResetKeyWord()
    //    {
    //        if (dict.ContainsKey(prefix))
    //        {
    //            dict[prefix]++;
    //        }
    //        else
    //        {
    //            //Add to dict
    //            dict.Add(prefix, 1);
    //            //Insert the keyword to the Root and dict
    //            //InsertWord_recursion(node, prefix, prefix); 
    //            InsertWord(prefix);
    //        }
    //        prefix = "";
    //        node = root;
    //    }
    //}

    ///**
    //    * Your AutocompleteSystem object will be instantiated and called as such:
    //    * AutocompleteSystem obj = new AutocompleteSystem(sentences, times);
    //    * IList<string> param_1 = obj.Input(c);
    //    */
    //public class MainClass
    //{
    //    public static void Main()
    //    {
    //        string[] sentences = new string[] { "i love you", "island", "iroman", "i love leetcode" };
    //        int[] time = new int[] { 5, 3, 2, 2 };
    //        AutocompleteSystem obj = new AutocompleteSystem(sentences, time);

    //        obj.Input('i');
    //        obj.Input(' ');
    //        obj.Input('a');
    //        obj.Input('#');
    //    }
    //}

    /**********************************RECCOMENDED SOLUTION********************************/
    public class AutocompleteSystem
    {
        private AutocompleteNode _trie;
        private IDictionary<string, int> _history;

        private string _sentence;
        private AutocompleteNode _node;

        public AutocompleteSystem(
            string[] sentences,
            int[] times)
        {
            _trie = new AutocompleteNode();

            _history = new Dictionary<string, int>();

            _node = _trie;

            _sentence = string.Empty;

            for (int index = 0; index < sentences.Length; index++)
            {
                var sentence = sentences[index];

                var time = times[index];

                _history.Add(sentence, time);

                Insert(_trie, sentence, sentence);
            }
        }

        private void Reset()
        {
            if (_history.ContainsKey(_sentence))
            {
                _history[_sentence]++;
            }
            else
            {
                _history.Add(_sentence, 1);

                Insert(_trie, _sentence, _sentence);
            }

            _sentence = string.Empty;

            _node = _trie;
        }

        public IList<string> Input(char c)
        {
            var list = new List<string>();

            if (c == '#')
            {
                Reset();

                return list;
            }

            _sentence += c;

            if (_node == null)
            {
                return list;
            }

            if (!_node.Children.TryGetValue(c, out _node))
            {
                return list;
            }

            return _node.Matches
                .OrderByDescending(match => _history[match])
                .ThenBy(match => match, StringComparer.Ordinal)
                .Take(3)
                .ToList();
        }

        private static void Insert(
            AutocompleteNode node,
            string word,
            string match)
        {
            if (string.IsNullOrEmpty(word))
            {
                return;
            }

            if (!node.Children.TryGetValue(word[0], out var child))
            {
                child = new AutocompleteNode(match);

                node.Children.Add(word[0], child);
            }
            else
            {
                child.Matches.Add(match);
            }

            Insert(child, word.Substring(1), match);
        }
    }

    public class AutocompleteNode
    {
        public IDictionary<char, AutocompleteNode> Children;
        public IList<string> Matches;

        public AutocompleteNode()
            : this(new List<string>())
        {
        }

        public AutocompleteNode(string match)
            : this(new List<string> { match })
        {
        }

        public AutocompleteNode(IList<string> matches)
        {
            Children = new Dictionary<char, AutocompleteNode>();
            Matches = matches;
        }
    }

    //public class MainClass
    //{
    //    public static void Main()
    //    {
    //        string[] sentences = new string[] { "i love you", "island", "iroman", "i love leetcode" };
    //        int[] time = new int[] { 5, 3, 2, 2 };
    //        AutocompleteSystem obj = new AutocompleteSystem(sentences, time);

    //        obj.Input('i');
    //        obj.Input(' ');
    //        obj.Input('a');
    //        obj.Input('#');
    //    }
    //}

}
