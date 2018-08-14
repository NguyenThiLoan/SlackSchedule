using NLog;
using NLog.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPBFramework.Logger
{
    public class LoggingService : NLog.Logger, ILoggingService
    {
        private const string _loggerName = "NLogLogger";

        public static ILoggingService GetLoggingService()
        {
            ConfigurationItemFactory.Default.LayoutRenderers
                .RegisterDefinition("utc_date", typeof(UtcDateRenderer));
            ConfigurationItemFactory.Default.LayoutRenderers
                .RegisterDefinition("web_variables", typeof(WebVariablesRenderer));
            ILoggingService logger = (ILoggingService)LogManager.GetLogger("NLogLogger", typeof(LoggingService));
            return logger;
        }

#pragma warning disable CS0108 // 'LoggingService.Debug(Exception, string, params object[])' hides inherited member 'Logger.Debug(Exception, string, params object[])'. Use the new keyword if hiding was intended.
        public void Debug(Exception exception, string format, params object[] args)
#pragma warning restore CS0108 // 'LoggingService.Debug(Exception, string, params object[])' hides inherited member 'Logger.Debug(Exception, string, params object[])'. Use the new keyword if hiding was intended.
        {
            if (!base.IsDebugEnabled) return;
            var logEvent = GetLogEvent(_loggerName, LogLevel.Debug, exception, format, args);
            base.Log(typeof(LoggingService), logEvent);
        }

#pragma warning disable CS0108 // 'LoggingService.Error(Exception, string, params object[])' hides inherited member 'Logger.Error(Exception, string, params object[])'. Use the new keyword if hiding was intended.
        public void Error(Exception exception, string format, params object[] args)
#pragma warning restore CS0108 // 'LoggingService.Error(Exception, string, params object[])' hides inherited member 'Logger.Error(Exception, string, params object[])'. Use the new keyword if hiding was intended.
        {
            if (!base.IsErrorEnabled) return;
            var logEvent = GetLogEvent(_loggerName, LogLevel.Error, exception, format, args);
            base.Log(typeof(LoggingService), logEvent);
        }

#pragma warning disable CS0108 // 'LoggingService.Fatal(Exception, string, params object[])' hides inherited member 'Logger.Fatal(Exception, string, params object[])'. Use the new keyword if hiding was intended.
        public void Fatal(Exception exception, string format, params object[] args)
#pragma warning restore CS0108 // 'LoggingService.Fatal(Exception, string, params object[])' hides inherited member 'Logger.Fatal(Exception, string, params object[])'. Use the new keyword if hiding was intended.
        {
            if (!base.IsFatalEnabled) return;
            var logEvent = GetLogEvent(_loggerName, LogLevel.Fatal, exception, format, args);
            base.Log(typeof(LoggingService), logEvent);
        }

#pragma warning disable CS0108 // 'LoggingService.Info(Exception, string, params object[])' hides inherited member 'Logger.Info(Exception, string, params object[])'. Use the new keyword if hiding was intended.
        public void Info(Exception exception, string format, params object[] args)
#pragma warning restore CS0108 // 'LoggingService.Info(Exception, string, params object[])' hides inherited member 'Logger.Info(Exception, string, params object[])'. Use the new keyword if hiding was intended.
        {
            if (!base.IsInfoEnabled) return;
            var logEvent = GetLogEvent(_loggerName, LogLevel.Info, exception, format, args);
            base.Log(typeof(LoggingService), logEvent);
        }

#pragma warning disable CS0108 // 'LoggingService.Trace(Exception, string, params object[])' hides inherited member 'Logger.Trace(Exception, string, params object[])'. Use the new keyword if hiding was intended.
        public void Trace(Exception exception, string format, params object[] args)
#pragma warning restore CS0108 // 'LoggingService.Trace(Exception, string, params object[])' hides inherited member 'Logger.Trace(Exception, string, params object[])'. Use the new keyword if hiding was intended.
        {
            if (!base.IsTraceEnabled) return;
            var logEvent = GetLogEvent(_loggerName, LogLevel.Trace, exception, format, args);
            base.Log(typeof(LoggingService), logEvent);
        }

#pragma warning disable CS0108 // 'LoggingService.Warn(Exception, string, params object[])' hides inherited member 'Logger.Warn(Exception, string, params object[])'. Use the new keyword if hiding was intended.
        public void Warn(Exception exception, string format, params object[] args)
#pragma warning restore CS0108 // 'LoggingService.Warn(Exception, string, params object[])' hides inherited member 'Logger.Warn(Exception, string, params object[])'. Use the new keyword if hiding was intended.
        {
            if (!base.IsWarnEnabled) return;
            var logEvent = GetLogEvent(_loggerName, LogLevel.Warn, exception, format, args);
            base.Log(typeof(LoggingService), logEvent);
        }

        public void Debug(Exception exception)
        {
            this.Debug(exception.Message.Replace("\r\n", ""), string.Empty);
        }

        public void Error(Exception exception)
        {
            this.Error(exception.Message.Replace("\r\n", ""), string.Empty);
        }

        public void Fatal(Exception exception)
        {
            this.Fatal(exception.Message.Replace("\r\n", ""), string.Empty);
        }

        public void Info(Exception exception)
        {
            this.Info(exception.Message.Replace("\r\n", ""), string.Empty);
        }

        public void Trace(Exception exception)
        {
            this.Trace(exception.Message.Replace("\r\n", ""), string.Empty);
        }

        public void Warn(Exception exception)
        {
            this.Warn(exception.Message.Replace("\r\n", ""), string.Empty);
        }

        private LogEventInfo GetLogEvent(string loggerName, LogLevel level, Exception exception, string format, object[] args)
        {
            string assemblyProp = string.Empty;
            string classProp = string.Empty;
            string methodProp = string.Empty;
            string messageProp = string.Empty;
            string innerMessageProp = string.Empty;

            var logEvent = new LogEventInfo
                (level, loggerName, string.Format(format, args));

            if (exception != null)
            {
                assemblyProp = exception.Source;
                classProp = exception.TargetSite.DeclaringType.FullName;
                methodProp = exception.TargetSite.Name;
                messageProp = exception.Message.Replace("\r\n", "");

                if (exception.InnerException != null)
                {
                    innerMessageProp = exception.InnerException.Message;
                }
            }

            logEvent.Properties["error-source"] = assemblyProp;
            logEvent.Properties["error-class"] = classProp;
            logEvent.Properties["error-method"] = methodProp;
            logEvent.Properties["error-message"] = messageProp;
            logEvent.Properties["inner-error-message"] = innerMessageProp;

            return logEvent;
        }
    }
}