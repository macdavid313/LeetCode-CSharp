/*
 * File: 128LongestConsecutiveSequence.cs
 * Project: UnionFind
 * Created Date: Saturday, 22nd August 2020 5:59:23 pm
 * Author: David Gu, macdavid313@gmail.com
 * Runtime: 100 ms, faster than 75.82% of C# online submissions for Longest Consecutive Sequence.
 * Memory Usage: 26.6 MB, less than 11.44% of C# online submissions for Longest Consecutive Sequence.
 * Copyright (c) David Gu 2020
 */


namespace LongestConsecutiveSequence
{
    using System.Collections.Generic;

    interface ISolution
    {
        int LongestConsecutive(int[] nums);
    }

    public class Solution : ISolution
    {
        public int LongestConsecutive(int[] nums)
        {
            // return early if corner cases found
            switch (nums.Length)
            {
                case 0: return 0;
                case 1: return 1;
            }

            var uf = new UF(nums.Length);
            var ht = new Dictionary<int, int>(nums.Length);
            for (var i = 0; i < nums.Length; i++)
            {
                if (!ht.ContainsKey(nums[i]))
                {
                    ht.Add(nums[i], i);
                }
            }
            for (var i = 0; i < nums.Length; i++)
            {
                var n = nums[i];
                if (ht[n] != i) continue; // ignore duplicate elements
                if (ht.ContainsKey(n - 1))
                {
                    uf.Union(i, ht[n - 1]);
                }
                if (ht.ContainsKey(n + 1))
                {
                    uf.Union(i, ht[n + 1]);
                }
            }
            return uf.MaxSize();
        }
    }

    /*
    * Runtime: 92 ms, faster than 96.08% of C# online submissions for Longest Consecutive Sequence.
    * Memory Usage: 25.1 MB, less than 74.84% of C# online submissions for Longest Consecutive Sequence.
    */
    public class Solution2 : ISolution
    {
        // a much shorter solution but the performance is similar
        public int LongestConsecutive(int[] nums)
        {
            var nums_set = new HashSet<int>();
            foreach (var n in nums)
            {
                nums_set.Add(n);
            }

            var maxLen = 0;

            foreach (var n in nums)
            {
                if (!nums_set.Contains(n - 1))
                {
                    var currentN = n;
                    var len = 1;
                    // look forward
                    while (nums_set.Contains(currentN + 1))
                    {
                        currentN += 1;
                        len += 1;
                    }
                    maxLen = maxLen < len ? len : maxLen;
                }
            }
            return maxLen;
        }
    }

    class UF
    {
        readonly int[] id;
        readonly int[] sz;
        readonly HashSet<int> roots;

        public UF(int n)
        {
            id = new int[n];
            sz = new int[n];
            roots = new HashSet<int>();
            for (var i = 0; i < n; i++)
            {
                id[i] = i;
                sz[i] = 1;
                roots.Add(i);
            }

        }

        public void Union(int p, int q)
        {
            var pRoot = Find(p);
            var qRoot = Find(q);
            if (pRoot == qRoot)
            {
                return;
            }

            if (sz[pRoot] < sz[qRoot])
            {
                id[pRoot] = qRoot;
                sz[qRoot] += sz[pRoot];
                roots.Remove(pRoot);
            }
            else
            {
                id[qRoot] = pRoot;
                sz[pRoot] += sz[qRoot];
                roots.Remove(qRoot);
            }
        }

        int Find(int i)
        {
            if (id[i] != i)
                id[i] = Find(id[i]);
            return id[i];
        }

        public int MaxSize()
        {
            int max = -1;
            foreach (int root in roots)
            {
                if (sz[root] > max)
                {
                    max = sz[root];
                }
            }
            return max;
        }
    }
}