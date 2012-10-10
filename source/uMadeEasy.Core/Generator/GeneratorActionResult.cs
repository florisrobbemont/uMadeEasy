// Copyright (c) Lucrasoft ICT Group. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lucrasoft.uMadeEasy.Core.Generator
{
    /// <summary>
    /// Holds the result of an action operation.
    /// </summary>
    public class GeneratorActionResult
    {
        /// <summary>
        /// Gets or sets the outcome of the operation.
        /// </summary>
        public bool OperationSuccesfull { get; set; }

        /// <summary>
        /// Gets or sets the message (optional).
        /// </summary>
        public string Message { get; set; }

        public GeneratorActionResult()
        {
        }

        public GeneratorActionResult(bool outcome, string message)
        {
            OperationSuccesfull = outcome;
            Message = message;
        }
    }
}