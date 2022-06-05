// See https://aka.ms/new-console-template for more information

namespace CMSConsoleAPP
{
    public class User : IUser
    {
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        public bool IsUserLogin { get; set; } = false;

        public void Login()
        {
            Console.Write("请输入用户名：");
            UserName = Console.ReadLine() ?? "";
            if (UserName != "sj")
            {
                Console.WriteLine("查无此人");
                return;
            }
            Console.Write("请输入密码:");
            Password = Console.ReadLine() ?? "";
            if (Password != "123456")
            {
                Console.WriteLine("密码错误");
                return;
            }
            IsUserLogin = true;
        }
    }
}