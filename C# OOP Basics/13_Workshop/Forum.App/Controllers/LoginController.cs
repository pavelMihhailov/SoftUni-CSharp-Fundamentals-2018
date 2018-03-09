using System;
using Forum.App.Services;
using Forum.App.UserInterface;
using Forum.App.Views;

namespace Forum.App.Controllers
{
    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface.Contracts;

    public class LogInController : IController, IReadUserInfoController
    {
        public LogInController()
        {
            ResetLogin();
        }

        public string Username { get; private set; }

        private string Password { get; set; }

        private bool Error { get; set; }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.ReadUsername:
                    ReadUsername();
                    return MenuState.Login;
                case Command.ReadPassword:
                    ReadPassword();
                    return MenuState.Login;
                case Command.LogIn:
                    bool loggedIn = UserService.TryLoginUser(Username, Password);
                    if (loggedIn) return MenuState.SuccessfulLogIn;
                    Error = true;
                    return MenuState.Error;
                case Command.Back:
                    ResetLogin();
                    return MenuState.Back;
            }
            throw new InvalidOperationException();
        }

        public IView GetView(string userName)
        {
            return new LogInView(Error, Username, Password.Length);
        }

        public void ReadPassword()
        {
            Password = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        public void ReadUsername()
        {
            Username = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        private enum Command
        {
            ReadUsername, ReadPassword, LogIn, Back
        }

        private void ResetLogin()
        {
            Error = false;
            Username = string.Empty;
            Password = string.Empty;
        }
    }
}
