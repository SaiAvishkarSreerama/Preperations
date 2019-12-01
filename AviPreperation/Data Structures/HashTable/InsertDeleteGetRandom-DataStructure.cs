using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.HashTable
{
    public class RandomizedSet
    {
        Dictionary<int, int> d;
        List<int> list;
        Random rand = new Random();
        /** Initialize your data structure here. */
        public RandomizedSet()
        {
            d = new Dictionary<int, int>();
            list = new List<int>();
        }

        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val)
        {
            if (d.ContainsKey(val))
                return false;

            d.Add(val, list.Count);
            list.Add(val);
            return true;
        }

        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public bool Remove(int val)
        {
            if (!d.ContainsKey(val))
                return false;

            //move the last value to the deleted position
            int indexToRemove = d[val]; //10 - index 0
            int positionToRemove = list[list.Count - 1]; //40

            list[indexToRemove] = positionToRemove;
            d[positionToRemove] = d[val];
            d.Remove(val);

            list.RemoveAt(list.Count - 1);
            return true;
        }

        /** Get a random element from the set. */
        public int GetRandom()
        {
            return list[rand.Next(0, list.Count - 1)];
        }
    }

    /**
     * Your RandomizedSet object will be instantiated and called as such:
     * RandomizedSet obj = new RandomizedSet();
     * bool param_1 = obj.Insert(val);
     * bool param_2 = obj.Remove(val);
     * int param_3 = obj.GetRandom();
     */
}
