using System.Collections;
using System.Collections.Generic;

public class Logger : ILogger
{
    private IEnumerable<IAppender> appenders;

    public Logger(IEnumerable<IAppender> appenders)
    {
        this.appenders = appenders;
    }

    public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>) this.appenders;

    public void Log(IError error)
    {
        foreach (var appender in appenders)
        {
            if (appender.Level <= error.Level)
            {
                appender.Append(error);
            }
        }
    }

    public void AddAppender(IAppender appender)
    {
        
    }
}
