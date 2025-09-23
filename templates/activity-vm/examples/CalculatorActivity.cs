using System.Activities;
using System.Diagnostics;
using ProjectName.Helpers;
using UiPath.Robot.Activities.Api;
using System.ComponentModel;

namespace ProjectName;

public enum Operation
{
    Add,
    Subtract,
    Multiply,
    Divide
}



// This is an example of a calculator, you can see how the interaction between the ViewModel and the Activity class works.
[DisplayName("Calculator Activity")]
[Description("This is an example activity")]
[Category("CustomActivities")]
public class CalculatorActivity : CodeActivity<int> // This base class exposes an OutArgument named Result
{
    /*
     * The returned value will be used to set the value of the Result argument
     */

    [RequiredArgument]
    public InArgument<int> FirstNumber { get; set; } //InArgument allows a variable to be set from the workflow

    [RequiredArgument]
    public InArgument<int> SecondNumber { get; set; } //InArgument allows a variable to be set from the workflow

    [RequiredArgument]
    public Operation SelectedOperation { get; set; } = Operation.Multiply; // We set a default value for the enum.

    protected override int Execute(CodeActivityContext context)
    {
        // This is how you can log messages from your activity. logs are sent to the Robot which will forward them to Orchestrator
        var message = new LogMessage
        {
            EventType = TraceEventType.Information,
            Message = "Executing Calculator activity"
        };
        context.GetExecutorRuntime().LogMessage(message);

        var firstNumber = FirstNumber.Get(context); //get the value from the workflow context (remember, this can be a variable)
        var secondNumber = SecondNumber.Get(context);
        // You can do validations before you actually run the private method.
        if (secondNumber == 0 && SelectedOperation == Operation.Divide)
        {
            throw new DivideByZeroException("Second number should not be zero when the selected operation is divide");
        }

        return ExecuteInternal(firstNumber, secondNumber);
    }

    private int ExecuteInternal(int firstNumber, int secondNumber)
    {
        return SelectedOperation switch
        {
            Operation.Add => firstNumber + secondNumber,
            Operation.Subtract => firstNumber - secondNumber,
            Operation.Multiply => firstNumber * secondNumber,
            Operation.Divide => firstNumber / secondNumber,
            _ => throw new NotSupportedException("Operation not supported"),
        };
    }
}

