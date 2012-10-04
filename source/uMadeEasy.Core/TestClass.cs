using Lucrasoft.uMadeEasy.Core.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lucrasoft.uMadeEasy.Core
{
    public class TestClass
    {
        public static TemplateInformation GetTemplate()
        {
            return TemplateReader.ReadTemplate(@"C:\Development\Github\uMadeEasy\documentation\Template.xml");
        }
    }
}