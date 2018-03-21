public interface IAppender : ILevelable
{
    ILayout Layout { get; }

    void Append(IError error);
}