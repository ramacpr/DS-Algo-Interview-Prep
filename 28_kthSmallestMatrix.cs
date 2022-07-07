using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://practice.geeksforgeeks.org/problems/kth-element-in-matrix/1/?category[]=Arrays&category[]=Strings&category[]=Matrix&category[]=two-pointer-algorithm&category[]=sliding-window&category[]=Segment-Tree&category[]=Trie&category[]=Fibonacci&category[]=prefix-sum&category[]=Pattern%20Searching&category[]=Disjoint%20Set&category[]=Kadane&category[]=Binary%20Indexed%20Tree&category[]=Range%20Minimum%20Query&category[]=LCS&category[]=Character%20Encoding&category[]=anagram&category[]=Match%20Making&category[]=Super%20Increasing%20Seq&category[]=Arrays&category[]=Strings&category[]=Matrix&category[]=two-pointer-algorithm&category[]=sliding-window&category[]=Segment-Tree&category[]=Trie&category[]=Fibonacci&category[]=prefix-sum&category[]=Pattern%20Searching&category[]=Disjoint%20Set&category[]=Kadane&category[]=Binary%20Indexed%20Tree&category[]=Range%20Minimum%20Query&category[]=LCS&category[]=Character%20Encoding&category[]=anagram&category[]=Match%20Making&category[]=Super%20Increasing%20Seq&difficulty[]=1&page=2&query=category[]Arrayscategory[]Stringscategory[]Matrixcategory[]two-pointer-algorithmcategory[]sliding-windowcategory[]Segment-Treecategory[]Triecategory[]Fibonaccicategory[]prefix-sumcategory[]Pattern%20Searchingcategory[]Disjoint%20Setcategory[]Kadanecategory[]Binary%20Indexed%20Treecategory[]Range%20Minimum%20Querycategory[]LCScategory[]Character%20Encodingcategory[]anagramcategory[]Match%20Makingcategory[]Super%20Increasing%20Seqdifficulty[]1page2category[]Arrayscategory[]Stringscategory[]Matrixcategory[]two-pointer-algorithmcategory[]sliding-windowcategory[]Segment-Treecategory[]Triecategory[]Fibonaccicategory[]prefix-sumcategory[]Pattern%20Searchingcategory[]Disjoint%20Setcategory[]Kadanecategory[]Binary%20Indexed%20Treecategory[]Range%20Minimum%20Querycategory[]LCScategory[]Character%20Encodingcategory[]anagramcategory[]Match%20Makingcategory[]Super%20Increasing%20Seq

namespace GPrep
{
    static class kthSmallestMatrix
    {
        public static void PrintResult()
        {
            int[,] mat = new[,]
            {
                {16,28,60,64 },
                {22,41,63,91 },
                {27,50,87,93 },
                {36,78,87,94 }
            };

            PrintKthSmallest(mat, mat.Length);
        }

        static void PrintKthSmallest(int[,] mat, int k)
        {
            if (k == 0)
                return;
            if (k > mat.Length)
                return; 

            int res = 0;
            int[,] isVisited = new int[mat.GetLength(0), mat.GetLength(1)];
            
            if(k == 1)            
                res = mat[0, 0];
            else
            {
                int hRow = 0, hCol = 1;
                int vRow = 1, vCol = 0;
                int count = 1;
                int rowCnt = mat.GetLength(0);
                int colCnt = mat.GetLength(1); 

                isVisited[0, 0] = 1;
                Console.WriteLine($"1'th smallest element is {mat[0,0]}");

                while (count < k)
                {
                    if (mat[hRow, hCol] < mat[vRow, vCol])
                    {
                        res = mat[hRow, hCol];
                        isVisited[hRow, hCol] = 1;
                        var nxtHCell = GetNextHCell(rowCnt, colCnt, hRow, hCol, isVisited);
                        if (nxtHCell == null)// all done
                            break;
                        hRow = nxtHCell.Item1;
                        hCol = nxtHCell.Item2;
                    }
                    else
                    {
                        res = mat[vRow, vCol];
                        isVisited[vRow, vCol] = 1;
                        var nxtVCell = GetNextVCell(rowCnt, colCnt, vRow, vCol, isVisited);
                        if (nxtVCell == null)// all done
                            break;
                        vRow = nxtVCell.Item1;
                        vCol = nxtVCell.Item2;
                    }
                    count += 1;
                    Console.WriteLine($"{count}'th smallest element is {res}");
                }
            }           

            
        }

        static Tuple<int, int> GetNextVCell(int rowCount, int colCount, int row, int col, int[,] isVisited)
        {
            Tuple<int, int> res = null;
            int newRow = row + 1, newCol = col; 

            if(newRow >= rowCount)
            {
                newRow = 0;
                newCol += 1;
            }
            while(newRow < rowCount && newCol < colCount && isVisited[newRow, newCol] == 1)
            {
                newRow = (newRow + 1) % (rowCount + 1);
                if(newRow == 0) newCol += 1;
                if (newCol >= colCount)
                    return null; 
            }

            if (newRow >= rowCount)
                return null; 

            return new Tuple<int, int>(newRow, newCol);
        }

        static Tuple<int, int> GetNextHCell(int rowCount, int colCount, int row, int col, int[,] isVisited)
        {
            Tuple<int, int> res = null;
            int newRow = row, newCol = col + 1;

            if (newCol >= colCount)
            {
                newCol = 0;
                newRow += 1;
            }
            while (newRow < rowCount && newCol < colCount && isVisited[newRow, newCol] == 1)
            {
                newCol = (newCol + 1) % (colCount + 1);
                if(newCol == 0) newRow += 1;
                if (newRow >= rowCount)
                    return null;
            }

            if (newCol >= colCount)
                return null; 
            
            return new Tuple<int, int>(newRow, newCol);
        }

    }
}
