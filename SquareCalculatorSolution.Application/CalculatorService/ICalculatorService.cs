using SquareCalculatorSolution.Application.DTO;
using SquareCalculatorSolution.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareCalculatorSolution.Application.CalculatorService
{
    public interface ICalculatorService
    {
        public double Calculate(SequenceDto sequence);
    }
}
