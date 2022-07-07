using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPrep
{
    static class SerializeDeserialize
    {
        static int index = 0;
        public static void SerializeDeserializeBT()
        {
            Node tree = new Node(20);
            tree.left = new Node(8);
            tree.left.left = new Node(5);
            tree.left.right = new Node(3);
            tree.right = new Node(22);

            int count = GetTreeSize(tree);
            int[] arr = new int[count];

            SerializeBT(tree, ref arr);

            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]} ");
        }

        static int GetTreeSize(Node root)
        {
            if (root == null)
                return 0; 

            int count = 0;
            count = 1 + GetTreeSize(root.left) + GetTreeSize(root.right);

            return count;
        }

        static void SerializeBT(Node root, ref int[] arr)
        {
            if (root == null)
                return;

            SerializeBT(root.left, ref arr);
            AddNextItemToArray(ref arr, root.data);
            SerializeBT(root.right, ref arr);
        }

        static void AddNextItemToArray(ref int[] arr, int item)
        {
            if (index >= arr.Length)
                return;
            arr[index] = item;
            index += 1;
        }
    }
}
