using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://practice.geeksforgeeks.org/problems/trapping-rain-water-1587115621/1/?category[]=Arrays&category[]=Strings&category[]=Matrix&category[]=two-pointer-algorithm&category[]=sliding-window&category[]=Segment-Tree&category[]=Trie&category[]=Fibonacci&category[]=prefix-sum&category[]=Pattern%20Searching&category[]=Disjoint%20Set&category[]=Kadane&category[]=Binary%20Indexed%20Tree&category[]=Range%20Minimum%20Query&category[]=LCS&category[]=Character%20Encoding&category[]=anagram&category[]=Match%20Making&category[]=Super%20Increasing%20Seq&category[]=Arrays&category[]=Strings&category[]=Matrix&category[]=two-pointer-algorithm&category[]=sliding-window&category[]=Segment-Tree&category[]=Trie&category[]=Fibonacci&category[]=prefix-sum&category[]=Pattern%20Searching&category[]=Disjoint%20Set&category[]=Kadane&category[]=Binary%20Indexed%20Tree&category[]=Range%20Minimum%20Query&category[]=LCS&category[]=Character%20Encoding&category[]=anagram&category[]=Match%20Making&category[]=Super%20Increasing%20Seq&difficulty[]=1&page=2&query=category[]Arrayscategory[]Stringscategory[]Matrixcategory[]two-pointer-algorithmcategory[]sliding-windowcategory[]Segment-Treecategory[]Triecategory[]Fibonaccicategory[]prefix-sumcategory[]Pattern%20Searchingcategory[]Disjoint%20Setcategory[]Kadanecategory[]Binary%20Indexed%20Treecategory[]Range%20Minimum%20Querycategory[]LCScategory[]Character%20Encodingcategory[]anagramcategory[]Match%20Makingcategory[]Super%20Increasing%20Seqdifficulty[]1page2category[]Arrayscategory[]Stringscategory[]Matrixcategory[]two-pointer-algorithmcategory[]sliding-windowcategory[]Segment-Treecategory[]Triecategory[]Fibonaccicategory[]prefix-sumcategory[]Pattern%20Searchingcategory[]Disjoint%20Setcategory[]Kadanecategory[]Binary%20Indexed%20Treecategory[]Range%20Minimum%20Querycategory[]LCScategory[]Character%20Encodingcategory[]anagramcategory[]Match%20Makingcategory[]Super%20Increasing%20Seq

namespace GPrep
{
    static class TrappedWater
    {
        public static void PrintResult()
        {
            ComputeTrappedWater(new int[] { 4,3,2,1 });
        }

        static void ComputeTrappedWater(int[] blocks)
        {
            if(blocks.Length <= 2)
            {
                Console.WriteLine($"0 units of water is trapped");
                return;
            }

            int arrLen = blocks.Length;
            int[] leftMax = new int[arrLen];
            int[] rightMax = new int[arrLen];
            Stack<int> st = new Stack<int>();
            int trappedWater = 0;

            st.Push(0);
            leftMax[0] = -1;
            rightMax[arrLen - 1] = -1; 

            // pass 1 - find left max 
            for(int i = 1; i < arrLen; i++)
            {
                var item = i; 
                // get the immediate max on left
                while (st.Count > 0 && blocks[item] >= blocks[st.Peek()])                
                    st.Pop();

                // ensure that top of stack is the max of max on left
                while (st.Count > 0)
                {
                    item = st.Pop();
                    if ((st.Count == 0) || (st.Count > 0 && blocks[item] > blocks[st.Peek()]))
                    {
                        st.Push(item);
                        break;
                    }  
                }

                if (st.Count == 0)
                    leftMax[i] = -1;
                else
                    leftMax[i] = st.Peek();

                st.Push(i);                     
            }

            st.Clear();

            st.Push(arrLen - 1);
            // pass 2 - find right max 
            for (int i = arrLen - 2; i >= 0; i--)
            {
                var item = i;
                // get the immediate max on left
                while (st.Count > 0 && blocks[item] >= blocks[st.Peek()])
                    st.Pop();

                // ensure that top of stack is the max of max on left
                while (st.Count > 0)
                {
                    item = st.Pop();
                    if ((st.Count == 0) || (st.Count > 0 && blocks[item] > blocks[st.Peek()]))
                    {
                        st.Push(item);
                        break;
                    }
                }

                if (st.Count == 0)
                    rightMax[i] = -1;
                else
                    rightMax[i] = st.Peek();

                st.Push(i);
            }

            // finally calculate the trapped water at each index and sum up
            // the first and last index item cannot block any water
            for(int i = 0; i < arrLen; i++)
            {
                if (leftMax[i] == -1 || rightMax[i] == -1)
                    continue; 
                trappedWater += Math.Min(blocks[leftMax[i]], blocks[rightMax[i]]) - blocks[i];
            }

            Console.WriteLine($"{trappedWater} units of water is trapped");
        }
    }
}
