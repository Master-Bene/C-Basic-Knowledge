// See https://aka.ms/new-console-template for more information

namespace CMSConsoleAPP
{
    public class Menu : IMenu
    {
        public void ShowMenu(bool isExit)
        {
            while (isExit)
            {
                Console.WriteLine("主菜单");
                Console.WriteLine("1.客户管理");
                Console.WriteLine("2.预约管理");
                Console.WriteLine("3.系统设置");
                Console.WriteLine("4.退出");

                string selection = Console.ReadLine() ?? "";
                switch (selection)
                {
                    case "1": Console.WriteLine("客户管理"); break;
                    case "2": Console.WriteLine("预约管理"); break;
                    case "3": Console.WriteLine("系统设置"); break;
                    case "4":
                    default:
                        Console.WriteLine("退出");
                        isExit = false;
                        break;
                }
            }
        }
    }
}