using System;
using NLog;

namespace Choless.Core.Utilities
{
    public class NLogger : ILogger
    {
        public Logger Logger { get; private set; }

        public void Debug(Exception exception, string message, params object[] args)
        {
            Logger.Debug(exception, message, args);
        }

        public void Error(Exception exception, string message, params object[] args)
        {
            Logger.Error(exception, message, args);

        }

        public void Fatal(Exception exception, string message, params object[] args)
        {
            Logger.Fatal(exception, message, args);
        }

        public void Info(Exception exception, string message, params object[] args)
        {
            Logger.Info(exception, message, args);
        }

        public void Trace(Exception exception, string message, params object[] args)
        {
            Logger.Trace(exception, message, args);
        }

        public void Warn(Exception exception, string message, params object[] args)
        {
            Logger.Warn(exception, message, args);
        }

        public NLogger()
        {
            Logger = LogManager.GetCurrentClassLogger();
        }
    }
}
