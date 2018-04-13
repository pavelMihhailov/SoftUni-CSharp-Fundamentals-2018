using Forum.App.Contracts;

public class PostInfoViewModel : IPostInfoViewModel
{
    public PostInfoViewModel(int id, string title, int replyCount)
    {
        Id = id;
        Title = title;
        ReplyCount = replyCount;
    }

    public int Id { get; }

    public string Title { get; }

    public int ReplyCount { get; }
}
