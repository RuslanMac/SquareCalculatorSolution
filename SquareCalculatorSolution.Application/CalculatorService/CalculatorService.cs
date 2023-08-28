using SquareCalculatorSolution.Application.DTO;
using SquareCalculatorSolution.Application.Validator;
using SquareCalculatorSolution.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SquareCalculatorSolution.Application.CalculatorService
{
    public class CalculatorService : ICalculatorService
    {
        public double Sum { get; set; }
        private readonly SequenceDtoValidator _validator;
        public CalculatorService(SequenceDtoValidator validator)
        {
            _validator = validator;
        }
        public double Calculate(SequenceDto sequence)
        {
            var validationResult = _validator.Validate(sequence);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException();
            }

            checked
            {
                try
                {
                    foreach (var number in sequence.Numbers)
                    {

                        Sum += Math.Pow(number, 2);
                    };
                    return Sum;
                }
                catch (OverflowException)
                {
                    throw new OverflowException();
                }

            }
        }

    }
}
