// Copyright (c) Lucrasoft ICT Group. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;

namespace Lucrasoft.uMadeEasy.Actions.ActionHelpers
{
    /// <summary>
    /// Performs a complete rename/copy action on all files and folders in the startup folders
    /// </summary>
    public class DirectoryRenamerCopier
    {
        #region "Properties"

        public string TemplateDirectoryPath { get; set; }

        public string DestinationDirectoryPath { get; set; }

        public Dictionary<string, string> RenameWords { get; set; }

        public List<string> RenameExtensions { get; set; }

        public List<string> RemoveExtensions { get; set; }

        public List<string> ExcludeExtensions { get; set; }

        public List<string> UtfExtensions { get; set; }

        #endregion "Properties"

        #region "Ctor"

        public DirectoryRenamerCopier()
        {
            RenameWords = new Dictionary<string, string>();
            RenameExtensions = new List<string>();
            RemoveExtensions = new List<string>();
            ExcludeExtensions = new List<string>();
            UtfExtensions = new List<string>();
        }

        public DirectoryRenamerCopier(string templateDirectoryPath, string destinationDirectoryPath)
            : this()
        {
            TemplateDirectoryPath = templateDirectoryPath;
            DestinationDirectoryPath = destinationDirectoryPath;
        }

        #endregion "Ctor"

        #region "Process"

        public bool StartRenaming(string sourcePath, string destinationPath)
        {
            if (string.IsNullOrEmpty(sourcePath))
                throw new ArgumentException("sourcePath cannot be null");

            if (string.IsNullOrEmpty(destinationPath))
                throw new ArgumentException("destinationPath cannot be null");

            if (!Directory.Exists(sourcePath))
                throw new DirectoryNotFoundException(string.Format("sourcePath '{0}' could not be found", sourcePath));

            if (!Directory.Exists(destinationPath))
                throw new DirectoryNotFoundException(string.Format("destinationPath '{0}' could not be found", destinationPath));

            var startFileNames = Directory.GetFiles(sourcePath);

            foreach (string fileName in startFileNames)
            {
                var currentFile = new FileInfo(fileName);
                var currentFileExtension = currentFile.Extension.ToLower();

                // Set new filepath and apply filename rename
                var destinationFileName = currentFile.Name;
                foreach (var renameWord in RenameWords)
                {
                    destinationFileName = StringHelpers.ReplaceEx(destinationFileName, renameWord.Key, renameWord.Value);
                }

                var destinationFilePath = Path.Combine(destinationPath, destinationFileName);

                if (ExcludeExtensions.Contains(currentFileExtension))
                {
                    // Just copy the file to the destination, and rename the filename
                    File.Copy(currentFile.FullName, destinationFilePath);
                }
                else if (RemoveExtensions.Contains(currentFileExtension))
                {
                    continue; // Skip this
                }
                else if (RenameExtensions.Contains(currentFileExtension))
                {
                    // Rename inside the file, and the filename
                    string fileContent = "";

                    if (UtfExtensions.Contains(currentFileExtension))
                        fileContent = File.ReadAllText(currentFile.FullName, System.Text.Encoding.UTF8);
                    else
                        fileContent = File.ReadAllText(currentFile.FullName);

                    foreach (var renameWord in RenameWords)
                    {
                        fileContent = StringHelpers.ReplaceEx(fileContent, renameWord.Key, renameWord.Value);
                    }

                    if (UtfExtensions.Contains(currentFileExtension))
                        File.WriteAllText(destinationFilePath, fileContent, System.Text.Encoding.UTF8);
                    else
                        File.WriteAllText(destinationFilePath, fileContent);
                }
            }

            var startDirectories = Directory.GetDirectories(sourcePath);

            foreach (var directoryName in startDirectories)
            {
                var currentDirectory = new DirectoryInfo(directoryName);

                // Directory needs to be renamed
                var destinationDirectoryName = currentDirectory.Name;
                foreach (var renameWord in RenameWords)
                {
                    destinationDirectoryName = StringHelpers.ReplaceEx(destinationDirectoryName, renameWord.Key, renameWord.Value);
                }

                string destinationDirectoryPath = Path.Combine(destinationPath, destinationDirectoryName);

                Directory.CreateDirectory(destinationDirectoryPath);

                StartRenaming(currentDirectory.FullName, destinationDirectoryPath);
            }

            return true;
        }

        public bool StartRenaming()
        {
            return StartRenaming(TemplateDirectoryPath, DestinationDirectoryPath);
        }

        #endregion "Process"
    }
}