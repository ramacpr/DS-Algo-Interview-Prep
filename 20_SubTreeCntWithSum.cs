using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://practice.geeksforgeeks.org/problems/count-number-of-subtrees-having-given-sum/1/?category[]=Tree&category[]=Tree&difficulty[]=1&page=1&query=category[]Treedifficulty[]1page1category[]Tree

namespace GPrep
{
    static class SubTreeCntWithSum
    {
        public static void FindSubtreeCount()
        {
            Node tree = new Node(5);
            tree.left = new Node(-10);
            tree.right = new Node(3);
            tree.left.left = new Node(9);
            tree.left.right = new Node(8);
            tree.right.left = new Node(-4);
            tree.right.right = new Node(7);

            Console.WriteLine($"Count = {GetSTCount(tree, 7)}");
        }

        static int GetSTCount(Node root, int sum)
        {
            int count = 0;

            if (root != null)
            {
                if (root.data == sum)
                    count += 1;
                if (root?.data + root?.left?.data + root?.right?.data == sum)
                    count += 1;

                count += GetSTCount(root.left, sum);
                count += GetSTCount(root.right, sum);
            }

            return count;
        }
    }
}
