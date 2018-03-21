internal class FileAppender : IAppender
{
    public FileAppender(ILayout layout, ErrorLevel errorLevel, ILogFile logFile)
    {
        Layout = layout;
        Level = errorLevel;
        this.logFile = logFile;
    }

    public ErrorLevel Level { get; }

    public ILayout Layout { get; }

    private ILogFile logFile;

    public void Append(IError error)
    {
        string formattedError = Layout.FormatError(error);
        logFile.WriteToFile(formattedError);
    }
}
