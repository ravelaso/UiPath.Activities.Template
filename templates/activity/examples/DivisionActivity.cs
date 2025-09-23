using System.Activities;
using System.ComponentModel;
using System.Diagnostics;
using ProjectName.Helpers;
using UiPath.Robot.Activities.Api;

namespace ProjectName;

[DisplayName("DivisionActivity")]
[Description("Division Example Activity")]
[Category("Ravelaso")]
public class DivisionActivity : CodeActivity<int>
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
            Message = "Executing Division activity"
        };
        context.GetExecutorRuntime().LogMessage(message);

        var firstNumber = FirstNumber.Get(context);
        var secondNumber = SecondNumber.Get(context);

        if (secondNumber == 0)
        {
            throw new DivideByZeroException("Second number should not be zero when dividing");
        }

        return firstNumber / secondNumber;
    }
}