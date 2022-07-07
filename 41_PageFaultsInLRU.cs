using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://practice.geeksforgeeks.org/problems/page-faults-in-lru5603/1/?category[]=Graph&category[]=Greedy&category[]=DFS&category[]=Binary%20Search%20Tree&category[]=BFS&category[]=Divide%20and%20Conquer&category[]=AVL-Tree&category[]=Graph&category[]=Greedy&category[]=DFS&category[]=Binary%20Search%20Tree&category[]=BFS&category[]=Divide%20and%20Conquer&category[]=AVL-Tree&difficulty[]=1&page=4&query=category[]Graphcategory[]Greedycategory[]DFScategory[]Binary%20Search%20Treecategory[]BFScategory[]Divide%20and%20Conquercategory[]AVL-Treedifficulty[]1page4category[]Graphcategory[]Greedycategory[]DFScategory[]Binary%20Search%20Treecategory[]BFScategory[]Divide%20and%20Conquercategory[]AVL-Tree
// O(n) time
// O(c) space 

namespace GPrep
{
    static class PageFaultsInLRU
    {
        public static void PrintResult()
        {
            var pf = GetPageFaultCount(new int[] { 5, 0, 1, 3, 2, 4, 1, 0, 5 }, 4); 

        }

        static int GetPageFaultCount(int[] arr, int capacity)
        {
            int count = 0;

            HashSet<int> pagesSet = new HashSet<int>(capacity);
            int[] pages = new int[capacity];
            int pageIndex = -1; 

            for(int index = 0; index < arr.Length; index++)
            {
                if (pagesSet.Contains(arr[index]))
                    continue;

                
                pageIndex = (pageIndex + 1) % (capacity);
                if (pageIndex == 0 || pagesSet.Count == capacity)
                    pagesSet.Remove(pages[pageIndex]);
                pages[pageIndex] = arr[index];
                pagesSet.Add(pages[pageIndex]);
                count++;
            }

            return count; 
        }
    }
}
