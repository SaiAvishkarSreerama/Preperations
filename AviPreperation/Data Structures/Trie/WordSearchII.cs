using System;
using System.Collections.Generic;
using System.Text;
/*
*  Given a 2D board and a list of words from the dictionary, find all words in the board.
* 
* Each word must be constructed from letters of sequentially adjacent cell, where "adjacent" cells are those horizontally or vertically neighboring. The same letter cell may not be used more than once in a word.
* 
*  
* 
* Example:
* 
* Input: 
* board = [
*   ['o','a','a','n'],
*   ['e','t','a','e'],
*   ['i','h','k','r'],
*   ['i','f','l','v']
* ]
* words = ["oath","pea","eat","rain"]
* 
* Output: ["eat","oath"]
*  
* 
* Note:
* 
* All inputs are consist of lowercase letters a-z.
* The values of words are distinct.
* */
namespace AviPreperation.Data_Structures.Trie
{
    public class WordSearchIISolution
    {
        //Trie + BackTracking
        public class TrieNode
        {
            public TrieNode[] children = new TrieNode[26];
            public string isWord;
        }

        public IList<string> FindWords(char[][] board, string[] words)
        {
            List<string> result = new List<string>();
            TrieNode root = BuildTrie(words);
            for (int r = 0; r < board.Length; r++)
            {
                for (int c = 0; c < board[0].Length; c++)
                {
                    Dfs(board, r, c, root, result);
                }
            }
            return result;
        }

        public void Dfs(char[][] board, int r, int c, TrieNode cur, List<string> result)
        {
            if (r < 0 || c < 0 || r >= board.Length || c >= board[0].Length)
                return;

            char ch = board[r][c];
            if (ch == '#' || cur.children[ch - 'a'] == null)
                return;
            cur = cur.children[ch - 'a'];

            if (cur.isWord != null)
            {
                result.Add(cur.isWord);
                cur.isWord = null;
            }

            board[r][c] = '#';

            Dfs(board, r - 1, c, cur, result);
            Dfs(board, r, c - 1, cur, result);
            Dfs(board, r + 1, c, cur, result);
            Dfs(board, r, c + 1, cur, result);

            board[r][c] = ch;
        }

        public TrieNode BuildTrie(string[] words)
        {
            TrieNode root = new TrieNode();
            foreach (string w in words)
            {
                TrieNode cur = root;
                foreach (char c in w)
                {
                    if (cur.children[c - 'a'] == null)
                        cur.children[c - 'a'] = new TrieNode();
                    cur = cur.children[c - 'a'];
                }
                cur.isWord = w;
            }
            return root;
        }
    }
    public class MainClass
    {
        public static void Main()
        {
            char[][] board = new char[4][]
            {
               new char[]{'o','a','a','n'},
               new char[]{'e','t','a','e'},
               new char[]{'i','h','k','r'},
               new char[]{'i','f','l','v'},
            };
            string[] words = new string[] { "oath", "pea", "eat", "rain" };
            var obj = new WordSearchIISolution();
            Console.WriteLine(obj.FindWords(board, words));
        }
    }
}
