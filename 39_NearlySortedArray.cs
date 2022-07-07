using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPrep
{
    static class NearlySortedArray
    {
        public static void SortNearySortedArr()
        {
            int[] arr = new int[] { 20, 46,89,10,93,35,109,78,209,102,97 };
            int k = 3;

            Console.WriteLine("Before");
            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]} ");

            SortArr(ref arr, k);

            Console.WriteLine("\nAfter");
            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]} ");


        }

        static void SortArr(ref int[] arr, int k)
        {
            int leftIndex = 0, rightIndex = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                leftIndex = i - k;
                if (leftIndex < 0)
                    leftIndex = 0;
                rightIndex = i + k;
                if (rightIndex >= arr.Length)
                    break;

                Sort(ref arr, leftIndex, rightIndex);
            }
        }

        static void Sort(ref int[] arr, int start, int end)
        {
            if(end > start)
            {
                int i = Partition(ref arr, start, end);
                Sort(ref arr, start, i - 1);
                Sort(ref arr, i + 1, end); 
            }
        }

        private static int Partition(ref int[] arr, int start, int end)
        {
            int smallestIndex = start - 1;
            int pivot = arr[end]; 

            for(int i = start; i < end; i++)
            {
                if(arr[i] < pivot)
                {
                    smallestIndex += 1;
                    int tmp1 = arr[i];
                    arr[i] = arr[smallestIndex];
                    arr[smallestIndex] = tmp1;
                }
            }

            smallestIndex += 1;
            var tmp = arr[end];
            arr[end] = arr[smallestIndex];
            arr[smallestIndex] = tmp;

            return smallestIndex; 
        }
    }
}
