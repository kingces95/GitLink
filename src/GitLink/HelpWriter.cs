using System;
using Catel.Reflection;

namespace GitLink {
    public static class HelpWriter {
        public static void WriteAppHeader(Action<string> writer) {
            var assembly = typeof(HelpWriter).Assembly;

            writer(string.Format("{0} v{1}", assembly.Title(), assembly.Version()));
            writer("================");
            writer(string.Empty);
        }

        public static void WriteHelp(Action<string> writer) {
            const string message = @"Update pdb files to link all sources. This will allow anyone to step through the source code while debugging without a symbol source server.

Note that the solution must be built because this application will update existing pdb files.

GitLink [solutionPath] -u [urlToRepository]

    solutionPath       The directory containing the solution with the pdb files.
    -u [url]           Url to remote git repository.
    -f [file]          Solution file name.
    -c [config]        Name of the configuration, default value is 'Release'.
    -p [platform]      Name of the platform, default value is 'AnyCPU'.
    -b [branch]        Name of the branch to use on the remote repository.
    -l [file]          The log file to write to.
    -s [shaHash]       The SHA-1 hash of the commit.
    -d [pdbDirectory]  The directory where pdb files exists, default value 
                       is the normal project output directory.
    -powershell        Use an indexing strategy that won't rely on SRCSRV http support,
                       but use a powershell command for URL download instead.
    -errorsaswarnings  Don't fail on errors, but treat them as warnings instead.
    -skipverify        Skip pdb verification in case it causes issues (it's a formality anyway)
    -debug             Enables debug mode with special dumps of msbuild.
";
            writer(message);
        }
    }
}