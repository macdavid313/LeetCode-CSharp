/*
 * File: 74SearchA2DMatrix.cs
 * Project: BinarySearch
 * Created Date: Friday, 11th September 2020 8:44:58 am
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 92 ms, faster than 96.96% of C# online submissions for Search a 2D Matrix.
 * Memory Usage: 25.7 MB, less than 52.58% of C# online submissions for Search a 2D Matrix.
 * Copyright (c) David Gu 2020
 */


using System;

namespace SearchA2DMatrix
{
    public class Solution
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {
            if (matrix is null) throw new ArgumentNullException(nameof(matrix));
            if (matrix.Length == 0) return false;
            if (matrix[0].Length == 0) return false;

            var m = matrix.Length;
            var n = matrix[0].Length;
            var lo = 0;
            var hi = m * n - 1;
            while (lo <= hi)
            {
                var mid = lo + (hi - lo) / 2;
                var i = mid / n;
                var j = mid % n;
                var item = matrix[i][j];
                if (item == target) return true;
                else if (item < target) lo = mid + 1;
                else hi = mid - 1;
            }
            return false;
        }

        /* 
        * Runtime: 100 ms, faster than 75.99% of C# online submissions for Search a 2D Matrix.
        * Memory Usage: 25.6 MB, less than 65.04% of C# online submissions for Search a 2D Matrix.
        public bool SearchMatrix(int[][] matrix, int target)
        {
            if (matrix is null) throw new ArgumentNullException(nameof(matrix));
            if (matrix.Length == 0) return false;
            if (matrix[0].Length == 0) return false;
            var m = matrix.Length;
            var n = matrix[0].Length;
            return BinarySearch(matrix, m, n, target);
        }

        bool BinarySearch(int[][] matrix, int m, int n, int target)
        {
            var lo = 0;
            var hi = m - 1;
            while (lo <= hi)
            {
                var mid = lo + (hi - lo) / 2;
                var row = matrix[mid];
                if (InRange(row, n, target)) return BinarySearch(row, n, target);
                else if (target < row[0]) hi = mid - 1;
                else lo = mid + 1;
            }
            return false;
        }

        bool InRange(int[] row, int n, int target) => target >= row[0] && target <= row[n - 1];

        bool BinarySearch(int[] row, int n, int target)
        {
            var lo = 0;
            var hi = n - 1;
            while (lo <= hi)
            {
                var mid = lo + (hi - lo) / 2;
                if (row[mid] == target) return true;
                else if (row[mid] > target) hi = mid - 1;
                else lo = mid + 1;
            }
            return false;
        } */
    }
}