using System;
using System.Collections.Generic;
using System.Text;
/*
*  Design and implement a data structure for Least Recently Used (LRU) cache. It should support the following operations: get and put.
* 
* get(key) - Get the value (will always be positive) of the key if the key exists in the cache, otherwise return -1.
* put(key, value) - Set or insert the value if the key is not already present. When the cache reached its capacity, it should invalidate the least recently used item before inserting a new item.
* 
* The cache is initialized with a positive capacity.
* 
* Follow up:
* Could you do both operations in O(1) time complexity?
* 
* Example:
* 
* LRUCache cache = new LRUCache( 2  ==> capacity  );
* 
* cache.put(1, 1);
* cache.put(2, 2);
* cache.get(1);       // returns 1
* cache.put(3, 3);    // evicts key 2
* cache.get(2);       // returns -1 (not found)
* cache.put(4, 4);    // evicts key 1
* cache.get(1);       // returns -1 (not found)
* cache.get(3);       // returns 3
* cache.get(4);       // returns 4
*/
namespace AviPreperation.Data_Structures.HashTable
{
    public class LRUCache
    {
        //Using a Hashtable gives fast lookup
        //Using a doubly linked list gives fast removals
        //Time Complexity - O(1)
        //Space Complexity - O(n)

        //Initial Doubly Linked List
        public class ListNode
        {
            public int key;
            public int val;
            public ListNode prev;
            public ListNode next;

            public ListNode() { }
        }

        //Declare Global variables
        Dictionary<int, ListNode> h;
        int size;
        int maxCapacity;
        ListNode head;
        ListNode tail;

        //Constructor
        public LRUCache(int capacity)
        {
            h = new Dictionary<int, ListNode>();
            size = 0;
            maxCapacity = capacity;
            head = new ListNode();
            tail = new ListNode();

            head.next = tail;
            tail.prev = head;
        }

        //GET Method
        //If no key found in h- return -1
        //If key found in h- Move that node to front, return the value of node
        public int Get(int key)
        {
            if (!h.ContainsKey(key))
            {
                return -1;
            }
            else
            {
                ListNode node = h[key];
                MoveToFront(node);
                return node.val;
            }
        }

        //PUT Method
        //If no key - create a node, push to h, add that node at front, increment size
        //If size > maxCapacity, Remove the least recently used key from the list
        //If key - take the node from h, update the value, move the node to front, no size increments
        public void Put(int key, int value)
        {
            if (!h.ContainsKey(key))
            {
                ListNode node = new ListNode();
                node.key = key;
                node.val = value;

                h.Add(key, node);
                AddToFront(node);
                size++;

                if (size > maxCapacity)
                {
                    RemoveLRUCache();
                }
            }
            else
            {
                ListNode node = h[key];
                node.val = value;
                MoveToFront(node);
            }
        }

        //To add to front, head-->node-->next.....-->tail
        public void AddToFront(ListNode node)
        {
            ListNode next = head.next;
            node.prev = head;
            node.next = next;
            next.prev = node;
            head.next = node;
        }

        //find the node(key) prev to tail, to remove from h and decrement size
        public void RemoveLRUCache()
        {
            ListNode tailPrev = PopTail();
            h.Remove(tailPrev.key);
        }

        //return the prev node of tail and remove that node from the linked list
        public ListNode PopTail()
        {
            ListNode node = tail.prev;

            RemoveFromList(node);
            size--;

            return node;
        }

        //Remove the node from the linked list
        public void RemoveFromList(ListNode node)
        {
            ListNode prev = node.prev;
            ListNode next = node.next;

            next.prev = prev;
            prev.next = next;
        }

        //To move front, attach the head to node and head.next to node.next
        public void MoveToFront(ListNode node)
        {
            RemoveFromList(node);
            AddToFront(node);
        }
    }

    /**
     * Your LRUCache object will be instantiated and called as such:
     * LRUCache obj = new LRUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */
}
