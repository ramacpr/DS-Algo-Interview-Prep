using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPrep
{
    static class MaxXORSubarr
    {
        public static void MaximumXOR(int[] arr)
        {
            int arrLen = arr.Length;
            if(arrLen == 0 || arrLen == 1)
            {
                Console.WriteLine("NotAnOperator input data!");
                return;
            }

            int leftPos = 0, rightPos = leftPos + 1;
            int maxXOR = 0, tmpXOR = 0;
            tmpXOR = arr[leftPos];
            while (rightPos < arrLen)
            {
                tmpXOR = tmpXOR ^ arr[rightPos];
                if (tmpXOR >= maxXOR)
                    maxXOR = tmpXOR;
                else
                {
                    tmpXOR = tmpXOR ^ arr[leftPos];
                    leftPos++;
                    if (tmpXOR > maxXOR)
                        maxXOR = tmpXOR;
                }
                rightPos++;                
            }
            
            while(leftPos < rightPos)
            {
                tmpXOR = tmpXOR ^ arr[leftPos];
                if (tmpXOR > maxXOR)
                    maxXOR = tmpXOR;
                leftPos++;
            }

            Console.WriteLine(maxXOR);

        }
    }
}
