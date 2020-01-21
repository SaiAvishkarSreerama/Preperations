using System;
using System.Collections.Generic;
using System.Text;
/*
*  Given a paragraph and a list of banned words, return the most frequent word that is not in the list of banned words.  It is guaranteed there is at least one word that isn't banned, and that the answer is unique.
* Words in the list of banned words are given in lowercase, and free of punctuation.  Words in the paragraph are not case sensitive.  The answer is in lowercase.
* 
* Example:
* Input: 
* paragraph = "Bob hit a ball, the hit BALL flew far after it was hit."
* banned = ["hit"]
* Output: "ball"
* 
* Explanation: 
* "hit" occurs 3 times, but it is a banned word.
* "ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph. 
* Note that words in the paragraph are not case sensitive,
* that punctuation is ignored (even if adjacent to words, such as "ball,"), 
* and that "hit" isn't the answer even though it occurs more because it is banned.
*  
* 
* Note:
* 1 <= paragraph.length <= 1000.
* 0 <= banned.length <= 100.
* 1 <= banned[i].length <= 10.
* The answer is unique, and written in lowercase (even if its occurrences in paragraph may have uppercase symbols, and even if it is a proper noun.)
* paragraph only consists of letters, spaces, or the punctuation symbols !?',;.
* There are no hyphens or hyphenated words.
* Words only consist of letters, never apostrophes or other punctuation symbols.
* */
namespace AviPreperation.Data_Structures.String
{
    public class MostCommonWordSolution
    {
        //Time Complexity - O(P + B), P-paragraph size, B-Banned size
        //Space Complexity - O(P + B), to store info of p and b
        public string MostCommonWord(string paragraph, string[] banned)
        {
            //Adding special char to paragraph, if p = "bob", it wont go to else if condition
            paragraph += ".";
            //Add banned list to hashset 
            HashSet<string> bannedSet = new HashSet<string>();
            foreach (string s in banned)
                bannedSet.Add(s);

            //ans and its count
            string ans = "";
            int ansCount = 0;

            //dictionary to count the most appear words
            Dictionary<string, int> d = new Dictionary<string, int>();

            //loops through each char and find each word
            StringBuilder word = new StringBuilder();

            foreach (char c in paragraph)
            {
                //if letter then add to word
                if (char.IsLetter(c))
                {
                    word.Append(char.ToLower(c));
                }
                else if (word.Length > 0)
                {
                    string sb = word.ToString();
                    //if not consists in banned list
                    if (!bannedSet.Contains(sb))
                    {
                        //add to dictionary and increment its counter
                        if (!d.ContainsKey(sb))
                        {
                            d.Add(sb, 1);
                        }
                        else
                            d[sb]++;
                        //check the current word count and update to ans
                        if (ansCount < d[sb])
                        {
                            ansCount = d[sb];
                            ans = sb;
                        }
                    }
                    word = new StringBuilder();
                }
            }
            return ans;
        }
    }
}
