/*
 * File: 841KeysAndRooms.cs
 * Project: Graph
 * Created Date: Monday, 31st August 2020 7:09:22 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 132 ms, faster than 40.30% of C# online submissions for Keys and Rooms.
 * Memory Usage: 26.1 MB, less than 82.84% of C# online submissions for Keys and Rooms.
 * Copyright (c) David Gu 2020
 */


using System.Collections.Generic;

namespace KeysAndRooms
{
    public class Solution
    {
        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            if (rooms.Count == 1) return true;

            var visited = new bool[rooms.Count];
            var count = 0;
            DFS(rooms, 0, visited, ref count);

            return count == rooms.Count;
        }

        void DFS(IList<IList<int>> rooms, int x, bool[] visited, ref int count)
        {
            visited[x] = true;
            count += 1;
            foreach (var room in rooms[x])
            {
                if (visited[room] == false)
                {
                    DFS(rooms, room, visited, ref count);
                }
            }
        }
    }
}