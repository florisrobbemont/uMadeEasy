using System.ComponentModel.Composition;
using System.Windows.Forms;

namespace Lucrasoft.uMadeEasy.Core.InputFields
{
    /// <summary>
    /// Defines the basic layout for an input field control.
    /// </summary>
    [InheritedExport]
    public partial class InputFieldControl : UserControl
    {
        public InputFieldControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Retrieves the values from the control and return them in a single dictionary.
        /// </summary>
        public virtual ActionInputValues GetInputValues()
        {
            return new ActionInputValues();
        }

        /// <summary>
        /// Validates the current control and returns information about the validation
        /// </summary>
        public virtual ActionInputValidationArguments ValidateInputValues()
        {
            return null;
        }
    }
}