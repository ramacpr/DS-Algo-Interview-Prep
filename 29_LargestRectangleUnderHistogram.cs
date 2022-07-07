using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPrep
{
    // https://www.geeksforgeeks.org/largest-rectangle-under-histogram/
    class LargestRectangleUnderHistogram
    {
        // The main function to find the
        // maximum rectangular area under
        // given histogram with n bars
        public int getMaxArea(int[] hist)
        {
            int area = 0, max_area = 0;

            int[] leftMin = new int[hist.Length];
            int[] rightMin = new int[hist.Length];
            for(int i = 0; i < hist.Length; i++)
            {
                leftMin[i] = -1;
                rightMin[i] = hist.Length;
            }
            UpdateLeftMins(ref leftMin, hist);
            UpdateRightMins(ref rightMin, hist);

            for(int i = 0; i < hist.Length; i++)
            {
                area = hist[i] * ((rightMin[i] - leftMin[i]) - 1);
                if (area > max_area)
                    max_area = area;
            }                      

            return max_area;
 
        }

        void UpdateLeftMins(ref int[] leftMin, int[] hist)
        {
            Stack<int> s = new Stack<int>();
            leftMin[0] = -1;
            s.Push(0);

            for (int i = 1; i < hist.Length; i++)
            {
                if (s.Count > 0 && hist[i] <= hist[s.Peek()])
                {
                    while (s.Count > 0 && hist[i] <= hist[s.Peek()])
                        s.Pop();
                    if (s.Count == 0)
                        leftMin[i] = -1;
                    else
                        leftMin[i] = s.Peek();
                }
                else
                {
                    leftMin[i] = i - 1;
                }

                s.Push(i);
            }
        }

        void UpdateRightMins(ref int[] rightMin, int[] hist)
        {
            Stack<int> s = new Stack<int>();
            rightMin[hist.Length - 1] = -1;
            s.Push(0);

            for (int i = hist.Length - 2; i >= 0; i--)
            {
                if (s.Count > 0 && hist[i] <= hist[s.Peek()])
                {
                    while (s.Count > 0 && hist[i] <= hist[s.Peek()])
                        s.Pop();
                    if (s.Count == 0)
                        rightMin[i] = hist.Length;
                    else
                        rightMin[i] = s.Peek();
                }
                else
                {
                    rightMin[i] = i + 1;
                }

                s.Push(i);
            }
        }
    }
}
