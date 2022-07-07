using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://practice.geeksforgeeks.org/problems/c-letters-collection4552/1/?difficulty[]=1&page=1&category[]=Arrays&category[]=Strings&category[]=Matrix&category[]=two-pointer-algorithm&category[]=sliding-window&category[]=Segment-Tree&category[]=Fibonacci&category[]=Trie&category[]=prefix-sum&category[]=Pattern%20Searching&category[]=Disjoint%20Set&category[]=Kadane&category[]=Binary%20Indexed%20Tree&category[]=Range%20Minimum%20Query&category[]=LCS&category[]=Character%20Encoding&category[]=anagram&category[]=Match%20Making&category[]=Super%20Increasing%20Seq&query=difficulty[]1page1category[]Arrayscategory[]Stringscategory[]Matrixcategory[]two-pointer-algorithmcategory[]sliding-windowcategory[]Segment-Treecategory[]Fibonaccicategory[]Triecategory[]prefix-sumcategory[]Pattern%20Searchingcategory[]Disjoint%20Setcategory[]Kadanecategory[]Binary%20Indexed%20Treecategory[]Range%20Minimum%20Querycategory[]LCScategory[]Character%20Encodingcategory[]anagramcategory[]Match%20Makingcategory[]Super%20Increasing%20Seq
// time = O(H) . H -> total number of hops in each query
// Space = n*m + H -> O(nm + H) 
namespace GPrep
{
    static class LettersCollection
    {
        public static void PrintHopAwaySums()
        {
            var mat = new int[4, 4]
            {
                {1, 2, 3, 4 },
                {5, 6, 7, 8 },
                {9, 1, 3, 4 },
                {1, 2, 3, 4 }
            };

            var query = new int[3, 3]
            {
                {1, 0, 1 },
                {2, 0, 1 },
                {3, 0, 0 }
            };

            PrintSum(mat, query);
        }

        static void PrintSum(int[,] mat, int[,] query)
        {
            int queryCount = query.GetLength(0);
            int hopCount = 0, qRow = 0, qCol = 0;
            int hopSum = 0;
            int[,] isProcessed = new int[mat.GetLength(0), mat.GetLength(1)];

            Queue<Tuple<int, int>> processQ = new Queue<Tuple<int, int>>();
            Queue<Tuple<int, int>> tmpQ = new Queue<Tuple<int, int>>(); 

            // O(h)
            for(int qIndex = 0; qIndex < queryCount; qIndex++) 
            {
                hopCount = query[qIndex, 0];
                qRow = query[qIndex, 1];
                qCol = query[qIndex, 2];
                isProcessed[qRow, qCol] = 1;

                processQ.Clear();
                tmpQ.Clear();
                processQ.Enqueue(new Tuple<int, int>(qRow, qCol));

                while (hopCount > 0 && processQ.Count > 0)
                {
                    while (hopCount > 0 && processQ.Count > 0)
                    {
                        var cell = processQ.Dequeue();
                        var neighbours = GetNeighbours(isProcessed, cell.Item1, cell.Item2); // O(1)
                        foreach (var neighbour in neighbours)
                        {
                            hopSum += mat[neighbour.Item1, neighbour.Item2];
                            isProcessed[neighbour.Item1, neighbour.Item2] = 1;
                            tmpQ.Enqueue(neighbour);
                        }
                    }

                    hopCount -= 1;
                    if (hopCount <= 0)
                        break;
                    hopSum = 0;

                    while (hopCount > 0 && tmpQ.Count > 0)
                    {
                        var cell = tmpQ.Dequeue();
                        var neighbours = GetNeighbours(isProcessed, cell.Item1, cell.Item2); // O(1)
                        foreach (var neighbour in neighbours)
                        {
                            hopSum += mat[neighbour.Item1, neighbour.Item2];
                            isProcessed[neighbour.Item1, neighbour.Item2] = 1;
                            processQ.Enqueue(neighbour);
                        }
                    }

                    hopCount -= 1;
                    if (hopCount <= 0)
                        break;
                    hopSum = 0;
                }
                Console.WriteLine($"Query => [{query[qIndex, 0]}, {query[qIndex, 1]}, {query[qIndex, 2]}] Sum => {hopSum}");
                isProcessed = new int[mat.GetLength(0), mat.GetLength(1)];
            }

        }

        // O(8)
        static List<Tuple<int, int>> GetNeighbours(int[,] isProcessed, int row, int col)
        {
            List<Tuple<int, int>> result = new List<Tuple<int, int>>();

            if(col - 1 >= 0 && isProcessed[row, col - 1] == 0)
                result.Add(new Tuple<int, int>(row, col - 1)); // left

            if(col + 1 < isProcessed.GetLength(1) && isProcessed[row, col + 1] == 0)
                result.Add(new Tuple<int, int>(row, col + 1)); // right

            if(row - 1 >= 0 && isProcessed[row - 1, col] == 0)
                result.Add(new Tuple<int, int>(row - 1, col)); // top

            if (row + 1 < isProcessed.GetLength(0) && isProcessed[row + 1, col] == 0)
                result.Add(new Tuple<int, int>(row + 1, col)); // bottom

            if (row - 1 >= 0 && col - 1 >= 0 && isProcessed[row - 1, col - 1] == 0)
                result.Add(new Tuple<int, int>(row - 1, col - 1)); // top-left

            if (row - 1 >= 0 && col + 1 < isProcessed.GetLength(1) && isProcessed[row - 1, col + 1] == 0)
                result.Add(new Tuple<int, int>(row - 1, col + 1)); // top-right

            if (row + 1 < isProcessed.GetLength(0) && col - 1 >= 0 && isProcessed[row + 1, col - 1] == 0)
                result.Add(new Tuple<int, int>(row + 1, col - 1)); // bottom-left

            if (row + 1 < isProcessed.GetLength(0) && col + 1 < isProcessed.GetLength(1) && isProcessed[row + 1, col + 1] == 0)
                result.Add(new Tuple<int, int>(row + 1, col + 1)); // bottom-right

            return result;
        }
    }
}
