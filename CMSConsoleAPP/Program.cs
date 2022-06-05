// See https://aka.ms/new-console-template for more information


using CMSConsoleAPP;
using Microsoft.Extensions.DependencyInjection;

ServiceCollection servicecollection = new ServiceCollection();
servicecollection.AddScoped<IUser, User>().AddScoped<IMenu, Menu>().AddScoped<ICMSController, CMSController>();
//servicecollection.AddScoped<ICMSController, CMSController>();
//servicecollection.AddScoped<IMenu, Menu>();

var services = servicecollection.BuildServiceProvider();
var cMSController = services.GetService<ICMSController>();
var user = services.GetService<IUser>();

Console.WriteLine("==================客户管理系统======================");
Console.WriteLine("请登录");

cMSController.Start();
                                                         
Console.WriteLine($"当前登录人：{user.UserName}");
Console.ReadKey();


#region OLD
////实例化用户系统
//User user = new User();

////实例化菜单系统
//Menu menu = new Menu();

////实例化流程控制系统
//CMSController cMSController = new CMSController();


//Console.WriteLine("==================客户管理系统======================");
//Console.WriteLine("请登录");

//cMSController.Start(user, menu);

//Console.WriteLine($"当前登录人：{user.UserName}");
//Console.ReadKey();


//public class User
//{

//    public string UserName { get; set; } = "";
//    public string Password { get; set; } = "";
//    public bool IsUserLogin { get; set; } = false;

//    public void Login()
//    {
//        Console.Write("请输入用户名：");
//        UserName = Console.ReadLine() ?? "";
//        if (UserName != "sj")
//        {
//            Console.WriteLine("查无此人");
//            return;
//        }
//        Console.Write("请输入密码:");
//        Password = Console.ReadLine() ?? "";
//        if (Password != "123456")
//        {
//            Console.WriteLine("密码错误");
//            return;
//        }
//        IsUserLogin = true;
//    }
//}

//public class Menu
//{
//    public void ShowMenu(bool isExit)
//    {
//        while (isExit)
//        {
//            Console.WriteLine("主菜单");
//            Console.WriteLine("1.客户管理");
//            Console.WriteLine("2.预约管理");
//            Console.WriteLine("3.系统设置");
//            Console.WriteLine("4.退出");

//            string selection = Console.ReadLine() ?? "";
//            switch (selection)
//            {
//                case "1": Console.WriteLine("客户管理"); break;
//                case "2": Console.WriteLine("预约管理"); break;
//                case "3": Console.WriteLine("系统设置"); break;
//                case "4":
//                default:
//                    Console.WriteLine("退出");
//                    isExit = false;
//                    break;
//            }
//        }
//    }
//}

//public class CMSController
//{
//    public void Start(User user, Menu menu)
//    {
//        do
//        {
//            user.Login();
//        } while (!user.IsUserLogin);
//        menu.ShowMenu(user.IsUserLogin);
//    }
//}
#endregion