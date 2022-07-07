using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPrep
{
    class NutsAndBolts
    {
        public static void MatchNutsAndBolts()
        {
            char[] nuts = new char[]{'^', '&', '%', '@', '#', '*', '$', '~', '!'};
            char[] bolts = new char[] { '~', '#', '@', '%', '&', '*', '$', '^', '!' };

            if(nuts.Length != bolts.Length)
            {
                Console.WriteLine("No match!");
                return;
            }

            int arrLen = nuts.Length;
            SortArr(ref nuts, 0, arrLen - 1);
            SortArr(ref bolts, 0, arrLen - 1);

            string result = ""; 

            for (int i = 0; i < arrLen; i++)
            {
                if (nuts[i] != bolts[i])
                {
                    Console.WriteLine("No match!");
                    return;
                }
                result += nuts[i].ToString() + " "; 
            }

            Console.WriteLine("Match found!");
            Console.WriteLine(result);
            Console.WriteLine(result); 
        }

        static void SortArr(ref char[] arr, int start, int end)
        {
            if(start < end)
            {
                int pi = Partition(ref arr, start, end);
                SortArr(ref arr, start, pi - 1);
                SortArr(ref arr, pi + 1, end); 
            }
        }

        private static int Partition(ref char[] arr, int start, int end)
        {
            int smallestIndex = start - 1;
            char pivot = arr[end], tmp; 

            for(int i = start; i < end; i++)
            {
                if(((int)arr[i]) < ((int)pivot))
                {
                    smallestIndex++;
                    tmp = arr[i];
                    arr[i] = arr[smallestIndex];
                    arr[smallestIndex] = tmp; 
                }
            }
            smallestIndex++; 

            tmp = arr[end];
            arr[end] = arr[smallestIndex];
            arr[smallestIndex] = tmp;

            return smallestIndex;
        }
    }
}
