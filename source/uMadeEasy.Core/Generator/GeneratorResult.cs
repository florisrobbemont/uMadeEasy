// Copyright (c) Lucrasoft ICT Group. All rights reserved. See License.txt in the project root for license information.

namespace Lucrasoft.uMadeEasy.Core.Generator
{
    /// <summary>
    /// Contains the results of a newly generated project.
    /// </summary>
    public sealed class GeneratorResult
    {
        /// <summary>
        /// Gets or sets last action of the generator.
        /// </summary>
        public IGeneratorAction LastAction { get; set; }

        /// <summary>
        /// Gets or sets wether the operation was succesfull.
        /// </summary>
        public bool OperationSuccesfull { get; set; }
    }
}