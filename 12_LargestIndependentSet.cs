using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://practice.geeksforgeeks.org/problems/largest-independent-set-problem/1/?category[]=Tree&category[]=Tree&difficulty[]=1&page=1&query=category[]Treedifficulty[]1page1category[]Tree
// 23min
namespace GPrep
{
    static class LargestIndependentSet
    {
        public static void PrintLIS()
        {
            Node root = new Node(10);
            root.left = new Node(20);
            root.right = new Node(30);
            root.left.left = new Node(40);
            root.left.right = new Node(50);
            root.left.right.left = new Node(70);
            root.left.right.right = new Node(80);
            root.right.right = new Node(60);

            var res = GetLIS(root);
            HashSet<Node> LIS = null;
            if (res.Item1.Count > res.Item2.Count)
                LIS = res.Item1;
            else
                LIS = res.Item2;

            Console.WriteLine($"LIS count is {LIS.Count}");
            foreach (var node in LIS)
                Console.Write($"{node.data} ");
        }

        static Tuple<HashSet<Node>, HashSet<Node>> GetLIS(Node root)
        {
            Tuple<HashSet<Node>, HashSet<Node>> result = null;

            if(root == null)
            {
                result = new Tuple<HashSet<Node>, HashSet<Node>>(new HashSet<Node>(), new HashSet<Node>());
                return result;
            }

            var leftPair = GetLIS(root.left);
            var rightPair = GetLIS(root.right);
            var with = new HashSet<Node>();
            with.Add(root);
            with.UnionWith(leftPair.Item2);
            with.UnionWith(rightPair.Item2);

            var without = new HashSet<Node>();
            if (leftPair.Item1.Count > leftPair.Item2.Count)
                without.UnionWith(leftPair.Item1);
            else
                without.UnionWith(leftPair.Item2);

            if (rightPair.Item1.Count > rightPair.Item2.Count)
                without.UnionWith(rightPair.Item1);
            else
                without.UnionWith(rightPair.Item2);

            result = new Tuple<HashSet<Node>, HashSet<Node>>(with, without);

            return result;
        }
    }
}
