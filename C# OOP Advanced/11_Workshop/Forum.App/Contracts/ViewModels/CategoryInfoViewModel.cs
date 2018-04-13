using Forum.App.Contracts;

public class CategoryInfoViewModel : ICategoryInfoViewModel
{
    public CategoryInfoViewModel(int id, string name, int postCount)
    {
        Id = id;
        Name = name;
        PostCount = postCount;
    }

    public int Id { get; }

    public string Name { get; }

    public int PostCount { get; }
}
