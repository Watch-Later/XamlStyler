﻿// (c) Xavalon. All rights reserved.

using Microsoft.VisualStudio.Shell;
using MonoDevelop.Projects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Xavalon.XamlStyler.Extension.Mac.Services.XamlFiles
{
    public class XamlFilesService : IXamlFilesService
    {
        public List<string> FindAllXamlFilePaths(Solution solution)
        {
            return solution.GetAllProjects()
                           .SelectMany(FindAllXamlFilePaths)
                           .ToList();
        }

        public List<string> FindAllXamlFilePaths(Project project)
        {
            return project.Files
                          .Where(file => IsXamlFile(file) || IsAvaloniaXaml(file))
                          .Select(file => file.FilePath.ToString())
                          .ToList();
        }

        private bool IsXamlFile(ProjectFile file)
        {
            var fileExtension = file.FilePath.Extension;
            var isXamlFile = string.Equals(fileExtension, Constants.XamlFileExtension, StringComparison.InvariantCultureIgnoreCase);
            return isXamlFile;
        }

        public bool IsAvaloniaXaml(ProjectFile file)
        {

            var fileExtension = file.FilePath.Extension;
            var isXamlFile = string.Equals(fileExtension, Constants.AxamlFileExtension, StringComparison.InvariantCultureIgnoreCase);
            return isXamlFile;
        }
    }
}