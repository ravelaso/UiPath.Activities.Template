using System.Activities.DesignViewModels;

namespace ProjectName.ViewModels
{
    public class ActivityTemplateViewModel : DesignPropertiesViewModel
    {
        /*
         * Properties names must match the names and generic type arguments of the properties in the activity
         * Use DesignInArgument for properties that accept a variable
         */
        public DesignInArgument<int> FirstNumber { get; set; }
        public DesignInArgument<int> SecondNumber { get; set; }
        /*
         * Use DesignProperty for properties that accept a constant value
         */
        public DesignProperty<Operation> SelectedOperation { get; set; }
        /*
         * The result property comes from the activity's base class
         */
        public DesignOutArgument<int> Result { get; set; }

        public ActivityTemplateViewModel(IDesignServices services) : base(services)
        {
        }

        protected override void InitializeModel()
        {
             Debugger.Break();
            /*
             * The base call will initialize the properties of the view model with the values from the xaml or with the default values from the activity
             */
            base.InitializeModel();

            PersistValuesChangedDuringInit(); // just for heads-up here; it's a mandatory call only when you change the values of properties during initialization


            /*
             * Required fields will automatically raise validation errors when empty.
             * Unless you do custom validation, required activity properties should be marked as such both in the view model and in the activity:
             *   -> in the view model use the IsRequired property
             *   -> in the activity use the [RequiredArgument] attribute.
             */
            FirstNumber.DisplayName = "First Number";
            FirstNumber.Tooltip = "First number for the operation";
            FirstNumber.IsRequired = true;
            FirstNumber.IsPrincipal = true; // specifies if it belongs to the main category (which cannot be collapsed)
           
            SecondNumber.DisplayName = "Second Number";
            SecondNumber.Tooltip = "Second number for the operation";
            SecondNumber.IsRequired = true;
            SecondNumber.IsPrincipal = true;

            SelectedOperation.DisplayName = "Select Operation";
            SelectedOperation.Tooltip = "Select the operation to calculate";
            SelectedOperation.IsRequired = true;
            SelectedOperation.IsPrincipal = true;

            /*
             * Output properties are never mandatory.
             * By convention, they are not principal and they are placed at the end of the activity.
             */
            Result.DisplayName = "Result Operation";
            Result.Tooltip = "The result Integer";
        }
    }
}
