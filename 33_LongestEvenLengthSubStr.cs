using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://www.geeksforgeeks.org/longest-even-length-substring-sum-first-second-half/

namespace GPrep
{
    static class LongestEvenLengthSubStr
    {
        public static void PrintResult()
        {
            CalculateLESS("1221");
        }

        static void CalculateLESS(string str)
        {
            if (str == "")
                return;

            int leftSum = 0, rightSum = 0;
            int leftIndex, rightIndex;
            int maxSubStrLen = 0, subStrLen = 0; 

            for(int i = 1; i < str.Length; i++)
            {
                leftSum = 0;
                rightSum = 0;
                leftIndex = i;
                rightIndex = i + 1;
                

                while(leftIndex >= 0 && rightIndex < str.Length)
                {               
                    leftSum += int.Parse(str[leftIndex].ToString());
                    rightSum += int.Parse(str[rightIndex].ToString());

                    if (leftSum == rightSum)
                        subStrLen = rightIndex - leftIndex + 1;

                    leftIndex -= 1;
                    rightIndex += 1; 
                }

                if (subStrLen > maxSubStrLen)
                    maxSubStrLen = subStrLen;
            }

            Console.WriteLine(maxSubStrLen.ToString());
        }
    }
}
