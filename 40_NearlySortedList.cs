using GPrep.Sorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPrep
{
    /*
    You are given a list of N numbers, in which each number is located at 
    most k places away from its sorted position. For example, if k = 1, a 
    given element at index 4 might end up at indices 3, 4, or 5.
    
    Come up with an algorithm that sorts this list in O(N log k) time.
    */
    public static class NearlySortedList
    {
        public static int[] Sort(int[] nearlySortedList, int K)
        {
            MinHeapSorter<int> minHeap = new MinHeapSorter<int>(); 
            int[] sortedList = new int[nearlySortedList.Length];

            // step 1: 
            // add only K + 1 items into the min heap
            for(int i = 0; 
                i < nearlySortedList.Length && i < K + 1;
                i++)
                minHeap.AddItem(nearlySortedList[i]);

            // ste 2: 
            // remove the min item from the (k+1) min heap and 
            // place it at index i (starting from 0), 
            // add next item from array to min heap. 
            // like this, add upto K+1 items to heap and sort them
            int sortedIndex = 0;
            int unsortedIndex = K + 1; 
            foreach(var sortedItem in minHeap.GetNextMinItem())
            {
                sortedList[sortedIndex++] = sortedItem;
                if(unsortedIndex < nearlySortedList.Length)
                    minHeap.AddItem(nearlySortedList[unsortedIndex++]);
            }


            return sortedList;
        }
    }
}
