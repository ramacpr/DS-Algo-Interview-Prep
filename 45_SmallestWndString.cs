using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://practice.geeksforgeeks.org/problems/smallest-window-in-a-string-containing-all-the-characters-of-another-string-1587115621/1

namespace GPrep
{
    static class SmallestWndString
    {
        public static void PrintResult()
        {
            ComputeMinWnd("abcdkepkepqptsvksq", "kps");
        }

        static void UpdateDictionary(ref Dictionary<char, int> hash, string s2)
        {
            hash = new Dictionary<char, int>();
            foreach (var c in s2)
            {
                var count = 0;
                if (!hash.TryGetValue(c, out count))
                    hash[c] = 1;
                else
                    hash[c] = count + 1;
            }
        }

        static bool IsWindowValid(Dictionary<char, int> hash)
        {
            foreach (var kv in hash)
                if (kv.Value > 0)
                    return false;
            return true;
        }

        static int HowManyFound(Dictionary<char, int> hash)
        {
            int count = 0;
            foreach (var kv in hash)
                if (kv.Value <= 0)
                    count++;
            return count;
        }

        static void ComputeMinWnd(string s1, string s2)
        {
            if (s1.Length == 0 || s2.Length == 0) 
                return;
            if (s1.Length < s2.Length) 
                return;

            int leftI = 0, rightI = 0;
            int toFindCount = s2.Length, foundCount = 0;
            string resString = "";
            int len = 0, startIndex = -1;
            int? minLen = null;
            Dictionary<char, int> hash = null;
            Queue<int> nextJumpIndex = new Queue<int>();
            UpdateDictionary(ref hash, s2);

            while (rightI < s1.Length)
            {
                // update how many values have been found in the range    
                foundCount = HowManyFound(hash);

                // expand right and find a window
                while (rightI < s1.Length)
                {
                    // expand wnd on right untill all chars are found
                    var remCount = 0;
                    if (!hash.TryGetValue(s1[rightI], out remCount))
                    {
                        if (leftI == rightI)
                            leftI++;
                        rightI++;
                        continue;
                    }
                    // instead of shrinking the wnd one at atime, we save and jump where we know it might start again
                    nextJumpIndex.Enqueue(rightI);
                    hash[s1[rightI]]--;
                    remCount--;
                    if (remCount == 0 && foundCount < toFindCount)
                    {
                        rightI++;
                        foundCount++;
                        if (foundCount != toFindCount)
                            continue;
                    }

                    // found a window!
                    if (foundCount == toFindCount)
                    {
                        rightI--;
                        len = rightI - leftI + 1;
                        if (minLen == null || len < minLen)
                        {
                            minLen = (int)len;
                            resString = s1.Substring(leftI, (rightI - leftI + 1));
                            startIndex = leftI;
                            
                        }
                        break; // break here to shrink the window
                    }
                    rightI++;
                }

                if (rightI >= s1.Length)
                    break;

                // q has the current LI too so remove it now and get the next probable LI 
                if(nextJumpIndex.Peek() == leftI)
                    leftI = nextJumpIndex.Dequeue();                

                hash[s1[leftI]]++;
                if (nextJumpIndex.Count > 0)
                    leftI = nextJumpIndex.Dequeue();
                else
                    break;

                // check if the window can be further shrunk (to minimize)
                while (leftI < rightI)
                {
                    if (IsWindowValid(hash))
                    {
                        len = rightI - leftI + 1;
                        if (minLen == null || len < minLen)
                        {
                            minLen = (int)len;
                            resString = s1.Substring(leftI, (rightI - leftI + 1));
                            startIndex = leftI;
                        }
                        if (nextJumpIndex.Count > 0)
                        {
                            hash[s1[leftI]]++;
                            leftI = nextJumpIndex.Dequeue();
                        }
                    }
                    else // once the window becomes invalid we need to expand right side
                    {
                        break;
                    }
                }
                rightI++;
            }

            Console.WriteLine("Minimum window is ");
            Console.WriteLine($"Length = {minLen}, start index = {startIndex}, string = {resString}");
        }
    }
}
