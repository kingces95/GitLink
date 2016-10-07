using Catel;

namespace GitLink {

    public static class StringExtensions {
        public static string OptimizeUrl(this string url) {
            Argument.IsNotNullOrWhitespace(() => url);

            url = url.EndsWith(".git") ? url.Substring(0, url.Length - 4) : url;
            return url;
        }
    }
}