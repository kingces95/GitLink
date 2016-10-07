using System;

namespace GitLink {
    public class GitLinkException : Exception {
        public GitLinkException(string message)
            : base(message) {
        }
    }
}