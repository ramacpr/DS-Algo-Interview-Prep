using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPrep
{
    static class MaxContigiousSumSubArr
    {
        public static void Printresult()
        {
            var sum = GetMaxContigiousSubArraySum(new int[] { -14, -16, -8, -10, -12, -7, 4 });
            Console.WriteLine($"Max subarray sum = {sum}");
        }

        static int GetMaxContigiousSubArraySum(int[] arr)
        {
            int? globalMaxSum = null;
            int localMaxSum = 0;

            for(int i = 0; i < arr.Length; i++)
            {
                localMaxSum += arr[i];

                if (globalMaxSum < localMaxSum || globalMaxSum == null)
                    globalMaxSum = localMaxSum; // max sum can be negative too

                if (localMaxSum < 0)
                    localMaxSum = 0; 
            }

            return (int)globalMaxSum;
        }
    }
}
