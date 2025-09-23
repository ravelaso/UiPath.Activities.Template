using System.Activities.DesignViewModels;

namespace ProjectName.ViewModels
{
    public class ActivityViewModel : DesignPropertiesViewModel
    {
        /*
         * Properties names must match the names and generic type arguments of the properties in the activity
         * Use DesignInArgument for properties that accept a variable
         */

        // Define argument properties

        public ActivityViewModel(IDesignServices services) : base(services)
        {
        }

        protected override void InitializeModel()
        {
            base.InitializeModel();
            PersistValuesChangedDuringInit();

            // Set UI properties
        }
    }
}
