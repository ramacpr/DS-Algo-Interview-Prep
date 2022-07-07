using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPrep
{
    static class SortedMatrixSearch
    {
        public static void PrintSearchResults()
        {
            int[,] matrix = {{ 3, 30, 38},
                                {36, 43, 60},
                                {40, 51, 69}
                              };
            int key = 40;
            Console.WriteLine($"Key {key} found? {IsKeyFound(matrix, key)}");
        }

        // O(n + m)
        static bool IsKeyFound(int[,] arr, int key)
        {
            int rowIndex = 0, colIndex = arr.GetLength(1) - 1; 

            while(rowIndex < arr.GetLength(0) && colIndex >= 0)
            {
                var item = arr[rowIndex, colIndex];
                if (key == item)
                    return true;
                if (key > item) // eliminate row
                    rowIndex += 1;
                else // eliminate column 
                    colIndex -= 1;
            }

            return false;
        }
    }
}
