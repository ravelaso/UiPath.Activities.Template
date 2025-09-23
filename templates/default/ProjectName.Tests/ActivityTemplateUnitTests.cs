using Xunit;
using System.Activities;

namespace ProjectName.Tests
{
    public class ActivityTemplateTests
    {
        [Theory]
        [InlineData(5, 3, Operation.Add, 8)]
        [InlineData(5, 3, Operation.Subtract, 2)]
        [InlineData(5, 3, Operation.Multiply, 15)]
        [InlineData(6, 3, Operation.Divide, 2)]
        public void Execute_ShouldReturnExpectedResult(int first, int second, Operation op, int expected)
        {
            // Arrange
            var activity = new ActivityTemplate
            {
                FirstNumber = new InArgument<int>(first),
                SecondNumber = new InArgument<int>(second),
                SelectedOperation = op
            };

            // Act
            var wfInvoker = new WorkflowInvoker(activity);
            var result = wfInvoker.Invoke();

            // Assert
            Assert.Equal(expected, result["Result"]);
        }

        [Fact]
        public void Execute_DivideByZero_ShouldThrow()
        {
            var activity = new ActivityTemplate
            {
                FirstNumber = new InArgument<int>(10),
                SecondNumber = new InArgument<int>(0),
                SelectedOperation = Operation.Divide
            };

            var wfInvoker = new WorkflowInvoker(activity);

            Assert.Throws<DivideByZeroException>(() => wfInvoker.Invoke());
        }
    }
}
