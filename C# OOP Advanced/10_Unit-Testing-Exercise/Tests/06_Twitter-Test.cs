using NUnit.Framework;

[TestFixture]
public class _06_Twitter_Test
{
    private string model = "K400";
    private string tweetMessage = "new tweet message!";

    [Test]
    public void WhenClientRecieveMessageReturnMessage()
    {
        Client client = new Client(model);
        Tweet tweet = new Tweet(tweetMessage);

        Assert.That(() => client.RecieveTweet(tweet), 
            Is.EqualTo($"{model}: {tweetMessage}"));
    }
}
