using System.Activities;
using System.ComponentModel;

namespace ProjectName;

[DisplayName("Activity")]
[Description("The Activity Description")]
[Category("Custom")]
public class Activity : CodeActivity
{
   // Define argument properties

    protected override void Execute(CodeActivityContext context)
    {
        // Do something
    }
}

