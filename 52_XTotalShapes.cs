using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://practice.geeksforgeeks.org/problems/x-total-shapes3617/1/?category[]=Graph&category[]=Greedy&category[]=DFS&category[]=Binary%20Search%20Tree&category[]=BFS&category[]=Divide%20and%20Conquer&category[]=AVL-Tree&category[]=Graph&category[]=Greedy&category[]=DFS&category[]=Binary%20Search%20Tree&category[]=BFS&category[]=Divide%20and%20Conquer&category[]=AVL-Tree&difficulty[]=1&page=1&query=category[]Graphcategory[]Greedycategory[]DFScategory[]Binary%20Search%20Treecategory[]BFScategory[]Divide%20and%20Conquercategory[]AVL-Treedifficulty[]1page1category[]Graphcategory[]Greedycategory[]DFScategory[]Binary%20Search%20Treecategory[]BFScategory[]Divide%20and%20Conquercategory[]AVL-Tree
// Time: O(n*m)
// Space: O(n*m)

namespace GPrep
{
    static class XTotalShapes
    {
        public static void PrintResult()
        {
            int[,] mat = new int[,]
            {
                {0,1,1,0,0 },
                {1,1,0,0,1 },
                {0,0,1,0,0 },
                {0,1,1,1,0 },
                {0,1,1,0,0 }
            };
            int count = GetXShapes(mat);
            Console.WriteLine($"There are {count} shapes of Xs ");
        }

        static int GetXShapes(int[,] mat)
        {
            int shapeCount = 0;
            int[,] isVisited = new int[mat.GetLength(0), mat.GetLength(1)];

            for(int row = 0; row < mat.GetLength(0); row++)
            {
                for(int col = 0; col < mat.GetLength(1); col++)
                {
                    if(mat[row, col] == 1 && isVisited[row, col] == 0)
                    {
                        shapeCount++;
                        MarkDownConnectedCells(row, col, mat, ref isVisited);
                    }
                }
            }
            return shapeCount; 
        }

        static void MarkDownConnectedCells(int row, int col, int[,] mat, ref int[,] isVisited)
        {
            int rowCount = mat.GetLength(0);
            int colCount = mat.GetLength(1);
            Stack<Tuple<int, int>> validNeighbours = new Stack<Tuple<int, int>>();
            validNeighbours.Push(new Tuple<int, int>(row, col));
            isVisited[row, col] = 1;

            while (validNeighbours.Count > 0)
            {
                var XCell = validNeighbours.Pop();

                // push all neighbours too!
                // left 
                int newRow = XCell.Item1;
                int newCol = XCell.Item2 - 1; 
                if (newCol >= 0 && mat[newRow, newCol] == 1 && isVisited[newRow, newCol] == 0)
                {
                    isVisited[newRow, newCol] = 1;
                    validNeighbours.Push(new Tuple<int, int>(newRow, newCol));
                }

                // right
                newRow = XCell.Item1;
                newCol = XCell.Item2 + 1; 
                if(newCol < colCount && mat[newRow, newCol] == 1 && isVisited[newRow, newCol] == 0)
                {
                    isVisited[newRow, newCol] = 1;
                    validNeighbours.Push(new Tuple<int, int>(newRow, newCol));
                }

                // top
                newRow = XCell.Item1 - 1;
                newCol = XCell.Item2; 
                if(newRow >= 0 && mat[newRow, newCol] == 1 && isVisited[newRow, newCol] == 0)
                {
                    isVisited[newRow, newCol] = 1;
                    validNeighbours.Push(new Tuple<int, int>(newRow, newCol));
                }

                // bottom 
                newRow = XCell.Item1 + 1;
                newCol = XCell.Item2; 
                if(newRow < rowCount && mat[newRow, newCol] == 1 && isVisited[newRow, newCol] == 0)
                {
                    isVisited[newRow, newCol] = 1;
                    validNeighbours.Push(new Tuple<int, int>(newRow, newCol));
                }
            }
        }
    }
}
