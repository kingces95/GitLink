using System;

namespace GitLink {

    public class Authentication {
        public Authentication() {
            Username = Environment.GetEnvironmentVariable("GITLINK_REMOTE_USERNAME");
            Password = Environment.GetEnvironmentVariable("GITLINK_REMOTE_PASSWORD");
        }

        public string Password { get; set; }
        public string Username { get; set; }
    }
}