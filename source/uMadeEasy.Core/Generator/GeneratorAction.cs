using Lucrasoft.uMadeEasy.Core.InputFields;

namespace Lucrasoft.uMadeEasy.Core.Generator
{
    /// <summary>
    /// Represents an action to be performed by the generator including the values from the input fields.
    /// </summary>
    public sealed class GeneratorAction
    {
        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        public IGeneratorAction Action { get; set; }

        /// <summary>
        /// Gets the input values from the user.
        /// </summary>
        public ActionInputValues InputValues { get; set; }
    }
}