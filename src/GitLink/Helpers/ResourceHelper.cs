using System.IO;
using Catel.Reflection;

namespace GitLink {
    public static class ResourceHelper {
        public static void ExtractEmbeddedResource(string resourceName, string destinationFileName) {
            var assembly = typeof(ResourceHelper).Assembly;

            using (var resource = assembly.GetManifestResourceStream(resourceName)) {
                using (var file = new FileStream(destinationFileName, FileMode.Create, FileAccess.Write)) {
                    resource.CopyTo(file);
                }
            }
        }
    }
}