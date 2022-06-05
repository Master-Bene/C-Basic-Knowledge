// See https://aka.ms/new-console-template for more information

namespace CMSConsoleAPP
{
    public interface IUser
    {
        bool IsUserLogin { get; set; }
        string Password { get; set; }
        string UserName { get; set; }

        void Login();
    }
}