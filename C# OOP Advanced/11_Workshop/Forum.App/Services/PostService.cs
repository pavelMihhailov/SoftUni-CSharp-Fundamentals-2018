using System;
using System.Collections.Generic;
using System.Linq;
using Forum.App.Contracts;
using Forum.Data;
using Forum.DataModels;

public class PostService : IPostService
{
    public PostService(ForumData forumData, IUserService userService)
    {
        this.forumData = forumData;
        this.userService = userService;
    }

    private ForumData forumData;
    private IUserService userService;

    public IEnumerable<ICategoryInfoViewModel> GetAllCategories()
    {
        IEnumerable<ICategoryInfoViewModel> categories = this.forumData.Categories
            .Select(x => new CategoryInfoViewModel(x.Id, x.Name, x.Posts.Count));

        return categories;
    }

    public IEnumerable<IPostInfoViewModel> GetCategoryPostsInfo(int categoryId)
    {
        IEnumerable<IPostInfoViewModel> categoryPosts = (IEnumerable<IPostInfoViewModel>) forumData.Categories
            .Where(x => x.Id.Equals(categoryId)).Select(x => x.Posts);

        return categoryPosts;
    }

    public IEnumerable<IReplyViewModel> GetPostReplies(int postId)
    {
        IEnumerable<IReplyViewModel> replies = this.forumData.Replies.Where(x => x.PostId.Equals(postId))
            .Select(x => new ReplyViewModel(this.userService.GetUserName(x.AuthorId), x.Content));

        return replies;
    }

    public string GetCategoryName(int categoryId)
    {
        string categoryName = this.forumData.Categories.Find(x => x.Id.Equals(categoryId))?.Name;

        if (categoryName == null)
            throw new ArgumentException($"Category with id {categoryId} not found!");

        return categoryName;
    }

    public IPostViewModel GetPostViewModel(int postId)
    {
        var post = forumData.Posts.FirstOrDefault(p => p.Id.Equals(postId));
        IPostViewModel postView = new PostViewModel(post.Title, userService.GetUserName(post.AuthorId),
            post.Content, this.GetPostReplies(postId));

        return postView;
    }

    public Category EnsureCategory(string categoryName)
    {
        Category category = null;
        if (!forumData.Categories.Any(x => x.Name.Equals(categoryName)))
        {
            category = new Category(categoryName);
            forumData.Categories.Add(category);
        }
        else category = forumData.Categories.FirstOrDefault(x => x.Name.Equals(categoryName));
        return category;
    }

    public int AddPost(int userId, string postTitle, string postCategory, string postContent)
    {
        bool emptyCategory = string.IsNullOrWhiteSpace(postCategory);
        bool emptyTitle = string.IsNullOrWhiteSpace(postTitle);
        bool emptyContent = string.IsNullOrWhiteSpace(postContent);

        if (emptyCategory || emptyContent || emptyTitle)
        {
            throw new ArgumentException("All fields must be filled!");
        }

        Category category = this.EnsureCategory(postCategory);
        int postId = forumData.Posts.Any() ? forumData.Posts.Last().Id + 1 : 1;
        User author = this.userService.GetUserById(userId);

        Post post = new Post(postId, postTitle, postContent, category.Id, userId, new List<int>());

        forumData.Posts.Add(post);
        author.Posts.Add(post.Id);
        category.Posts.Add(post.Id);
        forumData.SaveChanges();

        return post.Id;
    }

    public void AddReplyToPost(int postId, string replyContents, int userId)
    {
        throw new System.NotImplementedException();
    }
}
