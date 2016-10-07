﻿using System.Diagnostics;
using Catel;
using Catel.Logging;

namespace GitLink {
    public static class PdbStrHelper {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        public static void Execute(string pdbStrFileName, string projectPdbFile, string pdbStrFile) {
            Argument.IsNotNullOrWhitespace(() => projectPdbFile);
            Argument.IsNotNullOrWhitespace(() => pdbStrFile);

            var processStartInfo = new ProcessStartInfo(pdbStrFileName) {
                Arguments = string.Format("-w -s:srcsrv -p:\"{0}\" -i:\"{1}\"", projectPdbFile, pdbStrFile),
                CreateNoWindow = true,
                UseShellExecute = false
            };

            var process = new Process();
            process.StartInfo = processStartInfo;
            process.Start();
            process.WaitForExit();

            var processExitCode = process.ExitCode;
            if (processExitCode != 0) {
                throw Log.ErrorAndCreateException<GitLinkException>("PdbStr exited with unexpected error code '{0}'", processExitCode);
            }
        }
    }
}