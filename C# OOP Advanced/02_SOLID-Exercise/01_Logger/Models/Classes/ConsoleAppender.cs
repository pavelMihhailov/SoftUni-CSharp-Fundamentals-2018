using System;

public class ConsoleAppender : IAppender
{
    public ConsoleAppender(ILayout layout, ErrorLevel errorLevel)
    {
        Layout = layout;
        Level = errorLevel;
        MessagesAppended = 0;
    }
    
    public ErrorLevel Level { get; }

    public ILayout Layout { get; }

    public int MessagesAppended { get; private set; }

    public void Append(IError error)
    {
        string formattedError = this.Layout.FormatError(error);
        Console.WriteLine(formattedError);
        MessagesAppended++;
    }

    public override string ToString()
    {
        return
            $"Appender type: {GetType().Name}, Layout type: {Layout.GetType().Name}, Report level: {Level.ToString()}, Messages appended: {MessagesAppended}";
    }
}