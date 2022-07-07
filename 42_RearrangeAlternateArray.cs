using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://practice.geeksforgeeks.org/problems/-rearrange-array-alternately-1587115620/1/?category[]=Arrays&category[]=Strings&category[]=Matrix&category[]=two-pointer-algorithm&category[]=sliding-window&category[]=Segment-Tree&category[]=Fibonacci&category[]=Trie&category[]=prefix-sum&category[]=Pattern%20Searching&category[]=Disjoint%20Set&category[]=Kadane&category[]=Binary%20Indexed%20Tree&category[]=Range%20Minimum%20Query&category[]=LCS&category[]=anagram&category[]=Character%20Encoding&category[]=Match%20Making&category[]=Super%20Increasing%20Seq&category[]=Arrays&category[]=Strings&category[]=Matrix&category[]=two-pointer-algorithm&category[]=sliding-window&category[]=Segment-Tree&category[]=Fibonacci&category[]=Trie&category[]=prefix-sum&category[]=Pattern%20Searching&category[]=Disjoint%20Set&category[]=Kadane&category[]=Binary%20Indexed%20Tree&category[]=Range%20Minimum%20Query&category[]=LCS&category[]=anagram&category[]=Character%20Encoding&category[]=Match%20Making&category[]=Super%20Increasing%20Seq&difficulty[]=1&page=1&query=category[]Arrayscategory[]Stringscategory[]Matrixcategory[]two-pointer-algorithmcategory[]sliding-windowcategory[]Segment-Treecategory[]Fibonaccicategory[]Triecategory[]prefix-sumcategory[]Pattern%20Searchingcategory[]Disjoint%20Setcategory[]Kadanecategory[]Binary%20Indexed%20Treecategory[]Range%20Minimum%20Querycategory[]LCScategory[]anagramcategory[]Character%20Encodingcategory[]Match%20Makingcategory[]Super%20Increasing%20Seqdifficulty[]1page1category[]Arrayscategory[]Stringscategory[]Matrixcategory[]two-pointer-algorithmcategory[]sliding-windowcategory[]Segment-Treecategory[]Fibonaccicategory[]Triecategory[]prefix-sumcategory[]Pattern%20Searchingcategory[]Disjoint%20Setcategory[]Kadanecategory[]Binary%20Indexed%20Treecategory[]Range%20Minimum%20Querycategory[]LCScategory[]anagramcategory[]Character%20Encodingcategory[]Match%20Makingcategory[]Super%20Increasing%20Seq

namespace GPrep
{
    static class RearrangeAlternateArray
    {
        public static void PrintResult()
        {
            int[] arr = new int[] { 2, 4, 8, 12, 13, 16, 20 };

            Console.WriteLine("BEFORE");
            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]} ");

            ReArrange(ref arr);

            Console.WriteLine("\nAFTER");
            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]} ");

        }

        static void ReArrange(ref int[] arr)
        {
            int minI = 0, maxI = arr.Length - 1;
            int tmp = 0, nxtMin = 0;
            Queue<int> nextMinQ = null; 

            while(minI < arr.Length - 1)
            {
                if(minI != maxI)
                {
                    tmp = arr[minI];
                    if (nextMinQ == null)
                    {
                        nextMinQ = new Queue<int>();
                    }
                    nextMinQ.Enqueue(tmp);

                    Console.WriteLine($"Q count = {nextMinQ.Count}");
                    
                    arr[minI] = arr[maxI];
                    minI += 1;
                    nxtMin = arr[minI];
                    nextMinQ.Enqueue(nxtMin);
                    Console.WriteLine($"Q count = {nextMinQ.Count}");

                    if (nextMinQ.Count > 0)
                        tmp = nextMinQ.Dequeue(); 

                    arr[minI] = tmp;
                }
                else
                {
                    minI += 1;
                    while (nextMinQ.Count > 0 && minI < arr.Length)
                    {                        
                        tmp = nextMinQ.Dequeue();
                        arr[minI] = tmp;
                        minI += 1;
                    }
                    break;
                }
                minI += 1;
                maxI -= 1;
            }
        }
    }
}
