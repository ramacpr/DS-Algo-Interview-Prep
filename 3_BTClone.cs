using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://practice.geeksforgeeks.org/problems/clone-a-binary-tree/1/?category[]=Tree&category[]=Tree&difficulty[]=1&page=1&query=category[]Treedifficulty[]1page1category[]Tree
// 1Hr, 30mins

namespace GPrep
{
    class SNode
    {
        public int data;
        public SNode left;
        public SNode right;
        public SNode rand;

        public SNode(int val) => data = val; 
    }
    static class BTClone
    {
        static Dictionary<int, Stack<bool>> nodePath = new Dictionary<int, Stack<bool>>();

        public static void DoClone()
        {
            Console.WriteLine($"Result = {TryClone().ToString()}");
        }

        static bool TryClone()
        {            
            Stack<bool> pathSt = new Stack<bool>(); 

            SNode src = new SNode(1);
            src.left = new SNode(2);
            src.right = new SNode(3);
            src.left.left = new SNode(4);            
            src.left.right = new SNode(5);
            src.right.left = new SNode(6);
            src.right.right = new SNode(7);
            src.left.left.left = new SNode(8);
            src.left.left.right = new SNode(9);
            src.right.right.right = new SNode(10);

            src.rand = src.left.left.left;
            src.right.rand = src.left.left.right;
            src.left.right.rand = src.left.left;
            src.right.right.rand = src.left;
            src.right.right.right.rand = src.left.right;


            SNode dest = new SNode(src.data);

            // step 1, 
            // clone without rand
            if (!Clone(src, dest, ref pathSt))
                return false;

            // step 2: 
            // update rand pointers
            if (!UpdateRandomNodes(dest, src, ref dest))
                return false;

            return true;
        }

        private static bool UpdateRandomNodes(SNode srcRoot, SNode srcCurr, ref SNode destCurr)
        {
            if (srcCurr == null) return true; 

            if(srcCurr.rand != null)
            {
                int randVal = srcCurr.rand.data;
                Stack<bool> st = nodePath[randVal];
                if (st == null)
                    return false;
                var destRandNode = GetRandNode(srcRoot, st, randVal);
                if (destRandNode == null)
                    return false;

                // all checks done. Can assign the proper rand node now
                destCurr.rand = destRandNode;
            }

            if (!UpdateRandomNodes(srcRoot, srcCurr.left, ref destCurr.left))
                return false;

            if (!UpdateRandomNodes(srcRoot, srcCurr.right, ref destCurr.right))
                return false; 

            return true;
        }

        static SNode GetRandNode(SNode destRoot, Stack<bool> pathSt, int expectedRandVal)
        {
            SNode curr = destRoot;
            var path = pathSt.ToArray();
            for(int i = 0; 
                (i < path.Length && curr != null); 
                i++)
            {
                if (path[i] == false) // left
                    curr = curr.left;
                else
                    curr = curr.right; 
            }
            if (curr == null) // cant find rand
                return null;
            if (curr.data != expectedRandVal)
                return null;

            return curr;
        }

        static bool Clone(SNode root, SNode newRoot, ref Stack<bool> pathSt)
        {
            // for each new node we encounter, 
            // update how to reach it from the root of the tree
            if(newRoot == null)
            {
                Console.WriteLine("Somethings not right!");
                return false; 
            }

            if (root == null) // all done
                return true;

            nodePath[root.data] = new Stack<bool>(pathSt); 

            if (root.left != null)
            {
                newRoot.left = new SNode(root.left.data);
                pathSt.Push(false);
                if (!Clone(root.left, newRoot.left, ref pathSt))
                    return false;
                pathSt.Pop();
            }
            if (root.right != null)
            {
                pathSt.Push(true);
                newRoot.right = new SNode(root.right.data);
                if (!Clone(root.right, newRoot.right, ref pathSt))
                    return false;
                pathSt.Pop();
            }

            return true; 
        }
    }
}
