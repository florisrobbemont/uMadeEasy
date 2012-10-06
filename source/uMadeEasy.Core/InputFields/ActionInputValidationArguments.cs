using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lucrasoft.uMadeEasy.Core.InputFields
{
    /// <summary>
    /// Provides validation transfer for edit controls.
    /// </summary>
    public class ActionInputValidationArguments
    {
        /// <summary>
        /// Gets or sets wether the validation action was valid.
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// Gets or sets the optional message containing information about the validation.
        /// </summary>
        public string ValidationMessage { get; set; }
    }
}