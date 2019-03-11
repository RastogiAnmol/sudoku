using NUnit.Framework;
using SudokuWeb.Controllers;
using Shouldly;

namespace Tests
{
    public class SudokuSolverControllerTest
    {
        private SudokuSolverController _sudokuSolverController;
        private int?[,] _unsolvedSudoku;

        [SetUp]
        public void Setup()
        {
            _sudokuSolverController = new SudokuSolverController();
            _unsolvedSudoku = new int?[,]
                                 {
                                     {null, 3, 6, null, 5, 9, null, null, null},
                                     { null, null, null, null, null, null, 9, null, null },
                                     { null, null, 9, null, 1, null, null, 7, 6 },
                                     { null, null, null, null, null, 7, null, 8, null },
                                     { 9, null, 7, null, null, null, 1, null, 4 },
                                     { null, 5, null, 8, null, null, null, null, null },
                                     { 4, 6, null, null, 3, null, 5, null, null },
                                     { null, null, 2, null, null, null, null, null, null },
                                     { null, null, null, 7, 2, null, 8, 4, null }
                                 };
        }

        [Test]
        [Category("ControllerTest")]
        public void SolveSudoku_Should_Not_Return_Null_Test()
        {
            var returnedData = _sudokuSolverController.SolveSudoku(null);
            returnedData.ShouldNotBeNull();
        }
        [Test]
        [Category("ControllerTest")]
        public void SolveSudoku_Should_Return_Error_If_Passed_Null_Test()
        {
            var returnedData = _sudokuSolverController.SolveSudoku(null);
            returnedData.Value.ShouldBe("no data was provided");
        }
        [Test]
        [Category("ControllerTest")]
        public void SolveSudoku_Should_Return_Json_Error_If_Passed_Null_Test()
        {
            var returnedData = _sudokuSolverController.SolveSudoku(null);
            returnedData.ShouldBeOfType(typeof(Microsoft.AspNetCore.Mvc.JsonResult));
        }
        [Test]
        [Category("ControllerTest")]
        public void SolveSudoku_Returned_Object_Should_Have_Nullable_Int_Array_Test()
        {
            var returnedData = _sudokuSolverController.SolveSudoku(_unsolvedSudoku);
            returnedData.Value.ShouldBeOfType<int?[,]>();
        }
    }
}