using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPrep
{
    /*
    Given a string, find the longest palindromic contiguous substring. 
    If there are more than one with the maximum length, return any one.
    
    For example, the longest palindromic substring of "aabcdcb" is "bcdcb". 
    The longest palindromic substring of "bananas" is "anana".
    */
    public static class LongestPalindromicSubstring
    {
        public static string GetLongestPalindromicSubsequence(string input)
        {
            string palindromicSubSequence = "", longestPalindromicSubsequence = "";

            Dictionary<char, int> startAddressMap = new Dictionary<char, int>();
            Dictionary<char, int> endAddressMap = new Dictionary<char, int>();
            StringBuilder uniqueCharsInput = new StringBuilder();

            for(int index = 0; index < input.Length; index++)
            {
                if (!startAddressMap.ContainsKey(input[index]))
                {
                    startAddressMap[input[index]] = index;
                    uniqueCharsInput.Append(input[index]);
                }
                else
                    endAddressMap[input[index]] = index;
            }

            var str = uniqueCharsInput.ToString();
            int startIndex = 0, endIndex = 0; 
            foreach(char c in str)
            {
                if (startAddressMap.TryGetValue(c, out startIndex) == false)
                    continue;
                if (endAddressMap.TryGetValue(c, out endIndex) == false)
                    continue;

                int sIndex = startIndex, eIndex = endIndex;

                while(sIndex < eIndex && sIndex < input.Length &&
                    eIndex > sIndex && eIndex >= 0)
                {
                    if (input[sIndex] == input[eIndex])
                    {
                        sIndex++; eIndex--;
                    }
                    else
                    {
                        break; // not a palindrome
                    }
                }

                if(sIndex == eIndex || 
                    (sIndex == eIndex + 1) || (eIndex == sIndex - 1))
                {
                    // this is a palindrome!!!!
                    palindromicSubSequence = input.Substring(startIndex, endIndex - startIndex + 1);
                    Console.WriteLine(palindromicSubSequence);
                    if (palindromicSubSequence.Length > longestPalindromicSubsequence.Length)
                        longestPalindromicSubsequence = palindromicSubSequence;
                }
            }

            return longestPalindromicSubsequence;
        }




    }
}
