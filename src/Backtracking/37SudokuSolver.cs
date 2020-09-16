/*
 * File: 37SudokuSolver.cs
 * Project: Backtracking
 * Created Date: Tuesday, 15th September 2020 8:17:31 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 436 ms, faster than 30.25% of C# online submissions for Sudoku Solver.
 * Memory Usage: 32.5 MB, less than 41.97% of C# online submissions for Sudoku Solver.
 * Copyright (c) David Gu 2020
 */


using System;
using System.Linq;
using System.Collections.Generic;

namespace SudokuSolver
{
    public class Solution
    {
        static readonly char[] choices = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        static readonly Tuple<int, int>[] squares = new Tuple<int, int>[]
        {
            Tuple.Create(0, 0), Tuple.Create(3, 0), Tuple.Create(6, 0),
            Tuple.Create(0, 3), Tuple.Create(3, 3), Tuple.Create(6, 3),
            Tuple.Create(0, 6), Tuple.Create(3, 6), Tuple.Create(6, 6)
        };

        public void SolveSudoku(char[][] board) => Backtrack(board);

        bool Backtrack(char[][] board)
        {
            FindNextToFill(board, out int i, out int j);
            if (i == -1) return true;
            foreach (var choice in choices)
            {
                if (IsValid(board, i, j, choice))
                {
                    var impl = MakeImplications(board, i, j, choice);
                    if (Backtrack(board)) return true;
                    else UndoImplications(board, impl);
                }
            }
            return false;
        }

        static void FindNextToFill(char[][] board, out int i, out int j)
        {
            foreach (var x in Enumerable.Range(0, 9))
            {
                foreach (var y in Enumerable.Range(0, 9))
                {
                    if (board[x][y] == '.')
                    {
                        i = x;
                        j = y;
                        return;
                    }
                }
            }
            i = -1;
            j = -1;
        }

        static bool IsValid(char[][] board, int i, int j, char choice)
        {
            // check row
            for (var col = 0; col < 9; col++)
                if (board[i][col] == choice) return false;
            // check column
            for (var row = 0; row < 9; row++)
                if (board[row][j] == choice) return false;
            // check square
            var secRowTop = (i / 3) * 3;
            var secColTop = (j / 3) * 3;
            foreach (var x in Enumerable.Range(secRowTop, 3))
            {
                foreach (var y in Enumerable.Range(secColTop, 3))
                {
                    if (board[x][y] == choice) return false;
                }
            }
            return true;
        }

        static List<Tuple<int, int, char>> MakeImplications(char[][] board, int i, int j, char choice)
        {
            board[i][j] = choice;
            var impl = new List<Tuple<int, int, char>>()
            {
                Tuple.Create(i, j, choice)
            };
            var done = false;
            while (!done)
            {
                done = true;
                foreach ((var rowTop, var colTop) in squares)
                {
                    var squareInfo = new List<Tuple<int, int, HashSet<char>>>();

                    // Find missing elements in ith sector
                    var set = new HashSet<char>(choices);
                    foreach (var x in Enumerable.Range(rowTop, 3))
                    {
                        foreach (var y in Enumerable.Range(colTop, 3))
                        {
                            if (board[x][y] != '.') set.Remove(board[x][y]);
                        }
                    }

                    // attach copy of set to each missing square in ith sector
                    foreach (var x in Enumerable.Range(rowTop, 3))
                    {
                        foreach (var y in Enumerable.Range(colTop, 3))
                        {
                            if (board[x][y] == '.') squareInfo.Add(Tuple.Create(x, y, new HashSet<char>(set)));
                        }
                    }

                    foreach ((var x, var y, var info) in squareInfo)
                    {
                        // find the set of elements on the row corresponding to m and remove them
                        var rowv = new HashSet<char>();
                        for (var col = 0; col < 9; col++)
                            rowv.Add(board[x][col]);
                        var left = info.Except(rowv);
                        // find the set of elements on the column corresponding to m and remove them
                        var colv = new HashSet<char>();
                        for (var row = 0; row < 9; row++)
                            rowv.Add(board[row][y]);
                        left = left.Except(colv);

                        // check if the set is a singleton
                        if (left.Count() == 1)
                        {
                            var val = left.ElementAt(0);
                            if (IsValid(board, x, y, val))
                            {
                                board[x][y] = val;
                                impl.Add(Tuple.Create(x, y, val));
                                done = false;
                            }
                        }
                    }
                }
            }

            return impl;
        }

        static void UndoImplications(char[][] board, List<Tuple<int, int, char>> impl)
        {
            foreach ((var x, var y, var _) in impl)
            {
                board[x][y] = '.';
            }
            return;
        }
    }
}