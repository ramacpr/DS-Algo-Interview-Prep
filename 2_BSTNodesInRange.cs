using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://practice.geeksforgeeks.org/problems/count-bst-nodes-that-lie-in-a-given-range/1/?category[]=Tree&category[]=Tree&difficulty[]=1&page=1&query=category[]Treedifficulty[]1page1category[]Tree
// 18mins, 35s

namespace GPrep
{
    static class BSTNodesInRange
    {
        public static void PrintCountOfNodesInRng()
        {
            Node root = new Node(100);
            root.left = new Node(92);
            root.left.left = new Node(80);
            root.left.left.left = new Node(60);
            root.left.left.right = new Node(82);
            root.left.right = new Node(95);
            root.left.right.right = new Node(99);
            root.right = new Node(113);
            root.right.left = new Node(110);
            root.right.right = new Node(250);
            root.right.right.right = new Node(350);

            Console.WriteLine($"Number of nodes in range = {GetNodesInRange(root, 80, 200)}"); 

        }

        static int GetNodesInRange(Node root, int min, int max)
        {
            int count = 0;

            if (root == null)
                return count;

            if (root.data >= min && root.data <= max) // in range, process left and right subtrees
            {
                count++;
                count += GetNodesInRange(root.left, min, max);
                count += GetNodesInRange(root.right, min, max);
            }
            else if (root.data > max) // only check the left subtree           
                count += GetNodesInRange(root.left, min, max);
            else if (root.data < min) // only check the right subtree
                count += GetNodesInRange(root.right, min, max); 


            return count; 
        }
    }
}
