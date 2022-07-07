using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// O(2^(n-1))

namespace GPrep
{
    static class LongestCommonSubsequence
    {
        public static void PrintResult()
        {
            string s1 = "abcdgh";
            string s2 = "aedfhr";
            int count = 0;
            Dictionary<Tuple<int, int>, int> cache = new Dictionary<Tuple<int, int>, int>();
            int lcs = GetLCSLength(s1, s2, s1.Length - 1, s2.Length - 1, ref cache, ref count);

            Console.WriteLine($"'{s1}' and '{s2}' have Longest Common Subsequence length of {lcs}");
            Console.WriteLine($"'{s1.Length}' and '{s2.Length}' has count {count}");
        }

        static int GetLCSLength(string s1, string s2, int s1Index, int s2Index, ref Dictionary<Tuple<int, int>, int> cache, ref int count)
        {
           

            int maxLCSLen = 0;

            if (s1Index < 0 || s2Index < 0) // trying to analyze empty string 
                return 0;

            if(cache.TryGetValue(new Tuple<int, int>(s1Index, s2Index), out maxLCSLen))
                return maxLCSLen;

            count += 1;
            if (s1[s1Index] == s2[s2Index])
                maxLCSLen = 1 + GetLCSLength(s1, s2, s1Index - 1, s2Index - 1, ref cache, ref count);
            else
                maxLCSLen = Math.Max(GetLCSLength(s1, s2, s1Index, s2Index - 1, ref cache, ref count), GetLCSLength(s1, s2, s1Index - 1, s2Index, ref cache, ref count));

            cache[new Tuple<int, int>(s1Index, s2Index)] = maxLCSLen;

            return maxLCSLen; 
        }
    }
}
