using System;

public class Error : IError
{
    public Error(DateTime dateTime, ErrorLevel errorLevel, string message)
    {
        DateTime = dateTime;
        Level = errorLevel;
        Message = message;
    }

    public ErrorLevel Level { get; }

    public DateTime DateTime { get; }

    public string Message { get; }
}
