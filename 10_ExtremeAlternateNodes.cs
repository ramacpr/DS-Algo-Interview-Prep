using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://practice.geeksforgeeks.org/problems/extreme-nodes-in-alternate-order/1/?category[]=Tree&category[]=Tree&difficulty[]=1&page=2&query=category[]Treedifficulty[]1page2category[]Tree
// 1Hr

namespace GPrep
{
    static class ExtremeAlternateNodes
    {
        public static void PrintExtremeAlternateNodes()
        {
            Node root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);
            root.left.left = new Node(4);
            root.left.right = new Node(5);
            root.right.left = new Node(6);
            root.right.right = new Node(7);
            root.left.left.left = new Node(8);
            root.left.left.right = new Node(9);
            root.left.right.left = new Node(10);
            root.left.right.right = new Node(11);
            root.right.left.left = new Node(12);
            root.right.left.right = new Node(13);
            root.right.right.left = new Node(14);
            root.right.right.right = new Node(15);
            root.left.left.left.left = new Node(16);
            root.left.left.left.right = new Node(17);
            root.left.left.right.left = new Node(18);
            root.left.left.right.right = new Node(19);
            root.left.right.left.left = new Node(20);
            root.left.right.left.right = new Node(21);
            root.left.right.right.left = new Node(22);
            root.left.right.right.right = new Node(23);
            root.right.left.left.left = new Node(24);
            root.right.left.left.right = new Node(25);
            root.right.left.right.left = new Node(26);
            root.right.left.right.right = new Node(27);
            root.right.right.left.left = new Node(28);
            root.right.right.left.right = new Node(29);
            root.right.right.right.left = new Node(30);
            root.right.right.right.right = new Node(31);

            Console.WriteLine($"The alternate extreme nodes are: {GetExtAltNodes(root)}");
        }

        static string GetExtAltNodes(Node root)
        {
            string result = "";

            if (root == null)
                return result;

            Queue<Node> processQ = new Queue<Node>();
            int count = 1, jumpCount = 0, residueCnt = 0;
            Node deQNode = null;            

            processQ.Enqueue(root);

            while (processQ.Count > 0)
            {
                deQNode = processQ.Dequeue();
                if (deQNode.left != null)
                    processQ.Enqueue(deQNode.left);
                if (deQNode.right != null)
                    processQ.Enqueue(deQNode.right);

                result += deQNode.data.ToString() + " ";

                if (processQ.Count > 0)
                {
                    deQNode = processQ.Dequeue();
                    if (deQNode.left != null)
                        processQ.Enqueue(deQNode.left);
                    if (deQNode.right != null)
                        processQ.Enqueue(deQNode.right);

                    result += deQNode.data.ToString() + " ";
                }

                residueCnt = GetJumpCount(count) - 1;
                count++;
                jumpCount = GetJumpCount(count) + residueCnt - 1;
                count++;
                
                while (jumpCount > 0 && processQ.Count > 0)
                {
                    deQNode = processQ.Dequeue();
                    if (deQNode.left != null)
                        processQ.Enqueue(deQNode.left);
                    if (deQNode.right != null)
                        processQ.Enqueue(deQNode.right);
                    jumpCount -= 1;
                }                
            }

            return result;
        }

        static int GetJumpCount(int count)
        {
            return ((int)Math.Pow(2, count));
        }
    }
}
