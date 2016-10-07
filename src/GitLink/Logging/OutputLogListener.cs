﻿using System;
using Catel.Logging;

namespace GitLink.Logging {
    public class OutputLogListener : ConsoleLogListener {
        public OutputLogListener() {
            IgnoreCatelLogging = true;
            IsDebugEnabled = true;
        }

        protected override string FormatLogEvent(ILog log, string message, LogEvent logEvent, object extraData, LogData logData, DateTime time) {
            return message;
        }
    }
}