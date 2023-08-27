using FluentValidation;
using Microsoft.Extensions.Options;
using SquareCalculatorSolution.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareCalculatorSolution.Application.Validator
{
    public class SequenceDtoValidator : AbstractValidator<SequenceDto>
    {
        private readonly SequenceOptions _optionsValue; 

        public SequenceDtoValidator(IOptions<SequenceOptions> options)
        {
            _optionsValue = options.Value;
            RuleFor(s => s.Numbers.Length).NotNull().NotEmpty().LessThanOrEqualTo(_optionsValue.MaxNumber);
            RuleForEach(s => s.Numbers).LessThanOrEqualTo(_optionsValue.MaxValue);
            RuleForEach(s => s.Numbers).GreaterThanOrEqualTo(_optionsValue.MinValue);

        }
    }
}
