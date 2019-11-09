using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Stacks
{
    public class KeysRoomsClass
    {
        //This is a DFS, you visit one room(node) and then the accessible rooms(nodes) with the room keys
        //if already visited then avoid it(not pushing into stack)
        public static bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            // stack for rooms to visit
            // list for visited rooms
            bool[] seen = new bool[rooms.Count];
            seen[0] = true;//mark it as visited-true

            Stack<int> s = new Stack<int>(); //0 room is always open, so push it into stack-then we can access the key in room 0
            s.Push(0);

            while (s.Count > 0)
            {
                int keys = s.Pop();//take the top room number
                foreach (int key in rooms[keys])
                {//in that room we can expect list of keys, so foreach teh keys
                    if (!seen[key])
                    {//if the key number(key for that number room) is not visisted before
                        seen[key] = true;//visit now 
                        s.Push(key);//push that key-room number to stack for getting inner keys
                    }
                }
            }

            //finally, loop the seen all rooms and if any room not visited then return false, else true
            for (int i = 0; i < seen.Length; i++)
            {
                if (!seen[i])
                {
                    Console.WriteLine("room number " + i + " was not visited");
                    return false;
                }
            }
            return true;
        }
        static void Main()
        {
            List<IList<int>> rooms = new List<IList<int>>()
            { new List<int> { 2, 3 }
                ,new List<int> { 2 }
                ,new List<int> { 3 }
                ,new List<int> {  } 
            };

            Console.WriteLine(CanVisitAllRooms(rooms));
            Console.ReadLine();



        }
    }
}
