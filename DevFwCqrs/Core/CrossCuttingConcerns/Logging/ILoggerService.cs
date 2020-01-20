using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging
{
    public interface ILoggerService
    {
        bool IsInfoEnabled { get; }
        bool IsDebugEnabled { get; }
        bool IsWarnEnabled { get; }
        bool IsFatalEnabled { get; }
        bool IsErrorEnabled { get; }

        void Info(object logMessage);
        void Debug(object logMessage);
        void Warn(object logMessage);
        void Fatal(object logMessage);
        void Error(object logMessage);
    }
}
