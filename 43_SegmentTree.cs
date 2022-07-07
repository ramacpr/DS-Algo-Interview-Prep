using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPrep
{
    class STNode
    {
        public int SumValue = 0;
        public int StartIndex = -1;
        public int EndIndex = -1;

        public STNode(int sum, int startIndex, int endIndex)
        {
            SumValue = sum;
            StartIndex = startIndex;
            EndIndex = endIndex;
        }
    }

    public class SegmentTree
    {
        STNode[] segmentTree = null;
        int[] Arr = null; 

        public void ConstructST(int[] arr)
        {
            if (arr.Length == 0)
                return;

            Arr = arr; 
            int stSize = GetSTSize(arr.Length);
            segmentTree = new STNode[stSize];

            Build(arr, 0, arr.Length - 1);
        }

        // O(n), O(n) 
        int Build(int[] arr, int start, int end, int index = 0)
        {
            int sum = 0;
            if(start < end && index < segmentTree.Length)
            {
                int mid = (start + end) / 2;
                sum += Build(arr, start, mid, ((2 * index) + 1)); // left subtree
                sum += Build(arr, mid + 1, end, ((2 * index) + 2)); // right subtree

                segmentTree[index] = new STNode(sum, start, end);
            } 
            else if(start == end && index < segmentTree.Length)
            {
                segmentTree[index] = new STNode(arr[start], start, end);
                sum = arr[start];
            }
            return sum;
        }

        int GetSTSize(int arrLen)
        {
            int res = 0;

            if (arrLen % 2 != 0)
                res += 1;

            res = res + (arrLen / 2);

            return (int)Math.Pow(2, res + 1); 
        }

        public int SumQuery(int start, int end, int arrStart, int arrEnd, int stIndex = 0)
        {
            int sum = 0;
            if(arrStart <= arrEnd && stIndex < segmentTree.Length)
            {
                var treeNode = segmentTree[stIndex];
                if (treeNode == null)
                    return 0;

                // 1. No overlap, return 0
                if ((start < treeNode.StartIndex || start > treeNode.EndIndex) &&
                        (end > treeNode.EndIndex || end < treeNode.StartIndex))
                    return 0;

                // 2. Full overlap 
                if (start == treeNode.StartIndex && end == treeNode.EndIndex)
                    //((start > treeNode.StartIndex && start < treeNode.EndIndex) &&
                    //(end > treeNode.StartIndex && end < treeNode.EndIndex)))
                    return treeNode.SumValue; 
                else // partial overlap
                {
                    // look left then right
                    int mid = (arrStart + arrEnd) / 2;
                    sum += SumQuery(start, end, arrStart, mid, (2 * stIndex) + 1);
                    sum += SumQuery(start, end, mid + 1, arrEnd, (2 * stIndex) + 2); 
                }
                
            }
            return sum;
        }

        public int SumQueryNew(int left, int right, int start, int end)
        {
            int mid = (start + end) / 2;
            return segmentTree[0].SumValue - 
                (_SumQuery(left, right, 0, left - 1, 1) + _SumQuery(left, right, right + 1, Arr.Length - 1, 2));
        }
        int _SumQuery(int left, int right, int start, int end, int stIndex)
        {
            int sum = 0;
                       

            if (stIndex >= segmentTree.Length)
                return 0;

            var stNode = segmentTree[stIndex];
            if (stNode == null)
                return 0;

            // full match
            if (stNode.StartIndex == start && stNode.EndIndex == end)
                return stNode.SumValue;
            // no match
            if (start < stNode.StartIndex && start > stNode.EndIndex &&
                end < stNode.StartIndex && end > stNode.EndIndex)
                return 0;
            // partial match
            sum = stNode.SumValue - (_SumQuery(left, right, 0, left - 1, (2 * stIndex) + 1) +
                _SumQuery(left, right, right + 1, Arr.Length - 1, (2 * stIndex) + 2));

            return sum;
        }

        public void UpdateArrayAt(int index, int newValue)
        {
            if (index >= Arr.Length)
                return;

            Arr[index] = newValue;
            UpdateSegmentTree(0, segmentTree.Length - 1, 0, Arr[index] - newValue);          
        }

        void UpdateSegmentTree(int start, int end, int stIndex, int diffValue)
        {
            if (start > end) return;
            if (stIndex >= segmentTree.Length) return;

            int mid = (start + end) / 2;

            // update this node
            segmentTree[stIndex].SumValue -= diffValue;

            if (stIndex <= mid) // left subtree
                UpdateSegmentTree(start, mid, stIndex, diffValue);
            else
                UpdateSegmentTree(mid + 1, end, stIndex, diffValue);
        }
    }
}
