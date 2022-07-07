using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSumRectangle
{
    // https://practice.geeksforgeeks.org/problems/maximum-sum-rectangle2948/1
    static class Matrix
    {
        public static int[,] TheMatrix = new int[4, 5] {
                                        {1, 2, -1, -4, -20 },
                                        {-8, -3, 4, 2, 1 },
                                        {3, 8, 10, 1, 3 },
                                        {-4, -1, 1, 7, -6 } };
        public static int MaxRowCount = 4;
        public static int MaxColumnCount = 5;
    }

    class Cell
    {
        public Cell(int r, int c)
        {
            Row = r;
            Column = c;
        }
        public int Row;
        public int Column;
    }

    class SubMatrix
    {
        public SubMatrix(Cell startCell, Cell endCell)
        {
            StartCell = startCell;
            EndCell = endCell;
            CheckForExceptions();

        }

        public SubMatrix(int startCellRow, int startCellCol, int endCellRow, int endCellCol)
        {
            StartCell = new Cell(startCellRow, startCellCol);
            EndCell = new Cell(endCellRow, endCellCol);
            CheckForExceptions();
        }

        public SubMatrix(Cell startCell, int endCellRow, int endCellCol)
        {
            StartCell = startCell;
            EndCell = new Cell(endCellRow, endCellCol);
            CheckForExceptions();
        }

        public SubMatrix(int startCellRow, int startCellCol, Cell endCell)
        {
            StartCell = new Cell(startCellRow, startCellCol);
            EndCell = endCell;
            CheckForExceptions();
        }

        void CheckForExceptions()
        {
            if (StartCell.Row <= EndCell.Row && StartCell.Column <= EndCell.Column) return; 
            throw new Exception("Invalid SubMatrix start and end cell point!!!");
        }
        int? subMatrixSum = null;

        public Cell StartCell;

        public Cell EndCell;

        public int GetSubMatrixSum()
        {
            if (subMatrixSum == null)
            {
                subMatrixSum = 0;
                for (int rowIndex = StartCell.Row; rowIndex <= EndCell.Row; rowIndex++)
                {
                    for (int colIndex = StartCell.Column; colIndex <= EndCell.Column; colIndex++)
                    {
                        subMatrixSum += Matrix.TheMatrix[rowIndex, colIndex];
                    }
                }
            }

            return (int)subMatrixSum;
        }

        public override bool Equals(object obj)
        {
            SubMatrix toCompare = obj as SubMatrix;
            if (toCompare == null)
                return false;

            if (toCompare.StartCell.Row == this.StartCell.Row &&
                toCompare.StartCell.Column == this.StartCell.Column &&
                toCompare.EndCell.Row == this.EndCell.Row &&
                toCompare.EndCell.Column == this.EndCell.Column)
                return true;
            return false; 
        }
    }

    class MaxSumRectangleHelper
    {
        SubMatrix maxSumRectangle = null;

        public MaxSumRectangleHelper() {; }

        Stack<SubMatrix> ProcessedSubMatrix = new Stack<SubMatrix>();

        Stack<SubMatrix> ProcessingStack = new Stack<SubMatrix>();

        Stack<SubMatrix> ShrinkSubMatrix = new Stack<SubMatrix>();

        #region Shrinks
        List<SubMatrix> GetNextShrinks(SubMatrix currentSubMatrix)
        {
            List<SubMatrix> shrinks = new List<SubMatrix>();

            var shk = GetLeftShrinkSubMatrix(currentSubMatrix);
            if (shk != null)
                shrinks.Add(shk);
            shk = GetRightShrinkSubMatrix(currentSubMatrix);
            if (shk != null)
                shrinks.Add(shk);
            shk = GetTopShrinkSubMatrix(currentSubMatrix);
            if (shk != null)
                shrinks.Add(shk);
            shk = GetBottomShrinkSubMatrix(currentSubMatrix);
            if (shk != null)
                shrinks.Add(shk);

            shk = GetTopLeftShrinkSubMatrix(currentSubMatrix);
            if (shk != null)
                shrinks.Add(shk);
            shk = GetTopRightShrinkSubMatrix(currentSubMatrix);
            if (shk != null)
                shrinks.Add(shk);
            shk = GetBottomLeftShrinkSubMatrix(currentSubMatrix);
            if (shk != null)
                shrinks.Add(shk);
            shk = GetBottomRightShrinkSubMatrix(currentSubMatrix);
            if (shk != null)
                shrinks.Add(shk);

            return shrinks;
        }
        SubMatrix GetLeftShrinkSubMatrix(SubMatrix currentSubMatrix)
        {
            SubMatrix subMatrix = null;

            // return (X, Y+1)
            if(currentSubMatrix.StartCell.Column + 1 < Matrix.MaxColumnCount && currentSubMatrix.StartCell.Column + 1 <= currentSubMatrix.EndCell.Column)
            {
                subMatrix = new SubMatrix(currentSubMatrix.StartCell.Row,
                                            currentSubMatrix.StartCell.Column + 1,
                                            currentSubMatrix.EndCell);
                if (IsSubMatrixProcessed(subMatrix))
                    return null;
            }

            return subMatrix;
        }
        SubMatrix GetRightShrinkSubMatrix(SubMatrix currentSubMatrix)
        {
            SubMatrix subMatrix = null;

            // return (X, Y-1)
            if(currentSubMatrix.EndCell.Column - 1 >= 0 && currentSubMatrix.EndCell.Column - 1 >= currentSubMatrix.StartCell.Column)
            {
                subMatrix = new SubMatrix(currentSubMatrix.StartCell,
                                            currentSubMatrix.EndCell.Row,
                                            currentSubMatrix.EndCell.Column - 1);
                if (IsSubMatrixProcessed(subMatrix))
                    return null;
            }

            return subMatrix;
        }
        SubMatrix GetTopShrinkSubMatrix(SubMatrix currentSubMatrix)
        {
            SubMatrix subMatrix = null;

            // return (X-1, Y) 
            if(currentSubMatrix.StartCell.Row - 1 >= 0 && currentSubMatrix.StartCell.Row - 1 <= currentSubMatrix.EndCell.Row)
            {
                subMatrix = new SubMatrix(currentSubMatrix.StartCell.Row - 1,
                                            currentSubMatrix.StartCell.Column,
                                            currentSubMatrix.EndCell);
                if (IsSubMatrixProcessed(subMatrix))
                    return null;
            }

            return subMatrix;
        }
        SubMatrix GetBottomShrinkSubMatrix(SubMatrix currentSubMatrix)
        {
            SubMatrix subMatrix = null;

            // return (X-1, Y)
            if(currentSubMatrix.EndCell.Row - 1 >= 0 && currentSubMatrix.EndCell.Row - 1 >= currentSubMatrix.StartCell.Row)
            {
                subMatrix = new SubMatrix(currentSubMatrix.StartCell,
                                            currentSubMatrix.EndCell.Row - 1,
                                            currentSubMatrix.EndCell.Column);
                if (IsSubMatrixProcessed(subMatrix))
                    return null;
            }

            return subMatrix;
        }
        SubMatrix GetTopLeftShrinkSubMatrix(SubMatrix currentSubMatrix)
        {
            SubMatrix subMatrix = null;

            // return (X+1, Y+1)
            if(currentSubMatrix.StartCell.Row + 1 < Matrix.MaxRowCount && currentSubMatrix.StartCell.Row + 1 <= currentSubMatrix.EndCell.Row &&
                currentSubMatrix.StartCell.Column + 1 < Matrix.MaxColumnCount && currentSubMatrix.StartCell.Column + 1 <= currentSubMatrix.EndCell.Column)
            {
                subMatrix = new SubMatrix(currentSubMatrix.StartCell.Row + 1,
                                            currentSubMatrix.StartCell.Column + 1,
                                            currentSubMatrix.EndCell);
                if (IsSubMatrixProcessed(subMatrix))
                    return null;
            }

            return subMatrix;
        }
        SubMatrix GetTopRightShrinkSubMatrix(SubMatrix currentSubMatrix)
        {
            SubMatrix subMatrix = null;

            // return (X+1, Y-1)
            if(currentSubMatrix.StartCell.Row + 1 < Matrix.MaxRowCount && currentSubMatrix.StartCell.Row + 1 <= currentSubMatrix.EndCell.Row &&
                currentSubMatrix.EndCell.Column - 1 >= 0 && currentSubMatrix.EndCell.Column - 1 >= currentSubMatrix.StartCell.Column)
            {
                subMatrix = new SubMatrix(currentSubMatrix.StartCell.Row + 1,
                                            currentSubMatrix.StartCell.Column,
                                            currentSubMatrix.EndCell.Row,
                                            currentSubMatrix.EndCell.Column - 1);
                if (IsSubMatrixProcessed(subMatrix))
                    return null;
            }
            return subMatrix;
        }
        SubMatrix GetBottomLeftShrinkSubMatrix(SubMatrix currentSubMatrix)
        {
            SubMatrix subMatrix = null;

            // return (X-1, Y-1)
            if(currentSubMatrix.EndCell.Row - 1 >= 0 && currentSubMatrix.EndCell.Row - 1 >= currentSubMatrix.StartCell.Row &&
                currentSubMatrix.StartCell.Column - 1 >= 0 && currentSubMatrix.StartCell.Column - 1 <= currentSubMatrix.EndCell.Column)
            {
                subMatrix = new SubMatrix(currentSubMatrix.StartCell.Row,
                                            currentSubMatrix.StartCell.Column - 1,
                                            currentSubMatrix.EndCell.Row - 1,
                                            currentSubMatrix.EndCell.Column);
                if (IsSubMatrixProcessed(subMatrix))
                    return null;
            }

            return subMatrix;
        }
        SubMatrix GetBottomRightShrinkSubMatrix(SubMatrix currentSubMatrix)
        {
            SubMatrix subMatrix = null;

            // return (X-1, Y-1)
            if(currentSubMatrix.EndCell.Row - 1 >=0 && currentSubMatrix.EndCell.Row - 1 >= currentSubMatrix.StartCell.Row &&
                currentSubMatrix.EndCell.Column - 1 >= 0 && currentSubMatrix.EndCell.Column - 1 >= currentSubMatrix.StartCell.Column)
            {
                subMatrix = new SubMatrix(currentSubMatrix.StartCell,
                                            currentSubMatrix.EndCell.Row - 1,
                                            currentSubMatrix.EndCell.Column - 1);
                if (IsSubMatrixProcessed(subMatrix))
                    return null;
            }
            return subMatrix;
        }
        #endregion

        #region Expansions
        List<SubMatrix> GetNextExpansions(SubMatrix currentSubMatrix)
        {
            List<SubMatrix> expansions = new List<SubMatrix>();

            var exp = GetLeftExpandedSubMatrix(currentSubMatrix);
            if (exp != null)
                expansions.Add(exp);
            exp = GetRightExpandedSubMatrix(currentSubMatrix);
            if (exp != null)
                expansions.Add(exp);
            exp = GetTopExpandedSubMatrix(currentSubMatrix);
            if (exp != null)
                expansions.Add(exp);
            exp = GetBottomExpandedSubMatrix(currentSubMatrix);
            if (exp != null)
                expansions.Add(exp);

            exp = GetTopLeftExpandedSubMatrix(currentSubMatrix);
            if (exp != null)
                expansions.Add(exp);
            exp = GetTopRightExpandedSubMatrix(currentSubMatrix);
            if (exp != null)
                expansions.Add(exp);
            exp = GetBottomLeftExpandedSubMatrix(currentSubMatrix);
            if (exp != null)
                expansions.Add(exp);
            exp = GetBottomRightExpandedSubMatrix(currentSubMatrix);
            if (exp != null)
                expansions.Add(exp);


            return expansions;
        }
        bool IsSubMatrixProcessed(SubMatrix subMatrix)
        {
            var elements = ProcessedSubMatrix.Where(x => x.Equals(subMatrix)).ToList();
            if (elements != null && elements.Count > 0)
                return true;
            return false;
        }
        SubMatrix GetLeftExpandedSubMatrix(SubMatrix currentSubMatrix)
        {
            SubMatrix subMatrix = null;

            // return (X, Y-1)
            if(currentSubMatrix.StartCell.Column - 1 >= 0)
            {
                subMatrix = new SubMatrix(currentSubMatrix.StartCell.Row, 
                                            currentSubMatrix.StartCell.Column - 1, 
                                            currentSubMatrix.EndCell);
                if (IsSubMatrixProcessed(subMatrix))
                    return null;
            }

            return subMatrix;
        }
        SubMatrix GetRightExpandedSubMatrix(SubMatrix currentSubMatrix)
        {
            SubMatrix subMatrix = null;

            // return (X, Y+1)
            if(currentSubMatrix.EndCell.Column + 1 < Matrix.MaxColumnCount)
            {
                subMatrix = new SubMatrix(currentSubMatrix.StartCell, 
                                            currentSubMatrix.EndCell.Row, 
                                            currentSubMatrix.EndCell.Column + 1);
                if (IsSubMatrixProcessed(subMatrix))
                    return null;
            }
            return subMatrix;
        }
        SubMatrix GetTopExpandedSubMatrix(SubMatrix currentSubMatrix)
        {
            SubMatrix subMatrix = null;

            // return (X-1, Y) 
            if(currentSubMatrix.StartCell.Row - 1 >= 0)
            {
                subMatrix = new SubMatrix(currentSubMatrix.StartCell.Row - 1, currentSubMatrix.StartCell.Column, currentSubMatrix.EndCell);
                if (IsSubMatrixProcessed(subMatrix))
                    return null;
            }
            return subMatrix;
        }
        SubMatrix GetBottomExpandedSubMatrix(SubMatrix currentSubMatrix)
        {
            SubMatrix subMatrix = null;

            // return (X+1, Y)
            if(currentSubMatrix.EndCell.Row + 1 < Matrix.MaxRowCount)
            {
                subMatrix = new SubMatrix(currentSubMatrix.StartCell, currentSubMatrix.EndCell.Row + 1, currentSubMatrix.EndCell.Column);
                if (IsSubMatrixProcessed(subMatrix))
                    return null;
            }
            return subMatrix;
        }
        SubMatrix GetTopLeftExpandedSubMatrix(SubMatrix currentSubMatrix)
        {
            SubMatrix subMatrix = null;

            // return (X-1, Y-1)
            if(currentSubMatrix.StartCell.Row - 1 >= 0 && currentSubMatrix.StartCell.Column - 1 >= 0)
            {
                subMatrix = new SubMatrix(currentSubMatrix.StartCell.Row - 1, 
                                            currentSubMatrix.StartCell.Column - 1, 
                                            currentSubMatrix.EndCell);
                if (IsSubMatrixProcessed(subMatrix))
                    return null;
            }
            return subMatrix;
        }
        SubMatrix GetTopRightExpandedSubMatrix(SubMatrix currentSubMatrix)
        {
            SubMatrix subMatrix = null;

            // return (X-1, Y+1)
            if(currentSubMatrix.StartCell.Row - 1 >= 0 && currentSubMatrix.EndCell.Column + 1 < Matrix.MaxColumnCount)
            {
                subMatrix = new SubMatrix(currentSubMatrix.StartCell.Row - 1,
                                            currentSubMatrix.StartCell.Column,
                                            currentSubMatrix.EndCell.Row,
                                            currentSubMatrix.EndCell.Column + 1);
                if (IsSubMatrixProcessed(subMatrix))
                    return null;
            }
            return subMatrix;
        }
        SubMatrix GetBottomLeftExpandedSubMatrix(SubMatrix currentSubMatrix)
        {
            SubMatrix subMatrix = null;

            // return (X+1, Y-1)
            if(currentSubMatrix.EndCell.Row + 1 < Matrix.MaxRowCount && currentSubMatrix.StartCell.Column - 1 >= 0)
            {
                subMatrix = new SubMatrix(currentSubMatrix.StartCell.Row,
                                            currentSubMatrix.StartCell.Column - 1,
                                            currentSubMatrix.EndCell.Row + 1,
                                            currentSubMatrix.EndCell.Column);
                if (IsSubMatrixProcessed(subMatrix))
                    return null;
            }
            return subMatrix;
        }
        SubMatrix GetBottomRightExpandedSubMatrix(SubMatrix currentSubMatrix)
        {
            SubMatrix subMatrix = null;

            // return (X+1, Y+1)
            if(currentSubMatrix.EndCell.Row + 1 < Matrix.MaxRowCount && currentSubMatrix.EndCell.Column + 1 < Matrix.MaxColumnCount)
            {
                subMatrix = new SubMatrix(currentSubMatrix.StartCell,
                                            currentSubMatrix.EndCell.Row + 1,
                                            currentSubMatrix.EndCell.Column + 1);
                if (IsSubMatrixProcessed(subMatrix))
                    return null;
            }
            return subMatrix;
        }
        #endregion

        public int GetMaxSumRectangle()
        {
            SubMatrix start = new SubMatrix(new Cell(0, 0), new Cell(0, 0));
            ProcessingStack.Push(start);
            maxSumRectangle = start;

            // first expand and find sum of all possible valid expansions 
            while (ProcessingStack.Count > 0)
            {
                SubMatrix currentSubMatrix = ProcessingStack.Pop();
                if (currentSubMatrix == null) continue;

                var validExpansions = GetNextExpansions(currentSubMatrix); 
                foreach(var sm in validExpansions)
                {
                    if (sm == null) continue;

                    if (sm.GetSubMatrixSum() > maxSumRectangle.GetSubMatrixSum())
                            maxSumRectangle = sm;                    
                    
                    ProcessingStack.Push(sm);
                }
                ProcessedSubMatrix.Push(currentSubMatrix);
                ShrinkSubMatrix.Push(currentSubMatrix);
            }

            // start shrinking the expansions and keep track of max sum 
            while(ShrinkSubMatrix.Count > 0)
            {
                var currentSubMatrix = ShrinkSubMatrix.Pop();
                if (currentSubMatrix == null) continue;

                var validShrinks = GetNextShrinks(currentSubMatrix); 
                foreach(var sm in validShrinks)
                {
                    if (sm == null) continue;
                    if (sm.GetSubMatrixSum() > maxSumRectangle.GetSubMatrixSum())
                        maxSumRectangle = sm;
                    ShrinkSubMatrix.Push(sm);
                }
            }

            return maxSumRectangle.GetSubMatrixSum();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var msr = new MaxSumRectangleHelper();
            Console.WriteLine(msr.GetMaxSumRectangle().ToString());
            Console.ReadLine();
        }
    }
}
