using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://practice.geeksforgeeks.org/problems/populate-inorder-successor-for-all-nodes/1/?category[]=Tree&category[]=Tree&difficulty[]=1&page=2&query=category[]Treedifficulty[]1page2category[]Tree
// 1Hr, 30mins
// O(n)

namespace GPrep
{
    class InNode
    {
        public int data;
        public InNode left;
        public InNode right;
        public InNode next;

        public InNode(int val) => data = val; 
    }
    static class ConnectNodesInOrder
    {
        static int count = 0; 
        public static void ConnectInOrder()
        {
            InNode root = new InNode(1);
            root.left = new InNode(2);
            root.left.left = new InNode(6);
            root.left.left.left = new InNode(13);
            root.left.right = new InNode(7);
            root.right = new InNode(4);
            root.right.left = new InNode(8);
            root.right.right = new InNode(12);
            root.right.right.left = new InNode(18);
            root.right.right.right = new InNode(17);
            root.right.right.left.left = new InNode(14);
            root.right.right.left.left.left = new InNode(9);

            ConnectNode(root);
        }

        static void PrintInOrder(InNode root)
        {
            if(root != null)
            {
                PrintInOrder(root.left);
                Console.WriteLine($"{root.data.ToString()} ");
                PrintInOrder(root.right);
            }
        }

       
        static void ConnectNode(InNode root)
        {
            if(root != null)
            {
                ConnectNode(root.left); 

                var pred = GetPred(root.left);
                if (pred != null)
                    pred.next = root;
                var succ = GetSucc(root.right);
                root.next = succ;

                ConnectNode(root.right);
            }
        }

        static InNode GetPred(InNode root)
        {
            if (root == null) return null; 
            // left subtrees right most
            InNode predNode = null;

            if (root.right != null)
                predNode = GetPred(root.right);
            else
            {
                predNode = root;
                count++;
            }

            return predNode;
        }

        static InNode GetSucc(InNode root)
        {
            if (root == null) return null;
            InNode succNode = null;

            if (root.left != null)
                succNode = GetSucc(root.left);
            else
            {
                succNode = root;
                count++;
            }

            return succNode;
        }
    }
}
