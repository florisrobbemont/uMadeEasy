// Copyright (c) Lucrasoft ICT Group. All rights reserved. See License.txt in the project root for license information.

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