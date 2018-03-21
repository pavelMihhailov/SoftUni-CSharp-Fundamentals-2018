using System.Globalization;

public class SimpleLayout : ILayout
{
    private const string DateFormat = "M/d/yyyy h:mm:ss tt";
    private const string Format = "{0} - {1} - {2}";

    public string FormatError(IError error)
    {
        string dateString = error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture);
        string formattedError = string.Format(Format, dateString, error.Level.ToString(), error.Message);

        return formattedError;
    }
}
