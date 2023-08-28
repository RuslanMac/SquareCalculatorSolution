using Microsoft.Extensions.Options;
using SquareCalculatorSolution.Application.CalculatorService;
using SquareCalculatorSolution.Application.Validator;
using FluentValidation.TestHelper;
using System.Security.Cryptography.X509Certificates;
using SquareCalculatorSolution.Application.DTO;
using System.Drawing;
using System.ComponentModel.DataAnnotations;

namespace TestsProject
{
    public class UnitTest1
    {
        IOptions<SequenceOptions> optionsSeq;
        double[] numbers;
        SequenceDtoValidator sequenceDtoValidator;

        CalculatorService calculatorService;
        public UnitTest1()
        {
            optionsSeq = Options.Create<SequenceOptions>(new SequenceOptions
            {
                MaxNumber = 16,
                MaxValue = 100000,
                MinValue = -100000
            });
            sequenceDtoValidator = new SequenceDtoValidator(optionsSeq);
            calculatorService = new CalculatorService(sequenceDtoValidator);
        }

        [Fact]
        public void CalculateSum_ShouldReturnCorrectResult_WhenArgumentsCorrect()
        {
            //Arrange
            const int arraySize = 6;
            numbers = new double[arraySize];
            int i = 0;
            while (i < arraySize)
            {
                numbers[i] = i;
                i++;
            }
            SequenceDto sequence = new SequenceDto
            {
                Numbers = numbers
            };
            

            //Act 
            var result = calculatorService.Calculate(sequence);

            // Assert.Equal()
            Assert.Equal(55, result);

        }

        [Fact]
        public void CalculateSum_ShouldThrowArgumentException_WhenArraySizeExceeds()
        {
            //Arrange
            const int arraySize = 10000;
            numbers = new double[arraySize];
            int i = 0;
            while (i < arraySize)
            {
                numbers[i] = i;
                i++;
            }
            SequenceDto sequence = new SequenceDto
            {
                Numbers = numbers
            };

            //Act
            Assert.Throws<ArgumentException>(() => calculatorService.Calculate(sequence));
        }
        [Fact]
        public void CalculateSum_ShouldThrowArgumentException_WhenMaxValueExceeds()
        {
            //Arrange
            const int arraySize = 5;
            numbers = new double[arraySize];
            int i = 0;
            while (i < arraySize)
            {
                numbers[i] = 99999111;
                i++;
            }
            SequenceDto sequence = new SequenceDto
            {
                Numbers = numbers
            };
   

            //Act
            Assert.Throws<ArgumentException>(() => calculatorService.Calculate(sequence));
        }
        [Fact]
        public void CalculateSum_ShouldThrowArgumentException_WhenMinValueExceeds()
        {
            //Arrange
            const int arraySize = 5;
            numbers = new double[arraySize];
            int i = 0;
            while (i < arraySize)
            {
                numbers[i] = -5673491;
                i++;
            }
            SequenceDto sequence = new SequenceDto
            {
                Numbers = numbers
            };
            SequenceDtoValidator sequenceDtoValidator = new SequenceDtoValidator(optionsSeq);

            CalculatorService calculatorService = new CalculatorService(sequenceDtoValidator);

            //Act
            Assert.Throws<ArgumentException>(() => calculatorService.Calculate(sequence));
        }
      /*  [Fact] 
        public void CalculateSum_ShouldReturnOverflowException_WhenLimitNumberExceeds()
        {
            const int arraySize = 5;
            numbers = new double[arraySize];
            int i = 0;
            while (i < arraySize)
            { 
                numbers[i] = 1000000000000000;
                i++;
            }
            SequenceDto sequence = new SequenceDto
            {
                Numbers = numbers
            };

            optionsSeq = Options.Create<SequenceOptions>(new SequenceOptions
            {
                MaxNumber = 16,
                MaxValue = 10000,
                MinValue = -100000
            });

            sequenceDtoValidator = new SequenceDtoValidator(optionsSeq);
            calculatorService = new CalculatorService(sequenceDtoValidator);

            Assert.Throws<OverflowException>(() => calculatorService.Calculate(sequence));

        }
*/

    }
}