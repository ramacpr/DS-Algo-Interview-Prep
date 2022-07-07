using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://practice.geeksforgeeks.org/problems/bottom-view-of-binary-tree/1/?category[]=Tree&category[]=Tree&difficulty[]=1&page=2&query=category[]Treedifficulty[]1page2category[]Tree

namespace GPrep
{
    static class BottomViewBT
    {
        public static void PrintBottomView()
        {
            Node tree = new Node(20);
            tree.left = new Node(8);
            tree.left.left = new Node(5);
            tree.left.right = new Node(3);
            
            tree.right = new Node(22);
            

            Dictionary<int, Stack<int>> columnWiseData = new Dictionary<int, Stack<int>>();
            UpdateBottomView(tree, ref columnWiseData); 
            foreach(var kv in columnWiseData)
                Console.Write($"{kv.Value.Peek()} ");

        }

        static void UpdateBottomView(Node tree, ref Dictionary<int, Stack<int>> columnWiseData, int columnVal = 0)
        {
            if (tree == null) return;

            Stack<int> tmp = null;
            if(!columnWiseData.TryGetValue(columnVal, out tmp))
            {
                // add new column data 
                tmp = new Stack<int>();
                tmp.Push(tree.data);

                columnWiseData[columnVal] = tmp;
            }
            else
            {
                // column already present, just update the stack
                tmp.Push(tree.data);
            }

            UpdateBottomView(tree.left, ref columnWiseData, columnVal - 1);
            UpdateBottomView(tree.right, ref columnWiseData, columnVal + 1);

        }
    }
}
