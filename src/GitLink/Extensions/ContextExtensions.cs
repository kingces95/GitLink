using Catel;
using Catel.IO;

namespace GitLink {
    public static class ContextExtensions {
        public static string GetRelativePath(this Context context, string fullPath) {
            Argument.IsNotNull(() => context);
            Argument.IsNotNull(() => fullPath);

            return Path.GetRelativePath(fullPath, context.SolutionDirectory);
        }
    }
}