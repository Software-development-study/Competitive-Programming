using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Ex3_NQueens2
    {
        public static void Run()
        {
            int n = 4;

            int result = TotalNQueens(n);

            Console.WriteLine($"Output : {result}");
            Console.ReadKey();
        }

        public static int TotalNQueens( int n)
        {
            int[,] matrix = new int[n, n];

            int result = TotalNQueensPrint(matrix, n,false);

            return result;
        }

        public static bool isRowOccupied(int[,] matrix, int rowNumber)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[rowNumber, i] == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool isColOccupied(int[,] matrix, int colNumber)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[i, colNumber] == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool isDiagonalsOccupied(int[,] matrix, int row, int col)
        {
            int n = matrix.GetLength(0);

            if (row == col)//Main diagonals
            {
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, i] == 1 || matrix[n - i - 1, i] == 1)
                    {
                        return true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (i - row == j - col && (matrix[i, j] == 1 || matrix[n - i - 1, i] == 1))
                        {
                            return true;
                        }
                    }

                }
            }
            
            return false;
        }

        public static int TotalNQueensPrint(int[,] matrix, int n,bool skipFirstFound)
        {
            int usedQueens = 1;

            int[,] tempMatrix = matrix;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = 1;

                    if ( !isRowOccupied(tempMatrix, i) && !isColOccupied(tempMatrix, j) && !isDiagonalsOccupied(tempMatrix, i, j) && !skipFirstFound)//Not on same row & column - more efficient than checking the entire row each time
                    {
                        tempMatrix[i, j] = 1;
                        usedQueens++;
                        
                        if (usedQueens == n)
                        {
                            return 1 + TotalNQueensPrint(matrix, n, true);
                        }
                    }
                }
            }
            
            return TotalNQueensPrint(matrix, n, true); 
        }

        //public static int TotalNQueens(int n)
        //{
        //    int counter = 0;

        //    int startRowNumber = 0;

        //    int lastAttemptQueenColPosition = -1;

        //    for (int attempt = 0; attempt < n; attempt++)
        //    {
        //        int[,] matrix = new int[n, n];

        //        int[] usedRows = new int[n];
        //        int[] usedCols = new int[n];

        //        int usedQueens = 0;
        //        bool isFirstQueen = true;

        //        for (int i = 0; i < n; i++)
        //        {
        //            for (int j = 0; j < n; j++)
        //            {
        //                if (i > 0 || (i == 0 && j > lastAttemptQueenColPosition))
        //                {
        //                    if (usedRows[i] == 0 && usedCols[j] == 0)//Not on same row & column - more efficient than checking the entire row each time
        //                    {

        //                        if (matrix[i + (i + 1 < n ? 1 : 0), j + (j + 1 < n ? 1 : 0)] == 0 &&
        //                            matrix[i - (i - 1 >= 0 ? 1 : 0), j + (j + 1 < n ? 1 : 0)] == 0 &&
        //                            matrix[i + (i + 1 < n ? 1 : 0), j - (j - 1 >= 0 ? 1 : 0)] == 0 &&
        //                            matrix[i - (i - 1 >= 0 ? 1 : 0), j - (j - 1 >= 0 ? 1 : 0)] == 0)//Not around the current location
        //                        {
        //                            if (isFirstQueen)
        //                            {
        //                                isFirstQueen = false;
        //                                lastAttemptQueenColPosition = j;
        //                            }

        //                            matrix[i, j] = 1;
        //                            usedRows[i] = 1;
        //                            usedCols[j] = 1;
        //                            usedQueens++;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        if (usedQueens == n)
        //        {
        //            counter++;
        //        }
        //    }
        //    return counter;
        //}

        public static void Print2DArray<T>(T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
