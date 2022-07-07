using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://practice.geeksforgeeks.org/problems/spirally-traversing-a-matrix-1587115621/1/?category[]=Arrays&category[]=Strings&category[]=Matrix&category[]=two-pointer-algorithm&category[]=sliding-window&category[]=Segment-Tree&category[]=Trie&category[]=Fibonacci&category[]=prefix-sum&category[]=Pattern%20Searching&category[]=Disjoint%20Set&category[]=Kadane&category[]=Binary%20Indexed%20Tree&category[]=Range%20Minimum%20Query&category[]=LCS&category[]=Character%20Encoding&category[]=anagram&category[]=Match%20Making&category[]=Super%20Increasing%20Seq&category[]=Arrays&category[]=Strings&category[]=Matrix&category[]=two-pointer-algorithm&category[]=sliding-window&category[]=Segment-Tree&category[]=Trie&category[]=Fibonacci&category[]=prefix-sum&category[]=Pattern%20Searching&category[]=Disjoint%20Set&category[]=Kadane&category[]=Binary%20Indexed%20Tree&category[]=Range%20Minimum%20Query&category[]=LCS&category[]=Character%20Encoding&category[]=anagram&category[]=Match%20Making&category[]=Super%20Increasing%20Seq&difficulty[]=1&page=2&query=category[]Arrayscategory[]Stringscategory[]Matrixcategory[]two-pointer-algorithmcategory[]sliding-windowcategory[]Segment-Treecategory[]Triecategory[]Fibonaccicategory[]prefix-sumcategory[]Pattern%20Searchingcategory[]Disjoint%20Setcategory[]Kadanecategory[]Binary%20Indexed%20Treecategory[]Range%20Minimum%20Querycategory[]LCScategory[]Character%20Encodingcategory[]anagramcategory[]Match%20Makingcategory[]Super%20Increasing%20Seqdifficulty[]1page2category[]Arrayscategory[]Stringscategory[]Matrixcategory[]two-pointer-algorithmcategory[]sliding-windowcategory[]Segment-Treecategory[]Triecategory[]Fibonaccicategory[]prefix-sumcategory[]Pattern%20Searchingcategory[]Disjoint%20Setcategory[]Kadanecategory[]Binary%20Indexed%20Treecategory[]Range%20Minimum%20Querycategory[]LCScategory[]Character%20Encodingcategory[]anagramcategory[]Match%20Makingcategory[]Super%20Increasing%20Seq

namespace GPrep
{
    enum Direction
    {
        Right, 
        Bottom, 
        Left,
        Top
    }
    static class SpiralMatrixTraversal
    {
        public static void PrintResult()
        {
            int[,] mat = new int[,]
            {
                {1,2,3,4,5 },
                {14,15,16,17,6 },
                {13,20,19,18,7 },
                {12,11,10,9,8 }
            };

            SpiralTraverse(mat);
        }

        static void SpiralTraverse(int[,] mat)
        {
            int n = mat.GetLength(0);
            int m = mat.GetLength(1);
            int rightLimit = m - 1;
            int bottomLimit = n - 1;
            int leftLimit = m - 1;
            int topLimit = n - 2;
            int row = 0, col = 0;
            int count = 0; 
            Tuple<int, int> nextCell = null;

            Console.Write($"{mat[row, col]} ");

            while (rightLimit > 0)
            {
                count = 0;
                // traverse right
                while(rightLimit > 0 && count < rightLimit)
                {                    
                    nextCell = GetNextCell(n, m, new Tuple<int, int>(row, col), Direction.Right);
                    if (nextCell == null)
                        break;
                    row = nextCell.Item1;
                    col = nextCell.Item2;
                    Console.Write($"{mat[row, col]} ");
                    count += 1; 
                }

                count = 0;
                // traverse down
                while(bottomLimit > 0 && count < bottomLimit)
                {                    
                    nextCell = GetNextCell(n, m, new Tuple<int, int>(row, col), Direction.Bottom);
                    if (nextCell == null)
                        break;
                    row = nextCell.Item1;
                    col = nextCell.Item2;
                    Console.Write($"{mat[row, col]} ");
                    count += 1; 
                }

                count = 0;
                // traverse left
                while (leftLimit > 0 && count < leftLimit)
                {                    
                    nextCell = GetNextCell(n, m, new Tuple<int, int>(row, col), Direction.Left);
                    if (nextCell == null)
                        break;
                    row = nextCell.Item1;
                    col = nextCell.Item2;
                    Console.Write($"{mat[row, col]} ");
                    count += 1;
                }

                count = 0;
                // traverse top
                while (topLimit > 0 && count < topLimit)
                {                    
                    nextCell = GetNextCell(n, m, new Tuple<int, int>(row, col), Direction.Top);
                    if (nextCell == null)
                        break;
                    row = nextCell.Item1;
                    col = nextCell.Item2;
                    Console.Write($"{mat[row, col]} ");
                    count += 1;
                }

                if (topLimit <= 0)
                    break;

                rightLimit -= 1;
                bottomLimit -= 2;
                leftLimit -= 2;
                topLimit -= 2;

                
            }
        }

        static Tuple<int, int> GetNextCell(int n, int m, Tuple<int, int> currCell, Direction direction)
        {
            Tuple<int, int> res = null;

            switch(direction)
            {
                case Direction.Right:
                    if (currCell.Item2 + 1 < m)
                        res = new Tuple<int, int>(currCell.Item1, currCell.Item2 + 1); 
                    break;
                case Direction.Bottom:
                    if (currCell.Item1 + 1 < n)
                        res = new Tuple<int, int>(currCell.Item1 + 1, currCell.Item2);
                    break;
                case Direction.Left:
                    if (currCell.Item2 - 1 >= 0)
                        res = new Tuple<int, int>(currCell.Item1, currCell.Item2 - 1);
                    break;
                case Direction.Top:
                    if (currCell.Item1 - 1 >= 0)
                        res = new Tuple<int, int>(currCell.Item1 - 1, currCell.Item2);
                    break;
                default:
                    break;
            }

            return res; 
        }
    }
}
