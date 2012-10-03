using Lucrasoft.uMadeEasy.Core.Template;

namespace Lucrasoft.uMadeEasy.Core.Generator
{
    /// <summary>
    /// Holds all the arguments for creating a new project
    /// </summary>
    public sealed class GeneratorArguments
    {
        /// <summary>
        /// Gets or sets the name of the new project
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the template information for the new project
        /// </summary>
        public TemplateInformation TemplateInformation { get; set; }
    }
}