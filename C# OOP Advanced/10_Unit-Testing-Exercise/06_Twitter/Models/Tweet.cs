public class Tweet : ITweet
{
    public Tweet(string message)
    {
        Message = message;
    }

    public string Message { get; }
}