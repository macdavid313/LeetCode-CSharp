/*
 * File: 399EvaluateDivision.cs
 * Project: UnionFind
 * Created Date: Sunday, 23rd August 2020 4:15:22 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 252 ms, faster than 76.60% of C# online submissions for Evaluate Division.
 * Memory Usage: 30 MB, less than 97.45% of C# online submissions for Evaluate Division.
 * Copyright (c) David Gu 2020
 */


using System.Collections.Generic;

namespace EvaluateDivision
{
    public class Solution
    {
        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            var variables = GetAllVariables(equations);
            var uf = new UF(variables.Count);

            for (int i = 0; i < values.Length; i++)
            {
                var leftVar = equations[i][0];
                var rightVar = equations[i][1];
                double val = values[i];
                uf.Union(variables[leftVar], variables[rightVar], val);
            }

            double[] res = new double[queries.Count];
            for (var i = 0; i < queries.Count; i++)
            {
                var leftVar = queries[i][0];
                var rightVar = queries[i][1];
                if (variables.ContainsKey(leftVar) && variables.ContainsKey(rightVar))
                {
                    if (leftVar == rightVar)
                    {
                        res[i] = 1.0;
                        continue;
                    }
                    res[i] = uf.Evaluate(variables[leftVar], variables[rightVar]);
                }
                else
                {
                    res[i] = -1.0;
                }
            }
            return res;
        }

        Dictionary<string, int> GetAllVariables(IList<IList<string>> equations)
        {
            var allVariables = new Dictionary<string, int>();
            var count = 0;
            foreach (var equation in equations)
            {
                foreach (var variable in equation)
                {
                    if (!allVariables.ContainsKey(variable))
                    {
                        allVariables.Add(variable, count);
                        count += 1;
                    }
                }
            }
            return allVariables;
        }
    }

    class UF
    {
        readonly int[] id;
        readonly int[] sz;
        readonly double[] vals;

        public UF(int n)
        {
            id = new int[n];
            sz = new int[n];
            vals = new double[n];
            for (var i = 0; i < n; i++)
            {
                id[i] = i;
                sz[i] = 1;
                vals[i] = 1.0;
            }
        }

        public void Union(int p, int q, double val)
        {
            Root(p, out int pRoot, out double pRootVal);
            Root(q, out int qRoot, out double qRootVal);
            if (pRoot != qRoot)
            {
                // (p / pr) / (q / qr) / (p / q) = qr / pr
                double factor = pRootVal / qRootVal / val;
                if (sz[pRoot] <= sz[qRoot])
                {
                    id[pRoot] = qRoot;
                    sz[qRoot] += sz[pRoot];
                    vals[pRoot] = 1 / factor;
                }
                else
                {
                    id[qRoot] = pRoot;
                    sz[pRoot] += sz[qRoot];
                    vals[qRoot] = factor;
                }
            }
        }

        void Root(int i, out int root, out double val)
        {
            val = 1.0;
            while (id[i] != i)
            {
                val *= vals[i];
                i = id[i];
            }
            root = i;
            val *= vals[i];
        }

        public double Evaluate(int p, int q)
        {
            Root(p, out int pRoot, out double pRootVal);
            Root(q, out int qRoot, out double qRootVal);
            return pRoot == qRoot ? pRootVal / qRootVal : -1.0;
        }
    }
}