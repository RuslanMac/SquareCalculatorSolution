using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SquareCalculatorSolution.Application.CalculatorService;
using SquareCalculatorSolution.Application.DTO;
using System.Runtime.InteropServices;

namespace SquareCalculatorSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SquareCalculatorController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;
        public SquareCalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }
        [HttpPost]
        public ActionResult<double> Calculate([FromBody] SequenceDto dto)
        {
            try
            {
                var sum = _calculatorService.Calculate(dto);
                return Ok(sum);
            }
            catch (OverflowException)
            {
                return BadRequest("Ввод данных не соответсвует допустимым значениям!");
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
        }
    }
}
