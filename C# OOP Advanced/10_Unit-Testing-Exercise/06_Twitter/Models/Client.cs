public class Client : IClient
{
    public Client(string model)
    {
        Model = model;
    }

    public string Model { get; }

    public string RecieveTweet(ITweet tweet)
    {
        return $"{this.Model}: {tweet.Message}";
    }
}
