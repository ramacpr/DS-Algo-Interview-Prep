using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://practice.geeksforgeeks.org/problems/find-the-closest-element-in-bst/1/?category[]=Tree&category[]=Tree&difficulty[]=1&page=2&query=category[]Treedifficulty[]1page2category[]Tree
// 35mins

namespace GPrep
{
    static class ClosestNodeinBST
    {
        public static void PrintClosestNode()
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

            Console.WriteLine($"Node closest to 85 is {GetClosestNode(root, 150).data}");
        }

        static Node GetClosestNode(Node root, int key)
        {
            int minDiff = 0;
            Node closestNode = null;

            if (root.data == key) // this is the closest!
                return closestNode;

            minDiff = Math.Abs(root.data - key);
            closestNode = root;
            if (key < root.data && root.left != null)
                closestNode = GetClosestNode(root.left, key);
            else if(key > root.data && root.right != null)
                closestNode = GetClosestNode(root.right, key);

            if (closestNode != null && minDiff < Math.Abs(closestNode.data - key))
                closestNode = root; 

            return closestNode;
        }
    }
}
