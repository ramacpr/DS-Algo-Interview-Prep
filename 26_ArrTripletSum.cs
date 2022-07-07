using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://practice.geeksforgeeks.org/problems/triplet-sum-in-array-1587115621/1/?category[]=Arrays&category[]=Strings&category[]=Matrix&category[]=two-pointer-algorithm&category[]=sliding-window&category[]=Segment-Tree&category[]=Trie&category[]=Fibonacci&category[]=prefix-sum&category[]=Pattern%20Searching&category[]=Disjoint%20Set&category[]=Kadane&category[]=Binary%20Indexed%20Tree&category[]=Range%20Minimum%20Query&category[]=LCS&category[]=Character%20Encoding&category[]=anagram&category[]=Match%20Making&category[]=Super%20Increasing%20Seq&category[]=Arrays&category[]=Strings&category[]=Matrix&category[]=two-pointer-algorithm&category[]=sliding-window&category[]=Segment-Tree&category[]=Trie&category[]=Fibonacci&category[]=prefix-sum&category[]=Pattern%20Searching&category[]=Disjoint%20Set&category[]=Kadane&category[]=Binary%20Indexed%20Tree&category[]=Range%20Minimum%20Query&category[]=LCS&category[]=Character%20Encoding&category[]=anagram&category[]=Match%20Making&category[]=Super%20Increasing%20Seq&difficulty[]=1&page=2&query=category[]Arrayscategory[]Stringscategory[]Matrixcategory[]two-pointer-algorithmcategory[]sliding-windowcategory[]Segment-Treecategory[]Triecategory[]Fibonaccicategory[]prefix-sumcategory[]Pattern%20Searchingcategory[]Disjoint%20Setcategory[]Kadanecategory[]Binary%20Indexed%20Treecategory[]Range%20Minimum%20Querycategory[]LCScategory[]Character%20Encodingcategory[]anagramcategory[]Match%20Makingcategory[]Super%20Increasing%20Seqdifficulty[]1page2category[]Arrayscategory[]Stringscategory[]Matrixcategory[]two-pointer-algorithmcategory[]sliding-windowcategory[]Segment-Treecategory[]Triecategory[]Fibonaccicategory[]prefix-sumcategory[]Pattern%20Searchingcategory[]Disjoint%20Setcategory[]Kadanecategory[]Binary%20Indexed%20Treecategory[]Range%20Minimum%20Querycategory[]LCScategory[]Character%20Encodingcategory[]anagramcategory[]Match%20Makingcategory[]Super%20Increasing%20Seq

namespace GPrep
{
    class Triplet
    {
        public int item1;
        public int item2;
        public int item3; 

        public Triplet(int i1, int i2, int i3)
        {
            item1 = i1;
            item2 = i2;
            item3 = i3;
        }

    }
    static class ArrTripletSum
    {
        public static void PrintResult()
        {
            int sum = 20; 
            var res = GetSumTriplet(new int[] { 1, 4, 45, 6, 10, 8 }, sum);

            if(res != null)
                Console.WriteLine($"Triplet with sum {sum} = {res.item1}, {res.item2}, {res.item3}");
            else
                Console.WriteLine($"Triplet with sum {sum} not found");
        }

        static Triplet GetSumTriplet(int[] arr, int sum)
        {
            Triplet triplet = null;
            Tuple<int, int> pair = null;

            for(int i = 0; i < arr.Length; i++)
            {
                pair = GetSumPair(arr, sum - arr[i], i); 
                if(pair != null)
                {
                    triplet = new Triplet(pair.Item1, pair.Item2, arr[i]);
                    break;
                }
            }

            return triplet;
        }

        static Tuple<int, int> GetSumPair(int[] arr, int sum, int skipIndex)
        {
            Tuple<int, int> pair = null;
            Dictionary<int, int> values = new Dictionary<int, int>();
            int otherIndex = -1; 

            for(int i = 0; i < arr.Length; i++)
            {
                if (i == skipIndex) continue;
                if (!values.TryGetValue(sum - arr[i], out otherIndex))
                    values[arr[i]] = i;
                else
                {
                    pair = new Tuple<int, int>(arr[i], arr[otherIndex]);
                    break;
                }
            }

            return pair; 
        }
    }
}
