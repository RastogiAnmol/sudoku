using System;
using Microsoft.AspNetCore.Mvc;
using SudokuWeb.Services;

namespace SudokuWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SudokuSolverController : ControllerBase
    {
        // GET api/values
        [HttpPost("solve")]
        public JsonResult SolveSudoku(int?[,] input)
        {
            try
            {
                if (null != input)
                {
                    var solvedSudoku = SudokuService.GetSolvedSudoku(input);
                    return new JsonResult(solvedSudoku);
                }

                return new JsonResult("no data was provided");
            }
            catch (Exception e)
            {
                // Log the exception using any kind of logger
                return new JsonResult("please enter correct data");
            }
        }
    }
}