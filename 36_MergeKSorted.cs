using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://practice.geeksforgeeks.org/problems/merge-k-sorted-arrays/1/?category[]=Arrays&category[]=Strings&category[]=Matrix&category[]=two-pointer-algorithm&category[]=sliding-window&category[]=Segment-Tree&category[]=Fibonacci&category[]=Trie&category[]=prefix-sum&category[]=Pattern%20Searching&category[]=Disjoint%20Set&category[]=Kadane&category[]=Binary%20Indexed%20Tree&category[]=Range%20Minimum%20Query&category[]=LCS&category[]=anagram&category[]=Character%20Encoding&category[]=Match%20Making&category[]=Super%20Increasing%20Seq&category[]=Arrays&category[]=Strings&category[]=Matrix&category[]=two-pointer-algorithm&category[]=sliding-window&category[]=Segment-Tree&category[]=Fibonacci&category[]=Trie&category[]=prefix-sum&category[]=Pattern%20Searching&category[]=Disjoint%20Set&category[]=Kadane&category[]=Binary%20Indexed%20Tree&category[]=Range%20Minimum%20Query&category[]=LCS&category[]=anagram&category[]=Character%20Encoding&category[]=Match%20Making&category[]=Super%20Increasing%20Seq&difficulty[]=1&page=1&query=category[]Arrayscategory[]Stringscategory[]Matrixcategory[]two-pointer-algorithmcategory[]sliding-windowcategory[]Segment-Treecategory[]Fibonaccicategory[]Triecategory[]prefix-sumcategory[]Pattern%20Searchingcategory[]Disjoint%20Setcategory[]Kadanecategory[]Binary%20Indexed%20Treecategory[]Range%20Minimum%20Querycategory[]LCScategory[]anagramcategory[]Character%20Encodingcategory[]Match%20Makingcategory[]Super%20Increasing%20Seqdifficulty[]1page1category[]Arrayscategory[]Stringscategory[]Matrixcategory[]two-pointer-algorithmcategory[]sliding-windowcategory[]Segment-Treecategory[]Fibonaccicategory[]Triecategory[]prefix-sumcategory[]Pattern%20Searchingcategory[]Disjoint%20Setcategory[]Kadanecategory[]Binary%20Indexed%20Treecategory[]Range%20Minimum%20Querycategory[]LCScategory[]anagramcategory[]Character%20Encodingcategory[]Match%20Makingcategory[]Super%20Increasing%20Seq
/* Problem Statement:
    Given K sorted arrays arranged in the form of a matrix of size K*K. 
    The task is to merge them into one sorted array.
    Example 1:
        Input:
        K = 3
        arr[][] = {{1,2,3},{4,5,6},{7,8,9}}
        Output: 1 2 3 4 5 6 7 8 9
        Explanation:Above test case has 3 sorted
        arrays of size 3, 3, 3
        arr[][] = [[1, 2, 3],[4, 5, 6], 
        [7, 8, 9]]
        The merged list will be 
        [1, 2, 3, 4, 5, 6, 7, 8, 9].
    Example 2:
        Input:
        K = 4
        arr[][]={{1,2,3,4}{2,2,3,4},
                 {5,5,6,6},{7,8,9,9}}
        Output:
        1 2 2 2 3 3 4 4 5 5 6 6 7 8 9 9 
        Explanation: Above test case has 4 sorted
        arrays of size 4, 4, 4, 4
        arr[][] = [[1, 2, 2, 2], [3, 3, 4, 4],
        [5, 5, 6, 6]  [7, 8, 9, 9 ]]
        The merged list will be 
        [1, 2, 2, 2, 3, 3, 4, 4, 5, 5, 
        6, 6, 7, 8, 9, 9 ].
    
    Your Task:
    You do not need to read input or print anything. 
    Your task is to complete mergeKArrays() function which takes 2 arguments, 
    an arr[K][K] 2D Matrix containing K sorted arrays and an integer K denoting the 
    number of sorted arrays, as input and returns the merged sorted array ( as a pointer 
    to the merged sorted arrays in cpp, as an ArrayList in java, and list in python)

    Expected Time Complexity: O(K2*Log(K))
    Expected Auxiliary Space: O(K)
 */

namespace GPrep
{
    class HeapItem
    {
        public int data;
        public int row;
        public int col; 

        public HeapItem(int val, int r, int c)
        {
            data = val;
            row = r;
            col = c;
        }
    }
    class MinHeap
    {
        HeapItem[] root = null;

        public void AddItem(int data, int row, int col)
        {
            if (root == null)
                root = new HeapItem[1];
            else if (root[root.Length - 1] != null)
                Array.Resize(ref root, root.Length + 1);
            root[root.Length - 1] = new HeapItem(data, row, col);

            for (int i = (root.Length - 1)/2; i >= 0; i--)       
                Heapify(i);
        }

        public HeapItem ExtractMin()
        {
            if (root.Length == 0)
                return null;

            HeapItem min = new HeapItem(root[0].data, root[0].row, root[0].col);

            root[0] = new HeapItem(root[root.Length - 1].data, root[root.Length - 1].row, root[root.Length - 1].col);
            Array.Resize(ref root, root.Length - 1);
            Heapify(0); 

            return min;
        }

        void Heapify(int index)
        {
            if (index < 0)
                return;

            var leftChild = (2 * index) + 1;
            var rightChild = leftChild + 1;
            var smallesIndex = leftChild;

            if (leftChild < root.Length && rightChild < root.Length &&
                root[leftChild].data < root[rightChild].data)
                smallesIndex = leftChild;
            else if (leftChild < root.Length && rightChild < root.Length &&
                root[leftChild].data > root[rightChild].data)
                smallesIndex = rightChild;

            if (leftChild < root.Length &&
                root[index].data < root[smallesIndex].data)
                smallesIndex = index;

            // swap smallestIndex with index
            if (smallesIndex < root.Length && index < root.Length && smallesIndex != index)
            {
                var tmp = root[index];
                root[index] = root[smallesIndex];
                root[smallesIndex] = tmp; 
                if(smallesIndex >= (root.Length - 1)/2)
                    Heapify(smallesIndex);
            }
        }
    }

    static class MergeKSorted
    {
        static MinHeap heap = new MinHeap(); 

        public static void PrintResult()
        {
            int[,] arr = new int[,]
            {
                {10,20,48,56,78,87 },
                {23,35,49,59,86,97 },
                {40,45,52,60,89,99 }
            };
            SortKArrays(arr);
        }

        static void SortKArrays(int[,] arr)
        {
            int[] sortedArr = new int[arr.Length];
            int[] currIndex = new int[arr.GetLength(0)]; 

            // 1. build min heap of the current indexes
            for(int i = 0; i < arr.GetLength(0); i++)            
                heap.AddItem(arr[i, (int)currIndex[i]], i, (int)currIndex[i]);

            HeapItem smallestItem = null;
            int index = 0;
            while (index < sortedArr.Length && (smallestItem = heap.ExtractMin()) != null)
            {
                var row = smallestItem.row;
                var newCol = currIndex[smallestItem.row] + 1;
                currIndex[row] = newCol;

                if (currIndex[row] >= arr.GetLength(1))
                    currIndex[row] = -1;
                else
                    heap.AddItem(arr[row, newCol], row, newCol);
                
                sortedArr[index] = smallestItem.data;
                index++;
            }

            index = 0;
            for (; index < sortedArr.Length; index++)
                Console.Write($"{sortedArr[index]} ");
        }        
    }
}
