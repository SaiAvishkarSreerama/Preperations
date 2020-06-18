using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AviPreperation.Data_Structures.Trie
{
    //My Solution from the below one but failing to submit
    public class TrieNode
    {
        public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
        public List<string> matches = new List<string>();

        public TrieNode() { }

        public TrieNode(string match)
        {
            matches.Add(match);
        }
    }

    public class AutocompleteSystem
    {
        private TrieNode root;
        private TrieNode node;
        private Dictionary<string, int> history;
        private string prefix;

        public AutocompleteSystem(string[] sentences, int[] times)
        {
            root = new TrieNode();
            node = root;
            history = new Dictionary<string, int>();
            prefix = string.Empty;

            for (int i = 0; i < sentences.Length; i++)
            {
                history.Add(sentences[i], times[i]);
                InsertTrie(sentences[i]);
            }
        }

        public IList<string> Input(char c)
        {
            List<string> top3 = new List<string>();

            if (c == '#')
            {
                ResetSearch();
                return top3;
            }

            prefix += c;

            if (node == null)
                return top3;
            if (!node.children.TryGetValue(c, out node))
                return top3;
            return node.matches
                .OrderByDescending(match => history[match])
                .ThenBy(match => match, StringComparer.Ordinal)
                .Take(3)
                .ToList();
        }

        public void ResetSearch()
        {
            if (history.ContainsKey(prefix))
                history[prefix]++;
            else
            {
                history.Add(prefix, 1);
                InsertTrie(prefix);
            }

            //reset the variables
            prefix = string.Empty;
            node = root;
        }

        //Inserting word into Trie DS
        public void InsertTrie(string word)
        {
            TrieNode cur = root;
            // Console.WriteLine(cur.children.Count);
            foreach (char c in word)
            {
                if (!cur.children.ContainsKey(c))
                    cur.children.Add(c, new TrieNode());
                cur = cur.children[c];
                cur.matches.Add(word);
            }
        }
    }


    ///**
    //    * Your AutocompleteSystem object will be instantiated and called as such:
    //    * AutocompleteSystem obj = new AutocompleteSystem(sentences, times);
    //    * IList<string> param_1 = obj.Input(c);
    //    */
    //public class MainClass
    //{
    //    //public static void Main()
    //    //{
    //    //    string[] sentences = new string[] { "i love you", "island", "iroman", "i love leetcode" };
    //    //    int[] time = new int[] { 5, 3, 2, 2 };
    //    //    AutocompleteSystem obj = new AutocompleteSystem(sentences, time);

    //    //    obj.Input('i');
    //    //    obj.Input(' ');
    //    //    obj.Input('a');
    //    //    obj.Input('#');
    //    //}
    //    public static void Main()
    //    {
    //        string[] sentences = new string[] { "i love you", "island", "iroman", "i love leetcode" };
    //        int[] time = new int[] { 5, 3, 2, 2 };
    //        AutocompleteSystem obj = new AutocompleteSystem(sentences, time);

    //        obj.Input('w');
    //        obj.Input('i');
    //        obj.Input(' ');
    //        obj.Input('a');
    //        obj.Input('#');
    //        obj.Input('i');
    //        obj.Input(' ');
    //        obj.Input('a');
    //        obj.Input('#');
    //        obj.Input('i');
    //        obj.Input(' ');
    //        obj.Input('a');
    //        obj.Input('#');
    //    }
    //}

    /**********************************RECCOMENDED SOLUTION********************************/
    //public class AutocompleteSystem
    //{
    //    private AutocompleteNode _trie;
    //    private IDictionary<string, int> _history;

    //    private string _sentence;
    //    private AutocompleteNode _node;

    //    public AutocompleteSystem(
    //        string[] sentences,
    //        int[] times)
    //    {
    //        _trie = new AutocompleteNode();

    //        _history = new Dictionary<string, int>();

    //        _node = _trie;

    //        _sentence = string.Empty;

    //        for (int index = 0; index < sentences.Length; index++)
    //        {
    //            var sentence = sentences[index];

    //            var time = times[index];

    //            _history.Add(sentence, time);

    //            Insert(_trie, sentence, sentence);
    //        }
    //    }

    //    private void Reset()
    //    {
    //        if (_history.ContainsKey(_sentence))
    //        {
    //            _history[_sentence]++;
    //        }
    //        else
    //        {
    //            _history.Add(_sentence, 1);

    //            Insert(_trie, _sentence, _sentence);
    //        }

    //        _sentence = string.Empty;

    //        _node = _trie;
    //    }

    //    public IList<string> Input(char c)
    //    {
    //        var list = new List<string>();

    //        if (c == '#')
    //        {
    //            Reset();

    //            return list;
    //        }

    //        _sentence += c;

    //        if (_node == null)
    //        {
    //            return list;
    //        }

    //        if (!_node.Children.TryGetValue(c, out _node))
    //        {
    //            return list;
    //        }

    //        return _node.Matches
    //            .OrderByDescending(match => _history[match])
    //            .ThenBy(match => match, StringComparer.Ordinal)
    //            .Take(3)
    //            .ToList();
    //    }

    //    private static void Insert(
    //        AutocompleteNode node,
    //        string word,
    //        string match)
    //    {
    //        if (string.IsNullOrEmpty(word))
    //        {
    //            return;
    //        }

    //        if (!node.Children.TryGetValue(word[0], out var child))
    //        {
    //            child = new AutocompleteNode(match);

    //            node.Children.Add(word[0], child);
    //        }
    //        else
    //        {
    //            child.Matches.Add(match);
    //        }

    //        Insert(child, word.Substring(1), match);
    //    }
    //}

    //public class AutocompleteNode
    //{
    //    public IDictionary<char, AutocompleteNode> Children;
    //    public IList<string> Matches;

    //    public AutocompleteNode()
    //        : this(new List<string>())
    //    {
    //    }

    //    public AutocompleteNode(string match)
    //        : this(new List<string> { match })
    //    {
    //    }

    //    public AutocompleteNode(IList<string> matches)
    //    {
    //        Children = new Dictionary<char, AutocompleteNode>();
    //        Matches = matches;
    //    }
    //}

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
