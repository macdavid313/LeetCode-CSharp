/*
 * File: 278FirstBadVersion.cs
 * Project: BinarySearch
 * Created Date: Wednesday, 9th September 2020 3:19:14 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 32 ms, faster than 98.94% of C# online submissions for First Bad Version.
 * Memory Usage: 14.5 MB, less than 31.18% of C# online submissions for First Bad Version.
 * Copyright (c) David Gu 2020
 */


namespace FirstBadVersion
{
    /* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

    /* public class Solution : VersionControl
    {
        public int FirstBadVersion(int n)
        {
            var a = 1;
            var b = n;
            while (a < b)
            {
                var mid = a + (b - a) / 2;
                if (IsBadVersion(mid)) b = mid;
                else a = mid + 1;
            }
            return a;
        }
    } */
}