using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SudokuWeb.Services
{
    public class SudokuService
    {
        public static int?[,] GetSolvedSudoku(int?[,] puzzle)
        {
          var solvedSudoku = GetSolvedSudoku(puzzle, 0, 0);
          return solvedSudoku;
        }

        private static int?[,] GetSolvedSudoku(int?[,] puzzle, int gridRow, int gridCol)
        {
            if (gridRow < 9 && gridCol < 9)
            {
                if (puzzle[gridRow, gridCol] != null)
                {
                    if ((gridCol + 1) < 9) return GetSolvedSudoku(puzzle, gridRow, gridCol + 1);
                    else if ((gridRow + 1) < 9) return GetSolvedSudoku(puzzle, gridRow + 1, 0);
                    else return puzzle;
                }
                else
                {
                    for (int i = 0; i < 9; ++i)
                    {
                        if (IsAvailable(puzzle, gridRow, gridCol, i + 1))
                        {
                            puzzle[gridRow, gridCol] = i + 1;

                            if ((gridCol + 1) < 9)
                            {
                                if (GetSolvedSudoku(puzzle, gridRow, gridCol + 1) != null) return puzzle;
                                else puzzle[gridRow, gridCol] = null;
                            }
                            else if ((gridRow + 1) < 9)
                            {
                                if (GetSolvedSudoku(puzzle, gridRow + 1, 0) != null) return puzzle;
                                else puzzle[gridRow, gridCol] = null;
                            }
                            else return puzzle;
                        }
                    }
                }

                return null;
            }
            else return puzzle;
        }

        private static bool IsAvailable(int?[,] puzzle, int gridRow, int gridCol, int num)
        {
            int gridRowStart = (gridRow / 3) * 3;
            int gridColStart = (gridCol / 3) * 3;

            for (int i = 0; i < 9; ++i)
            {
                if (puzzle[gridRow, i] == num) return false;
                if (puzzle[i, gridCol] == num) return false;
                if (puzzle[gridRowStart + (i % 3), gridColStart + (i / 3)] == num) return false;
            }

            return true;
        }
    }
}
