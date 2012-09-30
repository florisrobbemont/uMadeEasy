using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Lucrasoft.uMadeEasy.Actions.ActionHelpers
{
    public class HostFileWriter
    {
        public static readonly string HostFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers\\etc\\hosts");

        public HostFileWriter()
        {
            ReadHostFile();
        }

        ~HostFileWriter()
        {
            hostFileLines.Clear();
            entryList.Clear();
        }

        #region "Reader"

        private readonly char[] whiteSpaceDelimiter = { ' ', '\t' };
        private List<string> hostFileLines;
        private readonly List<HostFileEntry> entryList = new List<HostFileEntry>();

        private void ReadHostFile()
        {
            // Get host file content
            var hostFileContent = File.ReadAllText(HostFilePath, Encoding.UTF8);

            // Split and Parse
            hostFileLines = new List<string>(hostFileContent.Split(Environment.NewLine.ToCharArray()));
            hostFileLines = hostFileLines.Where(x => !string.IsNullOrEmpty(x)).ToList();

            ParseHostFile();
        }

        private void ParseHostFile()
        {
            for (int i = 0; i < hostFileLines.Count; i++)
            {
                string hostLine = hostFileLines[i];

                // Check for comment and empty lines
                if (!hostLine.Trim().StartsWith("#") && !String.IsNullOrEmpty(hostLine))
                {
                    bool addToList = false;

                    var newEntry = new HostFileEntry { Index = i };

                    var match1 = Regex.Match(hostLine, @"((?:[0-9]{1,3}\.){3}[0-9]{1,3})");
                    var match2 = Regex.Match(hostLine, @"(#(?:[0-9]{1,3}\.){3}[0-9]{1,3})");
                    var match3 = Regex.Match(hostLine, @"(#\W+(?:[0-9]{1,3}\.){3}[0-9]{1,3})");
                    var match4 = Regex.Match(hostLine, @"([a-zA-Z]+.\-?\w+.*)");

                    if (match1.Success)
                    {
                        newEntry.IpAddress = match1.ToString().Replace(" ", String.Empty).Replace("\t", String.Empty);
                        addToList = true;
                    }
                    if (match2.Success)
                    {
                        newEntry.IpAddress = match2.ToString().Replace(" ", String.Empty).Replace("\t", String.Empty).Replace("#", String.Empty);
                        addToList = true;
                    }
                    if (match3.Success)
                    {
                        newEntry.IpAddress = match3.ToString().Replace(" ", String.Empty).Replace("\t", String.Empty).Replace("#", String.Empty);
                        addToList = true;
                    }

                    if (match4.Success)
                    {
                        var match5 = Regex.Match(match4.ToString(), @"(#.\w+.*)");
                        if (match5.Success)
                        {
                            newEntry.Comment = match5.ToString().Replace("#", String.Empty).TrimStart(whiteSpaceDelimiter);
                            newEntry.HostName = match4.ToString().Replace(match5.ToString(), String.Empty).Replace(" ", String.Empty).Replace("\t", String.Empty).Replace("#", String.Empty);
                        }
                        else
                        {
                            newEntry.HostName = match4.ToString().Replace(" ", String.Empty).Replace("\t", String.Empty).Replace("#", String.Empty);
                        }
                    }

                    if (addToList)
                        entryList.Add(newEntry);
                }
            }
        }

        #endregion "Reader"

        #region "Edit"

        public void AddOrUpdateEntry(string hostName, string ipAddress, string comment)
        {
            // Check if value already exists
            var originalEntry = entryList.FirstOrDefault(x => x.HostName == hostName);

            // Create the new value if neccesary
            if (originalEntry == null)
            {
                originalEntry = new HostFileEntry { Index = -1 };

                entryList.Add(originalEntry);
            }

            originalEntry.Comment = comment;
            originalEntry.HostName = hostName;
            originalEntry.IpAddress = ipAddress;
        }

        #endregion "Edit"

        #region "Save"

        public void Save()
        {
            foreach (var entry in entryList)
            {
                if (entry.Index == -1)
                    hostFileLines.Add(FormatHostEntry(entry));
                else
                    hostFileLines[entry.Index] = FormatHostEntry(entry);
            }

            var hostFileContent = string.Join<string>("\r\n", hostFileLines);
            File.WriteAllText(HostFilePath, hostFileContent, Encoding.UTF8);
        }

        private string FormatHostEntry(HostFileEntry entry)
        {
            var hostName = entry.HostName;
            var ipAddress = entry.IpAddress;

            return string.IsNullOrEmpty(entry.Comment) ?
                string.Concat(ipAddress, "\t", hostName) : string.Concat(ipAddress, "\t", hostName, "\t", "#", entry.Comment);
        }

        #endregion "Save"

        #region "HostFileEntry"

        private class HostFileEntry
        {
            public string IpAddress;
            public string HostName;
            public string Comment;

            public int Index;
        }

        #endregion "HostFileEntry"
    }
}