using System;
using System.Linq;
using Forum.App.Contracts;
using Forum.Data;
using Forum.DataModels;

public class UserService : IUserService
{
    public UserService(ForumData forumData, ISession session)
    {
        this.forumData = forumData;
        this.session = session;
    }

    private ForumData forumData;
    private ISession session;

    public bool TrySignUpUser(string username, string password)
    {
        bool validUsername = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
        bool validPassword = !string.IsNullOrWhiteSpace(password) && password.Length > 3;

        if (!validPassword || !validUsername)
        {
            throw new ArgumentException("Username and Password must be longer than 3 symbols!");
        }

        bool usernameExists = forumData.Users.Any(x => x.Username.Equals(username));

        if (usernameExists)
            throw new InvalidOperationException("Username taken!");

        int userId = forumData.Users.LastOrDefault()?.Id + 1 ?? 1;
        User user = new User(userId, username, password);

        forumData.Users.Add(user);
        forumData.SaveChanges();

        this.TryLogInUser(username, password);

        return true;
    }

    public bool TryLogInUser(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            return false;

        User user = forumData.Users.FirstOrDefault(x => x.Username.Equals(username) && x.Password.Equals(password));

        if (user == null)
            return false;

        session.Reset();
        session.LogIn(user);

        return true;
    }

    public string GetUserName(int userId)
    {
        string username = forumData.Users.FirstOrDefault(x => x.Id.Equals(userId))?.Username;

        return username;
    }

    public User GetUserById(int userId)
    {
        User user = forumData.Users.FirstOrDefault(x => x.Id.Equals(userId));

        return user;
    }
}
