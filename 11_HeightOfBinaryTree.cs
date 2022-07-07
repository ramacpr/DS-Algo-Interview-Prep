using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPrep
{
    class Node
    {
        public int data;
        public Node left;
        public Node right;

        public Node(int key)
        {
            this.data = key;
            this.left = null;
            this.right = null;
        }
    }

    static class HeightOfBinaryTree
    {
        public static void PrintHeightOfTree()
        {
            Node root = new Node(50);
            root.left = new Node(40);
            root.left.left = new Node(30);
            root.left.left.left = new Node(20);
            root.left.left.left.left = new Node(10);
            

            Console.WriteLine($"Height of tree = {ComputeHight(root)}");
        }

        static int ComputeHight(Node root)
        {
            int height = 0;

            if (root == null) return height;

            height = 1 + Math.Max(ComputeHight(root.left), ComputeHight(root.right));

            return height; 
        }
    }
}
