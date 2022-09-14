using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Ex7_SudokuSolver
    {
        public static void Run()
        {
            char[][] arr = new char[][]{
                new char[] {'5', '3', '.', '.', '7', '.', '.', '.', '.'},
                new char[] {'6', '.', '.', '1', '9', '5', '.', '.', '.'},
                new char[] {'.', '9', '8', '.', '.', '.', '.', '6', '.'},
                new char[] {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
                new char[] {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
                new char[] {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
                new char[] {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
                new char[] {'.', '.', '.', '4', '1', '9', '.', '.', '5'},
                new char[] {'.', '.', '.', '.', '8', '.', '.', '7', '9'}
            };
            char[][] arr1 = new char[][]{
                new char[]{'.','.','9','7','4','8','.','.','.'},
                new char[]{'7','.','.','.','.','.','.','.','.'},
                new char[]{'.','2','.','1','.','9','.','.','.'},
                new char[]{'.','.','7','.','.','.','2','4','.'},
                new char[]{'.','6','4','.','1','.','5','9','.'},
                new char[]{'.','9','8','.','.','.','3','.','.'},
                new char[]{'.','.','.','8','.','3','.','2','.'},
                new char[]{'.','.','.','.','.','.','.','.','6'},
                new char[]{ '.','.','.','2','7','5','9','.','.'}
            };

            var watch = System.Diagnostics.Stopwatch.StartNew();

            SolveSudoku(arr1);

            Console.WriteLine(watch.Elapsed.ToString());

            PrintMatrix(arr);

            Console.ReadKey();
        }
        public static void SolveSudoku(char[][] board)
        {
            SolveSudokuRecursive(board);
        }
        public static bool SolveSudokuRecursive(char[][] sudokuBoard)
        {
            char emptyCell = '.';

            bool isValid = true;

            for (int row = 0; row < 9; row++) //Check for empty cells existance
            {
                for (int col = 0; col < 9; col++)
                {
                    if (sudokuBoard[row][col] == emptyCell)
                    {
                        isValid = false;
                        break;
                    }
                }

                if (!isValid)
                {
                    break;
                }
            }

            if (isValid) //Recursion break
            {
                return true;
            }

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (sudokuBoard[row][col] == emptyCell)
                    {
                        for (int currentDigit = 1; currentDigit < 10; currentDigit++) //Try each digit on each cell recursively
                        {
                            if (!isDigitExistInRowOrCol(sudokuBoard, currentDigit, row, col) && !isDigitExistInSquare(sudokuBoard, currentDigit, row, col))
                            {
                                sudokuBoard[row][col] = char.Parse(currentDigit.ToString());//Try use current digit

                                if (SolveSudokuRecursive(sudokuBoard))
                                {
                                    return true;
                                }
                                else
                                {
                                    sudokuBoard[row][col] = emptyCell;//Reverse
                                }
                            }
                        }
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool isDigitExistInRowOrCol(char[][] board, int digit, int row, int col)
        {
            for (int i = 0; i < 9; i++)
            {
                if (board[row][i] == char.Parse(digit.ToString()) || board[i][col] == char.Parse(digit.ToString()))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool isDigitExistInSquare(char[][] board, int digit, int row, int col)
        {
            Tuple<int, int> squareCorner = GetSquareUpperLeftCorner(row, col);

            char currentDigit = char.Parse(digit.ToString());

            for (int i = squareCorner.Item1; i < squareCorner.Item1 + 3; i++)
            {
                for (int j = squareCorner.Item2; j < squareCorner.Item2 + 3; j++)
                {
                    if (board[i][j] == currentDigit)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static Tuple<int, int> GetSquareUpperLeftCorner(int row, int col)
        {
            int squareCenterRow = (row > 2 ? 3 : 0) + (row > 5 ? 3 : 0);
            int squareCenterCol = (col > 2 ? 3 : 0) + (col > 5 ? 3 : 0);

            return new Tuple<int, int>(squareCenterRow, squareCenterCol);
        }

















        public static bool IsValid(char[][] board)
        {
            bool isValid = true;

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (board[row][col] == '.')
                    {
                        isValid = false;
                    }

                    int currentDigit = int.Parse(board[row][col].ToString());

                    board[row][col] = '-';

                    if (isDigitExistInRowOrCol(board, currentDigit, row, col) ||
                       isDigitExistInSquare(board, currentDigit, row, col))
                    {
                        isValid = false;
                    }

                    board[row][col] = char.Parse(currentDigit.ToString());

                }
            }

            return isValid;
        }


        public static void RemoveOptionsFromExistingDigits(char[][] board, ref int[][][] options, int currentDigit, int row, int col)
        {
            bool isChanged = false;

            if (isDigitExistInRowOrCol(board, currentDigit, row, col))
            {
                for (int i = 0; i < 9; i++)
                {
                    options[row][i][currentDigit] = 0;
                    isChanged = true;
                }
            }

            if (isDigitExistInCol(board, currentDigit, col))
            {
                for (int i = 0; i < 9; i++)
                {
                    options[i][col][currentDigit] = 0;
                    isChanged = true;
                }
            }

            if (isDigitExistInSquare(board, currentDigit, row, col))
            {
                Tuple<int, int> currentSquareTopLeftCorener = GetSquareUpperLeftCorner(row, col);

                for (int i = currentSquareTopLeftCorener.Item1; i < currentSquareTopLeftCorener.Item1 + 3; i++)
                {
                    for (int j = currentSquareTopLeftCorener.Item2; j < currentSquareTopLeftCorener.Item2 + 3; j++)
                    {
                        options[i][j][currentDigit] = 0;
                        isChanged = true;
                    }
                }
            }
            if (isChanged)
                PrintOptions(options);
        }
        //public static void SolveSudoku(char[][] board)
        //{
        //    //int[][][] temporaryOptions = InitializeOptions();
        //    //int iterations = 0;
        //    //do
        //    //{
        //    //PrintMatrix(board);
        //    //iterations++;
        //    //Console.WriteLine($"Iteration : {iterations.ToString()}");

        //    for (int currentDigit = 1; currentDigit <= 9; currentDigit++)
        //    {
        //        for (int row = 0; row < 9; row++)
        //        {
        //            for (int col = 0; col < 9; col++)
        //            {
        //                if (board[row][col] == '.')
        //                {
        //                    board[row][col] = char.Parse(currentDigit.ToString());

        //                    if (IsValid(board))
        //                    {
        //                        SolveSudoku(board);
        //                    }
        //                    else
        //                    {
        //                        board[row][col] = '.';
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    //} while (IsValid(board));
        //}

        //public static void SolveSudoku1(char[][] board)
        //{
        //    int[][][] temporaryOptions = InitializeOptions();
        //    int iterations = 0;
        //    do
        //    {
        //        PrintMatrix(board);
        //        iterations++;
        //        Console.WriteLine($"Iteration : {iterations.ToString()}");
        //        for (int currentDigit = 1; currentDigit <= 9; currentDigit++)
        //        {
        //            for (int row = 0; row < 9; row++)
        //            {
        //                for (int col = 0; col < 9; col++)
        //                {
        //                    if (board[row][col] == '.'
        //                        && (
        //                            isDigitExistInRow(board, currentDigit, row) ||
        //                            isDigitExistInCol(board, currentDigit, col) ||
        //                            isDigitExistInSquare(board, currentDigit, row, col)))
        //                    {
        //                        temporaryOptions[row][col][currentDigit] = 0; //removes current digit from available options

        //                        if (col % 3 == 0)
        //                        {
        //                            Tuple<int, int> squareCenter = GetSquareCenter(row, col);

        //                            int count = 0;

        //                            for (int squareRow = squareCenter.Item1; squareRow < squareCenter.Item1 + 2; squareRow++)
        //                            {
        //                                for (int squareCol = squareCenter.Item2; squareCol < squareCenter.Item2 + 2; squareCol++)
        //                                {
        //                                    if (temporaryOptions[squareRow - 1][squareCol - 1][currentDigit] == 1)
        //                                    {
        //                                        count++;
        //                                    }
        //                                }
        //                            }

        //                            if (count == 1)
        //                            {
        //                                board[row][col] = char.Parse(currentDigit.ToString());
        //                            }
        //                        }
        //                    }

        //                }
        //            }
        //        }

        //        DisposeOptions(board, temporaryOptions);

        //    } while (TryResolve(board, temporaryOptions));
        //}
        //public static bool IsValid(char[][] board)
        //{
        //    bool isValid = true;

        //    for (int row = 0; row < 9; row++)
        //    {
        //        for (int col = 0; col < 9; col++)
        //        {
        //            if (board[row][col] == '.')
        //            {
        //                isValid = false;
        //            }

        //            int currentDigit = int.Parse(board[row][col].ToString());

        //            board[row][col] = '-';

        //            if (isDigitExistInRow(board, currentDigit, row) &&
        //               isDigitExistInCol(board, currentDigit, col) &&
        //               isDigitExistInSquare(board, currentDigit, row, col))
        //            {
        //                isValid = false;
        //            }

        //            board[row][col] = char.Parse(currentDigit.ToString());

        //        }
        //    }

        //    return isValid;
        //}


        //public static bool TryResolve(char[][] board, int[][][] temporaryOptions)
        //{
        //    bool isSolved = true;

        //    for (int row = 0; row < 9; row++)
        //    {
        //        for (int col = 0; col < 9; col++)
        //        {
        //            if (board[row][col] == '.')
        //            {
        //                int count = 0;
        //                char temp = '.';

        //                for (int currentDigit = 1; currentDigit <= 9; currentDigit++)
        //                {
        //                    if (temporaryOptions[row][col][currentDigit] == 1)
        //                    {
        //                        count++;
        //                        temp = char.Parse(currentDigit.ToString());
        //                    }
        //                }

        //                if (count == 1)//After all options above only one option is available 
        //                {
        //                    board[row][col] = temp;
        //                    for (int i = 0; i < 9; i++)
        //                    {
        //                        temporaryOptions[row][i][int.Parse(temp.ToString())] = 0;
        //                        temporaryOptions[i][col][int.Parse(temp.ToString())] = 0;
        //                    }
        //                }
        //                else
        //                {
        //                    isSolved = false;
        //                }
        //            }
        //        }
        //    }
        //    return !isSolved;
        //}
        public static int[][][] InitializeOptions() //everything available
        {
            int[][][] temporaryOptions = new int[9][][];

            for (int i = 0; i < 9; i++)
            {
                temporaryOptions[i] = new int[9][];

                for (int j = 0; j < 9; j++)
                {
                    temporaryOptions[i][j] = new int[10];

                    for (int k = 0; k < 10; k++)
                    {
                        temporaryOptions[i][j][k] = k;
                    }
                }
            }

            return temporaryOptions;
        }


        public static void PrintOptions<T>(T[][][] foos)
        {
            Console.WriteLine("================================================================");

            Console.WriteLine("Current Options");

            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {

                    Console.Write($"[{String.Join(",", foos[x][y])}],");

                }
                Console.Write(Environment.NewLine + Environment.NewLine);

            }
        }

        public static bool isDigitExistInCol(char[][] board, int digit, int colNumber)
        {
            for (int i = 0; i < 9; i++)
            {
                if (board[i][colNumber] == char.Parse(digit.ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        //public static void DisposeOptions(char[][] board, int[][][] temporaryOptions)
        //{
        //    for (int currentDigit = 1; currentDigit < 10; currentDigit++)
        //    {
        //        for (int row = 0; row < 9; row++)//count how many places in same row could be asssigned with current digit
        //        {
        //            int count = 0;
        //            int temp = -1;
        //            for (int col = 0; col < 9; col++)
        //            {
        //                if (temporaryOptions[row][col][currentDigit] == 1)
        //                {
        //                    temp = col;
        //                    count++;
        //                }
        //            }

        //            if (count == 1)
        //            {
        //                board[row][temp] = char.Parse(currentDigit.ToString());
        //            }
        //        }


        //        for (int col = 0; col < 9; col++)//count how many places in same col could be asssigned with current digit
        //        {
        //            int count = 0;
        //            int temp = -1;
        //            for (int row = 0; row < 9; row++)
        //            {
        //                if (temporaryOptions[row][col][currentDigit] == 1)
        //                {
        //                    temp = row;
        //                    count++;
        //                }
        //            }

        //            if (count == 1)
        //            {
        //                board[temp][col] = char.Parse(currentDigit.ToString());
        //            }
        //        }


        //        //for (int row = 0; row < 9; row++)
        //        //{
        //        //    for (int col = 0; col < 9; col++)
        //        //    {
        //        //        if (board[row][col] == '.' && !isDigitExistInSquare(board, currentDigit, row, col))
        //        //        {
        //        //            Tuple<int, int> squareCenter = GetSquareCenter(row, col);

        //        //            int count = 0;

        //        //            for (int squareRow = squareCenter.Item1; squareRow < squareCenter.Item1 + 2; squareRow++)
        //        //            {
        //        //                for (int squareCol = squareCenter.Item2; squareCol < squareCenter.Item2 + 2; squareCol++)
        //        //                {
        //        //                    if (temporaryOptions[squareRow - 1][squareCol - 1][currentDigit] == 1)
        //        //                    {
        //        //                        count++;
        //        //                    }
        //        //                }
        //        //            }

        //        //            if (count == 1 && !isDigitExistInRow(board, currentDigit, row) && !isDigitExistInCol(board, currentDigit, col))
        //        //            {
        //        //                board[row][col] = char.Parse(currentDigit.ToString());
        //        //            }
        //        //        }
        //        //    }
        //        //}


        //    }



        //    //for (int row = 0; row < 9; row++)
        //    //{
        //    //    for (int col = 0; col < 9; col++)
        //    //    {
        //    //        if (board[row][col] == '.')
        //    //        {
        //    //            for (int currentDigit = 1; currentDigit < 10; currentDigit++)
        //    //            {
        //    //                int rowCount = 0;
        //    //                int colCount = 0;

        //    //                for (int i = 0; i < 9; i++)
        //    //                {
        //    //                    if (temporaryOptions[i][col][currentDigit] == 1)
        //    //                    {
        //    //                        rowCount++;
        //    //                    }

        //    //                    if (temporaryOptions[row][i][currentDigit] == 1)
        //    //                    {
        //    //                        colCount++;
        //    //                    }
        //    //                }

        //    //                if (rowCount == 1 || colCount == 1)
        //    //                {
        //    //                    temporaryOptions[row][col] = new int[10];
        //    //                    temporaryOptions[row][col][currentDigit] = 1;
        //    //                }
        //    //            }
        //    //        }
        //    //    }
        //    //}
        //}



        public static void PrintMatrix<T>(T[][] arr)
        {
            Console.WriteLine("================================================================");

            Console.WriteLine("Current matrix");

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(string.Format("{0} ", arr[i][j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

    }
}
