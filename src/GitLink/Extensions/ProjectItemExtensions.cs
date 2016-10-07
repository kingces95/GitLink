using Catel;
using Catel.IO;
using Microsoft.Build.Evaluation;

namespace GitLink {
    public static class ProjectItemExtensions {
        public static string GetRelativeFileName(this ProjectItem projectItem) {
            Argument.IsNotNull(() => projectItem);

            return projectItem.EvaluatedInclude;
        }

        public static string GetFullFileName(this ProjectItem projectItem) {
            Argument.IsNotNull(() => projectItem);

            var filePath = Path.Combine(projectItem.Project.DirectoryPath, projectItem.GetRelativeFileName());
            var fullFile = System.IO.Path.GetFullPath(filePath);
            return fullFile;
        }
    }
}