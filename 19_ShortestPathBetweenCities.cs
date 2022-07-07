using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://practice.geeksforgeeks.org/problems/shortest-path-between-cities/1/?difficulty[]=1&page=1&category[]=Tree&query=difficulty[]1page1category[]Tree
// https://practice.geeksforgeeks.org/problems/min-distance-between-two-given-nodes-of-a-binary-tree/1/?category[]=Tree&category[]=Tree&difficulty[]=1&page=2&query=category[]Treedifficulty[]1page2category[]Tree

// 2hr, 34mins

namespace GPrep
{
    static class ShortestPathBetweenCities
    {
        public static void PrintShortestDist()
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

            var n1 = root.right.right.left.left.left;
            var n2 = root.right.right.left.left.left;
            GetShortestDist(root, n1, n2, ref st1, ref st2);

        }

        static bool isn1Found = false, isn2Found = false;

        static bool GetShortestDist(Node root, Node n1, Node n2, ref Stack<Node> st1, ref Stack<Node> st2)
        {
            if (root == null || (n1 == null && n2 == null))
                return false;
            if (n1 == n2)
            {
                Console.WriteLine($"Shortest distance between {n1.data} and {n2.data} is 0");
                return false; // same node distance is 0
            }

            if (n1 != null && root == n1) // found one
            {
                isn1Found = true;
                st1.Pop();
            }
            if (n2 != null && root == n2) // found the other 
            {
                isn2Found = true;
                st2.Pop();
            }

            if (isn1Found && isn2Found)
            {
                int diffCnt = 0;
                bool foundLCA = false;
                Stack<Node> larger = null, smaller = null;
                if (st1.Count > st2.Count)
                {
                    larger = st1;
                    smaller = st2;

                }
                else if (st1.Count < st2.Count)
                {
                    larger = st2;
                    smaller = st1;
                }
                if(larger != null && smaller != null)
                {
                    diffCnt = larger.Count - smaller.Count;
                    var cnt = diffCnt;
                    while (cnt > 0)
                    {
                        if (larger.Peek().data == n1.data || larger.Peek().data == n2.data)
                            foundLCA = true;
                        larger.Pop();
                        cnt--;
                    }
                }

                while (!foundLCA && st1.Peek() != st2.Peek())
                {                    
                    st1.Pop();
                    st2.Pop();
                    diffCnt += 2;
                }
                if(!foundLCA)
                    diffCnt += 2;
                Console.WriteLine($"Shortest distance between {n1.data} and {n2.data} is {diffCnt}");

                return false;
            }
            

            if (root.left != null)
            {
                if(!isn1Found)
                    st1.Push(root.left);
                if (!isn2Found)
                    st2.Push(root.left);

                if (!GetShortestDist(root.left, n1, n2, ref st1, ref st2))
                    return false;

                if (!isn1Found)
                    st1.Pop();
                if (!isn2Found)
                    st2.Pop();
            }

            if (root.right != null)
            {
                if (!isn1Found)
                    st1.Push(root.right);
                if (!isn2Found)
                    st2.Push(root.right);

                if (!GetShortestDist(root.right, n1, n2, ref st1, ref st2))
                    return false;

                if (!isn1Found)
                    st1.Pop();
                if (!isn2Found)
                    st2.Pop();
            }
            return true;
        }
    }
}
