using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://practice.geeksforgeeks.org/problems/lowest-common-ancestor-in-a-binary-tree/1/?category[]=Tree&category[]=Tree&difficulty[]=1&page=2&query=category[]Treedifficulty[]1page2category[]Tree

namespace GPrep
{
    static class LeastCommonAncestor
    {
        public static void PrintLCANode()
        {
            Node root = new Node(1);
            root.left = new Node(2);
            root.left.left = new Node(6);
            root.left.left.left = new Node(13);
            root.left.right = new Node(7);
            root.right = new Node(4);
            root.right.left = new Node(8);
            root.right.right = new Node(12);
            root.right.right.left = new Node(18);
            root.right.right.right = new Node(17);
            root.right.right.left.left = new Node(14);
            root.right.right.left.left.left = new Node(9);

            Stack<Node> st1 = new Stack<Node>();
            st1.Push(root);
            Stack<Node> st2 = new Stack<Node>();
            st2.Push(root);
            FindLCA(root, 18, 8, ref st1, ref st2);
        }

        static bool isn1Found = false, isn2Found = false; 
        static bool FindLCA(Node root, int n1, int n2, ref Stack<Node> stk1, ref Stack<Node> stk2)
        {

            if (root == null) return true; 
            if(root.data == n1) isn1Found = true;
            if(root.data == n2) isn2Found = true;

            if (isn1Found && isn2Found)
            {
                // print the LCA and return!
                stk1.Pop();
                stk2.Pop();
                PrintLCANode(n1, n2, stk1, stk2);
                return false;
            }
            else
            {
                // check left
                if (isn1Found == false) stk1.Push(root.left);
                if (isn2Found == false) stk2.Push(root.left);

                if (!FindLCA(root.left, n1, n2, ref stk1, ref stk2))
                    return false;

                if (isn1Found == false) stk1.Pop();
                if (isn2Found == false) stk2.Pop();

                // check right 
                if (isn1Found == false) stk1.Push(root.right);
                if (isn2Found == false) stk2.Push(root.right);

                if (!FindLCA(root.right, n1, n2, ref stk1, ref stk2))
                    return false;

                if (isn1Found == false) stk1.Pop();
                if (isn2Found == false) stk2.Pop();
            }
            return true;
        }

        static void PrintLCANode(int n1, int n2, Stack<Node> stk1, Stack<Node> stk2)
        {
            var largerStk = stk1;
            var smallerStk = stk2;
            Node LCANode = null; 

            if(smallerStk.Count > largerStk.Count)
            {
                largerStk = stk2;
                smallerStk = stk1;
            }

            int diffCount = largerStk.Count - smallerStk.Count; 
            while(diffCount > 0)
            {
                var node = largerStk.Pop(); 
                if(node.data == n1 || node.data == n2)
                {
                    LCANode = node;
                    break; 
                }
                diffCount -= 1;
            }

            while(LCANode == null && (largerStk.Peek().data != smallerStk.Peek().data))
            {
                largerStk.Pop();
                smallerStk.Pop(); 
            }

            if (largerStk.Peek().data == smallerStk.Peek().data)
                LCANode = largerStk.Peek();

            if (LCANode == null)
                Console.WriteLine($"LCA for {n1} and {n2} not found");
            else
                Console.WriteLine($"LCA for {n1} and {n2} is {LCANode.data}");
        }
    }
}
