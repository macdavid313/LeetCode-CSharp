/*
 * File: 79WordSearch.cs
 * Project: Backtracking
 * Created Date: Sunday, 13th September 2020 4:04:25 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 160 ms, faster than 56.49% of C# online submissions for Word Search.
 * Memory Usage: 30 MB, less than 15.18% of C# online submissions for Word Search.
 * Copyright (c) David Gu 2020
 */


using System;
using System.Collections.Generic;

namespace WordSearch
{
    public class Solution
    {
        public bool Exist(char[][] board, string word)
        {
            if (word is null) throw new ArgumentNullException(nameof(word));
            if (board is null) return false;

            var m = board.Length;
            var n = board[0].Length;
            var visited = new HashSet<int>(m * n);
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (board[i][j] == word[0])
                    {
                        var pos = To1DPosition(i, j, n);
                        visited.Add(pos);
                        var flag = Backtrack(board, m, n, word, 1, i, j, visited);
                        if (flag) return true;
                        else visited.Remove(pos);
                    }
                }
            }
            return false;
        }

        bool Backtrack(char[][] board, int m, int n, string word, int fill, int i, int j, HashSet<int> visited)
        {
            if (fill == word.Length) return true;
            var neighbours = new Tuple<int, int>[]
            {
                Tuple.Create(i-1, j),
                Tuple.Create(i+1, j),
                Tuple.Create(i, j-1),
                Tuple.Create(i, j+1),
            };
            foreach (var neighbour in neighbours)
            {
                (int i2, int j2) = neighbour;
                if (IsValidPosition(i2, j2, m, n) && board[i2][j2] == word[fill] && !Visited(visited, i2, j2, n))
                {
                    var pos = To1DPosition(i2, j2, n);
                    visited.Add(pos);
                    var flag = Backtrack(board, m, n, word, fill + 1, i2, j2, visited);
                    if (flag) return true;
                    else visited.Remove(pos);
                }
            }
            return false;
        }

        static int To1DPosition(int i, int j, int n) => i * n + j;

        static bool Visited(HashSet<int> visited, int i, int j, int n) => visited.Contains(To1DPosition(i, j, n));

        static bool IsValidPosition(int i, int j, int m, int n) => i >= 0 && i < m && j >= 0 && j < n;
    }
}