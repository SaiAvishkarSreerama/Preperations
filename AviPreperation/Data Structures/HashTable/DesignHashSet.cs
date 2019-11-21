using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.HashTable
{
    public class MyHashSet
    {
        //To avoid the collision, consider a List of Lists;
        public List<List<int>> list;

        /** Initialize your data structure here. */
        public MyHashSet()
        {
            list = new List<List<int>>();

            //Initialize the list
            for (int i = 0; i < 10; i++)
            {
                List<int> s = new List<int>();
                list.Add(s);
            }
        }

        public void Add(int key)
        {
            List<int> subList = new List<int>();
            subList.Add(key);
            int h = Hash(key); //return the hash key

            //If the key is not already exists
            if (!Contains(key))
            {
                //If the sub list is empty
                if (list[h].Count == 0)
                {
                    list[h] = subList;
                }
                else
                {
                    //Add the value to end of the subList
                    List<int> s = list[h];
                    s.Add(key);
                    list[h] = s;
                }
            }
        }

        public void Remove(int key)
        {
            int h = Hash(key);
            int index = -1;
            //If key presents then find the index of the key
            if (Contains(key))
            {
                for (int i = 0; i < list[h].Count; i++)
                {
                    if (list[h][i] == key)
                    {
                        index = i;
                        break;
                    }
                }
            }

            //Remove the key at index
            if (index > -1)
                list[h].RemoveAt(index);
        }

        /** Returns true if this set contains the specified element */
        public bool Contains(int key)
        {
            int h = Hash(key);
            //looping and finding if the key exists in the hash
            for (int i = 0; i < list[h].Count; i++)
            {
                if (list[h][i] == key)
                {
                    return true;
                }
            }
            return false;
        }

        //HashFunction() - Method return the hash value for the key
        public int Hash(int key)
        {
            //considering 10 size list
            return key % 10;
        }
    }

    /**
     * Your MyHashSet object will be instantiated and called as such:
     * MyHashSet obj = new MyHashSet();
     * obj.Add(key);
     * obj.Remove(key);
     * bool param_3 = obj.Contains(key);
     */
}
