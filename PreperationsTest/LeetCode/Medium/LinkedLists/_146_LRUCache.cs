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
// Companies: @Meta
namespace PreperationsTest.LeetCode.Medium.LinkedLists
{
    [TestClass]
    public class _146_LRUCache
    {
        [TestMethod]
        public void Run()
        {
            _146_LRUCache cache = new _146_LRUCache(2);
            cache.Put(1, 1);
            cache.Put(2, 2);
            cache.Get(1);
            cache.Put(3, 3);
            cache.Get(2);
            cache.Put(4, 4);
            cache.Get(1);
            cache.Get(3);
            cache.Get(4);

            // Calls: ["LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get"]
            // Input: [[2], [1, 1], [2, 2], [1], [3, 3], [2], [4, 4], [1], [3], [4]]
            // Output: [null, null, null, 1, null, -1, null, -1, 3, 4]

        }

        // Doubly linked list
        public class ListNode
        {
            public int key;
            public int val;
            public ListNode next;
            public ListNode prev;

            public ListNode() { }
        }

        //Global variables
        Dictionary<int, ListNode> dict;
        int size;
        int maxCapacity;
        ListNode head;
        ListNode tail;

        // Constructor
        public _146_LRUCache(int capacity)
        {
            size = 0;
            maxCapacity = capacity;
            head = new ListNode();
            tail = new ListNode();
            dict = new Dictionary<int, ListNode>();

            head.next = tail;
            tail.prev = head;
        }

        // Check if the key exists or not and return value or -1
        // Move the key to front
        public int Get(int key)
        {
            if (!dict.ContainsKey(key))
            {
                return -1;
            }
            ListNode node = dict[key];
            MoveToFront(node);
            return node.val;
        }

        // To insert new key-value
        // Add at fromt
        // Size must be with in capacity(maxCapacity), if exceeds, remove the LSU key
        public void Put(int key, int value)
        {
            if (!dict.ContainsKey(key))
            {
                // prepare a node
                ListNode node = new ListNode();
                node.key = key;
                node.val = value;

                // add it to front
                dict.Add(key, node);
                AddToFront(node);
                size++;

                // check the capacity
                if (size > maxCapacity)
                {
                    RemoveTheLRUNode();
                }
            }
            else
            {
                // if new value comes, we need to update the key-value
                ListNode node = dict[key];
                node.val = value;
                MoveToFront(node);
            }
        }

        // head -> node1-> node2 -> tail 
        public void RemoveTheLRUNode()
        {
            ListNode lastNode = tail.prev;
            RemoveFromList(lastNode);
            dict.Remove(lastNode.key);
            size--;
        }

        // Get the current key node from dictionary
        // Remove from the list
        // Add it to the front.
        public void MoveToFront(ListNode currNode)
        {
            RemoveFromList(currNode);
            AddToFront(currNode);
        }

        // we have prev->(.prev)curr(.next)->next
        // connect prev--->next
        public void RemoveFromList(ListNode currNode)
        {
            ListNode prev = currNode.prev;
            ListNode next = currNode.next;

            prev.next = next;
            next.prev = prev;
        }

        // head <-> node <-> tail
        // head <-> curr <-> node <-> tail
        // we need to conect head.next to curr, curr.prev to head, curr.next to node, node.prev to curr
        public void AddToFront(ListNode currNode)
        {
            ListNode next = head.next;
            head.next = currNode;
            currNode.prev = head;
            currNode.next = next;
            next.prev = currNode;
        }
    }

    /**
     * Your LRUCache object will be instantiated and called as such:
     * LRUCache obj = new LRUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */
}
