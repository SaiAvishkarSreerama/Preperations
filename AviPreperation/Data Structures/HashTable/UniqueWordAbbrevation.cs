using System;
using System.Collections.Generic;
using System.Text;
/*
*  An abbreviation of a word follows the form <first letter><number><last letter>. Below are some examples of word abbreviations:
* 
* a) it                      --> it    (no abbreviation)
* 
*      1
*      ↓
* b) d|o|g                   --> d1g
* 
*               1    1  1
*      1---5----0----5--8
*      ↓   ↓    ↓    ↓  ↓    
* c) i|nternationalizatio|n  --> i18n
* 
*               1
*      1---5----0
*      ↓   ↓    ↓
* d) l|ocalizatio|n          --> l10n
* Assume you have a dictionary and given a word, find whether its abbreviation is unique in the dictionary. A word's abbreviation is unique if no other word from the dictionary has the same abbreviation.
* 
* Example:
* 
* Given dictionary = [ "deer", "door", "cake", "card" ]
* 
* isUnique("dear") -> false
* isUnique("cart") -> true
* isUnique("cane") -> false
* isUnique("make") -> true
*/
namespace AviPreperation.Data_Structures.HashTable
{
    //Time complexity : O(n) pre-processing, O(1) for each isUnique call. Both Approach #2 and Approach #3 above take O(n) pre-processing time in the constructor. This is totally worth it if isUnique is called repeatedly.

    //Space complexity : O(n). We traded the extra O(n) space storing the table to reduce the time complexity in isUnique.

    public class ValidWordAbbr
    {
        HashSet<string> h;
        Dictionary<string, bool> d;


        public ValidWordAbbr(string[] dictionary)
        {
            h = new HashSet<string>(dictionary);
            d = new Dictionary<string, bool>();

            foreach (string s in h)
            {
                string key = GenerateKey(s);

                if (d.ContainsKey(key))
                {
                    d[key] = false;
                }
                else
                    d.Add(key, true);
            }
        }

        public bool IsUnique(string word)
        {
            string key = GenerateKey(word);
            return !d.ContainsKey(key) || (h.Contains(word) && d[key]);
        }

        public string GenerateKey(string s)
        {
            if (s.Length < 3)
                return s;

            int val = (s.Length - 2);
            return s[0] + val.ToString() + s[s.Length - 1];
        }
    }

    /**
     * Your ValidWordAbbr object will be instantiated and called as such:
     * ValidWordAbbr obj = new ValidWordAbbr(dictionary);
     * bool param_1 = obj.IsUnique(word);
     */
}
