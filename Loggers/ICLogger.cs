using System;
using System.Runtime.CompilerServices;

namespace nCroner.Common.Loggers
{
    public interface ICLogger
    {
        Guid EventId { get; }

        void Trace(string message, object request = null, object response = null,
            [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string methodName = "",
            [CallerFilePath] string sourceFilePath = "");

        void Debug(string message, object request = null, object response = null,
            [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string methodName = "",
            [CallerFilePath] string sourceFilePath = "");

        void Info(string message, object request = null, object response = null,
            [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string methodName = "",
            [CallerFilePath] string sourceFilePath = "");

        void Error(string message, object request = null, object response = null,
            [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string methodName = "",
            [CallerFilePath] string sourceFilePath = "");

        public void Error(string message, Exception exception, object request = null,
            [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string methodName = "",
            [CallerFilePath] string sourceFilePath = "");
    }
}