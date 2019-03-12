using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SudokuWeb.Services
{
    public class SudokuService
    {
        private static int?[,] SudokuGrid { get; set; }
        private static bool IsTheNumberInGridRow(int gridRow, int number)
        {
            for (int i = 0; i < 9; i++)
                if (SudokuGrid[gridRow, i] == number)
                    return true;

            return false;
        }
        private static bool IsTheNumberInGridCol(int gridCol, int number)
        {
            for (int i = 0; i < 9; i++)
                if (SudokuGrid[i, gridCol] == number)
                    return true;

            return false;
        }
        private static bool IsTheNumberInThreeByThreeBox(int gridRow, int gridCol, int number)
        {
            int boxRow = gridRow - gridRow % 3;
            int boxColumn = gridCol - gridCol % 3;

            for (int i = boxRow; i < boxRow + 3; i++)
            for (int j = boxColumn; j < boxColumn + 3; j++)
                if (SudokuGrid[i,j] == number)
                    return true;

            return false;
        }
        private static bool IsTheNumberAtValidPosition(int gridRow, int gridCol, int number)
        {
            return !IsTheNumberInGridRow(gridRow, number) && !IsTheNumberInGridCol(gridCol, number) && !IsTheNumberInThreeByThreeBox(gridRow, gridCol, number);
        }
        private static bool IsSudokuSolvable()
        {
            for (int sudokuRow = 0; sudokuRow < 9; sudokuRow++)
            {
                for (int sudokuCol = 0; sudokuCol < 9; sudokuCol++)
                {
                    if (SudokuGrid[sudokuRow,sudokuCol] == null)
                    {
                        for (int number = 1; number <= 9; number++)
                        {
                            if (IsTheNumberAtValidPosition(sudokuRow, sudokuCol, number))
                            {

                                SudokuGrid[sudokuRow,sudokuCol] = number;

                                if (IsSudokuSolvable())
                                { 
                                    return true;
                                }
                                else
                                {
                                    SudokuGrid[sudokuRow,sudokuCol] = null;
                                }
                            }
                        }

                        return false;
                    }
                }
            }

            return true; // sudoku solved
        }

        public static int?[,] GetSolvedSudoku(int?[,] input)
        {
            SudokuGrid = input;
            if (IsSudokuSolvable())
            {
                return SudokuGrid;
            }

            return null;
        }
    }
}
