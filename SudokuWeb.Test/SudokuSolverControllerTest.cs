using NUnit.Framework;
using  SudokuWeb.Controllers;
using Shouldly;
using Moq;

namespace Tests
{
    public class SudokuSolverControllerTest
    {
        private Mock<SudokuSolverController> _sudokuSolverController;

        [SetUp]
        public void Setup()
        {
            _sudokuSolverController  = new Mock<SudokuSolverController>();
        }

        [Test]
        [Category("ControllerTest")]
        public void SolveSudoku_Should_Not_Return_Null_Test()
        {
           var returnedData = _sudokuSolverController.Object.SolveSudoku(null);
           returnedData.ShouldNotBeNull();
        }
        [Test]
        [Category("ControllerTest")]
        public void SolveSudoku_Should_Return_Error_If_Passed_Null_Test()
        {
            var returnedData = _sudokuSolverController.Object.SolveSudoku(null);
            returnedData.Value.ShouldBe("no data was provided");
        }
        [Test]
        [Category("ControllerTest")]
        public void SolveSudoku_Should_Return_Json_Error_If_Passed_Null_Test()
        {
            var returnedData = _sudokuSolverController.Object.SolveSudoku(null);
            returnedData.ShouldBeOfType(typeof(Microsoft.AspNetCore.Mvc.JsonResult));
        }
        [Test]
        [Category("ControllerTest")]
        public void SolveSudoku_Should_Return_Json_Result_Test()
        {
            var returnedData = _sudokuSolverController.Object.SolveSudoku(It.IsAny<int?[,]>());
            returnedData.ShouldBeOfType(typeof(Microsoft.AspNetCore.Mvc.JsonResult));
        }
    }
}