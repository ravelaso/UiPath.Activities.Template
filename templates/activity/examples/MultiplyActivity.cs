using System.Activities;
using System.ComponentModel;
using System.Diagnostics;
using ProjectName.Helpers;
using UiPath.Robot.Activities.Api;

namespace ProjectName;

[DisplayName("MultiplicationActivity")]
[Description("Multiplication Example Activity")]
[Category("Ravelaso")]
public class MultiplicationActivity : CodeActivity<int>
{
    [RequiredArgument]
    [DisplayName("First Number")]
    [Description("First number for the operation")]
    public InArgument<int> FirstNumber { get; set; }

    [RequiredArgument]
    [DisplayName("Second Number")]
    [Description("Second number for the operation")]
    public InArgument<int> SecondNumber { get; set; }

    protected override int Execute(CodeActivityContext context)
    {
        var message = new LogMessage
        {
            EventType = TraceEventType.Information,
            Message = "Executing Multiplication activity"
        };
        context.GetExecutorRuntime().LogMessage(message);

        var firstNumber = FirstNumber.Get(context);
        var secondNumber = SecondNumber.Get(context);

        return firstNumber * secondNumber;
    }
}