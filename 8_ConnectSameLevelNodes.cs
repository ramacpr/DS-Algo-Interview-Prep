using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://practice.geeksforgeeks.org/problems/connect-nodes-at-same-level/1/?category[]=Tree&category[]=Tree&difficulty[]=1&page=2&query=category[]Treedifficulty[]1page2category[]Tree
// 33mins

namespace GPrep
{
    class LLTreeNode
    {
        public int data;
        public LLTreeNode left;
        public LLTreeNode right;
        public LLTreeNode rNode;

        public LLTreeNode(int val) => data = val;
    }
    static class ConnectSameLevelNodes
    {
        public static void ConnectLevelNodes()
        {
            LLTreeNode root = new LLTreeNode(1);
            root.left = new LLTreeNode(2);
            root.right = new LLTreeNode(3);
            root.left.left = new LLTreeNode(4);
            root.right.left = new LLTreeNode(6);
            root.right.right = new LLTreeNode(7);
            root.left.left.right = new LLTreeNode(9);
            root.right.left.left = new LLTreeNode(12);
            root.right.right.left = new LLTreeNode(14);

            Connect(root);
        }

        static void Connect(LLTreeNode root)
        {
            if (root == null)
                return;

            Queue<LLTreeNode> processQ = new Queue<LLTreeNode>();
            Queue<LLTreeNode> levelQ = new Queue<LLTreeNode>();
            LLTreeNode currNode = null;

            processQ.Enqueue(root);

            while (processQ.Count > 0)
            {
                while (processQ.Count > 0)
                {
                    currNode = processQ.Dequeue();
                    if (currNode.left != null)
                        levelQ.Enqueue(currNode.left);
                    if (currNode.right != null)
                        levelQ.Enqueue(currNode.right);

                    if (processQ.Count >= 1)
                        currNode.rNode = processQ.Peek();
                }

                while (levelQ.Count > 0)
                {
                    currNode = levelQ.Dequeue();
                    if(currNode.left != null)
                        processQ.Enqueue(currNode.left);
                    if(currNode.right != null)
                        processQ.Enqueue(currNode.right);

                    if(levelQ.Count >= 1)
                        currNode.rNode = levelQ.Peek();
                }
            }
        }
    }
}
