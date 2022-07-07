using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPrep.Matrix
{
    // https://www.geeksforgeeks.org/maximum-size-rectangle-binary-sub-matrix-1s/
    /* Problem statement
    Given an N by M matrix consisting only of 1's and 0's, 
    find the largest rectangle containing only 1's and return its area.
    
    For example, given the following matrix:
        [[1, 0, 0, 0],
        [1, 0, 1, 1],
        [1, 0, 1, 1],
        [0, 1, 0, 0]]
    Return 4.
    */

    public class LargestRectangleInMatrix
    {
        LargestRectangleUnderHistogram hist = new LargestRectangleUnderHistogram();
        int[,] matrix = new int[4, 4]
        {
            {1, 0, 0, 0 },
            {1, 0, 1, 1 },
            {1, 0, 1, 1 },
            {0, 1, 0, 0 }
        };

        public int GetLargestRectangleArea()
        {
            int area = 0, maxArea = 0;

            int[] sumRow = new int[4];

            for(int row = 0; row < 4; row++)
            {
                for(int col = 0; col < 4; col++)
                {
                    sumRow[col] += matrix[row, col]; 
                }

                area = hist.getMaxArea(sumRow);
                if (area > maxArea)
                    maxArea = area;
            }

            return maxArea;
        }

        
    }
}
