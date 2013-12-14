// Copyright (c) Lucrasoft ICT Group. All rights reserved. See License.txt in the project root for license information.

using System;

namespace Lucrasoft.uMadeEasy.Actions.Git
{
    /// <summary>
    /// Clones a GitLab project
    /// </summary>
    public class CloneGitRepositoryFromPreviousAction : CloneGitRepositoryAction
    {
        public override Type InputControl
        {
            get { return null; }
        }
    }
}