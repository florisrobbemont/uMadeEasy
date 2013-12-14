using System.Diagnostics;

namespace Lucrasoft.uMadeEasy.Actions.Git
{
    public class GitCommandRunner
    {
        public static void RunCommand(string command, string directory)
        {
            var gitInfo = new ProcessStartInfo
                          {
                              CreateNoWindow = false,
                              RedirectStandardError = false,
                              RedirectStandardOutput = false,
                              FileName = "git.exe"
                          };

            var gitProcess = new Process();
            gitInfo.Arguments = command;
            gitInfo.WorkingDirectory = directory;

            gitProcess.StartInfo = gitInfo;
            gitProcess.Start();
            gitProcess.WaitForExit();
            gitProcess.Close();
        }
    }
}