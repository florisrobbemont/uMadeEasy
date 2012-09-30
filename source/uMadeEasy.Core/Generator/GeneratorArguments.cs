namespace Lucrasoft.uMadeEasy.Core.Generator
{
    /// <summary>
    /// Holds all the arguments for creating a new website
    /// </summary>
    public sealed class GeneratorArguments
    {
        public string Name { get; set; }

        public string HostName { get; set; }

        public object SourceControlParameter { get; set; }

        public string Location { get; set; }

       
        //public Umbraco.UmbracoGenerator.ReportProgressDelegate ProgressDelegate { get; set; }

        //public Umbraco.UmbracoGenerator.ReportRollBackDelegate RollBackDelegate { get; set; }
    }
}