using System;

public class AppenderFactory
{
    public AppenderFactory(LayoutFactory layoutFactory)
    {
        this.layoutFactory = layoutFactory;
        fileNumber = 0;
    }

    private const string DefaultFileName = "logFile{0}.txt";
    private LayoutFactory layoutFactory;
    private int fileNumber;
    
    public IAppender CreateAppender(string appenderType, string levelString, string layoutType)
    {
        ILayout layout = layoutFactory.CreateLayout(layoutType);
        ErrorLevel errorLevel = ParseErrorLevel(levelString);
        IAppender appender = null;

        switch (appenderType)
        {
            case "ConsoleAppender":
                appender = new ConsoleAppender(layout, errorLevel);
                break;
            case "FileAppender":
                ILogFile logFile = new LogFile(string.Format(DefaultFileName));
                appender = new FileAppender(layout, errorLevel, logFile);
                break;
            default:
                throw new ArgumentException("Invalid Appender Type!");
        }
        return appender;
    }

    private ErrorLevel ParseErrorLevel(string levelString)
    {
        try
        {
            object levelObj = Enum.Parse(typeof(ErrorLevel), levelString);
            return (ErrorLevel)levelObj;
        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException("Invalid ErrorLevel Type!", ex);
        }
    }
}