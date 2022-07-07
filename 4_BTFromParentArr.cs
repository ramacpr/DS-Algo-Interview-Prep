using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://practice.geeksforgeeks.org/problems/construct-binary-tree-from-parent-array/1/?category[]=Tree&category[]=Tree&difficulty[]=1&page=2&query=category[]Treedifficulty[]1page2category[]Tree
// 15mins

namespace GPrep
{
    static class BTFromParentArr
    {
        public static void ConstructBTFromParentArr()
        {
            Node tree = ConstructBT(new int[] { -1, 0, 0, 1, 1, 3, 5 });
        }

        static Node ConstructBT(int[] parentArr)
        {
            Node root = null;
            Node curr = null, parentNode = null;
            Dictionary<int, Node> nodes = new Dictionary<int, Node>(); 

            for(int index = 0; index < parentArr.Length; index++)
            {
                curr = new Node(index);
                nodes[index] = curr;
                if (parentArr[index] == -1 && root == null)
                {
                    root = curr;
                    continue;
                }
                else if (parentArr[index] == -1 && root != null)
                {
                    Console.WriteLine("NotAnOperator data");
                    return null;
                }

                parentNode = nodes[parentArr[index]];
                if (parentNode != null)
                {
                    if (parentNode.left == null)
                        parentNode.left = curr;
                    else if (parentNode.right == null)
                        parentNode.right = curr;
                    else
                    {
                        Console.WriteLine("NotAnOperator data");
                        return null;
                    }
                }
            }


            return root; 
        }
    }
}
