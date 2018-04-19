using System;
namespace Choless.Core.Utilities
{
    public interface ILogger
    {
        void Trace(Exception exception, string message, params object[] args);
        void Debug(Exception exception, string message, params object[] args);
        void Info(Exception exception, string message, params object[] args);
        void Warn(Exception exception, string message, params object[] args);
        void Error(Exception exception, string message, params object[] args);
        void Fatal(Exception exception, string message, params object[] args);
    }
}
