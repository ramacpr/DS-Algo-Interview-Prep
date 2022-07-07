using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPrep
{
    static class CheckBST
    {
        public static void CheckForBST()
        {
            Node root = new Node(50);
            root.left = new Node(40);
            root.left.left = new Node(30);
            root.left.left.left = new Node(20);
            root.left.left.left.left = new Node(10);

            Console.WriteLine($"IsBST = {IsBST(root).ToString()}");
        }

        static bool IsBST(Node root)
        {
            if (root == null) return true;

            bool isSubTreeBST = true;
            if (root.left != null && root.left.data < root.data)
                isSubTreeBST = IsBST(root.left);
            else if (root.left != null && root.left.data >= root.data)
                isSubTreeBST = false;

            if (isSubTreeBST)
            {
                if (root.right != null && root.right.data >= root.data)
                    isSubTreeBST = IsBST(root.right);
                else if (root.right != null && root.right.data < root.data)
                    isSubTreeBST = false;
            }

            return isSubTreeBST;
        }
    }
}
