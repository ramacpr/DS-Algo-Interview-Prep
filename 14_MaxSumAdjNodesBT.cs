using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://www.geeksforgeeks.org/maximum-sum-nodes-binary-tree-no-two-adjacent/

namespace GPrep
{
    static class MaxSumAdjNodesBT
    {
        public static void PrintMaxSumAdjNodes()
        {
            Node root = new Node(50);
            root.left = new Node(40);
            root.left.left = new Node(30);
            root.left.left.left = new Node(20);
            root.left.left.left.left = new Node(10);
            var res = GetMaxSumOfAdjNodes(root);

            Console.WriteLine($"The max sum is : {Math.Max(res.Item1, res.Item2)}");
        }

        // item1 - sum with root.val 
        // item2 - sum without root.val
        static Tuple<int,int> GetMaxSumOfAdjNodes(Node root)
        {
            Tuple<int, int> sum = null;
            if(root == null)
            {
                sum = new Tuple<int, int>(0, 0);
                return sum;
            }

            var leftSum = GetMaxSumOfAdjNodes(root.left);
            var rightSum = GetMaxSumOfAdjNodes(root.right);
            int sumWith = root.data + leftSum.Item2 + rightSum.Item2;
            int sumWithout = Math.Max(leftSum.Item1, leftSum.Item2) +
                                Math.Max(rightSum.Item1, rightSum.Item2);

            sum = new Tuple<int, int>(sumWith, sumWithout);
            return sum; 
        }
    }
}
