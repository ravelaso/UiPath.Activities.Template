using System.Activities;

namespace ProjectName;

[DisplayName("Activity")]
[Description("The Activity Description")]
[Category("Custom")]
public class Activity : CodeActivity
{
   // Define argument properties

    protected override int Execute(CodeActivityContext context)
    {
        // Do something
    }
}

