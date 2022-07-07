using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://practice.geeksforgeeks.org/problems/maximum-sub-array5443/1/?category[]=Graph&category[]=Greedy&category[]=DFS&category[]=Binary%20Search%20Tree&category[]=BFS&category[]=Divide%20and%20Conquer&category[]=AVL-Tree&category[]=Graph&category[]=Greedy&category[]=DFS&category[]=Binary%20Search%20Tree&category[]=BFS&category[]=Divide%20and%20Conquer&category[]=AVL-Tree&difficulty[]=1&page=4&query=category[]Graphcategory[]Greedycategory[]DFScategory[]Binary%20Search%20Treecategory[]BFScategory[]Divide%20and%20Conquercategory[]AVL-Treedifficulty[]1page4category[]Graphcategory[]Greedycategory[]DFScategory[]Binary%20Search%20Treecategory[]BFScategory[]Divide%20and%20Conquercategory[]AVL-Tree
// time: O(n)
// space: O(1)

namespace GPrep
{
    static class MinimumSubarray
    {
        public static void PrintResult()
        {
            FindMinSubArr(new int[] { -1, -2, 20, 30, -7, 1, 2, 7, -3, 50 });
        }

        static void FindMinSubArr(int[] arr)
        {
            int? sum = null;
            int? maxSum = null;
            int maxSumStart = -1, maxSumEnd = -1;
            int sumStart = 0, sumEnd = 0; 

            while(sumStart < arr.Length && sumEnd < arr.Length)
            {
                if(arr[sumEnd] < 0) // skip negative number
                {
                    // what are the max values?? 
                    if(sum != null)
                    {
                        if(sum > maxSum || maxSum == null)
                        {
                            maxSum = sum;
                            maxSumStart = sumStart;
                            maxSumEnd = sumEnd - 1; 
                        }
                        else if(sum == maxSum)
                        {
                            if((sumEnd - sumStart) > (maxSumEnd - maxSumStart))
                            {
                                maxSum = sum;
                                maxSumStart = sumStart;
                                maxSumEnd = sumEnd - 1;
                            }
                        }
                    }
                    
                    sumEnd++;
                    sumStart = sumEnd;
                    sum = null; 
                    continue; 
                }

                if (sum == null)
                    sum = (int)arr[sumEnd];
                else
                    sum += (int)arr[sumEnd];

                sumEnd++; 
            }

            sumEnd--;
            if (sum != null)
            {
                if (sum > maxSum || maxSum == null)
                {
                    maxSum = sum;
                    maxSumStart = sumStart;
                    maxSumEnd = sumEnd;
                }
                else if (sum == maxSum)
                {
                    if ((sumEnd - sumStart) > (maxSumEnd - maxSumStart))
                    {
                        maxSum = sum;
                        maxSumStart = sumStart;
                        maxSumEnd = sumEnd;
                    }
                }
            }

            Console.WriteLine($"Sum = {(int)maxSum}, len = {maxSumEnd - maxSumStart + 1}, from {maxSumStart} to {maxSumEnd}");
        
        }
    }
}
